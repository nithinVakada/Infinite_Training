use cd;

--Procedures

create or alter proc proc_AddTrain
  @train_no int,
  @train_name varchar(25),
  @source varchar(25),
  @destination varchar(25),
  @class_id int,
  @seats_available int,
  @price int

as 
 begin
  if not exists(select * from Trains where Train_No=@train_no)
  begin
    insert into Trains(Train_No,Train_Name,Source_Station,Destination_Station)
    Values (@train_no,@train_name,@source,@destination);
    
  end
 
  
  If exists (select 1 from Train_Class where Train_No = @train_no AND Class_Id = @class_id)
  begin
   raiserror('This Combination already exists!',16,1);
   return 
  end

  insert into Train_Class(Train_No,Class_Id,Seats_Available,Cost_Per_Seat)
  Values (@train_no,@class_id,@seats_available,@price);

end

--exec proc_AddTrain 70136, 'Godavari Express', 'Visakhapatnam', 'Hyderabad', 4, 12, 900

create or alter proc proc_BookTickets
 @User_Name Varchar(25),
 @Train_no int,
 @class_id int,
 @Date_of_Travel date,
 @seats_booked int

 as
  begin
   if exists(select * from Train_Class where Train_No=@Train_No)
   begin
    declare @max_seats int
	select @max_seats=seats_Available from Train_Class
	        where Train_No=@Train_no and class_Id=@class_id

	if @max_seats < @seats_booked
	  begin
	   raiserror('Enough seats are not available',16,1);
	   return
	  end

	declare @user_id int;
	select @user_id=User_id from Users where User_Name=@User_Name

	declare @cost int;
	declare @total_cost int;
	select @cost=Cost_Per_Seat from Train_Class where Train_No=@Train_no and Class_Id=@class_id;
	set @total_cost=@cost * @seats_booked

	Update Train_Class set Seats_Available = Seats_Available-@seats_booked
	  where Train_No=@Train_No and Class_Id=@class_id;

	Insert into Bookings(Train_No,Cust_Id,Class_Id,Date_Of_Travel,Seats_Booked,Total_Cost)
	Values (@Train_No,@user_id,@class_id,@Date_Of_Travel,@seats_booked,@total_cost);

	 select 'Tickets booked successfully. Total Cost is ' + cast(@total_cost as varchar) as message, Booking_id as 'Booking_Id' from bookings;
	 end;
 end;

 exec proc_BookTickets 'Nithin', 76382, 1, '2025-08-10', 4


 create or alter proc proc_CancelTickets
    @user_name varchar(25),
	@bookingID int,
	@seats_ToGet_Cancelled int

    as begin
	   declare @user_id int;
	   select @user_id=User_Id from Users where User_Name=@user_name;

	   declare @seats_booked int;
	   select @seats_booked=Seats_booked from bookings
	      where Cust_Id=@user_id and Booking_id=@bookingID;

		if @seats_booked<@seats_ToGet_Cancelled
		begin
		 raiserror('Cannot cancel more than the booked tickets',16,1);
		end

		declare @train_no int,@class_id int;
		select @train_no=bk.train_no,@class_id=bk.class_id from Bookings bk 
		  where bk.Booking_id=@bookingID

		Update Bookings set Seats_booked=Seats_booked - @seats_ToGet_Cancelled 
		  where Booking_id=@bookingID

		Update Train_Class set Seats_Available = Seats_Available - @seats_ToGet_Cancelled
		  where Train_No=@train_no and Class_Id=@class_id;

		declare @cost int,@refund int
		select @cost=Cost_Per_Seat from Train_Class where Train_No=@train_no and Class_id=@class_id;
		set @refund=@cost * @seats_ToGet_Cancelled * 0.5;

		Update Bookings set Total_Cost = Total_Cost - @refund where Booking_Id = @bookingID;

		Update Bookings set Status='Inactive' where Booking_Id=@bookingID

		Insert into Cancellations(Booking_id,Seats_cancelled,Refund_amnt)
		 Values (@bookingID,@seats_ToGet_Cancelled,@refund);

		 select 'Tickets are Cancelled . Refunded Amount = ' + cast(@refund as varchar) as message

		 end;

exec proc_CancelTickets 'Nithin',2,1

