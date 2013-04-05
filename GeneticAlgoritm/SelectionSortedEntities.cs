using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace GeneticAlgoritm
{
    class SelectionSortedEntities:ISelection
    {
        private int entitiesCount;

        public SelectionSortedEntities(int entitiesCount)
        {
            this.entitiesCount = entitiesCount;
        }

        public List<IEntity> SelectEntities(List<IEntity> candidates, Func<IEntity, float> comparsionDelegate)
        {
            List<IEntity> bestEntities = new List<IEntity>();

            while (candidates.Count > 0 && bestEntities.Count < entitiesCount)
            {
                IEntity bestEntity = candidates.MaxBy(comparsionDelegate);
                bestEntities.Add(bestEntity);    
                candidates.Remove(bestEntity);
            }

            return bestEntities;
        }
    }
}
