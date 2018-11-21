use [OrderDb]
go

create table USR.Roles
(
User_RoleID int identity (1,1) not null primary key,
User_Role varchar (50) not null
)