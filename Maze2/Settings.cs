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

        private void saveButton_Click(object sender, EventArgs e)
        {
            Volume = Convert.ToByte(numericUpDown1.Value);

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            VolumeAdjustment(0.5);
        }

        private void VolumeAdjustment(double volume)
        {
            double adjustedValue;

            adjustedValue = volume * 100;

            numericUpDown1.Value = Convert.ToDecimal(adjustedValue);
        }
    }
}
