
namespace DanCook.Commun
{
    public class CommandLine
    {
        private string Input;
        public CommandEnum Label = CommandEnum.None;

        public CommandLine(string saisie)
        {
            var s = saisie.Replace("-", "_");
            Enum.TryParse(s, out Label);
        }
    }
    public enum CommandEnum
    {
        None, Get_Product, Get_Category, Get_Cart
    }
}
