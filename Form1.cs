using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ludostate1.cpp
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }

        private void picturebox1play_Click(object sender, EventArgs e)
        {
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBoxintro_Click(object sender, EventArgs e)
        {
            Form2entername f2 = new Form2entername();
            f2.ShowDialog();
        }
        

   
    }
}
