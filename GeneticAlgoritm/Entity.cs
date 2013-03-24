using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class Entity : IEntity
    {
        public Entity(PointF realLocation)
        {
            RealLocation = realLocation;
            FirstGene = BitConverter.GetBytes(RealLocation.X);
            SecondGene = BitConverter.GetBytes(RealLocation.Y);
            SetChromosome();
        }

        void SetChromosome()
        {
            List<byte> concatGene = FirstGene.ToList();
            concatGene.AddRange(SecondGene);

            Chromosome = concatGene;
        }

        public Point WindowLocation { get; set; }
        public PointF RealLocation { get; set; }
        public byte[] FirstGene { get; private set; }
        public byte[] SecondGene { get; private set; }
        public IEnumerable<byte> Chromosome { get; private set; }
    }
}
