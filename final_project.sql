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
password varchar(10)
);
select *from sign_up

drop table sign_up
GO
alter PROC sp_ins
@fn varchar(25),
@ln varchar(25),
@email varchar(50),
@ci varchar(15),
@password varchar(10)

AS
BEGIN
    insert into sign_up values(@fn,@ln,@email,@ci,@password)
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
    --userId int FOREIGN KEY REFERENCES sign_up(userId),
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
id int,
groomName varchar(20),
brideName varchar(20),
WeddingDate datetime,
guests int,
payment varchar (20)
);

drop table booked
create table weddingInfo
(
id int identity Not null,
groomName varchar(100),
brideName varchar(100),
packageName varchar(50),
price decimal(10, 2),
guests int,
Weddingdate DATETIME

);
select * from weddingInfo
drop table weddingInfo



alter PROCEDURE spInsert

@gn varchar(100),
@bn varchar(100),
@packageName varchar(50),
@price decimal(10,2),
@guests int,
@wd dateTime
AS
BEGIN
    insert into weddingInfo values( @gn,@bn, @packageName, @price, @guests,@wd)
end
GO

create PROCEDURE spPopulate
@id int
AS
	BEGIN
		SELECT * FROM weddingInfo WHERE ID = @ID;
		end


alter proc bookDisplay
@id int
as
begin
select id,brideName,groomName,guests,Weddingdate from weddingInfo where @id = id

end

exec bookDisplay 1

alter PROCEDURE UPDATEBOOK
@wd datetime,
@payment varchar(20),
@guests varchar(6),
@id int
AS
BEGIN
    update booked set    
    guests = @guests ,payment = @payment , @wd = WeddingDate where id = @id
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
PD int identity primary key,
serviceName varchar(100),
price int

);

insert into packageDetail values ('Beauty Service',6000)
insert into packageDetail values ('Photography Service',7000)
insert into packageDetail values ('Catering',10000)
insert into packageDetail values ('DJ',5000)
insert into packageDetail values ('Decor',12000)
insert into packageDetail values ('Venue Booking',60000)

select * from packageDetail

create function custom_total
( @price int)
returns
as
begin
	
	return @price
end
create table selected(
id int,
BeautyService bit,
PhotographyService bit,
Catering bit,
DJ bit,
Decor bit,
VenueBooking bit,

foreign key (id) references packageDetail(PD)
);

drop table selected;

create proc ins_selected
@id int ,
@BeautyService bit,
@PhotographyService bit,
@Catering bit,
@DJ bit,
@Decor bit,
@VenueBooking bit
as
begin
insert into selected values(@id,@BeautyService,@PhotographyService,@Catering,@DJ,@Decor,@VenueBooking)
end
select * from selected
create function priceCalc
(@id int)
returns int
as
begin
  declare @price int = 0
  if exists(select * from selected where BeautyService = 1 and ID = @id)
    select @price += price from packageDetail where serviceName = 'Beauty Service';
        
  if exists(select * from selected where PhotographyService = 1 and ID = @id)
    select @price += price from packageDetail where serviceName = 'Photography Service';
        
  if exists(select * from selected where Catering = 1 and ID = @id)
    select @price += price from packageDetail where serviceName = 'Catering';
        
  if exists(select * from selected where DJ = 1 and ID = @id)
    select @price += price from packageDetail where serviceName = 'DJ';
        
  if exists(select * from selected where Decor = 1 and ID = @id)
    select @price += price from packageDetail where serviceName = 'Decor';
        
  if exists(select * from selected where VenueBooking = 1 and ID = @id)
    select @price += price from packageDetail where serviceName = 'Venue Booking';
  
  return @price
end