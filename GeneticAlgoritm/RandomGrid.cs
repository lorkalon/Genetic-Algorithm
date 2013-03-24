using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class RandomGrid:IGrid
    {
        private int entitiesCount;

        private SearchArea searchAreaSize;

        private float intervalX;

        private float intervalY;

        public RandomGrid(SearchArea searchAreaSize, int entitiesCount)
        {
            this.searchAreaSize = searchAreaSize;
            this.entitiesCount = entitiesCount;
            intervalX = searchAreaSize.RightBorder - searchAreaSize.LeftBorder;
            intervalY = searchAreaSize.TopBorder - searchAreaSize.BottomBorder;
        }


        public IEnumerable<IEntity> GenerateGrid()
        {
            List<IEntity> entities = new List<IEntity>();

            Random random = new Random();
            for (int i = 0; i < entitiesCount; i++)
            {
                IEntity newEntity = new Entity(GetPointF(random));
                if (!entities.Contains(newEntity))
                {
                    entities.Add(newEntity);
                }
                else
                {
                    --i;
                }
            }
            return entities;
        }

        PointF GetPointF(Random random)
        {
            float x = Convert.ToSingle(random.NextDouble()*intervalX + searchAreaSize.LeftBorder);
            float y = Convert.ToSingle(random.NextDouble() * intervalY + searchAreaSize.BottomBorder);

            return new PointF(x,y);
        }
    }
}
