using DanCook.Commun;
using DanCook.Metier;

Console.Write("Dancook> ");
string saisie = Console.ReadLine();
Console.WriteLine("Vous avez tapé {0}", saisie);

CommandLine.Command = saisie;
Moteur.Execute();
Console.ReadLine();