using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class SearchArea
    {
        public float LeftBorder { get; set; }

        public float RightBorder { get; set; }

        public float TopBorder { get; set; }

        public float BottomBorder { get; set; }

        public SearchArea(float leftBorder, float rightBorder, float topBorder, float bottomBorder)
        {
            LeftBorder = leftBorder;
            RightBorder = rightBorder;
            TopBorder = topBorder;
            BottomBorder = bottomBorder;
        }
    }
}
