using DanCook.Commun;
using DanCook.Metier;

bool fin = false;
while (!fin)
{
    Console.Write("Dancook> ");
    string saisie = Console.ReadLine();

    if (saisie.ToLower() == "exit")
    {
        fin = true;
    }
    else
    {
        Console.WriteLine("Vous avez tapé {0}", saisie);

        var cmd1 = new CommandLine(saisie);
        var result = Moteur.Execute(cmd1);
        switch (result)
        {
            case -1:
                Console.WriteLine("Cette commande n'existe pas");
                break;
            case 0:
                Console.WriteLine("Exécution de la commande {0}", cmd1.Label); break;
        }
    }
    Console.ReadLine();
}