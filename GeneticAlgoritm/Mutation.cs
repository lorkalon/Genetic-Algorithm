﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class Mutation:IMutation
    {
        private int mutationPercent = 0;
        private SearchArea searchAreaSize;

        public Mutation(SearchArea searchAreaSize, int mutationPercent)
        {
            this.searchAreaSize = searchAreaSize;
            this.mutationPercent = mutationPercent;
        }

        public IEntity Mutate(IEntity entity)
        {
            IEntity tempEntity;
            Random random = new Random(DateTime.Now.Millisecond);
            do
            {
                BitArray firstGeneArray = new BitArray(entity.FirstGene);
                BitArray secondGeneArray = new BitArray(entity.SecondGene);

                tempEntity = new Entity(new PointF(GetMutateGene(firstGeneArray, random), GetMutateGene(secondGeneArray, random)));
            } while (tempEntity.IsValid(searchAreaSize) != true);
 
            var res = entity.Equals(tempEntity) ? null : tempEntity;
            return res;
        }

        private float GetMutateGene(BitArray geneArray, Random random)
        {
            for (int i = 0; i < geneArray.Count; i++)
            {
                if (AllowMutation(random))
                {
                    geneArray.Set(i, !geneArray[i]);
                }
            }

            byte[] bytes = new byte[(int)geneArray.Count / 8];
            geneArray.CopyTo(bytes, 0);
            return BitConverter.ToSingle(bytes, 0);
        }

        private bool AllowMutation(Random random)
        {
            int possibility = random.Next(0, 100);

            return (possibility < mutationPercent);
        }
    }
}
