using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercise
{
    public abstract class Animal
    {
        public void Sleep()
        {
            Console.WriteLine("Zzz");
        }
        public void Drink() 
        { 
            Console.WriteLine("Sluurp");
        }
    }
}
