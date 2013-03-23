using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class GeneticAlgoritmClass
    {
        private IGrid grid;

        public GeneticAlgoritmClass()
        {
            grid = new SquareGrid(new SearchArea(0, 100, 100, 0), 14);
            var result1 = grid.GenerateGrid();//for testing
            grid = new TriangleGrid(new SearchArea(0, 100, 100, 0), 14);
            var result2 = grid.GenerateGrid();//for testing
        }
    }
}
