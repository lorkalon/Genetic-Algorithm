using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class TriangleGrid:IGrid
    {
        private Random random = new Random(DateTime.Now.Millisecond);

        private const float e = 0.001f;

        private int entitiesCount;

        private SearchArea searchAreaSize;

        public TriangleGrid(SearchArea searchAreaSize, int entitiesCount)
        {
            this.searchAreaSize = searchAreaSize;
            this.entitiesCount = entitiesCount;
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

            Random random = new Random();
            for (int i = 0; i < entitiesCount; i++)
            {
                int randomPointIndex = random.Next(candidatePoints.Count());
                PointF randomPoint = candidatePoints[randomPointIndex];
                candidatePoints.RemoveAt(randomPointIndex);
                gridPoints.Add(new Entity(randomPoint));
            }
            return gridPoints;
        }

        private List<PointF> GetCandidatePoints()
        {
            List<PointF> candidatePoints = new List<PointF>();
            float horizontalStep = (searchAreaSize.RightBorder - searchAreaSize.LeftBorder) / 3;
            float horizontalHalfStep = horizontalStep / 2;
            float verticalStep = horizontalStep / 1.732f;

            int level = 0;
            float x;
            for (float y = searchAreaSize.BottomBorder; y <= searchAreaSize.TopBorder+e; y += verticalStep)
            {
                float leftBorder = GelLeftBorder(level, horizontalHalfStep);
                for (x = leftBorder; x <= searchAreaSize.RightBorder+e; x += horizontalStep)
                {
                    candidatePoints.Add(new PointF(x, y));
                }
                level += 1;
            }
            return candidatePoints;
        }

        private float GelLeftBorder(int level, float horizontalHalfStep)
        {
            float leftBorder;
            if (level % 2 != 0)
            {
                leftBorder = horizontalHalfStep + searchAreaSize.LeftBorder;
            }
            else
            {
                leftBorder = searchAreaSize.LeftBorder;
            }
            return leftBorder;
        }
    }
}
