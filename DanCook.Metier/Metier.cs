using DanCook.Commun;
using DanCook.Donnees;

namespace DanCook.Metier
{
    // Classe statique pour exécuter les commandes métier
    public static class Moteur
    {
        // Méthode pour exécuter la commande
        public static int Execute(CommandLine cmd)
        {
            // Vérifie si la commande est None
            if (cmd.Label == CommandEnum.None) return -1;

            // Exécute la commande Get_Product
            if (cmd.Label == CommandEnum.Get_Product)
            {
                return Data.Execute(cmd);
            }
            return 0;
        }
    }
}
