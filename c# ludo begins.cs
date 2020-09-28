using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        int y;
       
        public Form1()
        {
            InitializeComponent();

            y = 286;
        }
     //    public ImageForm(String imagePath)
     //{
     //    pictureBox1.Image = Image.FromFile(imagePath);
     // }
        public partial class Form3 : Form
        {
            public Form3()
            {
               
            }

            private void label1_Click(object sender, EventArgs e)
            {

            }
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            y =y-10;
            
          this.dice.Location = new Point(236, y);

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            //this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Form4 f2 = new Form4();
            //f2.ShowDialog();
            //f2.Show();
        }
        int dice1;
        //roll dice button
        private void button3_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            dice1 = random.Next(1,7);
            switch (dice1)
            {
                case 1:
                    pictureBox2.ImageLocation = "C:\\Users\\Azfar\\Desktop\\New folder (3)\\dice1.png";
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;

                case 2:
                    pictureBox2.ImageLocation = "C:\\Users\\Azfar\\Desktop\\New folder (3)\\dice2.png";
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;

                case 3:
                    pictureBox2.ImageLocation = "C:\\Users\\Azfar\\Desktop\\New folder (3)\\dice3.png";
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;

                case 4 :
                    pictureBox2.ImageLocation = "C:\\Users\\Azfar\\Desktop\\New folder (3)\\dice4.png";
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;

                case 5:
                    pictureBox2.ImageLocation = "C:\\Users\\Azfar\\Desktop\\New folder (3)\\dice5.png";
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;

                case 6:
                    pictureBox2.ImageLocation = "C:\\Users\\Azfar\\Desktop\\New folder (3)\\dices6.png";
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                    break;

            }
            

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            //ImageForm imageForm = new ImageForm("C:\\Users\\Azfar\\Desktop\\New folder (3)\\6.png")  
            // imageForm.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 f2 = new Form3();
            PictureBox pictureBox = new PictureBox();
            pictureBox.Dock = DockStyle.Fill;
            pictureBox.ImageLocation = "C:\\Users\\Azfar\\Desktop\\New folder (3)\\ludoking.jfif";
            f2.Controls.Add(pictureBox);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

           

           
            f2.ShowDialog();
        }

        //form 4

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 f2 = new Form4(txto2.Text);
            f2.ShowDialog();
        }

    
    }
}
