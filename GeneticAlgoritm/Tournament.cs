using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;

namespace GeneticAlgoritm
{
    class Tournament : ISelection
    {
        private int entitiesCount;

        public Tournament(int entitiesCount)
        {
            this.entitiesCount = entitiesCount;
        }

        public List<IEntity> SelectEntities(List<IEntity> candidates, Func<IEntity, double> comparsionDelegate)
        {
            List<IEntity> selectedEntities = new List<IEntity>();
            List<List<IEntity>> groups = new List<List<IEntity>>();

            if (candidates.Count() > entitiesCount)
            {
                int entitiesInGroup = candidates.Count() / entitiesCount;

                for (int i = 0; i < entitiesCount - 1; i++)
                {
                    groups.Add(candidates.GetRange(0, entitiesInGroup));
                    candidates.RemoveRange(0, entitiesInGroup);
                }
                groups.Add(candidates);
            }
            else
            {
                return candidates;
            }

            foreach (var group in groups)
            {
                selectedEntities.Add(group.MaxBy(comparsionDelegate));
            }

            return selectedEntities;
        }
    }
}
