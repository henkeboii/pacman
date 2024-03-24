using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace Maze2
{
    public partial class Settings : Form
    {
        public double Volume;

        public Settings(double volume)
        {
            InitializeComponent();

            //VolumeAdjustment anropas här för att värdet i uppner-menyn
            //ska överenstämma med värdet på musikvolymen då settings
            //öppnades.
            VolumeAdjustment(volume);
        }

        /// <summary>
        /// Sparar användarens inställningar.
        /// Uppner-menyns värde (0-100) omvandlas till 
        /// ett värde i intervallet 0 - 1 och sparas i Volume.
        /// Settings avslutas sedan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            Volume = Convert.ToDouble(volumeMenu.Value) / 100;

            this.Close();
        }

        /// <summary>
        /// Återställer musikvolymens standardvärde på 0.5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetButton_Click(object sender, EventArgs e)
        {
            VolumeAdjustment(0.5);
        }

        /// <summary>
        /// Sätter Volume lika med parametern volume för att inte musikvolymen
        /// ska bli 0 om settings stängs på annan väg än via saveButton.
        /// Justerar värdet på uppner-menyn 
        /// till det aktuella värdet på musikspelarens volym
        /// </summary>
        /// <param name="volume"></param>
        private void VolumeAdjustment(double volume)
        {
            Volume = volume;

            double adjustedValue;

            adjustedValue = volume * 100;

            volumeMenu.Value = Convert.ToDecimal(adjustedValue);
        }
    }
}
