using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    interface IHybridizable
    {
        List<IEntity> Hybridize(IEntity mom, IEntity dad);
    }
}
