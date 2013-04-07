namespace GeneticAlgoritm
{
    partial class EntitiesView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.initialCountLabel = new System.Windows.Forms.Label();
            this.entitiesCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.selectionFromGenerationCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.legendPictureBox = new System.Windows.Forms.PictureBox();
            this.executeGeneticAlgorithmButton = new System.Windows.Forms.Button();
            this.executeOneStepButton = new System.Windows.Forms.Button();
            this.crossPointNumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.selectionFromGroupsCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.mutationPercentNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.crossPointNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.selectionFromGenerationComboBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.divisionComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.selectionFromGroupsComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gridComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.illustrationPictureBox = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.entitiesTreeView = new System.Windows.Forms.TreeView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.startFindingBestAlgorithmButton = new System.Windows.Forms.Button();
            this.algorithmStatisticDataGridView = new System.Windows.Forms.DataGridView();
            this.findBestAlgorithmBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.entitiesCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectionFromGenerationCountNumericUpDown)).BeginInit();
            this.settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.legendPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crossPointNumericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectionFromGroupsCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationPercentNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crossPointNumericUpDown1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.illustrationPictureBox)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.algorithmStatisticDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // initialCountLabel
            // 
            this.initialCountLabel.AutoSize = true;
            this.initialCountLabel.Location = new System.Drawing.Point(78, 14);
            this.initialCountLabel.Name = "initialCountLabel";
            this.initialCountLabel.Size = new System.Drawing.Size(74, 13);
            this.initialCountLabel.TabIndex = 1;
            this.initialCountLabel.Text = "Entities count:";
            // 
            // entitiesCountNumericUpDown
            // 
            this.entitiesCountNumericUpDown.Location = new System.Drawing.Point(167, 12);
            this.entitiesCountNumericUpDown.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.entitiesCountNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.entitiesCountNumericUpDown.Name = "entitiesCountNumericUpDown";
            this.entitiesCountNumericUpDown.Size = new System.Drawing.Size(56, 20);
            this.entitiesCountNumericUpDown.TabIndex = 2;
            this.entitiesCountNumericUpDown.Value = new decimal(new int[] {
            14,
            0,
            0,
            0});
            this.entitiesCountNumericUpDown.ValueChanged += new System.EventHandler(this.GridTypeChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Selected from generation count:";
            // 
            // selectionFromGenerationCountNumericUpDown
            // 
            this.selectionFromGenerationCountNumericUpDown.Location = new System.Drawing.Point(168, 225);
            this.selectionFromGenerationCountNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.selectionFromGenerationCountNumericUpDown.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.selectionFromGenerationCountNumericUpDown.Name = "selectionFromGenerationCountNumericUpDown";
            this.selectionFromGenerationCountNumericUpDown.Size = new System.Drawing.Size(53, 20);
            this.selectionFromGenerationCountNumericUpDown.TabIndex = 2;
            this.selectionFromGenerationCountNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.selectionFromGenerationCountNumericUpDown.ValueChanged += new System.EventHandler(this.SelectionFromGenerationTypeChanged);
            // 
            // settingsPanel
            // 
            this.settingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settingsPanel.Controls.Add(this.legendPictureBox);
            this.settingsPanel.Controls.Add(this.executeGeneticAlgorithmButton);
            this.settingsPanel.Controls.Add(this.executeOneStepButton);
            this.settingsPanel.Controls.Add(this.crossPointNumericUpDown2);
            this.settingsPanel.Controls.Add(this.selectionFromGroupsCountNumericUpDown);
            this.settingsPanel.Controls.Add(this.mutationPercentNumericUpDown);
            this.settingsPanel.Controls.Add(this.label7);
            this.settingsPanel.Controls.Add(this.crossPointNumericUpDown1);
            this.settingsPanel.Controls.Add(this.label6);
            this.settingsPanel.Controls.Add(this.label5);
            this.settingsPanel.Controls.Add(this.selectionFromGenerationComboBox);
            this.settingsPanel.Controls.Add(this.label8);
            this.settingsPanel.Controls.Add(this.divisionComboBox);
            this.settingsPanel.Controls.Add(this.label4);
            this.settingsPanel.Controls.Add(this.selectionFromGroupsComboBox);
            this.settingsPanel.Controls.Add(this.label3);
            this.settingsPanel.Controls.Add(this.gridComboBox);
            this.settingsPanel.Controls.Add(this.label2);
            this.settingsPanel.Controls.Add(this.label1);
            this.settingsPanel.Controls.Add(this.initialCountLabel);
            this.settingsPanel.Controls.Add(this.entitiesCountNumericUpDown);
            this.settingsPanel.Controls.Add(this.selectionFromGenerationCountNumericUpDown);
            this.settingsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.settingsPanel.Location = new System.Drawing.Point(667, 0);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(247, 632);
            this.settingsPanel.TabIndex = 3;
            // 
            // legendPictureBox
            // 
            this.legendPictureBox.Location = new System.Drawing.Point(29, 463);
            this.legendPictureBox.Name = "legendPictureBox";
            this.legendPictureBox.Size = new System.Drawing.Size(191, 156);
            this.legendPictureBox.TabIndex = 9;
            this.legendPictureBox.TabStop = false;
            // 
            // executeGeneticAlgorithmButton
            // 
            this.executeGeneticAlgorithmButton.Location = new System.Drawing.Point(25, 421);
            this.executeGeneticAlgorithmButton.Name = "executeGeneticAlgorithmButton";
            this.executeGeneticAlgorithmButton.Size = new System.Drawing.Size(194, 23);
            this.executeGeneticAlgorithmButton.TabIndex = 8;
            this.executeGeneticAlgorithmButton.Text = "Execute genetic algorithm";
            this.executeGeneticAlgorithmButton.UseVisualStyleBackColor = true;
            this.executeGeneticAlgorithmButton.Click += new System.EventHandler(this.ExecuteGeneticAlgorithmButton_Click);
            // 
            // executeOneStepButton
            // 
            this.executeOneStepButton.Location = new System.Drawing.Point(25, 380);
            this.executeOneStepButton.Name = "executeOneStepButton";
            this.executeOneStepButton.Size = new System.Drawing.Size(194, 23);
            this.executeOneStepButton.TabIndex = 8;
            this.executeOneStepButton.Text = "Execute one step";
            this.executeOneStepButton.UseVisualStyleBackColor = true;
            this.executeOneStepButton.Click += new System.EventHandler(this.ExecuteOneStepButton_Click);
            // 
            // crossPointNumericUpDown2
            // 
            this.crossPointNumericUpDown2.Location = new System.Drawing.Point(168, 336);
            this.crossPointNumericUpDown2.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.crossPointNumericUpDown2.Name = "crossPointNumericUpDown2";
            this.crossPointNumericUpDown2.Size = new System.Drawing.Size(53, 20);
            this.crossPointNumericUpDown2.TabIndex = 6;
            this.crossPointNumericUpDown2.Value = new decimal(new int[] {
            62,
            0,
            0,
            0});
            this.crossPointNumericUpDown2.ValueChanged += new System.EventHandler(this.CrossPointsValueChanged);
            // 
            // selectionFromGroupsCountNumericUpDown
            // 
            this.selectionFromGroupsCountNumericUpDown.Location = new System.Drawing.Point(169, 261);
            this.selectionFromGroupsCountNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.selectionFromGroupsCountNumericUpDown.Name = "selectionFromGroupsCountNumericUpDown";
            this.selectionFromGroupsCountNumericUpDown.Size = new System.Drawing.Size(53, 20);
            this.selectionFromGroupsCountNumericUpDown.TabIndex = 6;
            this.selectionFromGroupsCountNumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.selectionFromGroupsCountNumericUpDown.ValueChanged += new System.EventHandler(this.SelectionFromGroupsTypeChanged);
            // 
            // mutationPercentNumericUpDown
            // 
            this.mutationPercentNumericUpDown.Location = new System.Drawing.Point(167, 299);
            this.mutationPercentNumericUpDown.Name = "mutationPercentNumericUpDown";
            this.mutationPercentNumericUpDown.Size = new System.Drawing.Size(53, 20);
            this.mutationPercentNumericUpDown.TabIndex = 6;
            this.mutationPercentNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.mutationPercentNumericUpDown.ValueChanged += new System.EventHandler(this.MutationPercentValueChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(22, 261);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Selected from groups count:";
            // 
            // crossPointNumericUpDown1
            // 
            this.crossPointNumericUpDown1.Location = new System.Drawing.Point(101, 336);
            this.crossPointNumericUpDown1.Maximum = new decimal(new int[] {
            63,
            0,
            0,
            0});
            this.crossPointNumericUpDown1.Name = "crossPointNumericUpDown1";
            this.crossPointNumericUpDown1.Size = new System.Drawing.Size(53, 20);
            this.crossPointNumericUpDown1.TabIndex = 6;
            this.crossPointNumericUpDown1.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.crossPointNumericUpDown1.ValueChanged += new System.EventHandler(this.CrossPointsValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mutation percent:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cross bits:";
            // 
            // selectionFromGenerationComboBox
            // 
            this.selectionFromGenerationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectionFromGenerationComboBox.FormattingEnabled = true;
            this.selectionFromGenerationComboBox.Location = new System.Drawing.Point(101, 168);
            this.selectionFromGenerationComboBox.Name = "selectionFromGenerationComboBox";
            this.selectionFromGenerationComboBox.Size = new System.Drawing.Size(121, 21);
            this.selectionFromGenerationComboBox.TabIndex = 4;
            this.selectionFromGenerationComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectionFromGenerationTypeChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 33);
            this.label8.TabIndex = 3;
            this.label8.Text = "Selection from generation:";
            // 
            // divisionComboBox
            // 
            this.divisionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.divisionComboBox.FormattingEnabled = true;
            this.divisionComboBox.Location = new System.Drawing.Point(102, 132);
            this.divisionComboBox.Name = "divisionComboBox";
            this.divisionComboBox.Size = new System.Drawing.Size(121, 21);
            this.divisionComboBox.TabIndex = 4;
            this.divisionComboBox.SelectionChangeCommitted += new System.EventHandler(this.DivisionTypeChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Division:";
            // 
            // selectionFromGroupsComboBox
            // 
            this.selectionFromGroupsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectionFromGroupsComboBox.FormattingEnabled = true;
            this.selectionFromGroupsComboBox.Location = new System.Drawing.Point(102, 96);
            this.selectionFromGroupsComboBox.Name = "selectionFromGroupsComboBox";
            this.selectionFromGroupsComboBox.Size = new System.Drawing.Size(121, 21);
            this.selectionFromGroupsComboBox.TabIndex = 4;
            this.selectionFromGroupsComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectionFromGroupsTypeChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 39);
            this.label3.TabIndex = 3;
            this.label3.Text = "Selection from groups:";
            // 
            // gridComboBox
            // 
            this.gridComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gridComboBox.FormattingEnabled = true;
            this.gridComboBox.Location = new System.Drawing.Point(102, 59);
            this.gridComboBox.Name = "gridComboBox";
            this.gridComboBox.Size = new System.Drawing.Size(121, 21);
            this.gridComboBox.TabIndex = 4;
            this.gridComboBox.SelectedIndexChanged += new System.EventHandler(this.GridTypeChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Grid:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(661, 632);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.illustrationPictureBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(653, 606);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Graphics";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // illustrationPictureBox
            // 
            this.illustrationPictureBox.Location = new System.Drawing.Point(27, 3);
            this.illustrationPictureBox.Name = "illustrationPictureBox";
            this.illustrationPictureBox.Size = new System.Drawing.Size(600, 600);
            this.illustrationPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.illustrationPictureBox.TabIndex = 1;
            this.illustrationPictureBox.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.entitiesTreeView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(653, 606);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Statistics";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // entitiesTreeView
            // 
            this.entitiesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.entitiesTreeView.Location = new System.Drawing.Point(3, 3);
            this.entitiesTreeView.Name = "entitiesTreeView";
            this.entitiesTreeView.Size = new System.Drawing.Size(647, 600);
            this.entitiesTreeView.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.startFindingBestAlgorithmButton);
            this.tabPage3.Controls.Add(this.algorithmStatisticDataGridView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(653, 606);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Find best algorithm";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // startFindingBestAlgorithmButton
            // 
            this.startFindingBestAlgorithmButton.Location = new System.Drawing.Point(518, 575);
            this.startFindingBestAlgorithmButton.Name = "startFindingBestAlgorithmButton";
            this.startFindingBestAlgorithmButton.Size = new System.Drawing.Size(129, 23);
            this.startFindingBestAlgorithmButton.TabIndex = 1;
            this.startFindingBestAlgorithmButton.Text = "Find best algorithm";
            this.startFindingBestAlgorithmButton.UseVisualStyleBackColor = true;
            this.startFindingBestAlgorithmButton.Click += new System.EventHandler(this.startFindingBestAlgorithmButton_Click);
            // 
            // algorithmStatisticDataGridView
            // 
            this.algorithmStatisticDataGridView.AllowUserToAddRows = false;
            this.algorithmStatisticDataGridView.AllowUserToDeleteRows = false;
            this.algorithmStatisticDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.algorithmStatisticDataGridView.Location = new System.Drawing.Point(8, 6);
            this.algorithmStatisticDataGridView.Name = "algorithmStatisticDataGridView";
            this.algorithmStatisticDataGridView.ReadOnly = true;
            this.algorithmStatisticDataGridView.Size = new System.Drawing.Size(639, 563);
            this.algorithmStatisticDataGridView.TabIndex = 0;
            // 
            // findBestAlgorithmBackgroundWorker
            // 
            this.findBestAlgorithmBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.findBestAlgorithmBackgroundWorker_DoWork);
            this.findBestAlgorithmBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.findBestAlgorithmBackgroundWorker_RunWorkerCompleted);
            // 
            // EntitiesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 632);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.settingsPanel);
            this.Name = "EntitiesView";
            this.Text = "Genetic algorithm";
            ((System.ComponentModel.ISupportInitialize)(this.entitiesCountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectionFromGenerationCountNumericUpDown)).EndInit();
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.legendPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crossPointNumericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectionFromGroupsCountNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationPercentNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crossPointNumericUpDown1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.illustrationPictureBox)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.algorithmStatisticDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label initialCountLabel;
        private System.Windows.Forms.NumericUpDown entitiesCountNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown selectionFromGenerationCountNumericUpDown;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.ComboBox gridComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox selectionFromGroupsComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox divisionComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown crossPointNumericUpDown2;
        private System.Windows.Forms.NumericUpDown crossPointNumericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown mutationPercentNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button executeGeneticAlgorithmButton;
        private System.Windows.Forms.Button executeOneStepButton;
        private System.Windows.Forms.NumericUpDown selectionFromGroupsCountNumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox illustrationPictureBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox legendPictureBox;

        private System.Windows.Forms.TreeView entitiesTreeView;
        private System.Windows.Forms.ComboBox selectionFromGenerationComboBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button startFindingBestAlgorithmButton;
        private System.Windows.Forms.DataGridView algorithmStatisticDataGridView;
        private System.ComponentModel.BackgroundWorker findBestAlgorithmBackgroundWorker;

    }
}

