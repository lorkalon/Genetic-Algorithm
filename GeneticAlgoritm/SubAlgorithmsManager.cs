using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    static class SubAlgorithmsManager
    {
        private static Dictionary<String, Type> gridsDictionary = new Dictionary<String, Type>() { { "Random", typeof(RandomGrid) }, { "Triangle", typeof(TriangleGrid) }, { "Square", typeof(SquareGrid) } };

        private static Dictionary<String, Type> divisionsDictionary = new Dictionary<String, Type>() { { "Center", typeof(CenterDivision) }, { "Even", typeof(EvenDivision) } };

        private static Dictionary<String, Type> selectionFromGroupsDictionary = new Dictionary<String, Type>() { { "Roulette", typeof(Roulette) }, { "Tournament", typeof(Tournament) }, { "From Sorted", typeof(SelectionSortedEntities) } };

        private static Dictionary<String, Type> selectionFromGenerationDictionary = new Dictionary<String, Type>() { { "Roulette", typeof(Roulette) }, { "Tournament", typeof(Tournament) }, { "From Sorted", typeof(SelectionSortedEntities) } };


        public static Dictionary<String, Type> GridsDictionary
        {
            get
            {
                return gridsDictionary;
            }
        }

        public static Dictionary<String, Type> DivisionsDictionary
        {
            get
            {
                return divisionsDictionary;
            }
        }

        public static Dictionary<String, Type> SelectionFromGroupsDictionary
        {
            get
            {
                return selectionFromGroupsDictionary;
            }
        }

        public static Dictionary<String, Type> SelectionFromGenerationDictionary
        {
            get
            {
                return selectionFromGenerationDictionary;
            }
        }
    }
}
