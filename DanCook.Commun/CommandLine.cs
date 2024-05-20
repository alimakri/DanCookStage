namespace DanCook.Commun
{
    // Classe représentant une ligne de commande
    public class CommandLine
    {
        private string Input;
        public CommandEnum Label = CommandEnum.None;
        public List<List<string>> Result = new List<List<string>>(); // Propriété pour stocker les résumtats de la commande requête SQL

        // Constructeur qui initialise la commande en fonction de ce que l'utilisateur saisie
        public CommandLine(string saisie)
        {
            var s = saisie.Replace("-", "_");
            Enum.TryParse(s, out Label);
        }
    }

    // Enumération des commandes
    public enum CommandEnum
    {
        None, Get_Product, Get_Category, Get_Cart, Get_Product_By_Category
    }
}
