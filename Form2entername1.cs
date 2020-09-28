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
    public partial class Form2entername : Form
    {
        public Form2entername()
        {
            InitializeComponent();
            
        }

        private void pictureBox1continue_Click(object sender, EventArgs e)
        {
            Form3ludomain click = new Form3ludomain(textBox1player1.Text,textBox1player2.Text,textBox1player3.Text,textBox1player4.Text);
            click.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
