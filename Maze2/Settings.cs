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
        public Settings()
        {
            InitializeComponent();
        }

        public int Volume;

        private void button1_Click(object sender, EventArgs e)
        {
            Volume = Convert.ToByte(numericUpDown1.Value);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
