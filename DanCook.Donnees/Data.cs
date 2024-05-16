using DanCook.Commun;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DanCook.Donnees
{
    public static class Data
    {
        public static int Execute(CommandLine cmd)
        {
            switch (cmd.Label)
            {
                case CommandEnum.Get_Product:
                    var cnx = new SqlConnection();
                    cnx.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=True;Encrypt=False";
                    cnx.Open();
                    var sqlCmd = new SqlCommand();
                    sqlCmd.Connection = cnx;
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = "select ProductID, Name, ListPrice from Production.Product";
                    SqlDataReader rd = sqlCmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Console.WriteLine($"{rd.GetInt32("ProductID")}: {rd.GetString("Name")}\t{rd.GetDecimal("ListPrice")}");
                    }
                    rd.Close();
                    return 0;
            }
            return 0;
        }
    }
}
