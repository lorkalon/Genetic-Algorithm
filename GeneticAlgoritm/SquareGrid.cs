using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class SquareGrid:IGrid
    {
        private int entitiesCount;

        public SquareGrid(int entitiesCount)
        {
            this.entitiesCount = entitiesCount;
        }

        public List<IEntity> GetEntities { get; private set; }
       
        public void GenericGrid()
        {
            throw new NotImplementedException();
        }
    }
}
