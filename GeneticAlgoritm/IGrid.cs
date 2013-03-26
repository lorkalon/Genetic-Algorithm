using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    interface IGrid
    {
        List<IEntity> GenerateGrid();
    }
}
