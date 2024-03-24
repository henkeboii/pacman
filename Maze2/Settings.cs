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
            VolumeAdjustment(volume);
        }

        /// <summary>
        /// Implementerar användarens inställningar.
        /// Uppner-menyns värde (0-100) omvandlas till 
        /// ett värde i intervallet 0 - 1 och sparas i Volume.
        /// Settings avslutas sedan.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            Volume = Convert.ToDouble(numericUpDown1.Value) / 100;

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            VolumeAdjustment(0.5);
        }

        /// <summary>
        /// Justerar värdet på uppner-menyn 
        /// till det aktuella värdet på musikspelarens volym
        /// </summary>
        /// <param name="volume"></param>
        private void VolumeAdjustment(double volume)
        {
            double adjustedValue;

            adjustedValue = volume * 100;

            numericUpDown1.Value = Convert.ToDecimal(adjustedValue);
        }
    }
}
