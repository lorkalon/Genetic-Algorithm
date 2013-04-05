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
        private static Dictionary<float, EntityTypes> entityTypeDictionary;
        private static List<IEntity> tempGeneration; 
        
        public static List<List<IEntity>> GetEntitiesData 
        {
            get { return entitiesData; }
        }
        
        public static EntityTypes GetTypeEntity(float entity)
        {
            return entityTypeDictionary[entity];
        }

        static Statistics()
        {
            entitiesData = new List<List<IEntity>>();
            entityTypeDictionary = new Dictionary<float, EntityTypes>();
            tempGeneration = new List<IEntity>();

        }

        public static void AddDataInCurrentGeneration(List<IEntity> entities, EntityTypes entityType)
        {
            foreach (var entity in entities)
            {
                if (tempGeneration.Contains(entity) == false)
                {
                    tempGeneration.Add(entity);
                }

                if (entityTypeDictionary.ContainsKey(entity.FGeneralized))
                {
                    entityTypeDictionary[entity.FGeneralized] = entityType;
                }
                else
                {
                    entityTypeDictionary.Add(entity.FGeneralized, entityType);
                }
            }
        }

        public static void SaveCurrentGeneration()
        {
            entitiesData.Add(tempGeneration);
            tempGeneration = new List<IEntity>();
        }
    }
}
