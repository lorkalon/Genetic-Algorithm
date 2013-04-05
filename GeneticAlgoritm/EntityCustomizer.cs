using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    enum EntityTypes { BestEntity, MutantEntity, ParentEntity, ChildEntity, SelectedEntity };

    static class EntityCustomizer
    {
        private static Dictionary<EntityTypes, Color> entityColorConformity;

        static EntityCustomizer()
        {
            entityColorConformity = new Dictionary<EntityTypes, Color>(){
            {EntityTypes.BestEntity,Color.Red},
            {EntityTypes.MutantEntity,Color.Green},
            //{EntityTypes.ParentEntity,Color.Green},
            {EntityTypes.ChildEntity,Color.Blue},
            {EntityTypes.SelectedEntity,Color.Orange}};
        }

        public static Color GetEntityColor(EntityTypes entityType)
        {
            return entityColorConformity[entityType];
        }

        public static void SetEntityColor(EntityTypes entityType, Color color)
        {
            entityColorConformity[entityType] = color;
        }

        public static Dictionary<EntityTypes, Color> GetEntityColorConformity()
        {
            return entityColorConformity;
        }
    }
}
