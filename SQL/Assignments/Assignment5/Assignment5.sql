--1. Write a T-Sql based procedure to generate complete payslip of a given employee with respect to the following condition

--   a) HRA as 10% of Salary
--   b) DA as 20% of Salary
--   c) PF as 8% of Salary
--   d) IT as 5% of Salary
--   e) Deductions as sum of PF and IT
--   f) Gross Salary as sum of Salary, HRA, DA
--   g) Net Salary as Gross Salary - Deductions

--Print the payslip neatly with all details
use Assignments

select * from emp

create or alter procedure GeneratePaySlipByEmployee(@Empno int)
as
begin
	declare @Ename varchar(30), @job varchar(20), @salary int, @hra float, @da float,
	@pf float, @it float, @deductions float, @gross_salary float, @net_salary float
	select @Ename = ename,@job = job, @salary = sal from emp where Empno = @Empno
	if(@salary is null)
	begin
		raiserror('Employee not found', 16,1)
		return
	end

	set @Hra = 0.1 * @salary;
	set @Da = 0.2 * @salary;
	set @Pf = 0.08 * @salary;
	set @It = 0.05 * @salary;
	set @Deductions = @pf + @it;
	set @Gross_salary = @salary + @hra + @da;
	set @Net_salary = @Gross_salary - @Deductions;

	print 'Payslip of the Employee:'
	print 'Employee Number: ' + cast(@Empno as varchar(5))
	print 'Employee Name: ' + @Ename
	print 'Job: '+ @Job
	print 'Salary: ' + cast(@salary as varchar(5))
	print 'HRA: ' + cast(@hra as varchar(5))
	print 'DA: ' + cast(@da as varchar(5))
	print 'PF: ' + cast(@pf as varchar(5))
	print 'IT: ' + cast(@it as varchar(5))
	print 'Deductions: ' + cast(@deductions as varchar(8))
	print 'Gross Product: ' + cast(@gross_salary as varchar(8))
	print 'Net Salary: ' + cast(@net_salary as varchar(8))
end

exec GeneratePaySlipByEmployee 7369



--2.  Create a trigger to restrict data manipulation on EMP table during General holidays.
--Display the error message like �Due to Independence day you cannot manipulate data� or "Due To Diwali",
--you cannot manipulate" etc

--Note: Create holiday table with (holiday_date,Holiday_name). 
--Store at least 4 holiday details. try to match and stop manipulation 

Create Table Holidays
(holiday_date date, 
holiday_name varchar(30));

insert into holidays values('2025-01-26', 'Republic day'),
('2025-10-02', 'Gandhi Jayanthi'),
('2025-08-15', 'Independence day'),
('2025-10-20', 'Diwali');
select * from Holidays

create or alter trigger trg_Dml
on emp
after insert, update, delete
as
begin
	declare @Holiday_name varchar(30), @error varchar(50)
	select @Holiday_name = Holiday_name from Holidays where Holiday_date = getdate(); 
	--select @holiday_name = holiday_name from holidays where holiday_date = '2025-08-15';

	if(@Holiday_name is not null)
	begin
		set @error = 'Due to ' + @Holiday_name + ', Manipulation of data is denied';
		raiserror(@error , 16, 1);
		rollback;
	end
end

select * from emp;
insert into emp values (7912, 'Name1', 'Sales', 7855, '24-APR-98', 1700, null, 30)
update emp set salary = salary + 500 where empno = 7912
delete from emp where empno = 7912