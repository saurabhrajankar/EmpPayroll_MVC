create database EmpMVC
drop table EmpRoll
create table EmpRoll(
 id int primary key identity,
 EmpName varchar(max)not null,
 Image varchar(max)not null,
 Gender varchar(max)not null,
 Department varchar(max)not null,
 Salary float not null,
 StartDate Datetime,
 Note varchar(max)not null
)
create or alter proc Addemp (@EmpName varchar(max), @Img varchar(max), @Gender varchar(max), @Department varchar(max), @Salary int, @StartDate datetime, @Note varchar(max))
as begin
insert into EmpRoll values(@EmpName, @EmpName, @Gender, @Department,@Salary,@StartDate,@Note)
end