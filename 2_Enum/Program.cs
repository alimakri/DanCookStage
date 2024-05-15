using _2_Enum;

//Dire à l'utilisateur de choisir un jour de la semaine
Console.WriteLine("Entrez un jour de la semaine: 1 pour Lundi, 2-Mardi, 3-Mercredi, 4-Jeudi, 5-Vendredi, 6-Samedi et 7-Dimanche");
int saisie = int.Parse(Console.ReadLine());

//Convertir la saisie en enum
JourDeLaSemaine jour = (JourDeLaSemaine)saisie;

Console.WriteLine("Le jour que vous avez saisi est " + jour);

if(jour ==JourDeLaSemaine.Samedi || jour == JourDeLaSemaine.Dimanche)
{
    Console.WriteLine("C'est le week-end");
}
else
{
    Console.WriteLine("C'est pas le week-end");
}