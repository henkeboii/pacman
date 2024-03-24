namespace Maze2
{
    partial class Settings
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
            numericUpDown1 = new NumericUpDown();
            saveButton = new Button();
            resetButton = new Button();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(12, 52);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 31);
            numericUpDown1.TabIndex = 4;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(162, 96);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(112, 34);
            saveButton.TabIndex = 5;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // resetButton
            // 
            resetButton.Location = new Point(10, 96);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(146, 34);
            resetButton.TabIndex = 6;
            resetButton.Text = "Reset to default";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 15);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(72, 31);
            textBox1.TabIndex = 7;
            textBox1.Text = "Volume";
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(328, 134);
            Controls.Add(textBox1);
            Controls.Add(resetButton);
            Controls.Add(saveButton);
            Controls.Add(numericUpDown1);
            Name = "Settings";
            Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NumericUpDown numericUpDown1;
        private Button saveButton;
        private Button resetButton;
        private TextBox textBox1;
    }
}