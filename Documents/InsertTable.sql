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
('2024-06-01 12:30:00', '10 Rue Georges Lyvet', 1234567890),  -- Première commande
('2024-06-02 15:45:00', '12 Rue Georges Lyvet', 2345678901), -- Deuxième commande
('2024-05-02 16:45:00', '10 Rue Georges Lyvet', 3456789012), -- Troisième commande
('2024-04-02 17:45:00', '11 Rue Georges Lyvet', 4567890123); -- Quatrième commande

-- Insertion des produits qui vont être commandés
INSERT INTO [dbo].[CartProduct] ([Cart], [Product], [Quantity])
VALUES
(1,1,2),
(2,1,1),
(3,1,3),
(4,1,5);

