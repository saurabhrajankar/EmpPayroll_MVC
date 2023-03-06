create database EmpMVC
drop table EmpRoll
create table EmpRoll(
 id int primary key identity,
 EmpName varchar(255)not null,
 Img varchar(255)not null,
 Gender varchar(10)not null,
 Department varchar(255)not null,
 Salary float not null,
 StartDate Datetime,
 Note varchar(max)not null
)
select * from EmpRoll

--Add Employee
create or alter proc Addemp (@EmpName varchar(255), @Img varchar(255), @Gender varchar(10), @Department varchar(max), @Salary float, @StartDate datetime, @Note varchar(max))
as begin
insert into EmpRoll values(@EmpName, @EmpName, @Gender, @Department,@Salary,@StartDate,@Note)
end

--Retrive Employee
create proc Getallemp
as begin
select * from EmpRoll      
end

--particular Employee 
create or alter proc empid(@id int)
as begin
select * from EmpRoll where id= @id
end

--Update Employee
create or alter proc Updtemp(@id int, @EmpName varchar(255), @Img varchar(255), @Gender varchar(10), @Department varchar(max), @Salary float, @StartDate datetime, @Note varchar(max))
as begin
update EmpRoll set Empname=@EmpName,Gender= @Gender, Department=@Department,Salary=@Salary, StartDate=@StartDate,Note=@Note where id=@id 
end

--Delete Employee
create or alter procedure DeleteEmp(@id int)         
as begin          
   Delete from EmpRoll where id=@id          
End
