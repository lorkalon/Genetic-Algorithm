using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            geneticAlgoritm = new GeneticAlgorithmCore(new SearchArea(0, 100, 0, 100), 10);
        }

        private void EntitiesView_Load(object sender, EventArgs e)
        {

        }
    }
}
