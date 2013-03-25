using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class Hybridizer : IHybridizable
    {
        private IEnumerable<int> hybridizePoints;

        public Hybridizer(IEnumerable<int> hybridizePoints)
        {
            List<int> sortedHybridizePoints = hybridizePoints.ToList();
            sortedHybridizePoints.Sort();
            this.hybridizePoints = sortedHybridizePoints;
        }

        public IEnumerable<IEntity> Hybridize(IEntity mom, IEntity dad)//add checking in borders
        {
            mom.Chromosome = new BitArray (new int[]{ 1, 1, 0, 0, 1, 1 });//test
            dad.Chromosome = new BitArray(new int[] { 0, 0, 1, 1, 0, 0 });//test

            IEntity firstChild = mom;
            IEntity secondChild = dad;

            bool swap = false;
            int j = 0;
            int chromosomeCount = mom.Chromosome.Length;
            for (int i = 0; i < chromosomeCount; i++)
            {
                if (j < hybridizePoints.Count())
                {
                    if (i == hybridizePoints.ElementAt(j))
                    {
                        swap = Invert(swap);
                        j += 1;
                    }
                }
                if (swap)
                {
                    bool temp = firstChild.Chromosome[i];
                    firstChild.Chromosome[i] = secondChild.Chromosome[i];
                    secondChild.Chromosome[i] = temp;
                }
            }
            List<IEntity> children = new List<IEntity>();
            //if(firstChild
            children.Add(firstChild);
            children.Add(secondChild);
            return children;
        }

        private bool Invert(bool value)
        {
            return (value == false);
        }
    }
}
