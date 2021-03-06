﻿using System;
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
        private BitArray firstGene;
        private BitArray secondGene;
        private BitArray chromosome;
        private PointF realLocation;

        //public Point WindowLocation { get; private set; }
        public PointF RealLocation { get { return realLocation; } private set { realLocation = value; } }
        public BitArray FirstGene { get { return firstGene; } private set { firstGene = value; } }
        public BitArray SecondGene { get { return secondGene; } private set { secondGene = value; } }
        public BitArray Chromosome { get { return chromosome; } private set { chromosome = value; } }

        public string GetFirstGene
        {
            get
            {
                string gene = "";
                foreach (var b in firstGene)
                {
                    int bit = Convert.ToInt16(b);
                    gene += (bit.ToString() + " ");
                }
                return gene;
            }
        }

        public string GetSecondGene
        {
            get
            {
                string gene = "";
                foreach (var b in secondGene)
                {
                    int bit = Convert.ToInt16(b);
                    gene += (bit.ToString() + " ");
                }
                return gene;
            }
        }

        public string GetChromosome
        {
            get
            {
                string gene = "";
                foreach (var b in chromosome)
                {
                    int bit = Convert.ToInt16(b);
                    gene += (bit.ToString() + " ");
                }
                return gene;
            }
        }

        internal delegate double FirstCriteriaDelegate(float x, float y);
        internal delegate double SecondCriteriaDelegate(float x, float y);

        private FirstCriteriaDelegate firstCriteria;
        private SecondCriteriaDelegate secondCriteria;

        public double f1;
        public double f2;
        public double fGeneralized;

        const double c1 = 1.0f;
        const double c2 = 1.0f;
        
        private double FirstCriteriaMethod(float x, float y)
        {
            return (1 / (1 + Math.Pow((x - 2), 2) + Math.Pow((y - 10), 2)) +
                               1 / (2 + Math.Pow((x - 10), 2) + Math.Pow((y - 15), 2)) +
                               1 / (2 + Math.Pow((x - 18), 2) + x * Math.Pow((y - 4), 2)));
        }

        private double SecondCriteriaMethod(float x, float y)
        {
            return (1 / (1 / (1 + Math.Pow((x - 2), 2) + Math.Pow((y - 10), 2)) +
                              1 / (2 + Math.Pow((x - 10), 2) + Math.Pow((y - 15), 2)) +
                              1 / (2 + Math.Pow((x - 18), 2) + x * Math.Pow((y - 4), 2))));
        }

        public Entity(PointF realLocation)
        {
            this.realLocation = realLocation;
            InitializeDelegates();
            InitializeCriterias();
            InitializeGenes();
            SetChromosome();
        }

        private void InitializeGenes()
        {
            firstGene = new BitArray(BitConverter.GetBytes(RealLocation.X));
            secondGene = new BitArray(BitConverter.GetBytes(RealLocation.Y));
        }

        private void InitializeDelegates()
        {
            SetF1Delegate = FirstCriteriaMethod;
            SetF2Delegate = SecondCriteriaMethod;
        }

        private void InitializeCriterias()
        {
            float x = realLocation.X;
            float y = realLocation.Y;
            f1 = firstCriteria(x, y);
            f2 = secondCriteria(x, y);
            fGeneralized = c1 * f1 + c2 * f2;
        }

        private void SetChromosome()
        {
            int length = firstGene.Count + secondGene.Count;
            chromosome = new BitArray(length);

            for (int i = 0; i < firstGene.Count; i++)
            {
                chromosome[i] = firstGene[i];
            }

            for (int i = firstGene.Count, j = 0; i < length; i++)
            {
                chromosome[i] = secondGene[j];
            }
        }

        public double F1
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

        public double F2
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

        public double FGeneralized
        {
            get
            {
                return fGeneralized;
            }
        }

        public bool IsValid(SearchArea searchAreaSize)
        {
            return (realLocation.X >= searchAreaSize.LeftBorder && realLocation.X <= searchAreaSize.RightBorder &&
                    realLocation.Y >= searchAreaSize.BottomBorder && realLocation.Y <= searchAreaSize.TopBorder);
        }

        public override bool Equals(object obj)
        {
            Entity entity = (Entity)obj;

            //return (this.RealLocation.Equals(entity.RealLocation)) && (this.firstGene.Equals(entity.FirstGene)) && (this.secondGene.Equals(entity.SecondGene)) && (this.chromosome.Equals(entity.Chromosome));
            //return (this.F1.Equals(entity.F1)) && (this.F2.Equals(entity.F2)) && (this.FGeneralized.Equals(entity.FGeneralized));
            return this.RealLocation.Equals(entity.RealLocation);
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + RealLocation.GetHashCode();
            hash = (hash * 7) + firstGene.GetHashCode();
            hash = (hash * 7) + secondGene.GetHashCode();
            hash = (hash * 7) + chromosome.GetHashCode();
            //hash = (hash * 7) + fGeneralized.GetHashCode();
            //hash = (hash * 7) + F1.GetHashCode();
            //hash = (hash * 7) + F2.GetHashCode();

            return hash.GetHashCode();
        }
    }
}
