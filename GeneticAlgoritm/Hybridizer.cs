﻿using System;
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

        public IEnumerable<IEntity> Hybridize(IEntity mom, IEntity dad)
        {
            mom.Chromosome=new List<byte>() { 1, 1, 0, 0, 1, 1 };//test
            dad.Chromosome=new List<byte>() { 0, 0, 1, 1, 0, 0 };//test

            IEntity firstChild = mom;
            IEntity secondChild = dad;

            bool swap = false;
            int j = 0;
            int chromosomeCount = mom.Chromosome.Count();
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
                    byte temp = firstChild.Chromosome[i];
                    firstChild.Chromosome[i] = secondChild.Chromosome[i];
                    secondChild.Chromosome[i] = temp;
                }
            }
            List<IEntity> children = new List<IEntity>();
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