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
	[ListPrice] decimal(18,2) NOT NULL,
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
	[Tel] [nvarchar](max) NOT NULL,
	CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED ([Id] ASC)
)

CREATE TABLE [dbo].[CartProduct]
(
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Cart] [int] NOT NULL,
	[Product] [int] NOT NULL,
	[Quantity] [int] NULL,
	[Price] decimal(18,2) NULL,
    CONSTRAINT [PK_CartProduct] PRIMARY KEY CLUSTERED ([Id] ASC)
)
GO

-- clé étrangère de la table Product qui est Category
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Category] FOREIGN KEY([Category]) REFERENCES [dbo].[Category] ([Id])
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Category]

-- clé étrangère de la table Product qui est SubCategory
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_SubCategory] FOREIGN KEY([SubCategory]) REFERENCES [dbo].[SubCategory] ([Id])
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_SubCategory]
GO

-- clé étrangère de la table SubCategory qui est Category
ALTER TABLE [dbo].[SubCategory]  WITH CHECK ADD  CONSTRAINT [PK_SubCategory_Category] FOREIGN KEY([Category]) REFERENCES [dbo].[Category] ([Id])
ALTER TABLE [dbo].[SubCategory] CHECK CONSTRAINT [PK_SubCategory_Category]
GO

-- clé étrangère de la table CartProduct qui est Cart
ALTER TABLE [dbo].[CartProduct]  WITH CHECK ADD  CONSTRAINT [PK_CartProduct_Cart] FOREIGN KEY([Cart]) REFERENCES [dbo].[Cart] ([Id])
ALTER TABLE [dbo].[CartProduct] CHECK CONSTRAINT [PK_CartProduct_Cart]

-- clé étrangère de la table CartProduct qui est Product
ALTER TABLE [dbo].[CartProduct]  WITH CHECK ADD  CONSTRAINT [PK_CartProduct_Product] FOREIGN KEY([Product]) REFERENCES [dbo].[Product] ([Id])
ALTER TABLE [dbo].[CartProduct] CHECK CONSTRAINT [PK_CartProduct_Product]

GO

-- Insertion des catégories principales
INSERT INTO [dbo].[Category] ([Name])
VALUES
('Coffrets Repas'),   
('Buffets & Cocktail'),      
('Cafés, Thés & Pause');         


-- Insertion des sous-catégories avec l'ID de la catégorie correspondante
INSERT INTO [dbo].[SubCategory] ([Name], [Category])
VALUES
('Menus du mois', 1),  
('Menu prestige', 1),  
('Menu excellence', 1);   


-- Insertion des produits avec les ID de la catégorie et de la sous-catégorie correspondantes
INSERT INTO [dbo].[Product] ([Name], [ListPrice], [Category], [SubCategory])
VALUES
-- Pour la catégorie Coffrets et Repas
('Tradi', 17.90, 1, 1),         
('Pecheur', 17.90, 1, 1),     
('Vege', 17.90, 1, 1),      
('Terre', 19.90, 1, 2),         
('Mer', 19.90, 1, 2),  
('Green', 19.90, 1, 2),            
('Lynx', 22.90, 1, 2),           
('Corail', 22.90, 1, 3),           
('Trefle', 22.90, 1, 3),   

-- Pour la catégorie Buffets et Cocktail --
('Sur le pouce', 9.90, 2, Null),         
('9 pièces', 15.90, 2, Null),     
('12 pièces', 21.90, 2, Null),      
('15 pièces', 28.90, 2, Null),         
('18 pièces', 28.90, 2, Null),

-- Pour la catégorie Café et Thé
('Lexpress', 5.90, 3, Null),         
('Lenergique', 8.50, 3, Null),     
('Le complet', 12.50, 3, Null);      


-- Insertion des commandes avec les détails de livraison et de contact
INSERT INTO [dbo].[Cart] ([DateCommande], [AdrLivraison], [Tel])
VALUES
('2024-06-01 12:30:00', '10 Rue Georges Lyvet', '1234567890'),  -- Première commande
('2024-06-02 15:45:00', '12 Rue Georges Lyvet', '2345678901'), -- Deuxième commande
('2024-05-02 16:45:00', '10 Rue Georges Lyvet', '3456789012'), -- Troisième commande
('2024-04-02 17:45:00', '11 Rue Georges Lyvet', '4567890123'); -- Quatrième commande
														   
-- Insertion des produits qui vont être commandés
INSERT INTO [dbo].[CartProduct] ([Cart], [Product], [Quantity], [Price])
VALUES
(1, 1, 2, 17.90),
(1, 2, 1, 17.90),
(1, 3, 3, 17.90),
(1, 4, 5, 19.90);

-- select pour vérifier si c'est correct
SELECT 
    cp.Cart AS NumeroPanier,
    p.Name AS NomProduit,
    cp.Price AS Prix,
    cp.Quantity AS Quantite
FROM 
    dbo.CartProduct cp
INNER JOIN 
    dbo.Product p ON cp.Product = p.Id
INNER JOIN 
    dbo.Cart c ON cp.Cart = c.Id;


	SELECT 
    p.Id AS ProductId,
    p.Name AS ProductName,
    p.ListPrice,
    p.SubCategory AS SubCategoryId,
    sc.Name AS SubCategoryName,
    c.Name AS CategoryName
FROM 
    dbo.Product p
INNER JOIN 
    dbo.SubCategory sc ON p.SubCategory = sc.Id
INNER JOIN 
    dbo.Category c ON p.Category = c.Id;
GO

Select
c.Id, c.Name 
From Category c;

Use master	
