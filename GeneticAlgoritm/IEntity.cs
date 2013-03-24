using System;
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

        IEnumerable<byte> FirstGene { get; }
        IEnumerable<byte> SecondGene { get; }
        IEnumerable<byte> Chromosome { get; }
        //float delegate FirstCriteria(float x,float y);
        float F1 { set; get; }
        float F2 { set; get; }
        float FGeneralized { set; get; }
    }
}
