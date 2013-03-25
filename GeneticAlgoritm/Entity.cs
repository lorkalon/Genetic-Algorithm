﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class Entity : IEntity
    {
        private static readonly delegate float firstCriteria(float x, float y);
        private static readonly delegate float secondCriteria(float x, float y);
        const float c1 = 1;
        const float c2 = 1;

        private static float FirstCriteria(float x, float y)
        {
            float result=0;


            return result;
        }

        static Entity()
        {
            //firstCriteria
        }

        public Entity(PointF realLocation)
        {
            RealLocation = realLocation;
            FirstGene = BitConverter.GetBytes(RealLocation.X);
            SecondGene = BitConverter.GetBytes(RealLocation.Y);
            //SetChromosome();test
        }

        void SetChromosome()
        {
            List<byte> concatGene = FirstGene.ToList();
            concatGene.AddRange(SecondGene);

            Chromosome = concatGene;
        }

        public Point WindowLocation { get; set; }
        public PointF RealLocation { get; set; }
        public IEnumerable<byte> FirstGene { get; private set; }
        public IEnumerable<byte> SecondGene { get; private set; }
        public List<byte> Chromosome { get; set; }

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


        System.Collections.BitArray IEntity.FirstGene
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.BitArray IEntity.SecondGene
        {
            get { throw new NotImplementedException(); }
        }

        System.Collections.BitArray IEntity.Chromosome
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
    }
}
