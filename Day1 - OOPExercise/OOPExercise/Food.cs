using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercise
{
    public class Food
    {
        public Food(int proteinCount, int fatCount) {
            ProteinCount = proteinCount;
            FatCount = fatCount;
        }

        protected int ProteinCount { get; set; }
        protected int FatCount { get; set; }
    }
}
