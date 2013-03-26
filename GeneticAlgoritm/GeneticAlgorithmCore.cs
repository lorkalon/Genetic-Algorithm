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
        private int cycles;

        private SearchArea searchAreaSize;
        private IGrid grid;
        private IHybridizable hybridize;
        private ISelection selection;
        private IDividable entitiesGroups;
        private IMutation performMutation;
        

        public SearchArea SearchAreaSize { get; set; }
        public IGrid Grid { get; set; }
        public IHybridizable Hybridize { get; set; }
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
            IEntity e = new Entity(new PointF(12,12));
            var a = e.GetF1(12, 12);
            var b = e.GetF2(12, 12);
            var c = e.GetFGeneralized(12, 12);

            Grid = new RandomGrid(searchAreaSize, 14);//Временное объявление
            selection = new Roulette(2);
            var entities=Grid.GenerateGrid();
            //entities.ElementAt(0).F1 = 1000f;//test
            //entities.ElementAt(1).F1 = 100f;//test
            //entities.ElementAt(2).F1 = 99f;//test
            //entities.ElementAt(3).F1 = 2f;//test
            //entities.ElementAt(4).F1 = 1f;//test
            //var best = selection.SelectEntities(entities.ToList(), entity => entity.F1);//test

            hybridize = new Hybridizer(searchAreaSize, new int[] { 2, 4 });
            var childs = hybridize.Hybridize(entities[0], entities[1]);//test

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
                List<List<IEntity>> groups = entitiesGroups.DivideEntities(entities);

                foreach (var group in groups)
                {
                    modifiedEntities.AddRange(selection.SelectEntities(group,entity=>entity.F1));
                    modifiedEntities.AddRange(GetMutationEntities(group));
                    modifiedEntities.AddRange(GetOffsprings(group)); // Не инициализирован объект hybridize!!!!!!!
                }

                entities = modifiedEntities;
            }

        }

        private List<IEntity> GetOffsprings(IEnumerable<IEntity> parents)
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
