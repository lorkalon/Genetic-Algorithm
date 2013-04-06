using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    enum EntityTypes { BestEntity, MutantEntity, UsualEntity, ChildEntity, SelectedEntity };

    static class EntityCustomizer
    {
        private static int transparensy = 170;

        private static Dictionary<EntityTypes, Color> entityColorConformity;

        static EntityCustomizer()
        {
            entityColorConformity = new Dictionary<EntityTypes, Color>(){
            {EntityTypes.BestEntity, Color.FromArgb(transparensy, Color.Red)},
            {EntityTypes.UsualEntity, Color.FromArgb(transparensy, Color.Gray)},
            {EntityTypes.MutantEntity, Color.FromArgb(transparensy, Color.Green)},
            {EntityTypes.ChildEntity, Color.FromArgb(transparensy, Color.Blue)},
            {EntityTypes.SelectedEntity, Color.FromArgb(transparensy, Color.Orange)}};
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
