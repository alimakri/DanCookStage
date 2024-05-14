using DanCook.Commun;
using DanCook.Metier;

CommandLine.Init();
Console.Write("Dancook> "); 
string saisie = Console.ReadLine();

Console.WriteLine("Vous avez tapé {0}", saisie);

var cmd1 = new CommandLine();
cmd1.Command = saisie;
var result = Moteur.Execute(cmd1);
switch (result)
{
    case -1: Console.WriteLine("Cette commande n'existe pas");
        break;
}
Console.ReadLine();