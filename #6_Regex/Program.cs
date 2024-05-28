using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


class program
{
    static void Main()
    {

        //Dictionnaire pour stocker les varibles et leurs valeurs
        Dictionary<string, int> variables = new Dictionary<string, int>();

        //Faire un Regex pour capturer les assignations des variables
        Regex assigneRegex = new Regex(@"(\w+)\s*=\s*(.*)");

        //Faire un Regex pour capturer les expressions avec les opérations
        Regex expressionRegex = new Regex(@"(\w+)\s*([\+\-\*\/])\s*(\w+)");

        Console.WriteLine("Entrez vos expresssions(tapez exit pour sortir)");

        while (true)
        {
            //Lire ce que l'utilisateur entre
            string input = Console.ReadLine();

            //Vérifier si l'utilisateur souhaite quitter
            if (input.ToLower() == "exit")
            {
                break;
            }

            // Essayer de trouver une assignation dans l'entrée
            Match assigneMatch = assigneRegex.Match(input);
            if (assigneMatch.Success)
            {
                //Extraire le nom de la variable d"expression
                string varNom = assigneMatch.Groups[1].Value;
                string expression = assigneMatch.Groups[2].Value;

                try
                {
                    //Evaluer l'expression et obtenir la valeur 
                    int value = EvaluateExpression(expression, variables, expressionRegex);

                    // Stocker la valeur dans le dictionnaire des variables
                    variables[varNom] = value;

                    // Afficher le résultat de l'assignation
                    Console.WriteLine($"{varNom} = {value}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur : {ex.Message}");
                }

            }
            else if (variables.ContainsKey(input))
            {
                //Si l'ntrée est simplement un nom de variable, afficher sa valeur
                Console.WriteLine("Entrée invalide ou variable non trouvée");
            }
        }
    }

    // Méthode pour évaluer une expression et retourner sa valeur
    static int EvaluateExpression(string expression, Dictionary<string, int> variables, Regex expressionRegex)
    {
        // Si l'expression est un nombre entier, le retourner directement
        if (int.TryParse(expression, out int nombre))
        {
            return nombre;
        }

        //Essayer de trouver une expression composée avec une opération
        Match expressionMatch = expressionRegex.Match(expression);
        if (expressionMatch.Success)
        {
            // Extraire les opérandes et l'opération
            string leftOperand = expressionMatch.Groups[1].Value;
            string operation = expressionMatch.Groups[2].Value;
            string rightOperand = expressionMatch.Groups[3].Value;

            //Obtenir la valeur des opérandes (soit des variables, soit des nombres)
            int leftValue = variables.ContainsKey(leftOperand) ? variables[leftOperand] : int.Parse(leftOperand);
            int rightValue = variables.ContainsKey(rightOperand) ? variables[rightOperand] : int.Parse(rightOperand);

            //Appliquer l'opération et afficher le résultat
            return operation switch
            {
                "+" => leftValue + rightValue,
                "-" => leftValue - rightValue,
                "*" => leftValue * rightValue,
                "/" => leftValue / rightValue,
                _ => throw new InvalidOperationException("Opération invalide"),
            };
        }

        //Si l'expression est invalide, On lève une exception 
        throw new ArgumentException("Expression invalide");
    }
}
