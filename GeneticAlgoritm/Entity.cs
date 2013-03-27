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
        public Point WindowLocation { get; private set; }
        public PointF RealLocation { get; private set; }

        public BitArray FirstGene { get; private set; }
        public BitArray SecondGene { get; private set; }
        public BitArray Chromosome { get; private set; }

        internal delegate float FirstCriteriaDelegate(float x, float y);
        internal delegate float SecondCriteriaDelegate(float x, float y);

        private FirstCriteriaDelegate firstCriteria;
        private SecondCriteriaDelegate secondCriteria;

        public float f1;
        public float f2;
        public float fGeneralized;

        const float c1 = 1.0f;
        const float c2 = 1.0f;

        private float FirstCriteriaMethod(float x, float y)
        {
            return (float)(1 / (1 + Math.Pow((x - 2), 2) + Math.Pow((y - 10), 2)) +
                              1 / (2 + Math.Pow((x - 10), 2) + Math.Pow((y - 15), 2)) +
                              1 / (2 + Math.Pow((x - 18), 2) + Math.Pow((y - 4), 2 * Math.Round(x))));
        }

        private float SecondCriteriaMethod(float x, float y)
        {
            return (float)( 1/(1 / (1 + Math.Pow((x - 2), 2) + Math.Pow((y - 10), 2)) +
                              1 / (2 + Math.Pow((x - 10), 2) + Math.Pow((y - 15), 2)) +
                              1 / (2 + Math.Pow((x - 18), 2) + Math.Pow((y - 4), 2 * Math.Round(x)))));
        }

        public Entity(PointF realLocation)
        {
            RealLocation = realLocation;

            InitializeDelegates();
            InitializeCriterias();
            InitializeGenes();
            SetChromosome();
        }

        private void InitializeGenes()
        {
            FirstGene = new BitArray(BitConverter.GetBytes(RealLocation.X));
            SecondGene = new BitArray(BitConverter.GetBytes(RealLocation.Y));
<<<<<<< HEAD
            SetChromosome();
            

=======
        }

        private void InitializeDelegates()
        {
            SetF1Delegate = FirstCriteriaMethod;
            SetF2Delegate = SecondCriteriaMethod;
        }

        private void InitializeCriterias()
        {
            float x = RealLocation.X;
            float y = RealLocation.Y;
            f1 = firstCriteria(x, y);
            f2 = secondCriteria(x, y);
            fGeneralized = c1 * f1 + c2 * f2;
>>>>>>> 56e8bfe1b6d99c62be80d5669a9c8494a5673c99
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
       
        public float F1
        {
            get
            {
                return f1;
            }
        }

        public FirstCriteriaDelegate SetF1Delegate
        {
            set { firstCriteria = value; }
        }

        public float F2
        {
            get
            {
                return f2;
            }
        }

        public SecondCriteriaDelegate SetF2Delegate
        {
            set { secondCriteria = value; }
        }

        public float FGeneralized
        {
            get
            {
                return fGeneralized;
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
