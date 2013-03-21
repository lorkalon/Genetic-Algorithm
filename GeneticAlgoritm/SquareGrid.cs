using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GeneticAlgoritm
{
    class SquareGrid:IGrid
    {
        private int entitiesCount;

        private SearchArea searchAreaSize;

        public SquareGrid(SearchArea searchAreaSize, int entitiesCount)
        {
            this.entitiesCount = entitiesCount;
            this.searchAreaSize = searchAreaSize;
        }

        //public List<IEntity> GetEntities { get; private set; }

        public IEnumerable<IEntity> GenerateGrid()
        {
            List<PointF> candidatePoints = GetCandidatePoints();
            IEnumerable<IEntity> gridPoints = SeedGridPoints(candidatePoints);
            return gridPoints;
        }

        private IEnumerable<IEntity> SeedGridPoints(List<PointF> candidatePoints)
        {
            List<IEntity> gridPoints = new List<IEntity>();
            Random random=new Random();
            for (int i = 0; i < entitiesCount; i++)
            {
                int randomPointIndex = random.Next(candidatePoints.Count());
                PointF randomPoint=candidatePoints[randomPointIndex];
                candidatePoints.RemoveAt(randomPointIndex);
                gridPoints.Add(new Entity(randomPoint));
            }
            return gridPoints;
        }

        private List<PointF> GetCandidatePoints()
        {
            List<PointF> candidatePoints = new List<PointF>();
            float horizontalStep = (searchAreaSize.RightBorder - searchAreaSize.LeftBorder) / 3;
            float verticalStep = (searchAreaSize.TopBorder - searchAreaSize.BottomBorder) / 3;

            for (float x = searchAreaSize.LeftBorder; x < searchAreaSize.RightBorder; x++)
            {
                for (float y = searchAreaSize.BottomBorder; y < searchAreaSize.TopBorder; y++)
                {
                    candidatePoints.Add(new PointF(x, y));
                }
            }
            return candidatePoints;
        }
    }
}
