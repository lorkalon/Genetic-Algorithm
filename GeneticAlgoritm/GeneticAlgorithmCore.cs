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
            IEntity e = new Entity(new PointF(5.422427f, 0.0000305175781f));
            var a = e.F1;
            var b = e.F2;
            var c = e.FGeneralized;

            grid = new SquareGrid(searchAreaSize, 14);//Временное объявление
            //selection = new Roulette(4);
            selection = new Tournament(4);
            var entities = grid.GenerateGrid();
            //entities.ElementAt(0).F1 = 1000f;//test
            //entities.ElementAt(1).F1 = 100f;//test
            //entities.ElementAt(2).F1 = 99f;//test
            //entities.ElementAt(3).F1 = 2f;//test
            //entities.ElementAt(4).F1 = 1f;//test
            var best = selection.SelectEntities(entities.ToList(), entity => entity.F1);//test

            hybridize = new Hybridizer(searchAreaSize, new int[] { 40, 62 });
            var childs = hybridize.Hybridize(entities[0], entities[1]);//test

            performMutation = new Mutation(searchAreaSize, 3);
            entitiesGroups = new CenterDivide();
            StartGeneticAlgorithm();
        }

        public void StartGeneticAlgorithm()
        {
            List<IEntity> entities = grid.GenerateGrid();
            
            for (int i = 0; i < cycles; i++)
            {
                List<List<IEntity>> groups = entitiesGroups.DivideEntities(entities);
                List<IEntity> newEntities = new List<IEntity>();

                for (int j = 0; j < groups.Count; j++ )
                {
                    List<IEntity> modifiedEntities = new List<IEntity>();
                    Func<IEntity, float> comprasionDelegate;

                    //if (j%2 == 0)
                    {
                        comprasionDelegate = entity => entity.F1;
                    }
                    //else
                    {
                      //  comprasionDelegate = entity => entity.F2;
                    }

                    modifiedEntities.AddRange(selection.SelectEntities(groups[j], comprasionDelegate));
                    modifiedEntities.AddRange(GetOffsprings(modifiedEntities));
                    var r = modifiedEntities;
                    var t = GetMutationEntities(modifiedEntities);
                    modifiedEntities.AddRange(t);
                    newEntities.AddRange(modifiedEntities);
                }
                entities = newEntities; //!сделать отбор по F
            }

            var c = entities.Count; //!максимум 16 может быть
            var max = entities.Max(e => e.F1);
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
