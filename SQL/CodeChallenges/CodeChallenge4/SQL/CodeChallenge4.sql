create database CodeChallenge

use CodeChallenge

CREATE TABLE book (
    id int PRIMARY KEY,
    title varchar(25),
    author varchar(255),
    isbn_no varchar(25) UNIQUE,
    published_date datetime
);
insert into book (id, title, author, isbn_no, published_date)
values
(1, 'my first sql book', 'mary parker', '98143029127', '2012-02-22 12:08:17'),
(2, 'my second sql book', 'john mayer', '857200923713', '1972-07-03 09:22:45'),
(3, 'my third sql book', 'cary flint', '523120967812', '2015-10-18 14:05:44');

select * from book
where author like '%er';

CREATE TABLE review(
 id int PRIMARY KEY,
 book_id int,
 reviewer_name varchar(25),
 content varchar (25),
 rating int,
 published_date datetime,
 foreign key (book_id) references book(id)
)

insert into review (id, book_id, reviewer_name, content, rating, published_date)
values
(1, 1, 'John Smith', 'My first review', 4, '2017-12-10 05:50:11'),
(2, 2, 'John Smith', 'My second review', 5, '2017-10-13 15:05:12'),
(3, 1, 'Alice Walker','My third review', 1, '2017-10-22 23:47:10');

select  b.title,  b.author,  r.reviewer_name from  book b
inner join review r on b.id = r.book_id;

SELECT reviewer_name
FROM review
GROUP BY reviewer_name
HAVING COUNT(DISTINCT book_id) > 1;


CREATE TABLE Customer (
    ID INT PRIMARY KEY,
    NAME VARCHAR(50),
    AGE INT,
    ADDRESS VARCHAR(100),
    SALARY DECIMAL(10, 2)
);

-- Insert 7 values
INSERT INTO Customer (ID, NAME, AGE, ADDRESS, SALARY) VALUES
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP',NULL),
(7, 'Muffy', 24, 'Indore',NULL);

SELECT LOWER(NAME) AS name_lowercase
FROM Customer
WHERE SALARY IS NULL;

SELECT NAME
FROM Customer
WHERE ADDRESS LIKE '%o%';

create table orders
(oid int primary key, 
date datetime,
customer_id int references Customer(id),
amount int)
 
insert into orders values
(102, '2009-10-08 00:00:00', 3, 3000),
(100, '2009-10-08 00:00:00', 3, 1500),
(101, '2009-11-20 00:00:00', 2, 1560),
(103, '2008-05-20 00:00:00', 4, 2060)

select o.date 'Date', count(distinct c.id) 'CountOfCustomers'
from orders o, Customer c
where o.customer_id = c.id
group by o.date

create table studentdetails( id int  primary key,
regno int,
name varchar(20),
age int,
Qualification varchar(10),
mobno bigint,
mail_id varchar(20),
location varchar(20),
gender char)
 

INSERT INTO studentdetails (id, regno, name, age, Qualification, mobno, mail_id, location, gender) VALUES
(2, 2, 'Sai', 22, 'B.E', 9876543211, 'Sai@example.com', 'Chennai', 'M'),
(3, 3, 'Kumar', 20, 'BSC', 9876543212, 'Kumar@example.com', 'Madurai', 'M'),
(4, 4, 'Selvi', 22, 'BTech', 9876543213, 'selvi@example.com', 'Selam', 'F'),
(5, 5, 'Nisha', 25, 'ME', 9876543214, 'Nisha@example.com', 'Theni', 'F'),
(6, 6, 'Sai Saran', 21, 'BA', 9876543215, 'saran@example.com', 'Pune', 'F'),
(7, 7, 'Tom', 23, 'BCA', 9876543216, 'Tom@example.com', 'Pune', 'M');

 
SELECT gender, COUNT(*) AS total_count
FROM studentdetails
GROUP BY gender;
