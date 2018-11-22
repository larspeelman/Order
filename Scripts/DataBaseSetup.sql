USE [OrderDb]
go

create Schema USR
Go

create table USR.Users
(
	User_ID int not null identity (1,1) primary key,
	User_FirstName varchar (50) not null,
	User_LastName varchar(50) not null,
	User_Email varchar (70) not null,
	User_Street varchar (100) not null,
	User_Number varchar (20) not null,
	User_Zip varchar (10) not null,
	User_Password varchar (80) not null,
	User_RoleID int not null,
)

alter table USR.Users
add constraint userrole_fk foreign key (User_RoleID) references USR.Roles(User_RoleID)

insert into USR.Users
(
	User_FirstName,
	User_LastName,
	User_Email,
	User_Street,
	User_Number,
	User_Zip,
	User_Password,
	User_RoleID
)
values
(
'lars',
'peelman',
'lars@admin.be',
'teststreet',
'5',
'2050',
'test2',
1
)