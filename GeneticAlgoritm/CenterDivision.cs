﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class CenterDivision:IDividable
    {
        public CenterDivision()
        {
            
        }

        public List<List<IEntity>> DivideEntities(List<IEntity> entities)
        {
            List<IEntity> firstHalf = new List<IEntity>();
            List<IEntity> secondHalf = new List<IEntity>();

            int entitiesFirstHalfCount = entities.Count() / 2;
            int entitiesSecondHalfCount = entities.Count() - entitiesFirstHalfCount;
            firstHalf.AddRange(entities.Take(entitiesFirstHalfCount));
            secondHalf.AddRange(entities.GetRange(entitiesFirstHalfCount, entitiesSecondHalfCount));

            List<List<IEntity>> halfs = new List<List<IEntity>>();
            halfs.Add(firstHalf);
            halfs.Add(secondHalf);

            return halfs;
        }
    }
}
