using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoritm
{
    static class ConfigurationManager
    {
        private static AppSettingsReader settingsReader = new AppSettingsReader();

        public static SearchArea GetAreaSize()
        {
            int serchAreaLeftBorder = (int)settingsReader.GetValue("serchAreaLeftBorder", typeof(int));
            int serchAreaRightBorder = (int)settingsReader.GetValue("serchAreaRightBorder", typeof(int));
            int serchAreaBottomBorder = (int)settingsReader.GetValue("serchAreaBottomBorder", typeof(int));
            int serchAreaTopBorder = (int)settingsReader.GetValue("serchAreaTopBorder", typeof(int));
            SearchArea searchAreaSize = new SearchArea(serchAreaLeftBorder, serchAreaRightBorder, serchAreaBottomBorder, serchAreaTopBorder);
            return searchAreaSize;
        }

        public static int GetCyclesCount()
        {
            return (int)settingsReader.GetValue("cyclesCount", typeof(int));
        }

        public static Size GetIllustrationCanvasSize()
        {
            int illustrationCanvasWidth = Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("illustrationCanvasWidth")[0]);
            int illustrationCanvasHeigth = Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("illustrationCanvasHeigth")[0]);
            return new Size(illustrationCanvasWidth, illustrationCanvasHeigth);
        }
    }
}
