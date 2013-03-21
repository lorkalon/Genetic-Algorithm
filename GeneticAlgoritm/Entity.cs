using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class Entity : IEntity
    {
        public Entity(PointF realLocation)
        {
            RealLocation = realLocation;
        }

        public System.Drawing.Point WindowLocation
        {
            get;
            set;
        }

        public System.Drawing.PointF RealLocation
        {
            get;
            set;
        }
    }
}
