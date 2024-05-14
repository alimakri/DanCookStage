
namespace DanCook.Commun
{
    public class CommandLine
    {
        public string Command;

        public bool Exists()
        {
            var s = Command.Replace("-", "_");
            return Enum.TryParse(s, out CommandsEnum _);
        }

        //public static List<string> Commands = new List<string>();
        public static void Init()
        {
            //Commands.Add("Get-Product");
            //Commands.Add("Get-Category");
            //Commands.Add("Get-Cart");
        }
    }
    public enum CommandsEnum
    {
        Get_Product,Get_Category, Get_Cart
    }
}
