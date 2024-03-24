using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Maze2
{
    internal class Sound
    {

        private MediaPlayer m_mediaPlayer;

        public double Volume = 0.5;

        public void Play()
        {
            m_mediaPlayer = new MediaPlayer();
            m_mediaPlayer.Open(new Uri("file:///c:/pacman-theme.wav"));
            m_mediaPlayer.Play();
        }

        // `volume` is assumed to be between 0 and 100.
        public void SetVolume(double volume)
        {
            // MediaPlayer volume is a float value between 0 and 1.
            m_mediaPlayer.Volume = volume / 100.0f;
            Volume = m_mediaPlayer.Volume;
        }
    }
}
