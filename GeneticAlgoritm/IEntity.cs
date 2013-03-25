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
        Point WindowLocation { get; set; }

        PointF RealLocation { get; set; }

        BitArray FirstGene { get; }
        BitArray SecondGene { get; }

        BitArray Chromosome { get; set; }

        float F1 { set; get; }

        float F2 { set; get; }

        float FGeneralized { set; get; }

        bool IsValid(SearchArea searchAreaSize);
    }
}
