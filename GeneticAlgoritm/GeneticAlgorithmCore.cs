﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgoritm
{
    class GeneticAlgorithmCore
    {
        private int currentStep = 0;

        private int cycles;

        private SearchArea searchAreaSize;

        private IGrid grid;

        private IHybridizable hybridize;

        private ISelection selectionFromGroups;

        private ISelection selectionFromGeneration;

        private IDividable entitiesDivision;

        private IMutation performMutation;

        private List<IEntity> entities;

        public IGrid Grid 
        {
            get
            {
                return grid;
            } 
            set
            {
                grid = value; 
                entities = grid.GenerateGrid();
            } 
        }

        public IHybridizable Hybridize { get { return hybridize; } set { hybridize = value; } }

        public ISelection SelectionFromGroups { get { return selectionFromGroups; } set { selectionFromGroups = value; } }

        public IDividable EntitiesDivision { get { return entitiesDivision; } set { entitiesDivision = value; } }

        public IMutation PerformMutation { get { return performMutation; } set { performMutation = value; } }

        public ISelection SelectionFromGeneration { get { return selectionFromGeneration; } set { selectionFromGeneration = value; } }

        public GeneticAlgorithmCore(SearchArea searchAreaSize, int cycles)
        {
            this.searchAreaSize = searchAreaSize;
            this.cycles = cycles;
        }

        public void ExecuteGeneticAlgorithm()
        {
            StartOverIfNeed();

            for (int i = currentStep; i < cycles; i++)
            {
                List<List<IEntity>> groups = entitiesDivision.DivideEntities(entities);
                entities = GetGenerationEntities(groups);
                Statistics.SaveCurrentGeneration();
                currentStep += 1;
            }
            EntitiesDrawer.DrawBestResult(entities);
        }

        public void ExecuteOneStep()
        {
            StartOverIfNeed();

            List<List<IEntity>> groups = entitiesDivision.DivideEntities(entities);
            entities = GetGenerationEntities(groups);
            Statistics.SaveCurrentGeneration();
            EntitiesDrawer.DrawBestResult(entities);
            currentStep += 1;
        }

        private void StartOverIfNeed()
        {
            if (currentStep >= cycles)
            {
                currentStep = 0;
                EntitiesDrawer.ClearCanvas();
                entities = grid.GenerateGrid();
            }
        }

        private List<IEntity> GetGenerationEntities(List<List<IEntity>> groups)
        {
            EntitiesDrawer.ClearCanvas();
            List<IEntity> newEntities = new List<IEntity>();

            for (int j = 0; j < groups.Count; j++)
            {
                EntitiesDrawer.DrawEntities(groups[j], EntityTypes.UsualEntity);
                Statistics.AddDataInCurrentGeneration(groups[j], EntityTypes.UsualEntity);

                List<IEntity> modifiedEntities = new List<IEntity>();
                Func<IEntity, float> comprasionDelegate;

                //if (j % 2 == 0)
                {
                    comprasionDelegate = entity => entity.F1;
                }
                //else
                {
                    //comprasionDelegate = entity => entity.F2;
                }
                //////////////////
                var leadingEntities = selectionFromGroups.SelectEntities(groups[j], comprasionDelegate);
                if (leadingEntities.Count == 0)//test
                {
                    MessageBox.Show("leading entities count is null !!! ");
                }
                modifiedEntities.AddRange(leadingEntities);
                EntitiesDrawer.DrawEntities(leadingEntities, EntityTypes.SelectedEntity);
                Statistics.AddDataInCurrentGeneration(leadingEntities, EntityTypes.SelectedEntity);

                var entitiesOffsprings = GetOffsprings(modifiedEntities);
                modifiedEntities.AddRange(entitiesOffsprings);
                EntitiesDrawer.DrawEntities(entitiesOffsprings, EntityTypes.ChildEntity);
                Statistics.AddDataInCurrentGeneration(entitiesOffsprings, EntityTypes.ChildEntity);

                var mutationEntities = GetMutationEntities(modifiedEntities);
                modifiedEntities.AddRange(mutationEntities);
                EntitiesDrawer.DrawEntities(mutationEntities, EntityTypes.MutantEntity);
                Statistics.AddDataInCurrentGeneration(mutationEntities, EntityTypes.MutantEntity);

                //////////////////

                //var mutationEntities = GetMutationEntities(groups[j]);
                //modifiedEntities.AddRange(mutationEntities);
                //var leadingEntities = selection.SelectEntities(modifiedEntities, comprasionDelegate);
                //modifiedEntities.AddRange(leadingEntities);
                //var entitiesOffsprings = GetOffsprings(modifiedEntities);
                //modifiedEntities.AddRange(entitiesOffsprings);


                newEntities.AddRange(modifiedEntities);
            }

            //var newPopulationEntities = selection.SelectEntities(newEntities, x => x.FGeneralized);   // !!!!!!!!!!!Обратить внимание на количество возвращаемых особей!!!!!
            var newPopulationEntities = selectionFromGeneration.SelectEntities(newEntities, x => x.F1);
            EntitiesDrawer.DrawEntities(newPopulationEntities, EntityTypes.BestEntity);
            Statistics.AddDataInCurrentGeneration(newPopulationEntities, EntityTypes.BestEntity);
            return newPopulationEntities;
        }

        private List<IEntity> GetOffsprings(List<IEntity> parents)
        {
            List<IEntity> offspring = new List<IEntity>();

            for (int i = 0; i < parents.Count() - 1; i += 2)
            {
                offspring.AddRange(hybridize.Hybridize(parents[i], parents[i + 1]).ToList());
            }
            return offspring;
        }

        private List<IEntity> GetMutationEntities(IEnumerable<IEntity> entities)
        {
            List<IEntity> mutationEntities = entities.Select(entity => performMutation.Mutate(entity)).Where(mutant => mutant != null).ToList();
            return mutationEntities;
        }
    }
}
