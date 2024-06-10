-- Insertion des cat�gories principales
INSERT INTO [dbo].[Category] ([Name])
VALUES
('Coffrets Repas'),   
('Buffets & Cocktail'),      
('Caf�s, Th�s & Pause');         


-- Insertion des sous-cat�gories avec l'ID de la cat�gorie correspondante
INSERT INTO [dbo].[SubCategory] ([Name], [Category])
VALUES
('Menus du mois', 1),  
('Menu prestige', 1),  
('Menu excellence', 1),   


-- Insertion des produits avec les ID de la cat�gorie et de la sous-cat�gorie correspondantes
INSERT INTO [dbo].[Product] ([Name], [ListPrice], [Category], [SubCategory])
VALUES
-- Pour la cat�gorie Coffrets et Repas
('Tradi', 17.90, 1, 1),         
('Pecheur', 17.90, 1, 1),     
('Vege', 17.90, 1, 1),      
('Terre', 19.90, 1, 2),         
('Mer', 19.90, 1, 2),  
('Green', 19.90, 1, 2),            
('Lynx', 22.90, 1, 2),           
('Corail', 22.90, 1, 3),           
('Trefle', 22.90, 1, 3),   

-- Pour la cat�gorie Buffets et Cocktail --
('Sur le pouce', 9.90, 2),         
('9 pi�ces', 15.90, 2),     
('12 pi�ces', 21.90, 2),      
('15 pi�ces', 28.90, 2),         
('18 pi�ces', 28.90, 2),

-- Pour la cat�gorie Caf� et Th�
('Lexpress', 5.90, 3),         
('Lenergique', 8.50, 3),     
('Le complet', 12.50, 3);      


-- Insertion des commandes avec les d�tails de livraison et de contact
INSERT INTO [dbo].[Cart] ([DateCommande], [AdrLivraison], [Tel])
VALUES
('2024-06-01 12:30:00', '10 Rue Georges Lyvet', 1234567890),  -- Premi�re commande
('2024-06-02 15:45:00', '10 Rue Georges Lyvet', 2345678901) -- Deuxi�me commande
