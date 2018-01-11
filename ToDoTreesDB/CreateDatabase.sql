USE master

IF DB_ID('ToDoTreesDB') IS NOT NULL
	DROP DATABASE ToDoTreesDB
GO

CREATE DATABASE ToDoTreesDB
GO

USE ToDoTreesDB
GO

CREATE TABLE Categories
(
	[CategoryID]	int			PRIMARY KEY		IDENTITY,
	[ParentID]		int			REFERENCES Categories(CategoryID)	NULL,
	[Name]			varchar(35)	NOT NULL
)
GO

INSERT INTO Categories(ParentID, [Name])
VALUES (NULL, 'All')
GO

CREATE TABLE ToDoItems
(
	[ToDoItemID]	int			PRIMARY KEY		IDENTITY,
	[CategoryID]	int			REFERENCES Categories(CategoryID),
	[Description]	varchar(50)	NOT NULL,
	[IsCompleted]	bit			NOT NULL		DEFAULT(0)
)
GO