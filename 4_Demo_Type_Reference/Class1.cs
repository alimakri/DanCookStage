using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Type_Valeur_Reference
{
    public struct VoitureValeur
    {
        public string Marque;
        public string Modele;
        public VoitureValeur()
        {
            Marque = "Inconnue";
            Modele = "Inconnu";
        }
        public void AfficherDetails(string nom)
        {
            Console.WriteLine($"{nom} --> {Marque} - {Modele}");
        }
    }
    public class VoitureReference
    {
        public string Marque;
        public string Modele;
        public VoitureReference()
        {
            Marque = "Inconnue";
            Modele = "Inconnu";
        }
        public void AfficherDetails(string nom)
        {
            Console.WriteLine($"{nom} --> {Marque} - {Modele}");
        }
    }
    public enum Couleur { None, Rouge, Vert , Bleu}
}
