USE [OrderDb]
go

create table USR.PhoneNumbers
(
	User_ID int not null,
	PhoneNumber varchar(50) not null
)

alter table USR.PhoneNumbers
add constraint PhoneNumber_fk foreign key (User_ID) references USR.Users(User_ID)