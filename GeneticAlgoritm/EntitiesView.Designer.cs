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
            this.illustrationPictureBox = new System.Windows.Forms.PictureBox();
            this.initialCountLabel = new System.Windows.Forms.Label();
            this.initialCountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.illustrationPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.initialCountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // illustrationPictureBox
            // 
            this.illustrationPictureBox.Location = new System.Drawing.Point(12, 12);
            this.illustrationPictureBox.Name = "illustrationPictureBox";
            this.illustrationPictureBox.Size = new System.Drawing.Size(600, 600);
            this.illustrationPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.illustrationPictureBox.TabIndex = 0;
            this.illustrationPictureBox.TabStop = false;
            // 
            // initialCountLabel
            // 
            this.initialCountLabel.AutoSize = true;
            this.initialCountLabel.Location = new System.Drawing.Point(699, 12);
            this.initialCountLabel.Name = "initialCountLabel";
            this.initialCountLabel.Size = new System.Drawing.Size(100, 13);
            this.initialCountLabel.TabIndex = 1;
            this.initialCountLabel.Text = "Initial entities count:";
            // 
            // initialCountNumericUpDown
            // 
            this.initialCountNumericUpDown.Location = new System.Drawing.Point(805, 10);
            this.initialCountNumericUpDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.initialCountNumericUpDown.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.initialCountNumericUpDown.Name = "initialCountNumericUpDown";
            this.initialCountNumericUpDown.Size = new System.Drawing.Size(56, 20);
            this.initialCountNumericUpDown.TabIndex = 2;
            this.initialCountNumericUpDown.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // EntitiesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 625);
            this.Controls.Add(this.initialCountNumericUpDown);
            this.Controls.Add(this.initialCountLabel);
            this.Controls.Add(this.illustrationPictureBox);
            this.Name = "EntitiesView";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.EntitiesView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.illustrationPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.initialCountNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox illustrationPictureBox;
        private System.Windows.Forms.Label initialCountLabel;
        private System.Windows.Forms.NumericUpDown initialCountNumericUpDown;
    }
}

