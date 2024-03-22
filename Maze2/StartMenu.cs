using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze2
{
    public partial class StartMenu : Form
    {
        Game gameForm = new Game();

        public StartMenu()
        {
            InitializeComponent();
        }
        void initalizeSound()
        {
            System.Media.SoundPlayer GameMusic = new System.Media.SoundPlayer(Properties.Resources.ytmp3free_cc_pacman_original_theme_youtubemp3free_org);
            GameMusic.Play();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            initalizeSound();
            gameForm.ShowDialog();
            this.Close();
        }
    }
}
