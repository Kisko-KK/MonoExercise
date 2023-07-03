using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercise
{
    public class Horse : Animal, ISoundable
    {
        public string Name { get; set; }
        public Horse() { 
            Name = string.Empty;
        }
        public Horse(string name) {                         //primjer polimorfizma
            Name = name;
        }

        public override string ToString()
        {
            return "I'm a horse!";
        }

        public void MakeNoise()
        {
            Console.WriteLine("Neeeeigh");
        }
    }
}
