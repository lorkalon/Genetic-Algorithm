using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgoritm
{
    static class Statistics
    {
        private static List<List<IEntity>> entitiesData;
        private static List<IEntity> tempGeneration;
        private static Dictionary<IEntity, EntityTypes> entityTypeDictionary;
        private static List<IEntity> entityBestTypeList;
        private static TreeView treeViewStatistics;
        private static int generationIndex;

        public static TreeView TreeViewStatistics
        {
            set { treeViewStatistics = value; }
        }
        
        public static List<List<IEntity>> GetEntitiesData 
        {
            get { return entitiesData; }
        }

        public static void ClearTreeView()
        {
            treeViewStatistics.Nodes.Clear();
            InitializeDataLists();
        }

        static Statistics()
        {
            InitializeDataLists();
        }

        static void InitializeDataLists()
        {
            generationIndex = 1;
            entitiesData = new List<List<IEntity>>();
            entityTypeDictionary = new Dictionary<IEntity, EntityTypes>();
            entityBestTypeList = new List<IEntity>();
            tempGeneration = new List<IEntity>();
        }

        public static void AddDataInCurrentGeneration(List<IEntity> entities, EntityTypes entityType)
        {
            if (entityType == EntityTypes.BestEntity)
            {
                entityBestTypeList.AddRange(entities);
                return;
            }
            foreach (var entity in entities)  
            {
                if (tempGeneration.Contains(entity) == false)
                {
                    tempGeneration.Add(entity);
                }

                if (entityTypeDictionary.ContainsKey(entity))
                {
                    entityTypeDictionary[entity] = entityType;
                }
                else
                {
                    entityTypeDictionary.Add(entity, entityType);
                }
            }
        }

        public static void SaveCurrentGeneration()
        {
            if (tempGeneration.Count == 0)
            {
                return;
            }
            entitiesData.Add(tempGeneration);
            InitializeGenerationNode();
            tempGeneration = new List<IEntity>();
            entityTypeDictionary = new Dictionary<IEntity, EntityTypes>();
            entityBestTypeList = new List<IEntity>();
        }

        //public static TreeView GetTreeViewStatistics
        //{
        //    get { return treeViewStatistics; }
        //}

        private static void InitializeGenerationNode()
        {
            var pointsCount = " ( " + entityTypeDictionary.Count.ToString() + " points ) ";
            var bestEntitiesCount = "  -  BestEntities  " + entityBestTypeList.Count.ToString();
            var selectedEntitiesCount = "  -  SelectedEntities  " + entityTypeDictionary.Where(x => x.Value == EntityTypes.SelectedEntity).Count().ToString();
            var childEntitiesCount = "  -  ChildEntities  " + entityTypeDictionary.Where(x => x.Value == EntityTypes.ChildEntity).Count().ToString();
            var mutationEntitiesCount = "  -  mutationEntities  " + entityTypeDictionary.Where(x => x.Value == EntityTypes.MutantEntity).Count().ToString();
            var usualEntitiesCount = "  -  usualEntities  " + entityTypeDictionary.Where(x => x.Value == EntityTypes.UsualEntity).Count().ToString();


            var generationNode = treeViewStatistics.Nodes.Add(generationIndex.ToString(), "Generation " + generationIndex.ToString() + 
                pointsCount + usualEntitiesCount + selectedEntitiesCount + childEntitiesCount + mutationEntitiesCount +  bestEntitiesCount);

            int childIndex = 1;
           
            foreach (var entity in tempGeneration)
            {
                string isBest = "";
                if (entityBestTypeList.Contains(entity))
                {
                    isBest = " (BEST) ";
                }
                var node = generationNode.Nodes.Add(childIndex.ToString(), "Point " + childIndex.ToString() + isBest);
                node.BackColor = EntityCustomizer.GetEntityColor(entityTypeDictionary[entity]);
                node.Nodes.Add(entity.RealLocation.X.ToString(), "X - " + entity.RealLocation.X.ToString());
                node.Nodes.Add(entity.RealLocation.Y.ToString(), "Y - " + entity.RealLocation.Y.ToString());
                node.Nodes.Add(entity.F1.ToString(), "F1 - " + entity.F1.ToString());
                node.Nodes.Add(entity.F2.ToString(), "F2 - " + entity.F2.ToString());
                node.Nodes.Add(entity.FGeneralized.ToString(), "F - " + entity.FGeneralized.ToString());
                node.Nodes.Add(entity.FGeneralized.ToString(), "First gene - " + ((Entity)entity).GetFirstGene);
                node.Nodes.Add(entity.FGeneralized.ToString(), "Second gene - " + ((Entity)entity).GetSecondGene);
                node.Nodes.Add(entityTypeDictionary[entity].ToString(), "Entity type - " + (entityTypeDictionary[entity].ToString()));
                
                ++childIndex;
            }
            ++generationIndex;
        }
    }
}
