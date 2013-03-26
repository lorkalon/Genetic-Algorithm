using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class Entity : IEntity
    {
        private delegate float firstCriteria(float x, float y);
        private delegate float secondCriteria(float x, float y);
        const float c1 = 1;
        const float c2 = 1;

        private float FirstCriteria(float x, float y)
        {
            float result = 0;

            return result;
        }

        static Entity()
        {
            //firstCriteria
        }

        public Entity(PointF realLocation)
        {
            RealLocation = realLocation;
            FirstGene = new BitArray(BitConverter.GetBytes(RealLocation.X));
            SecondGene = new BitArray(BitConverter.GetBytes(RealLocation.Y));
            SetChromosome();
        }


        void SetChromosome()
        {
            int length = FirstGene.Count + SecondGene.Count;
            Chromosome = new BitArray(length);
            
            for (int i = 0; i < FirstGene.Count; i++)
            {
                Chromosome[i] = FirstGene[i];
            }

            for (int i = FirstGene.Count, j = 0; i < length; i++)
            {
                Chromosome[i] = SecondGene[j];
            }
        }

        public Point WindowLocation { get; set; }
        public PointF RealLocation { get; set; }

        public BitArray FirstGene { get; private set; }
        public BitArray SecondGene { get; private set; }
        public BitArray Chromosome { get; set; }

        public float F1
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public float F2
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public float FGeneralized
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IsValid(SearchArea searchAreaSize)
        {
            return (RealLocation.X > searchAreaSize.LeftBorder && RealLocation.X < searchAreaSize.RightBorder &&
                    RealLocation.Y > searchAreaSize.BottomBorder && RealLocation.Y < searchAreaSize.TopBorder);
        }

        public override bool Equals(object obj)
        {
            IEntity entity = (IEntity)obj;

            return this.RealLocation.Equals(entity.RealLocation);
        }

        public override int GetHashCode()
        {
            return this.RealLocation.GetHashCode();
        }
    }
}
