using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _3_Demo_Type_Valeur
{
    public struct Voiture
    {
        public string Marque;
        public string Modele;

        public Voiture(string marque, string modele)
        {
            Marque = marque;
            Modele = modele;
        }

        public void AfficherDetails()
        {
            Console.WriteLine($"Marque: {Marque}, Modèle: {Modele}");
        }
    }
}
