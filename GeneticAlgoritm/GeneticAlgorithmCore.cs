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
        private SearchArea searchAreaSize;
        private IHybridizable hybridize;
        private ISelection selection;
        private IDividable entitiesGroups;
        private IMutation performMutation;

        private int cycles;

        public IGrid Grid { get; set; }
        public SearchArea SearchAreaSize { get; set; }
        public IHybridizable Hybridizable { get; set; }
        public ISelection Selection { get; set; }
        public IDividable EntitiesGroups { get; set; }
        public IMutation PerformMutation { get; set; }

        public GeneticAlgorithmCore(SearchArea searchAreaSize, int cycles)
        {
            this.searchAreaSize = searchAreaSize;
            this.cycles = cycles;
            /*
            grid = new SquareGrid(new SearchArea(0, 100, 100, 0), 14);
            var result1 = grid.GenerateGrid();//for testing
            grid = new TriangleGrid(new SearchArea(0, 100, 100, 0), 14);
            var result2 = grid.GenerateGrid();//for testing

            grid = new RandomGrid(new SearchArea(0, 100, 100, 0), 14);
            var result3 = grid.GenerateGrid();//for testing


            hybridize = new Hybridizer(new List<int>() { 2, 4 });
            IEntity mom = new Entity(new PointF(10, 10));
            IEntity dad = new Entity(new PointF(10, 10));
            hybridize.Hybridize(mom, dad);
            */
            
            Grid = new RandomGrid(searchAreaSize, 14);            //Временное объявление
            selection = new Roulette(10);
            performMutation = new Mutation(searchAreaSize, 3);
            
            entitiesGroups = new CenterDivide();
            StartGeneticAlgorithm();
        }

        public void StartGeneticAlgorithm()
        {
            List<IEntity> entities = Grid.GenerateGrid().ToList();

            for (int i = 0; i < cycles; i++)
            {
                List<IEntity> modifiedEntities = new List<IEntity>();
                List<IEnumerable<IEntity>> groups = entitiesGroups.DivideEntities(entities);

                foreach (var group in groups)
                {
                    //modifiedEntities.AddRange(selection.SelectEntities(group).ToList()); // Нужно реализовать этот метод!!!!!!!
                    modifiedEntities.AddRange(GetMutationEntities(group));
                    modifiedEntities.AddRange(GetOffspring(group)); // Не инициализирован объект hybridize!!!!!!!
                }

                entities = modifiedEntities;
            }

        }

        private List<IEntity> GetOffspring(IEnumerable<IEntity> parents)
        {
            List<IEntity> offspring = new List<IEntity>();

            for (int i = 0; i < parents.Count(); i+=2)
            {
                offspring.AddRange(hybridize.Hybridize(parents.ToList()[i], parents.ToList()[i + 1]).ToList());
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
