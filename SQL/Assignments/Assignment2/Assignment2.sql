use Assignments

Create Table Dept (
    Deptno Int Primary Key,
    Dname Varchar(20),
    Loc Varchar(20)
);

Create Table Emp (
    Empno Int Primary Key,
    Ename Varchar(20),
    Job Varchar(20),
    Mgr Int,
    Hiredate Varchar(20),
    Sal Int,
    Comm Int,
    Deptno Int,
    Foreign Key (Deptno) References Dept(Deptno),
    Foreign Key (Mgr) References Emp(Empno)
);

Insert Into Dept (Deptno, Dname, Loc) Values
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON');

Insert Into Emp (Empno, Ename, Job, Mgr, Hiredate, Sal, Comm, Deptno) Values
(7369, 'SMITH', 'CLERK', 7902, '17-Dec-80', 800, Null, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '20-Feb-81', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '22-Feb-81', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '02-Apr-81', 2975, Null, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '28-Sep-81', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '01-May-81', 2850, Null, 30),
(7782, 'CLARK', 'MANAGER', 7839, '09-Jun-81', 2450, Null, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '19-Apr-87', 3000, Null, 20),
(7839, 'KING', 'PRESIDENT', Null, '17-Nov-81', 5000, Null, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '08-Sep-81', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '23-May-87', 1100, Null, 20),
(7900, 'JAMES', 'CLERK', 7698, '03-Dec-81', 950, Null, 30),
(7902, 'FORD', 'ANALYST', 7566, '03-Dec-81', 3000, Null, 20),
(7934, 'MILLER', 'CLERK', 7782, '23-Jan-82', 1300, Null, 10);

--1. List all employees whose name begins with 'A'.
select * from Emp where ename like 'A%'

--2. Select all those employees who don't have a manager.
select * from Emp where mgr is null

--3. List employee name, number and salary
--for those employees who earn in the range 1200 to 1400.
select ename 'Employee Name', EmpNo, sal 'Salary' from emp
where sal between 1200 and 1400

--4. Give all the employees in the RESEARCH department a 10% pay rise. 
--Verify that this has been done by listing all their details
--before and after the rise. 

--before
Select * From Emp Where Deptno = (
    Select Deptno From Dept where Dname = 'RESEARCH');

--After
Update Emp Set Sal = Sal * 1.1
Where Deptno = (Select Deptno From Dept Where Dname = 'RESEARCH');

Select Ename,Sal from Emp;
--5. Find the number of CLERKS employed. Give it a descriptive heading. 
select count(*) 'No of Clerks' from Emp where Job = 'Clerk'

--6. Find the average salary for each job type 
--and the number of people employed in each job.

select Job , avg(sal) 'Avg Salary', count(*) 'No of people' from emp 
group by Job

--7. List the employees with the lowest and highest salary. 
Select * From Emp Where Sal = ( Select Min(Sal) From Emp);
Select * From Emp Where Sal = ( Select Max(Sal) From Emp);

--8. List full details of departments that don't have any employees.
Select * From Dept Where Deptno  Not In (
    Select  Deptno From Emp);

--9. Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort the answer by ascending order of name. 
Select Ename, Sal From Emp Where Job = 'ANALYST' And Sal > 1200
And Deptno = 20
Order By Ename ;

--10. For each department, list its name and number together with the total salary paid to employees in that department. 
Select D.Dname, D.Deptno, Sum(E.Sal) As Total_Salary
From Emp E
Join Dept D On E.Deptno = D.Deptno
Group By D.Dname, D.Deptno;

--11. Find out salary of both MILLER and SMITH.
select Ename, Sal from Emp where ename = 'Miller' or ename = 'smith'

--12. Find out the names of the employees whose name begin with ‘A’ or ‘M’. 
select Ename from emp where ename like '[AM]%' 

--13. Compute yearly salary of SMITH. 
select Ename 'Emp Name', (sal*12) 'Annual Salary' from emp where ename = 'Smith'

--14. List the name and salary for all employees whose salary is not in the range of 1500 and 2850. 
select ename 'Employee Name', sal 'Salary' from emp
where sal not between 1500 and 2850

--15. Find all managers who have more than 2 employees reporting to them

Select Mgr, Count(*) As Num_Employees From Emp
Group By Mgr Having Count(*) > 2;

