using DanCook.Commun;
using DanCook.Donnees;

namespace DanCook.Metier
{
    public static class Moteur
    {
        public static int Execute(CommandLine cmd)
        {
            if (!cmd.Exists())
                return -1;
            if(cmd.Command == "Get-Product")
            {
                Data.Execute(cmd);
            }
            else 
            {
                Console.WriteLine("Exécution de la commande (Métier) {0}", cmd.Command);
            }
            return 0;
        }
    }
}
