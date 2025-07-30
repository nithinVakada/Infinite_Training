use CodeChallenge;


--Write a stored Procedure that inserts records in the Employee_Details table
 
--The procedure should generate the EmpId automatically to insert and should return the generated value to the user
 
--Also the Salary Column is a calculated column (Salary is givenSalary - 10%)
 
--Table : Employee_Details (Empid, Name, Salary, Gender)
--Hint(User should not give the EmpId)
 
--Test the Procedure using ADO classes and show the generated Empid and Salary
 

Create Table Employee_Details (
    EmpId int identity(100,1) primary key,
    Name NVarchar(100) NOT NULL,
    Salary decimal(10,2) NOT NULL,
    Gender Nvarchar(10) NOT NULL,
    NetSalary as (Salary - (Salary * 0.10)) 
);

create procedure InsertEmployeeDetails
    @Name Nvarchar(100),
    @Salary decimal(10,2),
    @Gender Nvarchar(10),
    @EmpId int output,
    @NetSalary decimal(10,2) output
as
begin
    
    insert into Employee_Details (Name, Salary, Gender)
    values (@Name, @Salary, @Gender);

    set @EmpId = @@IDENTITY;

    set @NetSalary = @Salary * 0.9;
end;

select * from Employee_Details;

--Write a procedure that takes empid as input and outputs the updated salary as current salary + 100 for the give employee.
 
-- Test the procedure using ADO classes and display the Employee details of that employee whose salary has been updated

Create  procedure UpdateEmployeeSalary
    @EmpId int,
    @UpdatedSalary decimal(10,2) output
as
 begin
    update Employee_Details
    set Salary = Salary + 100
    where EmpId = @EmpId;

    select @UpdatedSalary = Salary
    from Employee_Details
    where EmpId = @EmpId;
 end;



