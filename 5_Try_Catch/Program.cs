using System;

// Début du bloc try où nous plaçons le code qui génère les exceptions
try
{
    // Affiche un message demandant à l'utilisateur d'entrer un nombre entier
    Console.WriteLine("Entrez un nombre entier: ");

    //Lit ce que l'utilisateur entre
    string userInput = Console.ReadLine();

    // Convertir ce que l'utilisateur à taper en entier
    int nombre = int.Parse(userInput);

    // Calcule le carré du nombre et l'affiche
    Console.WriteLine("Le carré de votre nombre est: " + (nombre * nombre));
}
// Ce bloc catch capture les exceptions de type FormatException
// qui se produisent si l'entrée de l'utilisateur n'est pas un nombre entier valide
catch (FormatException ex)
{
    // Affiche un message d'erreur spécifique pour les FormatException
    Console.WriteLine("Erreur: Veuillez entrer un nombre entier valide.");

    // Affiche les détails de l'exception
    Console.WriteLine("Détails de l'exception: " + ex.Message);
}
// Ce bloc catch capture les exceptions de type OverflowException
// qui se produisent si l'utilisateur tape un nombre trop grand ou trop petit
catch (OverflowException ex)
{
    // Affiche un message d'erreur spécifique pour les OverflowException
    Console.WriteLine("Erreur: Le nombre entré est trop grand ou trop petit.");

    // Affiche les détails de l'exception
    Console.WriteLine("Détails de l'exception: " + ex.Message);
}
// Ce bloc catch capture toutes les autres exceptions qui ne sont pas spécifiées par les précédents blocs catch
catch (Exception ex)
{
    // Affiche un message d'erreur générique pour toutes les autres exceptions
    Console.WriteLine("Une erreur inattendue s'est produite.");

    // Affiche les détails de l'exception (facultatif)
    Console.WriteLine("Détails de l'exception: " + ex.Message);
}
// Le bloc finally contient du code qui sera exécuté qu'une exception soit levée ou non
finally
{
    // Affiche un message indiquant que le bloc finally est exécuté
    // Utile pour libérer des ressources ou exécuter des actions de nettoyage
    Console.WriteLine("Bloc finally exécuté. Merci d'avoir utilisé le programme.");
}
