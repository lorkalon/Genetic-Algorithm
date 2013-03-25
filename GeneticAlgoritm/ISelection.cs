using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    interface ISelection
    {
        IEnumerable<IEntity> SelectEntities(IEnumerable<IEntity> candidates);
    }
}
