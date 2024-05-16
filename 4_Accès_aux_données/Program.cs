using System;
using System.Data;
using Microsoft.Data.SqlClient;

string chaineDeConnexion = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=True;Encrypt=False";
string requete = "select ProductID, Name, ListPrice from Production.Product";


using (SqlConnection connexion = new SqlConnection(chaineDeConnexion))
{
    connexion.Open();
    Console.WriteLine("Connexion ouverte avec succès.");

    using (SqlCommand commande = new SqlCommand(requete, connexion))
    {
        using (SqlDataReader lecteur = commande.ExecuteReader())
        {
            //Une boucle pour lire
            while (lecteur.Read())
            {
                // Supposons que la table a une colonne 'Id', une colonne 'Nom' et une colonne 'Prix'
                int id = lecteur.GetInt32("ProductID");
                string nom = lecteur.GetString("Name");
                decimal prix = lecteur.GetDecimal("ListPrice");

                //Affichage
                Console.WriteLine($"ID: {id}, Nom: {nom}, Prix: {prix}");
            }
        }
    }
}
