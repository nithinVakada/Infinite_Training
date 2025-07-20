use Assignments

select * from emp
select * from dept

--1. Retrieve a list of MANAGERS. 
  select ename as Managers from emp where empno in (select distinct(mgr) from emp) ;

--2. Find out the names and salaries of all employees earning more than 1000 per 
--month. 
  select ename,sal from emp where sal>1000

--3. Display the names and salaries of all employees except JAMES. 
 select ename,sal from emp where ename!='James'

--4. Find out the details of employees whose names begin with ‘S’. 
 select * from emp where ename like 'S%'

--5. Find out the names of all employees that have ‘A’ anywhere in their name.
 select * from emp where ename like '%A%'

--6. Find out the names of all employees that have ‘L’ as their third character in 
--their name. 
  select * from emp where ename like '__L%'

--7. Compute daily salary of JONES. 
 select ename,(sal*12)/365 as DailySalary from emp where ename='Jones'

--8. Calculate the total monthly salary of all employees.
 select sum(sal) from emp;

--9. Print the average annual salary . 
 select sum(sal)/12 from emp;

--10. Select the name, job, salary, department number of all employees except 
--SALESMAN from department number 30. 
 select  ename,job,sal,Deptno from emp where job!='Salesman'

--11. List unique departments of the EMP table.
 select d.dname,d.deptno from emp e join dept d on e.deptno=d.Deptno  group by d.deptno,d.Dname


--12. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. 
--Label the columns Employee and Monthly Salary respectively.
select ename as Employee,Sal as MonthlySalary from emp where sal>1500 and (Deptno=10 or Deptno=30)

--13. Display the name, job, and salary of all the employees whose job is MANAGER or 
--ANALYST and their salary is not equal to 1000, 3000, or 5000. 
 select ename,job,sal from emp where job!='Manager' and job!='Analyst' and sal not in(1000,3000,5000)

--14. Display the name, salary and commission for all employees whose commission 
--amount is greater than their salary increased by 10%. 
 select ename,sal, comm from emp where comm>sal*1.1;
--15. Display the name of all employees who have two Ls in their name and are in 
--department 30 or their manager is 7782. 
select ename from emp where ename like '%L%L%' and mgr=7782
--16. Display the names of employees with experience of over 30 years and under 40 yrs.
-- Count the total number of employees. 
 Select Ename FROM Emp where DateDiff(year, cast(Hiredate AS DATE), GetDate()) > 30
    AND DateDiff(year, cast(Hiredate AS DATE), GETDATE()) < 40;

--17. Retrieve the names of departments in ascending order and their employees in 
--descending order. 
select e.ename,d.Deptno,d.dname from emp e join Dept d on e.Deptno=d.Deptno order by d.Dname ,  e.ename desc;

--18. Find out experience of MILLER. 
select DateDiff(year, cast(Hiredate AS DATE), GetDate()) as 'Miller Experience' from emp where ename='Miller';

