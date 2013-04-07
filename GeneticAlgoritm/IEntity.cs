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
        PointF RealLocation { get; }

        BitArray FirstGene { get; }

        BitArray SecondGene { get; }

        BitArray Chromosome { get; }

        double F1 { get; }

        double F2 { get; }

        double FGeneralized { get; }

        bool IsValid(SearchArea searchAreaSize);
    }
}
