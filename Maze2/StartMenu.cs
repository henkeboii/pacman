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

        public class Sound
        {
            private MediaPlayer m_mediaPlayer;
            public void Play()
            {
                m_mediaPlayer = new MediaPlayer();
                m_mediaPlayer.Open(new Uri("file:///c:/pacman-theme.wav"));
                m_mediaPlayer.Play();
            }

            // `volume` is assumed to be between 0 and 100.
            public void SetVolume(int volume)
            {
                // MediaPlayer volume is a float value between 0 and 1.
                m_mediaPlayer.Volume = volume / 100.0f;
            }
        }

        Game gameForm = new Game();

        public StartMenu()
        {
            InitializeComponent();
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            Sound GameMusic = new Sound();
            GameMusic.Play();

            gameForm.ShowDialog();
            this.Close();
        }
    }
}
