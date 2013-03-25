using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class Roulette:ISelection
    {
        public IEnumerable<IEntity> GetBestEntities(IEnumerable<IEntity> group)
        {
            return group.Take(2);
        }
    }
}
