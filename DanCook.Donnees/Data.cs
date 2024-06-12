using DanCook.Commun;
using Microsoft.Data.SqlClient;
using System.Data;

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
                                        INNER JOIN 
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
                    if (cmd.Parameters.ContainsKey("Id") && cmd.Parameters.ContainsKey("Product") && cmd.Parameters.ContainsKey("Quantity"))
                    {
                        // La commande SQL pour ajouter un produit au panier
                        sqlCmd.CommandText = $@"INSERT INTO CartProduct (Cart, Product, Price, Quantity)
                                                VALUES ({cmd.Parameters["Id"]}, {cmd.Parameters["Product"]}, {cmd.Parameters["Price"]}, {cmd.Parameters["Quantity"]})";

                        lecture = false;
                    }
                    else
                    {
                        return -1;
                    }

                    break;

                case CommandEnum.Get_Cart:
                    sqlCmd.CommandText = @"SELECT 
                                            cp.Cart AS PanierNumero,
                                            p.Name AS NomProduit,
                                            cp.Price AS Prix,
                                            cp.Quantity AS Quantite
                                           FROM 
                                            dbo.CartProduct cp
                                           INNER JOIN 
                                            dbo.Product p ON cp.Product = p.Id
                                           INNER JOIN 
                                            dbo.Cart c ON cp.Cart = c.Id";

                    if (cmd.Parameters.ContainsKey("Cart"))
                    {
                        sqlCmd.CommandText += $" WHERE cp.Cart = {cmd.Parameters["Cart"]}";
                    }

                    // Ajoute un ordre de tri 
                    if (cmd.Parameters.ContainsKey("OrderBy"))
                    {
                        sqlCmd.CommandText += $" ORDER BY cp.{cmd.Parameters["OrderBy"]}";
                    }
                    lecture = true;
                break;

                default:
                    return -1;

            }

            if (lecture)
            {
                // Exécute la commande et lit les résultats
                SqlDataReader rd = null;
                try
                {
                    rd = sqlCmd.ExecuteReader();
                    while (rd.Read())
                    {
                        // Création d'une nouvelle ligne de résultats
                        var ligne = new List<string>();
                        if (cmd.Label == CommandEnum.Get_Product)
                        {
                            ligne.Add(rd["Id"].ToString());
                            ligne.Add(rd["Name"].ToString());
                            ligne.Add(rd["ListPrice"].ToString());
                            ligne.Add(rd["SubCategoryName"].ToString());
                            ligne.Add(rd["CategoryName"].ToString());
                        }
                        else if (cmd.Label == CommandEnum.Get_Category)
                        {
                            ligne.Add(rd["Id"].ToString());
                            ligne.Add(rd["Name"].ToString());
                        }
                        else if (cmd.Label == CommandEnum.Get_Cart)
                        {
                            ligne.Add(rd["PanierNumero"].ToString());
                            ligne.Add(rd["NomProduit"].ToString());
                            ligne.Add(rd["Prix"].ToString());
                            ligne.Add(rd["Quantite"].ToString());
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
