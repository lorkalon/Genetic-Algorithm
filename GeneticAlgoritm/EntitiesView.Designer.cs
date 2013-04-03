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
            this.selectedByFEntitiesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.settingsPanel = new System.Windows.Forms.Panel();
            this.executeGeneticAlgorithmButton = new System.Windows.Forms.Button();
            this.executeOneStepButton = new System.Windows.Forms.Button();
            this.crossPointNumericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.selectedEntitiesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.mutationPercentNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.crossPointNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.divisionComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.selectionComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gridComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.illustrationPictureBox = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.entitiesCountNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedByFEntitiesNumericUpDown)).BeginInit();
            this.settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crossPointNumericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedEntitiesNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationPercentNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crossPointNumericUpDown1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.illustrationPictureBox)).BeginInit();
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
            this.entitiesCountNumericUpDown.ValueChanged += new System.EventHandler(this.EntitiesCountValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Amount of selected by F entities:";
            // 
            // selectedByFEntitiesNumericUpDown
            // 
            this.selectedByFEntitiesNumericUpDown.Location = new System.Drawing.Point(167, 38);
            this.selectedByFEntitiesNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.selectedByFEntitiesNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.selectedByFEntitiesNumericUpDown.Name = "selectedByFEntitiesNumericUpDown";
            this.selectedByFEntitiesNumericUpDown.Size = new System.Drawing.Size(56, 20);
            this.selectedByFEntitiesNumericUpDown.TabIndex = 2;
            this.selectedByFEntitiesNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.selectedByFEntitiesNumericUpDown.ValueChanged += new System.EventHandler(this.SelectedByFEntitiesCountValueChanged);
            // 
            // settingsPanel
            // 
            this.settingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.settingsPanel.Controls.Add(this.executeGeneticAlgorithmButton);
            this.settingsPanel.Controls.Add(this.executeOneStepButton);
            this.settingsPanel.Controls.Add(this.crossPointNumericUpDown2);
            this.settingsPanel.Controls.Add(this.selectedEntitiesNumericUpDown);
            this.settingsPanel.Controls.Add(this.mutationPercentNumericUpDown);
            this.settingsPanel.Controls.Add(this.label7);
            this.settingsPanel.Controls.Add(this.crossPointNumericUpDown1);
            this.settingsPanel.Controls.Add(this.label6);
            this.settingsPanel.Controls.Add(this.label5);
            this.settingsPanel.Controls.Add(this.divisionComboBox);
            this.settingsPanel.Controls.Add(this.label4);
            this.settingsPanel.Controls.Add(this.selectionComboBox);
            this.settingsPanel.Controls.Add(this.label3);
            this.settingsPanel.Controls.Add(this.gridComboBox);
            this.settingsPanel.Controls.Add(this.label2);
            this.settingsPanel.Controls.Add(this.label1);
            this.settingsPanel.Controls.Add(this.initialCountLabel);
            this.settingsPanel.Controls.Add(this.entitiesCountNumericUpDown);
            this.settingsPanel.Controls.Add(this.selectedByFEntitiesNumericUpDown);
            this.settingsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.settingsPanel.Location = new System.Drawing.Point(667, 0);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(247, 632);
            this.settingsPanel.TabIndex = 3;
            // 
            // executeGeneticAlgorithmButton
            // 
            this.executeGeneticAlgorithmButton.Location = new System.Drawing.Point(29, 425);
            this.executeGeneticAlgorithmButton.Name = "executeGeneticAlgorithmButton";
            this.executeGeneticAlgorithmButton.Size = new System.Drawing.Size(194, 23);
            this.executeGeneticAlgorithmButton.TabIndex = 8;
            this.executeGeneticAlgorithmButton.Text = "Execute genetic algorithm";
            this.executeGeneticAlgorithmButton.UseVisualStyleBackColor = true;
            this.executeGeneticAlgorithmButton.Click += new System.EventHandler(this.ExecuteGeneticAlgorithmButton_Click);
            // 
            // executeOneStepButton
            // 
            this.executeOneStepButton.Location = new System.Drawing.Point(29, 384);
            this.executeOneStepButton.Name = "executeOneStepButton";
            this.executeOneStepButton.Size = new System.Drawing.Size(194, 23);
            this.executeOneStepButton.TabIndex = 8;
            this.executeOneStepButton.Text = "Execute one step";
            this.executeOneStepButton.UseVisualStyleBackColor = true;
            this.executeOneStepButton.Click += new System.EventHandler(this.executeOneStepButton_Click);
            // 
            // crossPointNumericUpDown2
            // 
            this.crossPointNumericUpDown2.Location = new System.Drawing.Point(167, 200);
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
            // selectedEntitiesNumericUpDown
            // 
            this.selectedEntitiesNumericUpDown.Location = new System.Drawing.Point(110, 273);
            this.selectedEntitiesNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.selectedEntitiesNumericUpDown.Name = "selectedEntitiesNumericUpDown";
            this.selectedEntitiesNumericUpDown.Size = new System.Drawing.Size(53, 20);
            this.selectedEntitiesNumericUpDown.TabIndex = 6;
            this.selectedEntitiesNumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.selectedEntitiesNumericUpDown.ValueChanged += new System.EventHandler(this.SelectionTypeChanged);
            // 
            // mutationPercentNumericUpDown
            // 
            this.mutationPercentNumericUpDown.Location = new System.Drawing.Point(108, 237);
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
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 275);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Selected entities:";
            // 
            // crossPointNumericUpDown1
            // 
            this.crossPointNumericUpDown1.Location = new System.Drawing.Point(108, 200);
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
            this.label6.Location = new System.Drawing.Point(3, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mutation percent:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Cross bits:";
            // 
            // divisionComboBox
            // 
            this.divisionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.divisionComboBox.FormattingEnabled = true;
            this.divisionComboBox.Location = new System.Drawing.Point(102, 160);
            this.divisionComboBox.Name = "divisionComboBox";
            this.divisionComboBox.Size = new System.Drawing.Size(121, 21);
            this.divisionComboBox.TabIndex = 4;
            this.divisionComboBox.SelectionChangeCommitted += new System.EventHandler(this.DivisionTypeChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Division:";
            // 
            // selectionComboBox
            // 
            this.selectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectionComboBox.FormattingEnabled = true;
            this.selectionComboBox.Location = new System.Drawing.Point(102, 124);
            this.selectionComboBox.Name = "selectionComboBox";
            this.selectionComboBox.Size = new System.Drawing.Size(121, 21);
            this.selectionComboBox.TabIndex = 4;
            this.selectionComboBox.SelectedIndexChanged += new System.EventHandler(this.SelectionTypeChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Selection:";
            // 
            // gridComboBox
            // 
            this.gridComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gridComboBox.FormattingEnabled = true;
            this.gridComboBox.Location = new System.Drawing.Point(102, 87);
            this.gridComboBox.Name = "gridComboBox";
            this.gridComboBox.Size = new System.Drawing.Size(121, 21);
            this.gridComboBox.TabIndex = 4;
            this.gridComboBox.SelectedIndexChanged += new System.EventHandler(this.GridTypeChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Grid:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(653, 606);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Statistics";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.selectedByFEntitiesNumericUpDown)).EndInit();
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.crossPointNumericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedEntitiesNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mutationPercentNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crossPointNumericUpDown1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.illustrationPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label initialCountLabel;
        private System.Windows.Forms.NumericUpDown entitiesCountNumericUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown selectedByFEntitiesNumericUpDown;
        private System.Windows.Forms.Panel settingsPanel;
        private System.Windows.Forms.ComboBox gridComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox selectionComboBox;
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
        private System.Windows.Forms.NumericUpDown selectedEntitiesNumericUpDown;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.PictureBox illustrationPictureBox;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

