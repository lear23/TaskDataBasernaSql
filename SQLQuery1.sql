 

CREATE TABLE CategoriesEntity ( 

  Id INT PRIMARY KEY IDENTITY, 

  CategoryName NVARCHAR(MAX) 

); 

 

CREATE TABLE ReadersEntity ( 

  Id INT PRIMARY KEY IDENTITY, 

  ReaderName NVARCHAR(MAX) 

); 

 

CREATE TABLE DirectionsEntity ( 

  Id INT PRIMARY KEY IDENTITY, 

  StreetName NVARCHAR(MAX), 

  PostalCode NVARCHAR(MAX), 

  City NVARCHAR(MAX) 

); 

 

CREATE TABLE ClientsEntity ( 

  Id INT PRIMARY KEY IDENTITY, 

  FirstName NVARCHAR(MAX), 

  LastName NVARCHAR(MAX), 

  ReaderId INT, 

  DirectionId INT, 

  FOREIGN KEY (ReaderId) REFERENCES ReadersEntity(Id), 

  FOREIGN KEY (DirectionId) REFERENCES DirectionsEntity(Id) 

); 

 

CREATE TABLE ProductsEntity ( 

  Id INT PRIMARY KEY IDENTITY, 

  ModelName NVARCHAR(MAX), 

  Color NVARCHAR(MAX), 

  CategoryId INT, 

  FOREIGN KEY (CategoryId) REFERENCES CategoriesEntity(Id) 

); 