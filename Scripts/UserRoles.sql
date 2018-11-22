use [OrderDb]
go

create table USR.Roles
(
User_RoleID int identity (1,1) not null primary key,
User_Role varchar (50) not null
)

insert into USR.Roles
(
	User_Role

)
values
(
'Customer'
)

SELECT TOP (1000) [User_RoleID]
      ,[User_Role]
  FROM [OrderDb].[USR].[Roles]

  select *
  from
  usr.Users