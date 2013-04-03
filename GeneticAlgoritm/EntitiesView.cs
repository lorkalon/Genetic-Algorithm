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
        private AppSettingsReader settingsReader;
        private SearchArea searchAreaSize;
        private int cycles;
        private Dictionary<string, Type> grids = new Dictionary<string, Type>(){{"Random", typeof(RandomGrid)}, {"Triangle", typeof(TriangleGrid)}, {"Square", typeof(SquareGrid)} };
        private Dictionary<string, Type> divisions = new Dictionary<string, Type>() { { "Center", typeof(CenterDivision) }, { "Even", typeof(EvenDivision) } };
        private Dictionary<string, Type> selections = new Dictionary<string, Type>() { { "Roulette", typeof(Roulette) }, { "Tournament", typeof(Tournament) } };
        private bool settigsChanged = false;
        private bool formLoaded = false;

        public EntitiesView()
        {
            InitializeComponent();
            settingsReader = new AppSettingsReader();
            InitializeComboBoxControls();
            searchAreaSize = GetAreaSize();
            cycles = GetCyclesCount();
            
            geneticAlgoritm = new GeneticAlgorithmCore(searchAreaSize, cycles);
            InitializeGeneticAlgorithmProperties();
            formLoaded = true;
        }

        private void InitializeComboBoxControls()
        {
            gridComboBox.Items.AddRange(grids.Keys.ToArray());
            gridComboBox.SelectedIndex = 0;

            divisionComboBox.Items.AddRange(divisions.Keys.ToArray());
            divisionComboBox.SelectedIndex = 0;

            selectionComboBox.Items.AddRange(selections.Keys.ToArray());
            selectionComboBox.SelectedIndex = 0;
        }

        private void InitializeGeneticAlgorithmProperties()
        {
            geneticAlgoritm.EntitiesCount = (int) entitiesCountNumericUpDown.Value;    
            geneticAlgoritm.AmountSortedEntities = (int)selectedByFEntitiesNumericUpDown.Value;
            
            geneticAlgoritm.Hybridize = new Hybridizer(searchAreaSize, new int[] { (int)crossPointNumericUpDown1.Value, (int)crossPointNumericUpDown2.Value });
            geneticAlgoritm.PerformMutation = new Mutation(searchAreaSize, (int)mutationPercentNumericUpDown.Value);
            
            geneticAlgoritm.Grid = (IGrid)Activator.CreateInstance(grids[gridComboBox.Text], searchAreaSize, (int)entitiesCountNumericUpDown.Value);
            geneticAlgoritm.Selection = (ISelection) Activator.CreateInstance(selections[selectionComboBox.Text], (int)selectedEntitiesNumericUpDown.Value);
            geneticAlgoritm.EntitiesDivision = (IDividable)Activator.CreateInstance(divisions[divisionComboBox.Text]);
        }

        private int GetCyclesCount()
        {
            return (int)settingsReader.GetValue("cyclesCount", typeof(int));
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
            int serchAreaLeftBorder = (int)settingsReader.GetValue("serchAreaLeftBorder", typeof(int));
            int serchAreaRightBorder = (int)settingsReader.GetValue("serchAreaRightBorder", typeof(int));
            int serchAreaBottomBorder = (int)settingsReader.GetValue("serchAreaBottomBorder", typeof(int));
            int serchAreaTopBorder = (int)settingsReader.GetValue("serchAreaTopBorder", typeof(int));
            SearchArea searchAreaSize = new SearchArea(serchAreaLeftBorder, serchAreaRightBorder, serchAreaBottomBorder, serchAreaTopBorder);
            return searchAreaSize;
        }

        private void EntitiesView_Load(object sender, EventArgs e)
        {
            
        }

        private void ExecuteGeneticAlgorithmButton_Click(object sender, EventArgs e)
        {
            geneticAlgoritm.ExecuteGeneticAlgorithm(); 
            this.illustrationPictureBox.Image = geneticAlgoritm.GetCanvas();
        }

        private void executeOneStepButton_Click(object sender, EventArgs e)
        {
            geneticAlgoritm.ExecuteOneStep();
            this.illustrationPictureBox.Image = geneticAlgoritm.GetCanvas();
        }

        private void SettingsChanged(object sender, EventArgs e)
        {
            settigsChanged = true;
        }

        private void ApplySettingsButton_Click(object sender, EventArgs e)
        {
            InitializeGeneticAlgorithmProperties();  // Вариант для ленивых
        }


        // ------------------- обработчики изменений настроек -------------------------
        private void EntitiesCountValueChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                geneticAlgoritm.EntitiesCount = (int) entitiesCountNumericUpDown.Value;
            }
        }

        private void SelectedByFEntitiesCountValueChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                geneticAlgoritm.AmountSortedEntities = (int) selectedByFEntitiesNumericUpDown.Value;
            }
        }

        private void CrossPointsValueChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                geneticAlgoritm.Hybridize = new Hybridizer(searchAreaSize, new int[] { (int)crossPointNumericUpDown1.Value, (int)crossPointNumericUpDown2.Value });
            }
        }

        private void MutationPercentValueChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                geneticAlgoritm.PerformMutation = new Mutation(searchAreaSize, (int) mutationPercentNumericUpDown.Value);
            }
        }

        private void GridTypeChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                geneticAlgoritm.Grid = (IGrid)Activator.CreateInstance(grids[gridComboBox.Text], searchAreaSize, (int)entitiesCountNumericUpDown.Value);
            }
        }

        private void SelectionTypeChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                geneticAlgoritm.Selection = (ISelection)Activator.CreateInstance(selections[selectionComboBox.Text], (int)selectedEntitiesNumericUpDown.Value);
            }
        }

        private void DivisionTypeChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                geneticAlgoritm.EntitiesDivision = (IDividable)Activator.CreateInstance(divisions[divisionComboBox.Text]);
            }
        }


    }
}
