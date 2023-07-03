using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercise
{
    public class Chicken : Animal, ISoundable
    {
        public Chicken() { }
        public override string ToString()
        {
            return "I'm a chicken!";
        }

        public void MakeNoise()
        {
            Console.WriteLine("Buck buck buck");
        }
    }
}
