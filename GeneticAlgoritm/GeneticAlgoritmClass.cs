using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class GeneticAlgoritmClass
    {
        private IGrid grid;

        private IHybridizable hybridize;

        public GeneticAlgoritmClass()
        {
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

            Mutation m = new Mutation(10);
            IEntity newEntity = m.Mutate(new Entity(new PointF(12, 12)));

        }
    }
}
