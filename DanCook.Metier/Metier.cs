using DanCook.Commun;
using DanCook.Donnees;

namespace DanCook.Metier
{
    public static class Moteur
    {
        public static int Execute(CommandLine cmd)
        {
            if (cmd.Label == CommandEnum.None) return -1;
            if(cmd.Label == CommandEnum.Get_Product)
            {
                return Data.Execute(cmd);
            }
            return 0;
        }
    }
}
