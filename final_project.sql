create database final_project
use final_project


-----------------ROLE OPTION----------
CREATE TABLE role(
    admin VARCHAR(10),
    customer VARCHAR(10),
    password VARCHAR(10)
);

-----------------LOGIN---------------- 

CREATE TABLE login(
    email varchar(50) NOT NULL,
    password varchar(10) NOT NULL
);
select * from login
create proc sp_insert
@email varchar( 50),@password varchar(10)
as
begin
insert into login values( @email, @password)
end

/*CREATE LOGIN admin WITH PASSWORD= 'admin' 
CREATE USER admin FOR LOGIN admin;
CREATE LOGIN user WITH PASSWORD=' '
CREATE USER user1 FOR LOGIN user;
 */
---------------SIGNUP------------------
CREATE TABLE sign_up(
userId INT PRIMARY KEY IDENTITY,
firstName varchar(25) NOT NULL,
lastName varchar(25) NOT NULL,
email varchar(100),
contactInfo varchar(15),
password varchar(10),
weddingDate DATETIME
);
select *from sign_up
GO
CREATE PROC sp_ins
@fn varchar(25),
@ln varchar(25),
@email varchar(50),
@ci varchar(15),
@password varchar(10),
@wd DATETIME
AS
BEGIN
    insert into sign_up values(@fn,@ln,@email,@ci,@password, @wd)
end
GO
---------------SERVICES------------------

CREATE TABLE services(
    dj ,
    photographer,
    venue,
    bakery,


);


----------EMPLOYEE--------------------

CREATE TABLE employee(
    employeeId int PRIMARY KEY identity,
    firstName varchar(25),
    lastName varchar(25),
    contactInfo varchar(15),
    DOB varchar(50),
    email varchar(50),
    Occupation varchar(25),
    gender varchar(6)
);
select *from employee

GO
alter PROCEDURE ADDEMP

@fn varchar(25),
@ln varchar(25),
@continfo varchar(15),
@DOB varchar(50),
@email varchar(50),
@Occupation varchar(25),
@gender varchar(6)
AS
BEGIN
    insert into employee values(@fn,@ln, @continfo, @DOB, @email, @Occupation, @gender)
end
GO

alter PROCEDURE UPDATEEMP
@fn varchar(25),
@ln varchar(25),
@continfo varchar(15),
@DOB varchar(50),
@email varchar(50),
@Occupation varchar(50),
@gender varchar(6),
@id int
AS
BEGIN
    update employee set firstName = @fn, lastName = @ln, contactInfo = @continfo, DOB = @DOB, email = @email, 
    Occupation = @Occupation, gender = @gender where employeeid = @id
end
GO

CREATE PROCEDURE DELETEEMP
@id int
AS
BEGIN
    delete from employee where employeeid = @id
END
GO

GO
CREATE PROCEDURE calcSalary
@sal money
As BEGIN
DECLARE @occ VARCHAR(50)
SET @occ=(SELECT Occupation from employee)
case @occ
when 'Photographer' then @sal=5000
when ''

END
GO

----------PACKAGES--------------------
CREATE TABLE package(
    packageId int PRIMARY KEY IDENTITY, 
    packageName varchar(15),
    packagePrice money
);
------------BILL----------------------

CREATE TABLE BILL(
    packageId int FOREIGN KEY REFERENCES package (packageId),

)

----------------------BOOKING------------------

CREATE TABLE booking(
    bookId int PRIMARY KEY IDENTITY,
    userId int FOREIGN KEY REFERENCES sign_up(userId),
    bookType VARCHAR(50),
    bookDate DATE
);

---------------------BOOKING UPDATE-------------
CREATE TABLE updatebooking(
    bookId int FOREIGN KEY REFERENCES booking(bookId),
    oldValue VARCHAR(50),
    newValue VARCHAR(50),
    updatedTime DATETIME
);

GO
CREATE TRIGGER trigUpdate
ON booking
AFTER UPDATE 
AS BEGIN
INSERT updatebooking(bookId,oldValue,newValue,updatedTime)
SELECT bookId, d.oldValue,i.newValue,i.updatedTime FROM inserted i JOIN deleted d ON i.bookId=d.bookId
END
GO
--------------------------------------booking-------------------------------------------------------------------
create table booked
(
userId int,
firstName varchar(20),
lastName varchar(20),
WD varchar(50),
guests int,
payment varchar (20)
);


create table weddingInfo
(
id int,
groomName varchar(100),
brideName varchar(100),
packageName varchar(50),
price decimal(10, 2),
guests int
);
select * from weddingInfo
drop table weddingInfo



alter PROCEDURE spInsert
@id int,
@gn varchar(100),
@bn varchar(100),
@packageName varchar(50),
@price decimal(10,2),
@guests int
AS
BEGIN
    insert into weddingInfo values(@id, @gn,@bn, @packageName, @price, @guests)
end
GO

create PROCEDURE spPopulate
@id int
AS
	BEGIN
		SELECT * FROM weddingInfo WHERE ID = @ID;



create proc bookDisplay
@id int
as
begin
select userId,firstName,lastName,weddingDate from sign_up where userId = @id

end

exec bookDisplay 1

create PROCEDURE UPDATEBOOK
@wd varchar(50),
@payment varchar(10),
@guests varchar(6),
@id int
AS
BEGIN
    update booked set   WD = @wd, 
    guests = @guests ,payment = @payment where userId = @id
end
GO


CREATE PROCEDURE DELETEBOOK
@id int
AS
BEGIN
    delete from booked where userId = @id
END
GO

---------------------custom---------------------------
create table packageDetail(
);