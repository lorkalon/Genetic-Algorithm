using System;
using System.Collections;
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
        private Dictionary<string, Type> gridsDictionary = new Dictionary<string, Type>() { { "Random", typeof(RandomGrid) }, { "Triangle", typeof(TriangleGrid) }, { "Square", typeof(SquareGrid) } };
        private Dictionary<string, Type> divisionsDictionary = new Dictionary<string, Type>() { { "Center", typeof(CenterDivision) }, { "Even", typeof(EvenDivision) } };
        private Dictionary<string, Type> selectionFromGroupsDictionary = new Dictionary<string, Type>() { { "Roulette", typeof(Roulette) }, { "Tournament", typeof(Tournament) }, { "From Sorted", typeof(SelectionSortedEntities) } };
        private Dictionary<string, Type> selectionFromGenerationDictionary = new Dictionary<string, Type>() { { "Roulette", typeof(Roulette) }, { "Tournament", typeof(Tournament) }, { "From Sorted", typeof(SelectionSortedEntities) } };
        private bool formLoaded = false;
        private bool settingsChanged = false;

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

            legendPictureBox.Image = EntitiesDrawer.DrawLegend();
            Statistics.TreeViewStatistics = entitiesTreeView;
        }

        private void InitializeComboBoxControls()
        {
            gridComboBox.Items.AddRange(gridsDictionary.Keys.ToArray());
            gridComboBox.SelectedIndex = 0;

            divisionComboBox.Items.AddRange(divisionsDictionary.Keys.ToArray());
            divisionComboBox.SelectedIndex = 0;

            selectionFromGroupsComboBox.Items.AddRange(selectionFromGroupsDictionary.Keys.ToArray());
            selectionFromGroupsComboBox.SelectedIndex = 0;

            selectionFromGenerationComboBox.Items.AddRange(selectionFromGenerationDictionary.Keys.ToArray());
            selectionFromGenerationComboBox.SelectedIndex = 0;
        }

        private void InitializeGeneticAlgorithmProperties()
        {
            //geneticAlgoritm = (int) entitiesCountNumericUpDown.Value;    
            //geneticAlgoritm.SelectionFromGroupsCount = (int)selectionFromGroupsCountNumericUpDown.Value;
            //geneticAlgoritm.SelectionFromGenerationCount = (int) selectionFromGenerationCountNumericUpDown.Value;

            geneticAlgoritm.Hybridize = new Hybridizer(searchAreaSize, new int[] { (int)crossPointNumericUpDown1.Value, (int)crossPointNumericUpDown2.Value });
            geneticAlgoritm.PerformMutation = new Mutation(searchAreaSize, (int)mutationPercentNumericUpDown.Value);

            geneticAlgoritm.Grid = (IGrid)Activator.CreateInstance(gridsDictionary[gridComboBox.Text], searchAreaSize, (int)entitiesCountNumericUpDown.Value);
            geneticAlgoritm.SelectionFromGroups = (ISelection)Activator.CreateInstance(selectionFromGroupsDictionary[selectionFromGroupsComboBox.Text], (int)selectionFromGroupsCountNumericUpDown.Value);
            geneticAlgoritm.EntitiesDivision = (IDividable)Activator.CreateInstance(divisionsDictionary[divisionComboBox.Text]);
            geneticAlgoritm.SelectionFromGeneration = (ISelection)Activator.CreateInstance(selectionFromGenerationDictionary[selectionFromGenerationComboBox.Text], (int)selectionFromGenerationCountNumericUpDown.Value);
        }

        private int GetCyclesCount()
        {
            return (int)settingsReader.GetValue("cyclesCount", typeof(int));
        }

        private SearchArea GetAreaSize()
        {
            int serchAreaLeftBorder = (int)settingsReader.GetValue("serchAreaLeftBorder", typeof(int));
            int serchAreaRightBorder = (int)settingsReader.GetValue("serchAreaRightBorder", typeof(int));
            int serchAreaBottomBorder = (int)settingsReader.GetValue("serchAreaBottomBorder", typeof(int));
            int serchAreaTopBorder = (int)settingsReader.GetValue("serchAreaTopBorder", typeof(int));
            SearchArea searchAreaSize = new SearchArea(serchAreaLeftBorder, serchAreaRightBorder, serchAreaBottomBorder, serchAreaTopBorder);
            return searchAreaSize;
        }

        private void ExecuteGeneticAlgorithmButton_Click(object sender, EventArgs e)
        {
            if (entitiesTreeView.Nodes.Count >= 100 || settingsChanged)
            {
                Statistics.ClearTreeView();
            }
            geneticAlgoritm.SetLogOn();
            geneticAlgoritm.ExecuteGeneticAlgorithm();
            this.illustrationPictureBox.Image = EntitiesDrawer.GetIllustrationCanvas();
            settingsChanged = false;
        }

        private void ExecuteOneStepButton_Click(object sender, EventArgs e)
        {
            if (entitiesTreeView.Nodes.Count >= 100 || settingsChanged)
            {
                Statistics.ClearTreeView();
            }
            geneticAlgoritm.SetLogOn();
            geneticAlgoritm.ExecuteOneStep();
            this.illustrationPictureBox.Image = EntitiesDrawer.GetIllustrationCanvas();
            settingsChanged = false;
        }

        // ------------------- обработчики изменений настроек -------------------------

        private void CrossPointsValueChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                geneticAlgoritm.Hybridize = new Hybridizer(searchAreaSize, new int[] { (int)crossPointNumericUpDown1.Value, (int)crossPointNumericUpDown2.Value });
                settingsChanged = true;
            }
        }

        private void MutationPercentValueChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                geneticAlgoritm.PerformMutation = new Mutation(searchAreaSize, (int)mutationPercentNumericUpDown.Value);
                settingsChanged = true;
            }
        }

        private void GridTypeChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                geneticAlgoritm.Grid = (IGrid)Activator.CreateInstance(gridsDictionary[gridComboBox.Text], searchAreaSize, (int)entitiesCountNumericUpDown.Value);
                settingsChanged = true;
            }
        }

        private void SelectionFromGroupsTypeChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                geneticAlgoritm.SelectionFromGroups = (ISelection)Activator.CreateInstance(selectionFromGroupsDictionary[selectionFromGroupsComboBox.Text], 
                    (int)selectionFromGroupsCountNumericUpDown.Value);
                settingsChanged = true;
            }
        }

        private void SelectionFromGenerationTypeChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                geneticAlgoritm.SelectionFromGeneration = (ISelection)Activator.CreateInstance(selectionFromGenerationDictionary[selectionFromGroupsComboBox.Text], 
                    (int)selectionFromGenerationCountNumericUpDown.Value);
                settingsChanged = true;
            }
        }

        private void DivisionTypeChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                geneticAlgoritm.EntitiesDivision = (IDividable)Activator.CreateInstance(divisionsDictionary[divisionComboBox.Text]);
                settingsChanged = true;
            }
        }


    }
}
