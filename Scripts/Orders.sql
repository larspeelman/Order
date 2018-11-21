use [OrderDb]
go

create schema ORD
go

create table ORD.Orders
(
User_ID int not null,
Order_TotalPrice decimal (5,2) not null,
Order_ID int identity (1,1) primary key not null,
Order_Date DateTime not null
)

create table ORD.ItemGroup
(
Order_ID int not null,
ItemGroup_Amount int not null,
ItemGroup_Price decimal (5,2) not null,
ItemGroup_ShippingDate DateTime not null,
Item_ID int not null
)

alter table ORD.ItemGroup
add constraint ItemGroupOrderID_fk foreign key (Order_ID) references ORD.Orders(Order_ID)

alter table ORD.ItemGroup
add constraint ItemGroupProductID_fk foreign key (Item_ID) references IT.Item(Item_ID)

alter table ORD.Orders
add constraint user_fk foreign key (User_ID) references USR.Users(User_ID)