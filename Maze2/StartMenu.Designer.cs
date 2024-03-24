namespace Maze2
{
    partial class StartMenu
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
            startButton = new Button();
            settingsButton = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.Location = new Point(130, 60);
            startButton.Name = "startButton";
            startButton.Size = new Size(112, 34);
            startButton.TabIndex = 0;
            startButton.Text = "Start game";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += startButton_Click;
            // 
            // settingsButton
            // 
            settingsButton.Location = new Point(130, 100);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new Size(112, 34);
            settingsButton.TabIndex = 1;
            settingsButton.Text = "Settings";
            settingsButton.UseVisualStyleBackColor = true;
            settingsButton.Click += settingsButton_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(130, 20);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(112, 31);
            textBox1.TabIndex = 2;
            textBox1.Text = "PAC-MAN";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // StartMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 149);
            Controls.Add(textBox1);
            Controls.Add(settingsButton);
            Controls.Add(startButton);
            Name = "StartMenu";
            Text = "Pac-Man Launcher";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button startButton;
        private Button settingsButton;
        private TextBox textBox1;
    }
}