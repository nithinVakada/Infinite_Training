use cd;

Create Table Trains
(
  Train_No Int Primary Key,
  Train_Name Varchar(25),
  Source_Station Varchar(25),
  Destination_Station Varchar(25)
);

Create Table Class
(
  Class_Id Int Primary Key,
  Class_Name Varchar(10)
);

Create Table Train_Class
(
  Train_No Int References Trains(Train_No),
  Class_Id Int References Class(Class_Id),
  Seats_Available Int,
  Cost_Per_Seat Int,
  
  Primary Key(Train_No,Class_ID)
);

Create Table Users
(
  User_Id Int Primary Key Identity,
  User_Name Varchar(25),
  Phone Varchar(10),
  Email Varchar(25) unique,
  Role Varchar(5) default 'user',
  Password Varchar(12)
);

select * from Admin;
insert into Users Values ('Nithin','7095049101','nithin@123','user','Nithin@123')
Create Table Admin
(
  Admin_Name Varchar(25),
  Admin_Password Varchar(25),
  role Varchar(5) default 'Admin'
);

insert into Admin Values('Admin','Admin@123','Admin');

select * from Trains
select * from Class;
select * from Train_Class;


Create Table Bookings
(
 Booking_id Int Primary Key Identity,
 Train_No Int References Trains(Train_No),
 Cust_Id Int References Users(User_Id),
 Class_Id Int References Class(Class_Id),
 Date_Of_Booking Date default GetDate(),
 Date_Of_Travel Date,
 Seats_booked Int,
 Total_Cost Int,
 Status Varchar(10) default 'Active'
);

Create Table Cancellations (
    Cancellation_id Int Primary Key Identity,
    Booking_id Int,
    Seats_cancelled Int,
    Cancellation_date Date default GetDate(),
	Refund_amnt decimal(10,2),
    FOREIGN KEY (booking_id) REFERENCES Bookings(booking_id)
);

insert into class values
(1, 'First AC'),
(2, 'Second AC'),
(3, 'Third Ac'),
(4, 'Sleeper');

select * from Class;
select * from Bookings;
select * from Train_Class;
select * from Trains;
select * from Users;
select * from Cancellations;

alter  table Trains add  Status Varchar(10) default 'Active'

delete from Trains where Train_No = 12345

update Trains set Status='Active' 

update Bookings set Seats_booked=0 where Seats_booked=-1



