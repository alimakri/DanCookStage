using DanCook.Commun;
using DanCook.Metier;

bool fin = false;
while (!fin)
{
    // Demande à l'utilisateur de saisir une commande
    Console.Write("Dancook> ");
    string saisie = Console.ReadLine();

    // Si l'utilisateur tape "exit", fini la boucle
    if (saisie.ToLower() == "exit")
    {
        fin = true;
    }
    else
    {
        // Affiche la commande saisie par l'utilisateur
        Console.WriteLine("Vous avez tapé {0}", saisie);

        // Crée une nouvelle instance de CommandLine avec la saisie de l'utilisateur
        var cmd1 = new CommandLine(saisie);

        // Exécute la commande
        var result = Moteur.Execute(cmd1);
        switch (result)
        {
            case -1:
                // Affiche un message si la commande n'existe pas
                Console.WriteLine("Cette commande n'existe pas");
                break;
            case 0:
                // Affiche un message et les résultats de la commande
                Console.WriteLine("Exécution de la commande {0}", cmd1.Label);
                foreach (var ligne in cmd1.Result)
                {
                    // Affiche chaque ligne de résultats
                    Console.WriteLine(string.Join("\t", ligne));
                }
                break;
        }
    }
    // Attendre ce que l'utilisateur saisi avant de continuer
    Console.ReadLine();
}