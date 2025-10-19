USE master
GO
CREATE DATABASE CrudProduct
GO

USE CrudProduct
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = N'masters')
BEGIN
    EXEC sys.sp_executesql N'CREATE SCHEMA [masters]'
END
GO