using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    interface IDividable
    {
        List<List<IEntity>> DivideEntities(List<IEntity> entities);
    }
}
