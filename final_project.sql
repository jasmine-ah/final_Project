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
    password varchar(10) NOT NULL,
	id int foreign key references sign_up_info(userId)
);
--drop table login
select * from login
GO
alter proc sp_insert
@email varchar( 50),@password varchar(10),@id int
as
begin
insert into login values( @email, @password,@id)
end
GO

/*CREATE LOGIN admin WITH PASSWORD= 'admin' 
CREATE USER admin FOR LOGIN admin;
CREATE LOGIN user WITH PASSWORD=' '
CREATE USER user1 FOR LOGIN user;
 */
---------------SIGNUP------------------
CREATE TABLE sign_up_info(
userId INT PRIMARY KEY IDENTITY,
firstName varchar(25) NOT NULL,
lastName varchar(25) NOT NULL,
email varchar(100),
contactInfo varchar(15),
password varchar(10)
);
select *from sign_up_info
insert into sign_up_info values('abebe','shewa','a@Gmail.com','0987654322','12');
insert into sign_up_info values('kebede','shewa','k@Gmail.com','0987987322','1234');
--drop table sign_up


--delete from sign_up where userId=1;
--drop table sign_up
GO
alter PROC sp_ins
@fn varchar(25),
@ln varchar(25),
@email varchar(50),
@ci varchar(15),
@password varchar(10),
@id int output

AS
BEGIN
    insert into sign_up_info values(@fn,@ln,@email,@ci,@password)
	select @id=(select SCOPE_IDENTITY())
end
GO
------------------------trigger that fires when same email and pwd is inserted for creating acc---------------------------------------------------
alter trigger trig_sameEmailAndPhone
on sign_up_info
after insert
as begin

if exists(select email from inserted )
begin
raiserror('EMAIL ALREADY TAKEN CANNNOT CREATE ACCOUNT',16,1)
ROLLBACK
end
END
go
CREATE TRIGGER trigsamePhone
on sign_up_info
after insert
as begin
if exists (select contactInfo from inserted)
begin
raiserror('USER WITH THIS PHONE NUMBER ALREADY EXISTS!!!',16,1)
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
payment varchar (20) default ' ',
foreign key (id) references sign_up_info(userId)
);
 
select * from booked
--drop table booked
go
alter PROC spInserted
@gn varchar(25),
@bn varchar(25),
@wedding datetime,
@g int,
@pay varchar(20)

AS
BEGIn
declare @lastid int;
set @lastid = SCOPE_IDENTITY()

    insert into booked values(@lastid,@gn,@bn,@wedding,@g,@pay)
end
GO
/*
go
create trigger addInfo
on weddingInfos
after insert
as begin
insert booked(groomName,brideName,guests,WeddingDate)
select groomName,brideName,guests,weddingDate from inserted 
end
go
*/
--drop table booked

create table weddingInfos
(

groomName varchar(100),
brideName varchar(100),
packageName varchar(50),
price int,
guests int,
Weddingdate DATETIME,
userId int foreign key references sign_up_info (userId)

);
select * from weddingInfos
--drop table weddingInfos

GO
alter PROCEDURE spInsert

@gn varchar(100),
@bn varchar(100),
@packageName varchar(50),
@price decimal(10,2),
@guests int,
@wd dateTime,
@id int
AS
BEGIN
    insert weddingInfos values(@gn, @bn, @packageName, @price, @guests,@wd,@id)
end
GO
--------------------------------trigger inserts records on booked table after there is an insert in weddingInfo----------------
create trigger trigins
on weddingInfos
after insert
as begin 
insert booked(id,groomName,brideName,weddingDate,guests)
select i.userId,i.groomName,i.brideName,i.weddingDate,i.guests from inserted i
end
------------------------------------------------------------------------------
/*
alter trigger trigins2
on weddingInfos
after insert
as begin
insert booked(groomName,brideName,WeddingDate,guests)
select i.groomName,i.brideName,i.Weddingdate,i.guests from inserted i 
end
*/
go
create PROCEDURE spPopulate
@id int
AS
	BEGIN
		SELECT * FROM weddingInfo WHERE id = @ID;
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
alter PROCEDURE UPDATEBOOK
@gn varchar(100),
@bn varchar(100),
@wd datetime,
@payment varchar(20),
@guests varchar(6),
@id int
AS
BEGIN
    update booked set    
             groomName=@gn,brideName=@bn, guests = @guests ,payment = @payment , WeddingDate = @wd where id = @id
end
GO
create PROCEDURE DB
@id int
AS
BEGIN
    delete from booked where id = @id
END
GO

create trigger updwedd
on booked
after update
as begin
update weddingInfos set groomName=i.groomName,brideName=i.brideName,guests=i.guests,Weddingdate=i.WeddingDate from inserted i join weddingInfos w on i.id=w.userId
end
go
create trigger delwed
on booked 
after delete
as begin
delete from weddingInfos w inner join deleted d userId on w.userId=d.id
end
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

drop table packageDetail

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
id int ,
BeautyService bit,
PhotographyService bit,
Catering bit,
DJ bit,
Decor bit,
VenueBooking bit,
foreign key (id) references packageDetail(PD),
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
go
CREATE PROCEDURE PRICE
@id int
AS
BEGIN
	SELECT DBO.priceCalc (@id);
END
select * from selected
go

GO
ALTER FUNCTION priceCalc
(@id int)
returns int
as
begin
  declare @price int = 0
--  DECLARE @id int=0
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

go



---------------------------trigger that fires if the inserted wedding date is near-----------------------------
go
create trigger trig_nearDate
on weddingInfos
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
on weddingInfos
after insert 
as begin
declare @wd date,@s int
set @wd=(select cast(weddingDate AS datetime)from inserted )
set @s=(select count(w.weddingDate)from weddingInfos w join inserted i on w.weddingDate=i.weddingDate)
if @s>5
begin
raiserror('CANNOT BOOK!! Inserted Wedding date is fully booked ',16,1)
rollback
end
end

-----------------------------triggger to stop booking morethan one wedding with the same email-----------

go
create trigger trig_noupdate
on booked
after update
as begin
declare @wd date
declare @id int
set @wd=(select WeddingDate from booked where id=@id)
if DATEDIFF(day,getdate(),@wd)<15
begin
raiserror('Cannot update any info the wedding is near!!!',16,1)
rollback
end
end
go
---------------------------------------------------------------------------
CREATE TABLE revenue(
total money,
vat money
);
go
CREATE FUNCTION 



