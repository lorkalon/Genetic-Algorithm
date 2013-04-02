using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class EvenDivide:IDividable
    {
        public List<List<IEntity>> DivideEntities(List<IEntity> entities)
        {
            List<List<IEntity>> groups = new List<List<IEntity>>();
            List<IEntity> firstGroup = new List<IEntity>();
            List<IEntity> secondGroup = new List<IEntity>();

            for (int i = 0; i < entities.Count; i++)
            {
                if (i%2 == 0)
                {
                    firstGroup.Add(entities[i]);
                }
                else
                {
                    secondGroup.Add(entities[i]);
                }
            }
            
            groups.Add(firstGroup);
            groups.Add(secondGroup);

            return groups;
        }
    }
}
