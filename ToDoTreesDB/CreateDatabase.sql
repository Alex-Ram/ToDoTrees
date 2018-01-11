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
	[Name]			varchar(35)	NOT NULL,
	[ParentID]		int			REFERENCES Categories(CategoryID)	NULL
)
GO

CREATE TABLE ToDoItems
(
	[ID]			int			PRIMARY KEY		IDENTITY,
	[Category]		int			REFERENCES Categories(CategoryID),
	[Description]	varchar(50)	NOT NULL,
	[IsCompleted]	bit			NOT NULL		DEFAULT(0)
)
GO