using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExercise
{
    public class Algae : Food
    {
        public int OmegaOilCount { get; set; }
        public Algae(int proteinCount, int fatCount, int omegaOilCount) : base(proteinCount, fatCount) {
            OmegaOilCount = omegaOilCount;
        }

        public override string ToString()
        {
            return $"Protein count: {ProteinCount}, Fat count: {FatCount}, Omega Oil count: {OmegaOilCount}";
        }
    }
}
