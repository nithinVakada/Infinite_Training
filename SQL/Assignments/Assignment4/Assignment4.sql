use Assignments;

--1.	Write a T-SQL Program to find the factorial of a given number.
declare @num int=6
declare @factorial int=@num
while @num>=2
 begin
  set @num=@num-1
  set @factorial=@factorial*@num;
  end
print('The factorial is '+ CAST(@factorial AS VARCHAR));
 

--Create a stored procedure to generate multiplication table 
--that accepts a number and generates up to a given number. 
create or alter proc sp_multiplicationTable(@num int,@end_number int)
as
 begin
  declare @upto int=1;
  while @upto<=@end_number
   begin
    print(cast(@num as varchar) + ' * '+ cast(@upto as varchar)+' = '+cast(@num*@upto as varchar));
    set @upto=@upto+1;
   end
 end

 exec sp_multiplicationTable @num=8,@end_number=10;


--Create a function to calculate the status of the student. 
--If student score >=50 then pass, else fail. Display the data 

 CREATE TABLE Student (
    Sid int PRIMARY KEY,
    Sname VARCHAR(50)
 );

 CREATE TABLE Marks (
    Mid int Primary KEY,
    Sid int Foreign KEY REFERENCES Student(Sid),
    Score INT
);

INSERT INTO Student (Sid, Sname) VALUES
(1, 'Jack'),
(2, 'Rithvik'),
(3, 'Jaspreeth'),
(4, 'Praveen'),
(5, 'Bisa'),
(6, 'Suraj');

INSERT INTO Marks (Mid, Sid, Score) VALUES
(1, 1, 23),
(2, 6, 95),
(3, 4, 98),
(4, 2, 17),
(5, 3, 53),
(6, 5, 13);


select * from Student
Select * from Marks

create function dbo.ResultDetails(@score int)
return varchar(10)
as
begin
 declare @result varchar(10)
   if @score>=50 
   set @result= 'Pass'
	 else
	 set @result='Fail'
	
	return @result
end;

select s.sid,s.sname,m.score,dbo.ResultDetails(m.score) As Result from Student s join Marks m on s.sid=m.Sid