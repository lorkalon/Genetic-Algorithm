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
            mom.Chromosome = new BitArray(new int[] { 1, 1, 0, 0, 1, 1 });//test
            dad.Chromosome = new BitArray(new int[] { 0, 0, 1, 1, 0, 0 });//test


            IEntity firstChild = mom;
            IEntity secondChild = dad;

            int[] c3 = new int[300];
            firstChild.Chromosome.CopyTo(c3, 0);
            int[] c4 = new int[300];
            secondChild.Chromosome.CopyTo(c4, 0);

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
                    bool temp = firstChild.Chromosome.Get(i);
                    bool f=secondChild.Chromosome.Get(i);
                    firstChild.Chromosome.Set(i, f);
                    bool f1 = firstChild.Chromosome.Get(i);
                    secondChild.Chromosome.Set(i, temp);
                }
            }
            List<IEntity> children = new List<IEntity>();
            //if(firstChild
            children.Add(firstChild);
            children.Add(secondChild);
            int[] c1 = new int[300];
            children[0].Chromosome.CopyTo(c1,0);
            int[] c2 = new int[300];
            children[1].Chromosome.CopyTo(c2, 0);
            return children;
        }

        private bool Invert(bool value)
        {
            return (value == false);
        }
    }
}
