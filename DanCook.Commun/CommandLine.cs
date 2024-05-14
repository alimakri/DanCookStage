namespace DanCook.Commun
{
    public class CommandLine
    {
        public string Command; 
        public static List<string> Commands = new List<string>();
        public static void Init()
        {
            Commands.Add("Get-Product");
            Commands.Add("Get-Category");
            Commands.Add("Get-Cart");
        }
    }
}
