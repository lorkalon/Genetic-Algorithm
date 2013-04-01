using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgoritm
{
    public partial class EntitiesView : Form
    {
        private GeneticAlgorithmCore geneticAlgoritm;

        public EntitiesView()
        {
            InitializeComponent();

            geneticAlgoritm = new GeneticAlgorithmCore(new SearchArea(0, 10, 0, 10), 30);
            geneticAlgoritm.StartGeneticAlgorithm();
        }

        private int GetCyclesCount()
        {
            return Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("cyclesCount")[0]);
        }

        //private Size GetIllustrationCanvasSize()
        //{
        //    int illustrationCanvasWidth = Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("illustrationCanvasWidth")[0]);
        //    int illustrationCanvasHeigth = Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("illustrationCanvasHeigth")[0]);
        //    Size illustrationCanvasSize = new Size(illustrationCanvasWidth, illustrationCanvasHeigth);
        //    return illustrationCanvasSize;
        //}

        private SearchArea GetAreaSize()
        {
            int serchAreaLeftBorder = Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("serchAreaLeftBorder")[0]);
            int serchAreaRightBorder = Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("serchAreaRightBorder")[0]);
            int serchAreaBottomBorder = Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("serchAreaBottomBorder")[0]);
            int serchAreaTopBorder = Convert.ToInt32(ConfigurationSettings.AppSettings.GetValues("serchAreaTopBorder")[0]);
            SearchArea searchAreaSize = new SearchArea(serchAreaLeftBorder, serchAreaRightBorder, serchAreaBottomBorder, serchAreaTopBorder);
            return searchAreaSize;
        }

        private void EntitiesView_Load(object sender, EventArgs e)
        {
            this.illustrationPictureBox.Image = geneticAlgoritm.GetCanvas();
        }
    }
}
