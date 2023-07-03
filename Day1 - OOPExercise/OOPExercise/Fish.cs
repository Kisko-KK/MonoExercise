using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercise
{
    public class Fish : Animal
    {
        public bool IsSaltWater { get; private set; }
        public Fish(bool isSaltWater) { 
            IsSaltWater = isSaltWater;
        }

        public void Eat(Algae algae)
        {
            Console.WriteLine(algae.OmegaOilCount);
            //Console.WriteLine(algae.FatCount);                                //ne može se pristupiti fatCount-u jer je protected tipa  
            Console.WriteLine(algae);                                           // možemo ispisati sastav algi jer je ToString public a unutar njega koristimo
                                                                                // protected clanove kojima je moguće pristupiti iz izvedene klase
        }

        public void Eat(Algae algae, int numOfAlgae)
        {
            Console.WriteLine(algae.OmegaOilCount);
            Console.WriteLine($"I ate {numOfAlgae} of these algae:");
            Console.WriteLine(algae);
        }

        public override string ToString()
        {
            return "I'm a fish";
        }

    }
}
