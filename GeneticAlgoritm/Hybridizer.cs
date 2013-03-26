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

        private SearchArea searchAreaSize;

        public Hybridizer(SearchArea searchAreaSize, IEnumerable<int> hybridizePoints)
        {
            List<int> sortedHybridizePoints = hybridizePoints.ToList();
            sortedHybridizePoints.Sort();
            this.hybridizePoints = sortedHybridizePoints;
            this.searchAreaSize = searchAreaSize;
        }

        public List<IEntity> Hybridize(IEntity mom, IEntity dad)
        {
            BitArray momChromosome = new BitArray(mom.Chromosome);
            BitArray dadChromosome = new BitArray(dad.Chromosome);

            momChromosome = new BitArray(new bool[] { true, true, false, false, true, true, false, false, true, true, false, false, true, true, false, false, true, true, true, false, false, true, true, false, false, true, true, false, false, true, true, false, false, true, true, true, false, false, true, true, false, false, true, true, false, false, true, true, false, false, true, true });//test
            dadChromosome = new BitArray(new bool[] { true, true, false, false, true, true, false, false, true, true, false, false, true, true, false, false, true, true, true, false, false, true, true, false, false, true, true, false, false, true, true, false, false, true, false, false, true, true, false, false, false, false, true, true, false, false, true, true, false, false, true, true });//test

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
                    bool temp = momChromosome[i];
                    momChromosome.Set(i, dadChromosome[i]);
                    dadChromosome.Set(i, temp);
                }
            }

            return GetValidChilds(momChromosome, dadChromosome);
        }

        private bool Invert(bool value)
        {
            return (value == false);
        }

        private List<IEntity> GetValidChilds(BitArray momChromosome, BitArray dadChromosome)
        {
            PointF momGenes = GetGenes(momChromosome);
            PointF dadGenes = GetGenes(dadChromosome);

            List<IEntity> validChilds = new List<IEntity>();
            IEntity firstChild = new Entity(momGenes);
            IEntity secondChild = new Entity(dadGenes);
            if (firstChild.IsValid(searchAreaSize))
            {
                validChilds.Add(firstChild);
            }
            if (secondChild.IsValid(searchAreaSize))
            {
                validChilds.Add(secondChild);
            }
            return validChilds;
        }

        private PointF GetGenes(BitArray chromosome)
        {
            BitArray firstGene = new BitArray(chromosome.Count / 2);
            for (int i = 0; i < chromosome.Count/2; i++)
            {
                firstGene.Set(i, chromosome[i]);
            }
            BitArray secondGene = new BitArray(chromosome.Count / 2);
            for (int i = 0; i < chromosome.Count / 2; i++)
            {
                secondGene.Set(i, chromosome[i + chromosome.Count / 2]);
            }
            byte[] firstGeneArray = new byte[(int)Math.Ceiling((double)firstGene.Count / 8)];
            byte[] secondGeneArray = new byte[(int)Math.Ceiling((double)secondGene.Count / 8)];
            firstGene.CopyTo(firstGeneArray, 0);
            secondGene.CopyTo(secondGeneArray, 0);

            float firstGeneValue = BitConverter.ToSingle(firstGeneArray, 0);
            float secondGeneValue = BitConverter.ToSingle(secondGeneArray, 0);

            return new PointF(firstGeneValue, secondGeneValue);
        }
    }
}
