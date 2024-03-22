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
            SuspendLayout();
            // 
            // startButton
            // 
            startButton.Location = new Point(0, 0);
            startButton.Name = "startButton";
            startButton.Size = new Size(112, 34);
            startButton.TabIndex = 0;
            startButton.Text = "Start game";
            startButton.UseVisualStyleBackColor = true;
            startButton.Click += button1_Click;
            // 
            // StartMenu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(startButton);
            Name = "StartMenu";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private Button startButton;
    }
}