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
                    sqlCmd.CommandText = "select ProductID, Name, ListPrice from Production.Product";
                    break;
                case CommandEnum.Get_Product_By_Category:
                    sqlCmd.CommandText = "select ProductID, Name, ListPrice from Production.Product where ProductCategoryID = 1";
                    break;
                default:
                    return -1;
            }

            // Exécute la commande et lit les résultats
            SqlDataReader rd = sqlCmd.ExecuteReader();

            while (rd.Read())
            {
                // Création d'une nouvelle ligne de résultats
                var ligne = new List<string>
                {
                    rd["ProductID"].ToString(),
                    rd["Name"].ToString(),
                    rd["ListPrice"].ToString()
                };
                // Ajoute la ligne aux résultats de la commande
                cmd.Result.Add(ligne);
            }

            // Ferme le DataReader
            rd.Close();
            cnx.Close();
            return 0;
        }
    }
}
