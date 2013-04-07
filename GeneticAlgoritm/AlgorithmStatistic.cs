using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class AlgorithmStatistic
    {
        private String grid;

        private String division;

        private String selectionFromGroups;

        private String selectionFromGeneration;

        private float fGeneralized;

        public String Grid { set; get; }

        public String Division { set; get; }

        public String SelectionFromGroups { set; get; }

        public String SelectionFromGeneration { set; get; }

        public double FGeneralized { set; get; }
    }
}
