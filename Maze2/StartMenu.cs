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

        private void button1_Click(object sender, EventArgs e)
        {
            gameForm.ShowDialog();
            this.Close();
        }
    }
}
