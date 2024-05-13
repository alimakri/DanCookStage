using DanCook.Commun;
using DanCook.Donnees;

namespace DanCook.Metier
{
    public static class Moteur
    {
        public static void Execute()
        {
            if(CommandLine.Command == "Get-Product")
            {
                Data.Execute();
            }
            else 
            {
                Console.WriteLine("Exécution de la commande (Métier) {0}", CommandLine.Command);
            }
        }
    }
}
