using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    interface IEntity
    {
        //Point WindowLocation { get; }
        PointF RealLocation { get; }

        BitArray FirstGene { get; }
        BitArray SecondGene { get; }
        BitArray Chromosome { get; }

        float F1 { get; }

        float F2 { get; }

        float FGeneralized { get; }

        bool IsValid(SearchArea searchAreaSize);
    }
}
