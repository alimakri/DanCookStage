using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public abstract class Vehicule
    {
        public abstract void Rouler();
        public void Arreter() { }
    }

    public class Auto: Vehicule
    {
        public override void Rouler() { Console.WriteLine("L'auto roule"); }
    }

    public class Moto : Vehicule
    {
        public override void Rouler() { Console.WriteLine("La moto roule"); }
    }
}
