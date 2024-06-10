USE [master]
GO
/****** Object:  Database [DanCookStage]    Script Date: 06/06/2024 10:55:09 ******/
CREATE DATABASE [DanCookStage]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DanCookStage', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DanCookStage.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DanCookStage_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DanCookStage_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO

USE [DanCookStage]
GO
/** Table Product **/
CREATE TABLE [dbo].[Product]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[ListPrice] [int] NOT NULL,
	[Category] [int] NULL,
	[SubCategory] [int] NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO


/** Table Category **/
CREATE TABLE [dbo].[Category]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED ([Id] ASC)
)

/** Table SubCategory **/
CREATE TABLE [dbo].[SubCategory]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Category] [int] NULL,
	CONSTRAINT [PK_SubCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
)

/** Table Cart **/
CREATE TABLE [dbo].[Cart]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateCommande] [datetime] NOT NULL,
	[AdrLivraison] [nvarchar](max) NOT NULL,
	[Tel] [int] NOT NULL,
	CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED ([Id] ASC)
)

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([Category]) REFERENCES [dbo].[Category] ([Id])
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]

ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_SubCategory] FOREIGN KEY([SubCategory])
REFERENCES [dbo].[SubCategory] ([Id])
GO

ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_SubCategory]
GO
