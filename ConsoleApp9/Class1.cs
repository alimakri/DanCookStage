using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public interface IVehicule
    {
        void Rouler();
        void Arreter() { }
    }

    public class Auto : IHabitation,  IVehicule
    {
        public void Rouler() { Console.WriteLine("L'auto roule"); }
        public void habiter () { Console.WriteLine("J'habite dans l'auto"); }
    }

    public class Moto : IVehicule
    {
        public void Rouler() { Console.WriteLine("La moto roule"); }
    }
    public interface IHabitation
    {
        void habiter();
    }
}
