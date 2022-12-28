create SCHEMA bhanu
go
create table bhanu.department(
    [id] int PRIMARY key,
    [name] VARCHAR(20),
    [location] VARCHAR(30),
)

--drop table bhanu.department
--drop table bhanu.employee
--drop table bhanu.empdetails

create table bhanu.employee(
    [id] int PRIMARY KEY,
    [firstname] VARCHAR(20),
    [lastname] VARCHAR(20),
    [ssn] bigint,
    [deptid] int
    FOREIGN key (deptid) REFERENCES bhanu.department(id)
)

create table bhanu.empdetails(
    [id] int PRIMARY KEY,
    [empid] int unique,
    [salary] int,
    [address1] VARCHAR(30),
    [address2] VARCHAR(30),
    [city] VARCHAR(20),
    [state] VARCHAR(20),
    [country] VARCHAR(20),
    FOREIGN key (empid) REFERENCES bhanu.employee(id)
)

alter table bhanu.empdetails 
   add CONSTRAINT empid UNIQUE

insert into bhanu.department values(1,'Marketing','chennai'),(2,'IT','delhi'),(3,'sales','chennai')

select * from bhanu.department

insert into bhanu.employee values(1,'bhanu','kola',1234512345,2),(2,'solu','syed',1212121212,1),(3,'raghu','vamshi',1231231234,2),(4,'Tina','smith',5675675678,1)

--delete from bhanu.employee where id = 4 

select * from bhanu.employee
------------------


insert into bhanu.employee values(4,'Tina','Smith',5675675675,1)

insert into bhanu.empdetails values(1,1,9000,'street 1','street 2','vizag','andhra pradesh','india'),(2,2,10000,'street 1','street 2','hyderabad','telangana','india'),
(3,3,7000,'street 1','street 2','chennai','tamil nadu','india')

select * from bhanu.empdetails

insert into bhanu.empdetails values(4,4,15000,'street 1','street 2','kakinada','telangana','india')
---------------------

select firstname,lastname from bhanu.employee
inner join bhanu.department on bhanu.employee.deptid=bhanu.department.id where bhanu.department.name='Marketing' 
-------------------

select sum(bhanu.empdetails.salary) as 'Total salary' from bhanu.empdetails
inner join bhanu.employee on bhanu.empdetails.empid=bhanu.employee.id 
inner join bhanu.department on bhanu.employee.deptid=bhanu.department.id where bhanu.department.name='Marketing'
------------------

select count(*) as 'Total Employees',bhanu.department.name from bhanu.employee 
inner join bhanu.department on  bhanu.employee.deptid=bhanu.department.id group by bhanu.department.name
-----------------

UPDATE bhanu.empdetails set salary = 90000 from bhanu.empdetails
inner join bhanu.employee on bhanu.empdetails.empid=bhanu.employee.id where bhanu.employee.firstname = 'Tina'