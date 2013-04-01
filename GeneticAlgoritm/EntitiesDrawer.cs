using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    class EntitiesDrawer
    {
        private static Size illustrationCanvasSize;

        public static void DrawEntities(Bitmap canvas, List<Entity> entities)
        {
            if (canvas == null)
            {
                InitializeCanvas(canvas);
            }
            //draw
        }

        private static Size InitializeCanvas(Bitmap canvas)
        {
            int illustrationCanvasWidth = Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("illustrationCanvasWidth")[0]);
            int illustrationCanvasHeigth = Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("illustrationCanvasHeigth")[0]);
            canvas = new Bitmap(illustrationCanvasWidth, illustrationCanvasHeigth);
            illustrationCanvasSize = new Size(illustrationCanvasWidth, illustrationCanvasHeigth);
            return illustrationCanvasSize;
        }
    }
}
