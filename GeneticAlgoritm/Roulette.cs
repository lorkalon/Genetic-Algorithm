using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class Roulette : ISelection
    {
        private int entitiesCount;

        public Roulette(int entitiesCount)
        {
            this.entitiesCount = entitiesCount;
        }

        public IEnumerable<IEntity> SelectEntities(IEnumerable<IEntity> candidates)
        {

        }
    }
}
