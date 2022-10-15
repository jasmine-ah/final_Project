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
GO
create proc sp_insert
@email varchar( 50),@password varchar(10)
as
begin
insert into login values( @email, @password)
end
GO

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
insert into sign_up values('a','s','a@Gmail.com','0987654322','12');



--delete from sign_up where userId=1;
--drop table sign_up
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
------------------------trigger that fires when same email and pwd is inserted for creating acc---------------------------------------------------
create trigger trig_sameEmail
on sign_up
instead of insert
as begin
declare @em varchar(100),@pwd varchar(10)
set @em=(select email from inserted)
set @pwd=(select password from inserted)
if @em=(select email from sign_up) 
BEGIN
raiserror('EMAIL ALREADY TAKEN CANNNOT CREATE ACCOUNT',16,1)
ROLLBACK
end
IF @pwd=(select password from sign_up)
begin
raiserror('PASSWORD ALREADY TAKEN!!!',16,1)
ROLLBACK
end
end
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
CREATE PROCEDURE ADDEMP

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

CREATE PROCEDURE UPDATEEMP
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
/*
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
*/
--------------------------------------booking-------------------------------------------------------------------
create table booked
(
id int,
groomName varchar(20),
brideName varchar(20),
WeddingDate datetime,
guests int,
payment varchar (20),
foreign key (id) references sign_up(userId)
);
select * from booked
--drop table booked
go
alter PROC spInserted
@id INT,
@gn varchar(25),
@bn varchar(25),
@wedding datetime,
@g int,
@pay varchar(20)

AS
BEGIn


    insert into booked values(@@IDENTITY,@gn,@bn,@wedding,@g,@pay)
end
GO
alter trigger addId
on sign_up
after insert
as begin
insert booked(id)
select userId from inserted
insert weddingInfo(id) select userId from inserted
end

go
create trigger addInfo
on weddingInfo
after insert
as begin
insert booked(groomName,brideName,guests,WeddingDate)
select groomName,brideName,guests,weddingDate from inserted 
end
go
--drop table booked

create table weddingInfo
(
id int ,
foreign key (id) references sign_up(userId),
groomName varchar(100),
brideName varchar(100),
packageName varchar(50),
price decimal(10, 2),
guests int,
Weddingdate DATETIME

);
select * from weddingInfo
--drop table weddingInfo

GO
alter PROCEDURE spInsert
@id int,
@gn varchar(100),
@bn varchar(100),
@packageName varchar(50),
@price decimal(10,2),
@guests int,
@wd dateTime
AS
BEGIN
--declare @em varchar(100)=(select email from sign_up where @email)
    insert weddingInfo values((select userId from sign_up ),@gn, @bn, @packageName, @price, @guests,@wd)
end
GO


alter trigger trigins2
on weddingInfo
after insert
as begin
insert booked(groomName,brideName,WeddingDate,guests)
select i.groomName,i.brideName,i.Weddingdate,i.guests from inserted i 
end
go
create PROCEDURE spPopulate
@id int
AS
	BEGIN
		SELECT * FROM weddingInfo WHERE ID = @ID;
		end

go
create proc bookDisplay
@id int
as
begin
select id,brideName,groomName,guests,Weddingdate from weddingInfo where @id = id

end

exec bookDisplay 1
go
create PROCEDURE UPDATEBOOK
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


create PROCEDURE DB
@id int
AS
BEGIN
    delete from booked where id = @id
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
/*
create function custom_total
( @price int)
returns
as
begin
	
	return @price
end
*/
create table selected(
id int foreign key references packageDetail(PD),
BeautyService bit,
PhotographyService bit,
Catering bit,
DJ bit,
Decor bit,
VenueBooking bit,

);

--drop table selected;
GO
alter proc ins_selected
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
go

GO
create proc priceCalc
@id int

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





drop trigger trig_full
---------------------------trigger that fires if the inserted wedding date is near-----------------------------
go
create trigger trig_nearDate
on weddingInfo
after insert 
as begin
declare @wd date
set @wd=(select cast(weddingDate AS datetime)from inserted )
if datediff(day,getdate(),@wd)<15
begin
raiserror('Cannot book!!! Wedding date is near.',16,1)
rollback
end
end
go
-----------------------trigger that fires if there is booking on occupied wedding date------------------------
go
create trigger trig_full
on weddingInfo
after insert 
as begin
declare @wd date,@s int
set @wd=(select cast(weddingDate AS datetime)from inserted )
set @s=(select count(w.weddingDate)from weddingInfo w join inserted i on w.weddingDate=i.weddingDate)
if @s>5
begin
raiserror('CANNOT BOOK!! Inserted Wedding date is fully booked ',16,1)
rollback
end
end

-----------------------------triggger to stop booking morethan one wedding with the same email-----------
go
create trigger trig_no2acc
on sign_up
instead of insert
as begin
declare @

----------------------------------------------------------------------
go
drop trigger trigins2
go
create trigger trig_noupdate
on booked
after update
as begin
declare @wd date
set @wd=(select cast(WD as datetime)from booked where id=)
if DATEDIFF(day,getdate(),@wd)<15
begin
raiserror('Cannot update any info',16,1)
rollback
end
end

go
create trigger trigins
on sign_up
after insert
as begin 
insert booked(userId,firstName,lastName,WD)
select i.id,i.firstName,i.lastName,i.weddingDate from inserted i
end
---------------------------------------------------------------------------
go



