use [OrderDb]
go

create schema IT
go

create table IT.Item
(
Item_ID int identity (1,1) primary key not null,
Item_Name varchar(100) not null,
Item_Description varchar(300),
Item_Price decimal (5,2) not null,
Item_Amount int not null,
Item_InStock int not null
)
