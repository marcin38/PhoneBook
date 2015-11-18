IF OBJECT_ID('PhoneBook', 'U') IS NOT NULL
	drop table PhoneBook;

IF OBJECT_ID('PhoneTypes', 'U') IS NOT NULL
	drop table PhoneTypes;

IF OBJECT_ID('Users', 'U') IS NOT NULL
	drop table Users;

CREATE TABLE Users(
	Id int NOT NULL PRIMARY KEY IDENTITY,
	FirstName nvarchar(50) NOT NULL,
	LastName nvarchar(50) NOT NULL,
	InsertDate datetime,
	UpdateDate datetime
);

CREATE TABLE PhoneTypes(
	Id int NOT NULL PRIMARY KEY IDENTITY,
	Name nvarchar(50) NOT NULL,
	InsertDate datetime,
	UpdateDate datetime
);

CREATE TABLE PhoneBook(
	Id int NOT NULL PRIMARY KEY IDENTITY,
	UserId int NOT NULL,
	PhoneTypeId int NOT NULL,
	Number nvarchar(20) NOT NULL,
	InsertDate datetime,
	UpdateDate datetime


	CONSTRAINT FK_PhoneBook_UserId FOREIGN KEY (UserId) REFERENCES Users(Id),
	CONSTRAINT FK_PhoneBook_PhoneTypeId FOREIGN KEY (PhoneTypeId) REFERENCES PhoneTypes(Id)
);