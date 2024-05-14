using DanCook.Commun;
using DanCook.Metier;

Console.Write("Dancook> ");
string saisie = Console.ReadLine();
Console.WriteLine("Vous avez tapé {0}", saisie);

var cmd1 = new CommandLine();
cmd1.Command = saisie;
Moteur.Execute(cmd1);
Console.ReadLine();