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

        MediaPlayer music = new MediaPlayer();
        

        public StartMenu()
        {
            InitializeComponent();

            music.MediaEnded += OnMediaEnded;

            PlayMusic();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            gameForm.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Öppnar settings
        /// Ändrar musikvolymen till angivet värde i settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void settingsButton_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings(music.Volume);

            if (settings.ShowDialog() == DialogResult.OK)
            {
                music.Volume = settings.Volume;
            }
        }

        private void PlayMusic()
        {
            music.Open(new Uri("file:///c:/pacman-theme.wav"));

            music.Play();
        }

        /// <summary>
        /// Eventet att spåret som music spelar upp
        /// tar slut.
        /// Då ska music upprepa spåret.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnMediaEnded(object? sender, EventArgs e)
        {
            PlayMusic();
        }
    }
}
