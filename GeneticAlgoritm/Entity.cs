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
        internal delegate float FirstCriteriaDelegate(float x, float y);
        internal delegate float SecondCriteriaDelegate(float x, float y);

        private FirstCriteriaDelegate firstCriteria;
        private SecondCriteriaDelegate secondCriteria;

        const float c1 = 1.0f;
        const float c2 = 1.0f;

        private float FirstCriteriaMethod(float x, float y)
        {
            return (float) (1/(1 + Math.Pow((x - 2), 2) + Math.Pow((y - 10), 2)) +
                              1/(2 + Math.Pow((x - 10), 2) + Math.Pow((y - 15), 2)) +
                              1/(2 + Math.Pow((x - 18), 2) + Math.Pow((y - 4), 2*x)));
        }

        private float SecondCriteriaMethod(float x, float y)
        {
            return (float)( 1/(1 / (1 + Math.Pow((x - 2), 2) + Math.Pow((y - 10), 2)) +
                              1 / (2 + Math.Pow((x - 10), 2) + Math.Pow((y - 15), 2)) +
                              1 / (2 + Math.Pow((x - 18), 2) + Math.Pow((y - 4), 2 * x))) );
        }

        public Entity(PointF realLocation)
        {
            RealLocation = realLocation;
            FirstGene = new BitArray(BitConverter.GetBytes(RealLocation.X));
            SecondGene = new BitArray(BitConverter.GetBytes(RealLocation.Y));
            SetChromosome();
            

        }

        private void SetChromosome()
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

       
        public float GetF1(float x, float y)
        {
            return firstCriteria(x, y);
        }

        public FirstCriteriaDelegate SetF1
        {
            set { firstCriteria = value; }
        }

        public float GetF2(float x, float y)
        {
            return secondCriteria(x, y);
        }

        public SecondCriteriaDelegate SetF2
        {
            set { secondCriteria = value; }
        }

        public float GetFGeneralized(float x, float y)
        {
             return (float) (firstCriteria(x,y)*c1 + secondCriteria(x,y)*c2); 
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
