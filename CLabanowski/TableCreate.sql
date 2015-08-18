create table BlogPosts(
	Id int primary key not null,
	Title varchar(100) not null,
	[Text] varchar(max) not null,
	[Date] date not null,
	RouteName varchar(200) not null
)
go

create table PortfolioProjects(
	Id int primary key not null,
	Name varchar(100) not null,
	Technologies varchar(max) not null,
	[Description] varchar(max) not null,
	LinkURL varchar(200) not null,
	ImgURL varchar(200) not null
)

go