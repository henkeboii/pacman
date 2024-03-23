using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Maze2
{
    public partial class StartMenu : Form
    {
        Game gameForm = new Game();

        Sound GameMusic = new Sound();

        public StartMenu()
        {
            InitializeComponent();
            initializeAudio();
        }

        void initializeAudio()
        {
            GameMusic.Play();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            gameForm.ShowDialog();
            this.Close();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();

            if (settings.ShowDialog() == DialogResult.OK)
            {
                GameMusic.SetVolume(settings.Volume);
            }
        }
        
        
    }
}
