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
            var result = grid.GenerateGrid();//for testing
        }
    }
}
