using DanCook.Commun;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq.Expressions;

namespace DanCook.Donnees
{
    // Classe statique pour les opérations de données
    public static class Data
    {
        // Méthode pour exécuter la commande
        public static int Execute(CommandLine cmd)
        {
            bool lecture = false;

            // Crée et ouvre une connexion SQL
            var cnx = new SqlConnection();
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=DanCookStage;Integrated Security=True;Encrypt=False";
            cnx.Open();

            SqlCommand sqlCmd = new SqlCommand();
            SqlDataReader rd = null;
            sqlCmd.Connection = cnx;
            sqlCmd.CommandType = CommandType.Text;

            // Choisis l'action en fonction de la commande 
            switch (cmd.Label)
            {
                case CommandEnum.Get_Product:

                    sqlCmd.CommandText = @"SELECT 
                                            p.Id,
                                            p.Name,
                                            p.ListPrice,
                                            p.SubCategory,
                                            sc.Name AS SubCategoryName,
                                            c.Name AS CategoryName
                                        FROM 
                                            dbo.Product p
                                        LEFT JOIN 
                                            dbo.SubCategory sc ON p.SubCategory = sc.Id
                                        INNER JOIN 
                                            dbo.Category c ON p.Category = c.Id";

                    if (cmd.Parameters.ContainsKey("Category"))
                    {
                        sqlCmd.CommandText += $" where c.Id = {cmd.Parameters["Category"]}";
                    }

                    // Ajoute un ordre de tri 
                    if (cmd.Parameters.ContainsKey("OrderBy"))
                    {
                        sqlCmd.CommandText += $" order by p.{cmd.Parameters["OrderBy"]}";
                    }
                    lecture = true;
                    break;

                case CommandEnum.Get_Category:
                    sqlCmd.CommandText = @"Select
                                            c.Id, c.Name 
                                            From Category c";

                    // Ajoute un ordre de tri 
                    if (cmd.Parameters.ContainsKey("OrderBy"))
                    {
                        sqlCmd.CommandText += $" order by c.{cmd.Parameters["OrderBy"]}";
                    }
                    lecture = true;

                    break;

                case CommandEnum.Add_Cart:
                    //Add-Cart -Id 5 -Product 1 -Quantity 3 -Price 17
                    if (cmd.Parameters.ContainsKey("Id") && cmd.Parameters.ContainsKey("Product") && cmd.Parameters.ContainsKey("Quantity"))
                    {
                        sqlCmd.CommandText = $@"Select Id from Cart where id = {cmd.Parameters["Id"]}";
                        try
                        {
                            rd = sqlCmd.ExecuteReader();
                            if (!rd.Read())
                            {
                                rd.Close();
                                // La commande SQL pour ajouter un nouveau panier
                                sqlCmd.CommandText = $@"INSERT INTO Cart (Id, DateCommande)
                                                VALUES ({cmd.Parameters["Id"]}, GETDATE());";

                                sqlCmd.ExecuteNonQuery();
                            }
                            // La commande SQL pour ajouter un produit au panier
                            sqlCmd.CommandText = $@"INSERT INTO CartProduct (Cart, Product, Price, Quantity)
                                                VALUES ({cmd.Parameters["Id"]}, {cmd.Parameters["Product"]}, {cmd.Parameters["Price"]}, {cmd.Parameters["Quantity"]})";
                            sqlCmd.ExecuteNonQuery();

                            sqlCmd.CommandText = $@"Select Id from Cart where id = {cmd.Parameters["Id"]}";
                            lecture = true;
                        }
                        catch (Exception ex)
                        {
                            lecture = false;
                        }
                    }
                    else
                    {
                        return -1;
                    }
                    break;
                case CommandEnum.Get_Cart:
                    if (cmd.Parameters.ContainsKey("Id"))
                    {
                        int cartId = int.Parse(cmd.Parameters["Id"]);
                        if (cmd.Parameters.ContainsKey("Option") && cmd.Parameters["Option"].ToLower() == "total")
                        {
                            sqlCmd.CommandText = $@"SELECT SUM(cp.Price * cp.Quantity) AS Total
                                                    FROM CartProduct cp
                                                    WHERE cp.Cart = {cartId}";
                        }
                        else
                        {
                            sqlCmd.CommandText = $@"SELECT 
                                                    cp.Cart AS PanierNumero,
                                                    p.Name AS NomProduit,
                                                    cp.Price AS Prix,
                                                    cp.Quantity AS Quantite
                                                FROM 
                                                    dbo.CartProduct cp
                                                INNER JOIN 
                                                    dbo.Product p ON cp.Product = p.Id
                                                INNER JOIN 
                                                    dbo.Cart c ON cp.Cart = c.Id
                                                WHERE 
                                                    cp.Cart = {cartId}";

                            // Ajoute un ordre de tri 
                            if (cmd.Parameters.ContainsKey("OrderBy"))
                            {
                                sqlCmd.CommandText += $" ORDER BY cp.{cmd.Parameters["OrderBy"]}";
                            }
                        }
                        lecture = true;
                    }
                    else 
                    {
                        sqlCmd.CommandText = $@"Select Id From Cart";
                        lecture = true;
                    }
                break;

                default:
                    return -1;

            }

            if (lecture)
            {
                // Exécute la commande et lit les résultats
                try
                {
                    rd = sqlCmd.ExecuteReader();
                    while (rd.Read())
                    {
                        // Création d'une nouvelle ligne de résultats
                        var ligne = new List<string>();
                        switch (cmd.Label)
                        {
                            case CommandEnum.Get_Product:

                                ligne.Add(rd["Id"].ToString());
                                ligne.Add(rd["Name"].ToString());
                                ligne.Add(rd["ListPrice"].ToString());
                                ligne.Add(rd["SubCategoryName"].ToString());
                                ligne.Add(rd["CategoryName"].ToString());
                                break;
                            case CommandEnum.Get_Category:

                                ligne.Add(rd["Id"].ToString());
                                ligne.Add(rd["Name"].ToString());
                                break;
                            case CommandEnum.Get_Cart:
                                if (cmd.Parameters.ContainsKey("Option") && cmd.Parameters["Option"].ToLower() == "total")
                                {
                                    ligne.Add(rd["Total"].ToString());
                                }
                                else
                                {
                                    ligne.Add(rd["PanierNumero"].ToString());
                                    ligne.Add(rd["NomProduit"].ToString());
                                    ligne.Add(rd["Prix"].ToString());
                                    ligne.Add(rd["Quantite"].ToString());
                                }
                                break;
                            case CommandEnum.Add_Cart:

                                ligne.Add(rd["Id"].ToString());
                                break;
                        }
                        // Ajoute la ligne aux résultats de la commande
                        cmd.Result.Add(ligne);
                    }

                }
                catch (Exception)
                {
                    return -2;
                }

                // Ferme le DataReader
                rd.Close();
            }
            else
            {
                return sqlCmd.ExecuteNonQuery();
            }
            return 0;
        }
    }
}
