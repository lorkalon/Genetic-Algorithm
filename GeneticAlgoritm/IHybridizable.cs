using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    interface IHybridizable
    {
        IEnumerable<IEntity> Hybridize(IEntity mom, IEntity dad);
    }
}
