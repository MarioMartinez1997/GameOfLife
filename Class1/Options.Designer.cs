namespace Class1
{
    partial class Options
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownTimerInterval = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWidthUniverseCells = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownHeightUniverseCells = new System.Windows.Forms.NumericUpDown();
            this.buttonOkOptionsDialog = new System.Windows.Forms.Button();
            this.buttonCancelOptionsDialog = new System.Windows.Forms.Button();
            this.buttonResetColorOption = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimerInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidthUniverseCells)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeightUniverseCells)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(2, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(438, 311);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.numericUpDownHeightUniverseCells);
            this.tabPage1.Controls.Add(this.numericUpDownWidthUniverseCells);
            this.tabPage1.Controls.Add(this.numericUpDownTimerInterval);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(430, 285);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonResetColorOption);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(430, 285);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(430, 285);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Advanced";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Timer Interval in Milliseconds";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Width of Universe in Cells";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Height of Universe in Cells";
            // 
            // numericUpDownTimerInterval
            // 
            this.numericUpDownTimerInterval.Location = new System.Drawing.Point(182, 21);
            this.numericUpDownTimerInterval.Name = "numericUpDownTimerInterval";
            this.numericUpDownTimerInterval.Size = new System.Drawing.Size(83, 20);
            this.numericUpDownTimerInterval.TabIndex = 3;
            // 
            // numericUpDownWidthUniverseCells
            // 
            this.numericUpDownWidthUniverseCells.Location = new System.Drawing.Point(182, 57);
            this.numericUpDownWidthUniverseCells.Name = "numericUpDownWidthUniverseCells";
            this.numericUpDownWidthUniverseCells.Size = new System.Drawing.Size(83, 20);
            this.numericUpDownWidthUniverseCells.TabIndex = 4;
            // 
            // numericUpDownHeightUniverseCells
            // 
            this.numericUpDownHeightUniverseCells.Location = new System.Drawing.Point(182, 100);
            this.numericUpDownHeightUniverseCells.Name = "numericUpDownHeightUniverseCells";
            this.numericUpDownHeightUniverseCells.Size = new System.Drawing.Size(83, 20);
            this.numericUpDownHeightUniverseCells.TabIndex = 5;
            // 
            // buttonOkOptionsDialog
            // 
            this.buttonOkOptionsDialog.Location = new System.Drawing.Point(9, 314);
            this.buttonOkOptionsDialog.Name = "buttonOkOptionsDialog";
            this.buttonOkOptionsDialog.Size = new System.Drawing.Size(75, 23);
            this.buttonOkOptionsDialog.TabIndex = 1;
            this.buttonOkOptionsDialog.Text = "OK";
            this.buttonOkOptionsDialog.UseVisualStyleBackColor = true;
            // 
            // buttonCancelOptionsDialog
            // 
            this.buttonCancelOptionsDialog.Location = new System.Drawing.Point(101, 314);
            this.buttonCancelOptionsDialog.Name = "buttonCancelOptionsDialog";
            this.buttonCancelOptionsDialog.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelOptionsDialog.TabIndex = 2;
            this.buttonCancelOptionsDialog.Text = "Cancel";
            this.buttonCancelOptionsDialog.UseVisualStyleBackColor = true;
            // 
            // buttonResetColorOption
            // 
            this.buttonResetColorOption.Location = new System.Drawing.Point(6, 254);
            this.buttonResetColorOption.Name = "buttonResetColorOption";
            this.buttonResetColorOption.Size = new System.Drawing.Size(75, 23);
            this.buttonResetColorOption.TabIndex = 3;
            this.buttonResetColorOption.Text = "Reset";
            this.buttonResetColorOption.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 345);
            this.Controls.Add(this.buttonCancelOptionsDialog);
            this.Controls.Add(this.buttonOkOptionsDialog);
            this.Controls.Add(this.tabControl1);
            this.Name = "Options";
            this.Text = "Options";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimerInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidthUniverseCells)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeightUniverseCells)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NumericUpDown numericUpDownHeightUniverseCells;
        private System.Windows.Forms.NumericUpDown numericUpDownWidthUniverseCells;
        private System.Windows.Forms.NumericUpDown numericUpDownTimerInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonResetColorOption;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonOkOptionsDialog;
        private System.Windows.Forms.Button buttonCancelOptionsDialog;
    }
}