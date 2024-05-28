namespace DanCook.Commun
{
    // Classe représentant une ligne de commande
    public class CommandLine
    {
        private string Input;
        public CommandEnum Label = CommandEnum.None;
        public Dictionary<string, string> Parameters = new Dictionary<string, string>(); // Propriété pour stocker les paramètres
        public List<List<string>> Result = new List<List<string>>(); // Propriété pour stocker les résultats de la commande requête SQL

        // Constructeur qui initialise la commande en fonction de ce que l'utilisateur saisie
        public CommandLine(string saisie)
        {
            Input = saisie;
            ParseInput(saisie);
        }

        // Méthode pour analyser l'entrée de l'utilisateur
        private void ParseInput(string saisie)
        {
            // Expression régulière pour capturer la commande et ses arguments
            var regex = new System.Text.RegularExpressions.Regex(@"(?<command>\w+-\w+)(?:\s+-\s*(?<parameter>\w+)\s+""(?<value>[^""]*)"")*");
            var match = regex.Match(saisie);

            if (match.Success)
            {
                // Le premier match est la commande
                var command = match.Groups["command"].Value.Replace("-", "_");
                Enum.TryParse(command, out Label);

                // Les suivants sont les arguments
                var parameterCaptures = match.Groups["parameter"].Captures;
                var valueCaptures = match.Groups["value"].Captures;

                for (int i = 0; i < parameterCaptures.Count; i++)
                {
                    Parameters[parameterCaptures[i].Value] = valueCaptures[i].Value;
                }
            }
        }
    }

    // Enumération des commandes
    public enum CommandEnum
    {
        None, Get_Product, Get_Category, Get_Cart
    }
}
