using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    interface ISelection
    {
        List<IEntity> SelectEntities(List<IEntity> candidates, Func<IEntity, double> comparsionDelegate);
    }
}
