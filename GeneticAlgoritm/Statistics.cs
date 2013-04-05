using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    static class Statistics
    {
        private static List<List<IEntity>> entitiesData;
        public static List<List<IEntity>> GetEntitiesData 
        {
            get { return entitiesData; }
        }
        
        static Statistics()
        {
            entitiesData = new List<List<IEntity>>();
        }

        public static void SaveData(List<IEntity> entities)
        {
            entitiesData.Add(entities);
        }
    }
}
