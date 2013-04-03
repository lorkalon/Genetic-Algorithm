using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class GeneticAlgorithmCore
    {
        private Bitmap canvas;
        private int cycles;
        private SearchArea searchAreaSize;
        private IGrid grid;
        private IHybridizable hybridize;
        private ISelection selection;
        private IDividable entitiesDivision;
        private IMutation performMutation;
        private int amountSortedEntites;
        private int entitiesCount;
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
        public ISelection Selection { get { return selection; } set { selection = value; } }
        public IDividable EntitiesDivision { get { return entitiesDivision; } set { entitiesDivision = value; } }
        public IMutation PerformMutation { get { return performMutation; } set { performMutation = value; } }
        public int AmountSortedEntities { get { return amountSortedEntites; } set { amountSortedEntites = value; } }
        public int EntitiesCount { get { return entitiesCount; } set { entitiesCount = value; } }

        public GeneticAlgorithmCore(SearchArea searchAreaSize, int cycles)
        {
            this.searchAreaSize = searchAreaSize;
            this.cycles = cycles;
        }

        public void ExecuteGeneticAlgorithm()
        {
            entities = grid.GenerateGrid();
            EntitiesDrawer.ClearCanvas();
            canvas = EntitiesDrawer.DrawEntities(entities);
            for (int i = 0; i < cycles; i++)
            {
                List<List<IEntity>> groups = entitiesDivision.DivideEntities(entities);
                entities = GetGenerationEntities(groups);
            }
        }

        public void ExecuteOneStep()
        {
            List<List<IEntity>> groups = entitiesDivision.DivideEntities(entities);
            entities = GetGenerationEntities(groups);
            canvas = EntitiesDrawer.DrawEntities(entities);
        }

        private List<IEntity> GetGenerationEntities(List<List<IEntity>> groups)
        {
            List<IEntity> newEntities = new List<IEntity>();

            for (int j = 0; j < groups.Count; j++)
            {
                List<IEntity> modifiedEntities = new List<IEntity>();
                Func<IEntity, float> comprasionDelegate;

               if (j % 2 == 0)
                {
                    comprasionDelegate = entity => entity.F1;
               }
               else
                {
                    comprasionDelegate = entity => entity.F2;
                }

                modifiedEntities.AddRange(selection.SelectEntities(groups[j], comprasionDelegate));
                modifiedEntities.AddRange(GetOffsprings(modifiedEntities));
                modifiedEntities.AddRange(GetMutationEntities(modifiedEntities));
                newEntities.AddRange(modifiedEntities);    
            }

            return selection.SelectEntities(newEntities, x => x.FGeneralized);   // !!!!!!!!!!!Обратить внимание на количество возвращаемых особей!!!!!
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

        public Bitmap GetCanvas()
        {
            return canvas;
        }
    }
}
