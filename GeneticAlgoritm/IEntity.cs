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
    }
}
