using DanCook.Commun;

namespace DanCook.Donnees
{
    public static class Data
    {
        public static void Execute(CommandLine cmd)
        {
            Console.WriteLine("Exécution de la commande (Données) {0}", cmd.Command);
        }
    }
}
