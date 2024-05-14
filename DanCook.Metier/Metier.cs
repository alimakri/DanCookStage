using DanCook.Commun;
using DanCook.Donnees;

namespace DanCook.Metier
{
    public static class Moteur
    {
        public static void Execute(CommandLine cmd)
        {
            if(cmd.Command == "Get-Product")
            {
                Data.Execute(cmd);
            }
            else 
            {
                Console.WriteLine("Exécution de la commande (Métier) {0}", cmd.Command);
            }
        }
    }
}
