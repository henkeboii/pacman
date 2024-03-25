using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Maze2
{
    public partial class StartMenu : Form
    {
        //music kommer att spela upp PacMan-Theme.wav tills universums värmedöd
        //eller att programmet avslutas, vilken som än kommer först.
        MediaPlayer music = new MediaPlayer();
        

        public StartMenu()
        {
            InitializeComponent();

            music.MediaEnded += OnMediaEnded;

            PlayMusic();
        }

        /// <summary>
        /// Om startknappen trycks ska spelfönstret öppnas och startmenyn döljas.
        /// När spelfönstret stängs ska startmenyn synas igen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click(object sender, EventArgs e)
        {
            Game gameForm = new Game();

            this.Hide();

            gameForm.ShowDialog();

            this.Show();
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

            settings.ShowDialog();
            
            music.Volume = settings.Volume;
            
        }

        /// <summary>
        /// Initiera Mediaplayern music och börja spela musiken
        /// </summary>
        private void PlayMusic()
        {
            music.Open(new Uri("Audio/PacMan-Theme.wav", UriKind.Relative));
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
