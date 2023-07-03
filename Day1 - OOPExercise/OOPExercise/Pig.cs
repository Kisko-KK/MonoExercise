using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace OOPExercise
{
    public class Pig : Animal, ISoundable
    {
        public Pig() { }

        public override string ToString()
        {
            return "I'm a pig!";
        }

        public void MakeNoise()
        {
            Console.WriteLine("Oink Oink");
        }
    }
}
