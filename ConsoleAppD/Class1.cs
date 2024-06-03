using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppD
{
    internal class Compteur
    {
        public int Min = 1; 
        public int Max = 100;
        public ConsoleColor Couleur = ConsoleColor.Green;
        public int Pause;
        public void Compter()
        {
            for (int i = Min; i <= Max; i++)
            {
                Console.ForegroundColor = Couleur;
                Console.WriteLine(i);
                Thread.Sleep(Pause);
            }
        }
    }

    public delegate void CompteurDelegue();
}
