using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticAlgoritm
{
    public partial class EntitiesView : Form
    {
        private Stopwatch stopwatch = new Stopwatch();

        private GeneticAlgorithmCore geneticAlgoritm;

        private AppSettingsReader settingsReader;

        private SearchArea searchAreaSize;

        private int cycles;
        
        private bool formLoaded = false;
        private bool settingsChanged = false;

        public EntitiesView()
        {
            InitializeComponent();

            settingsReader = new AppSettingsReader();
            InitializeComboBoxControls();
            searchAreaSize = ConfigurationManager.GetAreaSize();
            cycles = ConfigurationManager.GetCyclesCount();

            geneticAlgoritm = new GeneticAlgorithmCore(searchAreaSize, cycles);
            InitializeGeneticAlgorithmProperties();
            formLoaded = true;

            legendPictureBox.Image = EntitiesDrawer.DrawLegend();
            Statistics.TreeViewStatistics = entitiesTreeView;
        }

        private void InitializeComboBoxControls()
        {
            gridComboBox.Items.AddRange(SubAlgorithmsManager.GridsDictionary.Keys.ToArray());
            gridComboBox.SelectedIndex = 0;

            divisionComboBox.Items.AddRange(SubAlgorithmsManager.DivisionsDictionary.Keys.ToArray());
            divisionComboBox.SelectedIndex = 0;

            selectionFromGroupsComboBox.Items.AddRange(SubAlgorithmsManager.SelectionFromGroupsDictionary.Keys.ToArray());
            selectionFromGroupsComboBox.SelectedIndex = 0;

            selectionFromGenerationComboBox.Items.AddRange(SubAlgorithmsManager.SelectionFromGenerationDictionary.Keys.ToArray());
            selectionFromGenerationComboBox.SelectedIndex = 0;
        }

        private void InitializeGeneticAlgorithmProperties()
        {
            geneticAlgoritm.Hybridize = new Hybridizer(searchAreaSize, new int[] { (int)crossPointNumericUpDown1.Value, (int)crossPointNumericUpDown2.Value });
            geneticAlgoritm.PerformMutation = new Mutation(searchAreaSize, (int)mutationPercentNumericUpDown.Value);

            geneticAlgoritm.Grid = (IGrid)Activator.CreateInstance(SubAlgorithmsManager.GridsDictionary[gridComboBox.Text], searchAreaSize, (int)entitiesCountNumericUpDown.Value);
            geneticAlgoritm.SelectionFromGroups = (ISelection)Activator.CreateInstance(SubAlgorithmsManager.SelectionFromGroupsDictionary[selectionFromGroupsComboBox.Text], (int)selectionFromGroupsCountNumericUpDown.Value);
            geneticAlgoritm.EntitiesDivision = (IDividable)Activator.CreateInstance(SubAlgorithmsManager.DivisionsDictionary[divisionComboBox.Text]);
            geneticAlgoritm.SelectionFromGeneration = (ISelection)Activator.CreateInstance(SubAlgorithmsManager.SelectionFromGenerationDictionary[selectionFromGenerationComboBox.Text], (int)selectionFromGenerationCountNumericUpDown.Value);
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
                geneticAlgoritm.Grid = (IGrid)Activator.CreateInstance(SubAlgorithmsManager.GridsDictionary[gridComboBox.Text], searchAreaSize, (int)entitiesCountNumericUpDown.Value);
                settingsChanged = true;
            }
        }

        private void SelectionFromGroupsTypeChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                geneticAlgoritm.SelectionFromGroups = (ISelection)Activator.CreateInstance(SubAlgorithmsManager.SelectionFromGroupsDictionary[selectionFromGroupsComboBox.Text], 
                    (int)selectionFromGroupsCountNumericUpDown.Value);
                settingsChanged = true;
            }
        }

        private void SelectionFromGenerationTypeChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                geneticAlgoritm.SelectionFromGeneration = (ISelection)Activator.CreateInstance(SubAlgorithmsManager.SelectionFromGenerationDictionary[selectionFromGroupsComboBox.Text], 
                    (int)selectionFromGenerationCountNumericUpDown.Value);
                settingsChanged = true;
            }
        }

        private void DivisionTypeChanged(object sender, EventArgs e)
        {
            if (formLoaded)
            {
                geneticAlgoritm.EntitiesDivision = (IDividable)Activator.CreateInstance(SubAlgorithmsManager.DivisionsDictionary[divisionComboBox.Text]);
                settingsChanged = true;
            }
        }

        private void startFindingBestAlgorithmButton_Click(object sender, EventArgs e)
        {
            stopwatch.Restart();

            findBestAlgorithmBackgroundWorker.RunWorkerAsync();
        }

        private void findBestAlgorithmBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BestAlgorithmFinder bestAlgorithmFinder = new BestAlgorithmFinder(1);
            e.Result = bestAlgorithmFinder.FindBestAlgorithm();
        }

        private void findBestAlgorithmBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<AlgorithmStatistic> algorithmsStatistics = e.Result as List<AlgorithmStatistic>;
            algorithmStatisticDataGridView.DataSource = algorithmsStatistics;
            algorithmStatisticDataGridView.AutoResizeColumns();

            stopwatch.Stop();
            this.Text = stopwatch.Elapsed.ToString();
        }
    }
}
