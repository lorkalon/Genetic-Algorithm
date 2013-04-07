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

        public List<IEntity> SelectEntities(List<IEntity> candidates, Func<IEntity, double> comparsionDelegate)
        {
            List<IEntity> selectedEntities = new List<IEntity>();

            Random random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < entitiesCount; i++)
            {
                double sum = candidates.Sum(comparsionDelegate);
                double selectedValue = sum * Convert.ToSingle(random.NextDouble());
                double cursor = 0;
                int j = 0;
                while (cursor < sum)
                {
                    cursor += comparsionDelegate(candidates[j]);
                    if (cursor >= selectedValue)
                    {
                        selectedEntities.Add(candidates[j]);
                        candidates.Remove(candidates[j]);
                        break;
                    }
                    j += 1;
                }
            }
            return selectedEntities;
        }
    }
}
