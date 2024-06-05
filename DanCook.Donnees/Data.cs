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
            cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=True;Encrypt=False";
            cnx.Open();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = cnx;
            sqlCmd.CommandType = CommandType.Text;

            // Choisis l'action en fonction de la commande 
            switch (cmd.Label)
            {
                case CommandEnum.Get_Product:

                    sqlCmd.CommandText = @"select 
	                                            p.ProductID, 
	                                            p.Name, 
	                                            p.ListPrice, 
	                                            p.ProductSubcategoryID, 
	                                            sc.Name souscat,
	                                            sc.ProductCategoryID,
	                                            c.Name cat
                                            from Production.Product p
                                            inner join Production.ProductSubcategory sc on p.ProductSubcategoryID = sc.ProductSubcategoryID
                                            inner join Production.ProductCategory c on sc.ProductCategoryID = c.ProductCategoryID";

                    if (cmd.Parameters.ContainsKey("Category"))
                    {
                        sqlCmd.CommandText += $" where c.ProductCategoryID = {cmd.Parameters["Category"]}";
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
                                                c.ProductCategoryID,
                                                c.Name 
                                              From Production.ProductCategory c";

                    // Ajoute un ordre de tri 
                    if (cmd.Parameters.ContainsKey("OrderBy"))
                    {
                        sqlCmd.CommandText += $" order by c.{cmd.Parameters["OrderBy"]}";
                    }
                    lecture = true;

                    break;

                case CommandEnum.Add_Cart:
                    // La commande SQL pour ajouter un produit au panier
                    sqlCmd.CommandText = $@"Insert into Cart (CartID, ProductID, Quantity)
                                           values ({cmd.Parameters["Id"]}, {cmd.Parameters["Product"]}, {cmd.Parameters["Quantity"]})";

                    lecture = false;
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
                            ligne.Add(rd["ProductID"].ToString());
                            ligne.Add(rd["Name"].ToString());
                            ligne.Add(rd["ListPrice"].ToString());
                        }
                        else if (cmd.Label == CommandEnum.Get_Category)
                        {
                            ligne.Add(rd["ProductCategoryID"].ToString());
                            ligne.Add(rd["Name"].ToString());
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
