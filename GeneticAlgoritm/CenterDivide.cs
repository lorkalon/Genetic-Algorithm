using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class CenterDivide:IDividable
    {
        public CenterDivide()
        {
            
        }

        public List<IEnumerable<IEntity>> DivideEntities(IEnumerable<IEntity> entities)
        {
            List<IEntity> firstHalf = new List<IEntity>();
            List<IEntity> secondHalf = new List<IEntity>();

            firstHalf.AddRange(entities.Take(entities.Count()/2));
            for (int i = entities.Count()/2; i < entities.Count(); i++)
            {
                secondHalf.Add(entities.ToList()[i]);
            }

            List<IEnumerable<IEntity>> halfs = new List<IEnumerable<IEntity>>();
            halfs.Add(firstHalf);
            halfs.Add(secondHalf);

            return halfs;
        }
    }
}
