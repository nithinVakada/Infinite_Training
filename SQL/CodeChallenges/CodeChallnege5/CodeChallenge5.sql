use CodeChallenge
use Assignments
--1.Write a query to display your birthday( day of week)
select DATENAME(WEEKDAY,'2025-10-10') as 'Birthday weekday'

--2. Write a query to display your age in days
select DATEDIFF(Day,'2003-10-10','2025-07-23') as 'Age in Days';

--3.Write a query to display all employees information those who joined before 5 years in the current month

 

select * from emp1;
select * from emp1 where YEAR(hiredate)+5 <= YEAR(GETDATE())
  AND MONTH(hiredate) = MONTH(GETDATE());

 --4.Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction
	--a. First insert 3 rows 
	--b. Update the second row sal with 15% increment  
    --c. Delete first row.
    --After completing above all actions, recall the deleted row without losing increment of second row

	-- Create the Employee table
CREATE TABLE Employee1 (
    EmpNo int primary key,
    EName Varchar(100),
    Sal decimal(10, 2),
    DOJ date
);

-- Begin transaction
BEGIN TRANSACTION;

-- a. Inserting 3 rows
INSERT INTO Employee1 VALUES (101, 'Nithin', 30000, '2020-10-10'), (102, 'Kiran', 35000, '2019-03-25'), (103, 'Ram', 40000, '2018-07-07');

select * from Employee1
-- b. Updating second row's salary with an increment of 15%
UPDATE Employee1
SET Sal = Sal * 1.15
WHERE EmpNo = 102;

-- Savepoint after update
SAVE TRANSACTION Trans1;

-- c. Delete first row
DELETE FROM Employee1 WHERE EmpNo = 103;

ROLLBACK TRANSACTION Trans1;

COMMIT;
select * from Employee1


--5.Create a user defined function calculate Bonus for all employees of a  given dept using	following conditions
	--a.     For Deptno 10 employees 15% of sal as bonus.
	--b.     For Deptno 20 employees  20% of sal as bonus
	--c      For Others employees 5%of sal as bonus

create function dbo.CalculateTheBonus (@DeptNo int, @Sal int)
RETURNS int
AS
BEGIN
    DECLARE @Bonus int;

    if @DeptNo = 10
        set @Bonus = @Sal * 0.15;
    else if @DeptNo = 20
        SET @Bonus = @Sal * 0.20;
    else
        SET @Bonus = @Sal * 0.05;

    return @Bonus;
end;

select * from Emp
select EmpNo, EName, Sal, DeptNo, dbo.CalculateTheBonus(DeptNo, Sal) AS Bonus
FROM emp;

--6. Create a procedure to update the salary of employee by 500 whose dept name is Sales 
--and current salary is below 1500 (use emp table)

select * from Dept

create or alter proc UpdateSalaries 
as 
 begin
   update emp
set sal = sal+ 500
where deptno in (
    select deptno from dept where dname = 'sales') and sal<1500;
 end;
 select * from emp
 exec UpdateSalaries
  select * from emp
  select * from Dept





