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
     //   private static List<IEntity> tempGeneration;
        private static Dictionary<IEntity, EntityTypes> entityTypeDictionary;
        private static Dictionary<EntityTypes, List<IEntity>> typesLists; 

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
          
            typesLists = new Dictionary<EntityTypes, List<IEntity>>()
            {{EntityTypes.UsualEntity, new List<IEntity>()},
            {EntityTypes.SelectedEntity, new List<IEntity>()},
            {EntityTypes.ChildEntity, new List<IEntity>()}, 
            {EntityTypes.MutantEntity, new List<IEntity>()},
            {EntityTypes.BestEntity, new List<IEntity>()}};
        }

        static void InitializeDataLists()
        {
            generationIndex = 1;
            entitiesData = new List<List<IEntity>>();
            entityTypeDictionary = new Dictionary<IEntity, EntityTypes>();
        }

        public static void AddDataInCurrentGeneration(List<IEntity> entities, EntityTypes entityType)
        {
            typesLists[entityType].AddRange(entities);
        }


        public static void SaveCurrentGeneration()
        {
            entitiesData.Add(GetTempGeneration());
            InitializeGenerationNode();
           
            foreach (var key in typesLists.Keys)
            {
                typesLists[key].Clear();
            }

        }

        private static List<IEntity> GetTempGeneration()
        {
            List<IEntity> tempGeneration = new List<IEntity>();
            tempGeneration.AddRange(typesLists[EntityTypes.UsualEntity]);
            tempGeneration.AddRange(typesLists[EntityTypes.ChildEntity]);
            tempGeneration.AddRange(typesLists[EntityTypes.MutantEntity]);
            return tempGeneration;
        }

        //public static TreeView GetTreeViewStatistics
        //{
        //    get { return treeViewStatistics; }
        //}

        private static void InitializeGenerationNode()
        {
            var pointsCount = " ( " + typesLists[EntityTypes.UsualEntity].Count.ToString() + " points ) ";
            var bestEntitiesCount = "  -  BestEntities  " + typesLists[EntityTypes.BestEntity].Count.ToString();
            var selectedEntitiesCount = "  -  SelectedEntities  " + typesLists[EntityTypes.SelectedEntity].Count().ToString();
            var childEntitiesCount = "  -  ChildEntities  " + typesLists[EntityTypes.ChildEntity].Count().ToString();
            var mutationEntitiesCount = "  -  mutationEntities  " + typesLists[EntityTypes.MutantEntity].Count().ToString();
            var usualEntitiesCount = "  -  usualEntities  " + typesLists[EntityTypes.UsualEntity].Count().ToString();

            var generationNode = treeViewStatistics.Nodes.Add(generationIndex.ToString(), "Generation " + generationIndex.ToString() + 
                pointsCount + usualEntitiesCount + selectedEntitiesCount + childEntitiesCount + mutationEntitiesCount +  bestEntitiesCount);

            int childIndex = 1;

            List<IEntity> tempGeneration = GetTempGeneration();
            
            foreach (var entity in tempGeneration)
            {
                string type = "  ";
               
                foreach (var key in typesLists.Keys)
                {
                    if (key != EntityTypes.UsualEntity && typesLists[key].Contains(entity))
                    {
                        type +=("  -  " + key.ToString());
                    }
                }

                var node = generationNode.Nodes.Add(childIndex.ToString(), "Point " + childIndex.ToString() + type);
               
                node.Nodes.Add(entity.RealLocation.X.ToString(), "X - " + entity.RealLocation.X.ToString());
                node.Nodes.Add(entity.RealLocation.Y.ToString(), "Y - " + entity.RealLocation.Y.ToString());
                node.Nodes.Add(entity.F1.ToString(), "F1 - " + entity.F1.ToString());
                node.Nodes.Add(entity.F2.ToString(), "F2 - " + entity.F2.ToString());
                node.Nodes.Add(entity.FGeneralized.ToString(), "F - " + entity.FGeneralized.ToString());
                node.Nodes.Add(entity.FGeneralized.ToString(), "First gene - " + ((Entity)entity).GetFirstGene);
                node.Nodes.Add(entity.FGeneralized.ToString(), "Second gene - " + ((Entity)entity).GetSecondGene);
                
                ++childIndex;
            }
            ++generationIndex;
        }
    }
}
