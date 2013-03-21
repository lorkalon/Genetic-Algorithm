using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class TriangleGrid:IGrid
    {
        private int entitiesCount;

        public TriangleGrid(int entitiesCount)
        {
            this.entitiesCount = entitiesCount;
        }

        //public List<IEntity> GetEntities { get; private set; }

        public IEnumerable<IEntity> GenerateGrid()
        {
            throw new NotImplementedException();
        }
    }
}
