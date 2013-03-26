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


        float GetF1(float x, float y);

        float GetF2(float x, float y);

        float GetFGeneralized(float x, float y);


        bool IsValid(SearchArea searchAreaSize);
    }
}
