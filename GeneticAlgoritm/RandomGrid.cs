using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class RandomGrid:IGrid
    {
        private int entitiesCount;

        public RandomGrid(int entitiesCount)
        {
            this.entitiesCount = entitiesCount;
        }

        //public IEnumerable<IEntity> GetEntities { get; private set; }

        public IEnumerable<IEntity> GenerateGrid()
        {
            throw new NotImplementedException();
        }
    }
}
