using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ludostate1.cpp
{


    public partial class Form3ludomain : Form
    {
        private int no_ticks=0;
        System.Drawing.Point stopred= new Point(132, 284); 
         System.Drawing.Point stopblue= new Point(288, 184);
         System.Drawing.Point stopgreen= new Point(23,142);     
         System.Drawing.Point stopyellow= new Point(175,42);
        //  red patch
        
        piece redpiece1, redpiece2;
        static int red_1pos = 0;
        static int red_2pos = 0;
        static int red_3pos = 0;
        static int red_4pos= 0;
        static int win_red = 0;   // it acts like a counter if its 4 red is won
        static Point[] red_arr;
         static int dice;
          System.Drawing.Point p_outred = new Point(154, 185);
        Point[] red_arr1 = new Point[] 
                                   { 
                                   new Point { X = 132, Y = 284 }, new Point { X = 132, Y = 267 }, new Point { X = 132, Y = 250 },new Point { X = 132, Y = 228 },
                                   new Point { X = 132, Y = 205 }, new Point { X = 107, Y = 182 }, new Point { X = 90, Y = 182 },new Point { X = 67, Y = 182 },
                                   new Point { X = 45, Y = 182 }, new Point { X = 23, Y = 182 },new Point { X =0, Y = 182 },
                                   new Point { X =0, Y = 165 },new Point { X =0, Y = 140 },/*greenstop*/new Point { X =23, Y = 142 }, new Point { X =45, Y = 140 },
                                    new Point { X =65, Y = 140 }, new Point { X =85, Y = 140 }, new Point { X =110, Y = 140},  new Point { X =130, Y = 120 },
                                    new Point { X =130, Y = 100 },new Point { X =130, Y = 80 }, new Point { X =130, Y = 60}, new Point { X =130, Y = 40 },
                                    new Point { X =130, Y = 20 }, new Point { X =155, Y = 20 }, new Point { X =175, Y = 20 },/*yellowstop*/new Point { X =175, Y = 42 },
                                    new Point { X =175, Y = 60 },new Point { X =175, Y = 80 },new Point { X =175, Y = 100 },new Point { X =175, Y = 120 },
                                    new Point { X =200, Y = 140 },new Point { X =220, Y = 140 },new Point { X =240, Y = 140 }, new Point { X =265, Y = 140 },
                                    new Point { X =288, Y = 140 }, new Point { X =308, Y = 140 },new Point { X =308, Y = 160 },new Point { X =308, Y = 185 },
                                  /*blue stop*/  new Point { X =288, Y = 184 } , new Point { X =268, Y = 185 },  new Point { X =245, Y = 185 },  new Point { X =223, Y = 185 },
                                    new Point { X =200, Y = 185 },  new Point { X =177, Y = 205 }, new Point { X =177, Y = 225 }, new Point { X =177, Y = 245 }, 
                                    new Point { X =177, Y = 265 },new Point { X =177, Y = 285 },new Point { X =177, Y = 305 },    new Point { X =154, Y = 305 },  
                                    new Point { X =154, Y = 285 }, new Point { X =154, Y = 265 },new Point { X =154, Y = 245 }, new Point { X =154, Y = 225 }, 
                                    new Point { X =154, Y = 205 }, new Point { X =154, Y =185 }, 
                               };
        // red patch ends

        // blue patch

        piece bluepiece1, bluepiece2;
        static int blue_1pos = 0;
        static int blue_2pos = 0;
        static int blue_3pos = 0;
        static int blue_4pos = 0;
        static int win_blue = 0;   // it acts like a counter if its 4 blue is won
        static Point[] blue_arr;
        System.Drawing.Point p_outblue = new Point(179, 162);
        Point[] blue_arr1 = new Point[] 
                                   { 
                                   new Point { X = 288, Y = 184 }, new Point { X = 268, Y = 184 }, new Point { X = 248, Y = 184 },new Point { X = 225, Y = 184 },
                                   new Point { X = 202, Y = 184 }, new Point { X = 180, Y = 204 }, new Point { X = 180, Y = 224 },new Point { X = 180, Y = 244},
                                   new Point { X = 182, Y = 264 }, new Point { X = 180, Y = 284},new Point { X =180, Y = 304 },
                                   new Point { X =160, Y = 304 },new Point { X =135, Y = 304 },/*stop red */new Point { X =132, Y = 284 }, new Point { X =135, Y = 264 },
                                    new Point { X =135, Y = 244 }, new Point { X =135, Y = 224}, new Point { X =135, Y = 204},  new Point { X =112, Y = 182 },
                                    new Point { X =87, Y = 182 },new Point { X =67, Y = 182 }, new Point { X =47, Y = 182}, new Point { X =25, Y = 182 },
                                    new Point { X =5, Y = 182 }, new Point { X =3, Y = 162 },  new Point { X =3, Y =142 },
                                   /*greenstop*/ new Point { X =23,Y = 142 },new Point { X =43, Y = 142 },new Point { X =63, Y = 142},new Point { X =87, Y = 142},
                                    new Point { X =110, Y = 142 },new Point { X =133, Y = 122},new Point { X =133, Y = 102 }, new Point { X =133, Y = 82 },
                                    new Point { X =133, Y = 62 }, new Point { X =133, Y = 42},new Point { X =133, Y = 22 },new Point { X =155, Y = 22 },
                                    new Point { X =175, Y = 22 } ,/*yellowstop*/ new Point { X =175, Y = 42 },  new Point { X =175, Y = 62 },  new Point { X =175, Y = 82 },
                                    new Point { X =175, Y = 102 },  new Point { X =175, Y = 122 }, new Point { X =198, Y = 142 }, new Point { X =218, Y = 142 }, 
                                    new Point { X =242, Y =142 },new Point { X =265, Y = 142 },new Point { X =287, Y = 142 },    new Point { X =310, Y = 142},  
                                    new Point { X =310, Y = 162 }, new Point { X =290, Y = 162},new Point { X =266, Y = 162 }, new Point { X =244, Y = 162 }, 
                                    new Point { X =221, Y = 162 }, new Point { X =199, Y =162 }, new Point { X =179, Y =162 },  
                               };

        // blue patch ends


        //yellow patch

            piece yellowpiece1, yellowpiece2;
        static int yellow_1pos = 0;
        static int yellow_2pos = 0;
        static int yellow_3pos = 0;
        static int yellow_4pos= 0;
        static int win_yellow = 0;   
        static Point[] yellow_arr;
         
          System.Drawing.Point p_outyellow = new Point(157, 140);
        Point[] yellow_arr1 = new Point[] 
                                   { 
                     new Point { X = 175, Y = 42 }, new Point { X = 175, Y = 62 }, new Point { X = 175, Y = 82 },new Point { X = 175, Y = 102 },
                      new Point { X = 175, Y = 122 }, new Point { X = 198, Y = 142 }, new Point { X = 220, Y = 142 },new Point { X = 244, Y = 142 },
                      new Point { X = 268, Y = 142 },new Point { X = 288, Y = 142 },new Point { X =308, Y = 142 },
                     new Point { X =308, Y = 162 },new Point { X =308, Y = 182 },/*blue stop*/new Point { X =288, Y = 184 }, new Point { X =268, Y = 182 },
                     new Point { X =245, Y = 182 }, new Point { X =225, Y = 182 }, new Point { X =200, Y = 182},  new Point { X =178, Y = 202 },
                     new Point { X =178, Y = 222 },new Point { X =178, Y = 242 }, new Point { X =178, Y = 262}, new Point { X =178, Y = 282 },
                     new Point { X =178, Y = 302 }, new Point { X =158, Y = 302 }, new Point { X =135, Y = 302 },/*redstop*/new Point { X =132, Y = 284 },
                     new Point { X =135, Y = 260 },new Point { X =135, Y = 240 },new Point { X =135, Y = 220 },new Point { X =135, Y = 200 },
                     new Point { X =113, Y = 180 },new Point { X =87, Y = 180 },new Point { X =67, Y = 180 }, new Point { X =47, Y = 180 },
                     new Point { X =25, Y = 180 }, new Point { X =3, Y = 180 },new Point { X =3, Y = 160 },new Point { X =3, Y = 140 },
                     /*greenstop*/new Point { X =23, Y = 142 } , new Point { X =43, Y = 140 },  new Point { X =65, Y = 140 },  new Point { X =88, Y = 140 },
                     new Point { X =108, Y = 140 },  new Point { X =132, Y = 120 }, new Point { X =132, Y = 100 }, new Point { X =132, Y = 80 }, 
                     new Point { X =132, Y = 60 },new Point { X =132, Y =40 },new Point { X =132, Y = 20 },    new Point { X =157, Y = 20 },  
                     new Point { X =157, Y = 40 }, new Point { X =157, Y =60 },new Point { X =157, Y = 80 }, new Point { X =157, Y = 100 }, 
                      new Point { X =157, Y = 120 }, new Point { X =157, Y =140 }, 
                               };

        //yellow patch ends 
        public Form3ludomain(string s1, string s2, string s3, string s4)
        {
            InitializeComponent();
            textBox1p1.Text = s1;
            textBox1p2.Text = s2;
            textBox1p3.Text = s3;
            textBox1p4.Text = s4;
          
        }

        private void Form3ludomain_Load(object sender, EventArgs e)
        {

        }

        


        private void pictureBox1rolldice_Click(object sender, EventArgs e)
        {
             int timerconstant=0;
            //pictureBox1dice.Visible = false;
             if (timerconstant == 0)
             {
                 timer1.Enabled = true;
                 timer1.Start();
                 pictureBox1dice.Visible = false;
                 //pictureBoxrollingdice.Visible = true;
                 timerconstant = 1;
             }
             if (timerconstant == 1)
             {
                 Random random = new Random();
                 dice = random.Next(1, 7);

                 //Thread.Sleep(30);

                 switch (dice)
                 {
                          
                     case 1:

                         pictureBox1dice.ImageLocation = "C:\\Users\\Azfar\\Desktop\\New folder (3)\\dice111.png";
                         pictureBox1dice.SizeMode = PictureBoxSizeMode.StretchImage;
                         timerconstant = 0;
                         break;

                     case 2:

                         pictureBox1dice.ImageLocation = "C:\\Users\\Azfar\\Desktop\\New folder (3)\\dice222.png";
                         pictureBox1dice.SizeMode = PictureBoxSizeMode.StretchImage;
                         timerconstant = 0;
                         break;

                     case 3:

                         pictureBox1dice.ImageLocation = "C:\\Users\\Azfar\\Desktop\\New folder (3)\\dice333.png";
                         pictureBox1dice.SizeMode = PictureBoxSizeMode.StretchImage;
                         timerconstant = 0;
                         break;

                     case 4:

                         pictureBox1dice.ImageLocation = "C:\\Users\\Azfar\\Desktop\\New folder (3)\\dice444.png";
                         pictureBox1dice.SizeMode = PictureBoxSizeMode.StretchImage;
                         timerconstant = 0;
                         break;

                     case 5:

                         pictureBox1dice.ImageLocation = "C:\\Users\\Azfar\\Desktop\\New folder (3)\\dice555.png";
                         pictureBox1dice.SizeMode = PictureBoxSizeMode.StretchImage;
                         timerconstant = 0;
                         break;

                     case 6:

                         pictureBox1dice.ImageLocation = "C:\\Users\\Azfar\\Desktop\\New folder (3)\\dice666.png";
                         pictureBox1dice.SizeMode = PictureBoxSizeMode.StretchImage;
                         timerconstant = 0;
                         break;

                 }

             }
        }

        private void pictureBox1testing_Click(object sender, EventArgs e)
        {
            
        }


       
        public class red_patch
        {
            //Point p1;
            //Point p2;

        }
        // red area begins
       

        private void pictureBoxredpiece1_Click(object sender, EventArgs e)
        {

            if (dice == 6 && pictureBoxredpiece1.Location == new Point(80, 260))
            {
                
                //pictureBoxredpiece1.Location = new Point(132,284);
                pictureBoxredpiece1.Location =new Point(132,284);
                //redpiece1.active = true;

            }
            else if (pictureBoxredpiece1.Location != new Point(80, 260))
            {
                if (red_1pos >= 50)
                {
                    if (dice <= 56 - red_1pos)
                    {
                        int x = 0;
                        for (x = 0; x <= dice; x++)
                        {
                            pictureBoxredpiece1.Location = red_arr1[red_1pos + x];
                          

                            if (pictureBoxredpiece1.Location == p_outred)
                            {
                                //MessageBox.Show("inside loop p_outred for hiding");
                                pictureBoxredpiece1.Hide();
                                win_red++;
                            }                                                        

                            if (win_red == 4)
                            {
                                pictureBox1celebration.Visible = true;
                                MessageBox.Show("congrats is the winner ", textBox1p3.Text);
                                // name of player playing red peice
                            }
                            Thread.Sleep(30);
                        }

                        red_1pos = red_1pos + (x - 1);
                        //string r = red_1pos.ToString();
                        //MessageBox.Show("red_1pos updated value", r);
                    }
                    else
                    {
                        MessageBox.Show("illegal move");
                    }


                }

                else
                {
                    int i;
                    for (i = 0; i <= dice; i++)
                    {
                        pictureBoxredpiece1.Location = red_arr1[red_1pos + i];
                        //if (pictureBoxredpiece1.Location == p_outred)
                        //{
                        //    pictureBoxredpiece1.Hide();
                        //    win_red++;
                        //}


                        Thread.Sleep(30);
                    }
                    //if (win_red == 4)
                    //{
                    //    pictureBox1celebration.Visible = true;
                    //    MessageBox.Show("congrats is the winner ", textBox1p3.Text);
                    //    // name of player playing red peices
                    //}
                    red_1pos = red_1pos + (i - 1);
                    //string r = red_1pos.ToString();
                    //MessageBox.Show("red_1pos", r);
                    if(red_1pos>38)
                    {
                        if ((red_1pos == blue_1pos + 39) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxbluepiece1.Location = new Point(270, 255);
                            blue_1pos = 0;
                        }
                        else if ((red_1pos == blue_2pos + 39) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxbluepiece2.Location = new Point(245, 230);
                            blue_2pos = 0;
                        }
                        else if ((red_1pos == blue_3pos + 39) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                        {
                            pictureBoxbluepiece3.Location = new Point(223, 260);
                            blue_3pos = 0;
                        }
                        else if ((red_1pos == blue_4pos + 39) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                        {
                            pictureBoxbluepiece4.Location = new Point(247, 280);
                            blue_4pos = 0;
                        }
                     
                    }

                    else
                    {
                        if ((red_1pos == blue_1pos - 13) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxbluepiece1.Location = new Point(270, 255);
                            blue_1pos = 0;
                        }
                        else if ((red_1pos == blue_2pos - 13) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxbluepiece2.Location = new Point(245, 230);
                            blue_2pos = 0;
                        }
                        else if ((red_1pos == blue_3pos - 13) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                        {
                            pictureBoxbluepiece3.Location = new Point(223, 260);
                            blue_3pos = 0;
                        }
                        else if ((red_1pos == blue_4pos - 13) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                        {
                            pictureBoxbluepiece4.Location = new Point(247, 280);
                            blue_4pos = 0;
                        }
                    }
                    if (red_1pos < 26)
                    {
                        if ((red_1pos == yellow_1pos - 26) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece1.Location = new Point(277, 70);
                            yellow_1pos = 0;
                        }
                        else if ((red_1pos == yellow_2pos - 26) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece2.Location = new Point(230, 70);
                            yellow_2pos = 0;
                        }
                        else if ((red_1pos == yellow_3pos - 26) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece3.Location = new Point(253, 98);
                            blue_3pos = 0;
                        }
                        else if ((red_1pos == yellow_4pos - 26) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece4.Location = new Point(253, 51);
                            yellow_4pos = 0;
                        }

                    }

                    else
                    {
                        if ((red_1pos == yellow_1pos + 26) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece1.Location = new Point(277, 70);
                            yellow_1pos = 0;
                        }
                        else if ((red_1pos == yellow_2pos + 26) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece2.Location = new Point(230, 70);
                            yellow_2pos = 0;
                        }
                        else if ((red_1pos == yellow_3pos + 26) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece3.Location = new Point(253, 98);
                            yellow_3pos = 0;
                        }
                        else if ((red_1pos == yellow_4pos + 26) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece4.Location = new Point(253, 51);
                            yellow_4pos = 0;
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxredpiece2_Click(object sender, EventArgs e)
        {
            if (dice == 6 && pictureBoxredpiece2.Location == new Point(33, 260))
            {

                //pictureBoxredpiece1.Location = new Point(132,284);
                pictureBoxredpiece2.Location = new Point(132, 284);
                //redpiece2.active = true;

            }
            else if (pictureBoxredpiece2.Location != new Point(33, 260))
            {
                if (red_2pos >= 50)
                {
                    if (dice <= 56 - red_2pos)
                    {
                        int x = 0;
                        for (x = 0; x <= dice; x++)
                        {
                            pictureBoxredpiece2.Location = red_arr1[red_2pos + x];

                            if (pictureBoxredpiece2.Location == p_outred)
                            {
                                pictureBoxredpiece2.Hide();
                                win_red++;
                            }

                            if (win_red == 4)
                            {
                                pictureBox1celebration.Visible = true;
                                MessageBox.Show("congrats is the winner ", textBox1p3.Text);
                                // name of player playing red peice
                            }
                            Thread.Sleep(30);
                        }

                        red_2pos = red_2pos + (x - 1);
                    }
                    else
                    {
                        MessageBox.Show("illegal move");
                    }


                }

                else
                {
                    int i;
                    for (i = 0; i <= dice; i++)
                    {
                        pictureBoxredpiece2.Location = red_arr1[red_2pos + i];
                        //if (pictureBoxredpiece1.Location == p_outred)
                        //{
                        //    pictureBoxredpiece1.Hide();
                        //    win_red++;
                        //}


                        Thread.Sleep(30);
                    }
                    //if (win_red == 4)
                    //{
                    //    pictureBox1celebration.Visible = true;
                    //    MessageBox.Show("congrats is the winner ", textBox1p3.Text);
                    //    // name of player playing red peices
                    //}
                    red_2pos = red_2pos + (i - 1);
                    //string r = red_1pos.ToString();
                    //MessageBox.Show("red_1pos", r);
                    if (red_2pos > 38)
                    {
                        if ((red_2pos == blue_1pos + 39) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxbluepiece1.Location = new Point(270, 255);
                            blue_1pos = 0;
                        }
                        else if ((red_2pos == blue_2pos + 39) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxbluepiece2.Location = new Point(245, 230);
                            blue_2pos = 0;
                        }
                        else if ((red_2pos == blue_3pos + 39) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                        {
                            pictureBoxbluepiece3.Location = new Point(223, 260);
                            blue_3pos = 0;
                        }
                        else if ((red_2pos == blue_4pos + 39) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                        {
                            pictureBoxbluepiece4.Location = new Point(247, 280);
                            blue_4pos = 0;
                        }

                    }

                    else
                    {
                        if ((red_2pos == blue_1pos - 13) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxbluepiece1.Location = new Point(270, 255);
                            blue_1pos = 0;
                        }
                        else if ((red_2pos == blue_2pos - 13) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxbluepiece2.Location = new Point(245, 230);
                            blue_2pos = 0;
                        }
                        else if ((red_2pos == blue_3pos - 13) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                        {
                            pictureBoxbluepiece3.Location = new Point(223, 260);
                            blue_3pos = 0;
                        }
                        else if ((red_2pos == blue_4pos - 13) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                        {
                            pictureBoxbluepiece4.Location = new Point(247, 280);
                            blue_4pos = 0;
                        }
                    }
                    if (red_2pos < 26)
                    {
                        if ((red_2pos == yellow_1pos - 26) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece1.Location = new Point(277, 70);
                            yellow_1pos = 0;
                        }
                        else if ((red_2pos == yellow_2pos - 26) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece2.Location = new Point(230, 70);
                            yellow_2pos = 0;
                        }
                        else if ((red_2pos == yellow_3pos - 26) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece3.Location = new Point(253, 98);
                            blue_3pos = 0;
                        }
                        else if ((red_2pos == yellow_4pos - 26) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece4.Location = new Point(253, 51);
                            yellow_4pos = 0;
                        }

                    }

                    else
                    {
                        if ((red_2pos == yellow_1pos + 26) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece1.Location = new Point(277, 70);
                            yellow_1pos = 0;
                        }
                        else if ((red_2pos == yellow_2pos + 26) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece2.Location = new Point(230, 70);
                            yellow_2pos = 0;
                        }
                        else if ((red_2pos == yellow_3pos + 26) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece3.Location = new Point(253, 98);
                            yellow_3pos = 0;
                        }
                        else if ((red_2pos == yellow_4pos + 26) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece4.Location = new Point(253, 51);
                            yellow_4pos = 0;
                        }
                    }
                }
            }
        }

        private void pictureBoxrollingdice_Click(object sender, EventArgs e)
        {
            pictureBoxrollingdice.Visible = false;
        }

        private void pictureBox1redpiece3_Click(object sender, EventArgs e)
        {
            if (dice == 6 && pictureBox1redpiece3.Location == new Point(55, 230))
            {

                //pictureBoxredpiece1.Location = new Point(132,284);
                pictureBox1redpiece3.Location = new Point(132, 284);
                //redpiece2.active = true;

            }
            else if (pictureBox1redpiece3.Location != new Point(55, 230))
            {
                if (red_3pos >= 50)
                {
                    if (dice <= 56 - red_3pos)
                    {
                        int x = 0;
                        for (x = 0; x <= dice; x++)
                        {
                            pictureBox1redpiece3.Location = red_arr1[red_3pos + x];

                            if (pictureBox1redpiece3.Location == p_outred)
                            {
                                pictureBox1redpiece3.Hide();
                                win_red++;
                            }

                            if (win_red == 4)
                            {
                                pictureBox1celebration.Visible = true;
                                MessageBox.Show("congrats is the winner ", textBox1p3.Text);
                                // name of player playing red peice
                            }
                            Thread.Sleep(30);
                        }

                        red_3pos = red_3pos + (x - 1);
                    }
                    else
                    {
                        MessageBox.Show("illegal move");
                    }


                }

                else
                {
                    int i;
                    for (i = 0; i <= dice; i++)
                    {
                        pictureBox1redpiece3.Location = red_arr1[red_3pos + i];
                        //if (pictureBoxredpiece1.Location == p_outred)
                        //{
                        //    pictureBoxredpiece1.Hide();
                        //    win_red++;
                        //}


                        Thread.Sleep(30);
                    }
                    //if (win_red == 4)
                    //{
                    //    pictureBox1celebration.Visible = true;
                    //    MessageBox.Show("congrats is the winner ", textBox1p3.Text);
                    //    // name of player playing red peices
                    //}
                    red_3pos = red_3pos + (i - 1);
                    //string r = red_1pos.ToString();
                    //MessageBox.Show("red_1pos", r);
                    if (red_3pos > 38)
                    {
                        if ((red_3pos == blue_1pos + 39) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxbluepiece1.Location = new Point(270, 255);
                            blue_1pos = 0;
                        }
                        else if ((red_3pos == blue_2pos + 39) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxbluepiece2.Location = new Point(245, 230);
                            blue_2pos = 0;
                        }
                        else if ((red_3pos == blue_3pos + 39) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                        {
                            pictureBoxbluepiece3.Location = new Point(223, 260);
                            blue_3pos = 0;
                        }
                        else if ((red_3pos == blue_4pos + 39) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                        {
                            pictureBoxbluepiece4.Location = new Point(247, 280);
                            blue_4pos = 0;
                        }

                    }

                    else
                    {
                        if ((red_3pos == blue_1pos - 13) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxbluepiece1.Location = new Point(270, 255);
                            blue_1pos = 0;
                        }
                        else if ((red_3pos == blue_2pos - 13) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxbluepiece2.Location = new Point(245, 230);
                            blue_2pos = 0;
                        }
                        else if ((red_3pos == blue_3pos - 13) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                        {
                            pictureBoxbluepiece3.Location = new Point(223, 260);
                            blue_3pos = 0;
                        }
                        else if ((red_3pos == blue_4pos - 13) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                        {
                            pictureBoxbluepiece4.Location = new Point(247, 280);
                            blue_4pos = 0;
                        }
                    }
                    if (red_3pos < 26)
                    {
                        if ((red_3pos == yellow_1pos - 26) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece1.Location = new Point(277, 70);
                            yellow_1pos = 0;
                        }
                        else if ((red_3pos == yellow_2pos - 26) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece2.Location = new Point(230, 70);
                            yellow_2pos = 0;
                        }
                        else if ((red_3pos == yellow_3pos - 26) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece3.Location = new Point(253, 98);
                            blue_3pos = 0;
                        }
                        else if ((red_3pos == yellow_4pos - 26) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece4.Location = new Point(253, 51);
                            yellow_4pos = 0;
                        }

                    }

                    else
                    {
                        if ((red_3pos == yellow_1pos + 26) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece1.Location = new Point(277, 70);
                            yellow_1pos = 0;
                        }
                        else if ((red_3pos == yellow_2pos + 26) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece2.Location = new Point(230, 70);
                            yellow_2pos = 0;
                        }
                        else if ((red_3pos == yellow_3pos + 26) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece3.Location = new Point(253, 98);
                            yellow_3pos = 0;
                        }
                        else if ((red_3pos == yellow_4pos + 26) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece4.Location = new Point(253, 51);
                            yellow_4pos = 0;
                        }
                    }
                }
            }
        }

        private void pictureBox1redpiece4_Click(object sender, EventArgs e)
        {
            if (dice == 6 && pictureBox1redpiece4.Location == new Point(55, 276))
            {

                //pictureBoxredpiece1.Location = new Point(132,284);
                pictureBox1redpiece4.Location = new Point(132, 284);
                //redpiece2.active = true;

            }
            else if (pictureBox1redpiece4.Location != new Point(55, 276))
            {
                if (red_4pos >= 50)
                {
                    if (dice <= 56 - red_4pos)
                    {
                        int x = 0;
                        for (x = 0; x <= dice; x++)
                        {
                            pictureBox1redpiece4.Location = red_arr1[red_4pos + x];

                            if (pictureBox1redpiece4.Location == p_outred)
                            {
                                pictureBox1redpiece4.Hide();
                                win_red++;
                            }

                            if (win_red == 4)
                            {
                                pictureBox1celebration.Visible = true;
                                MessageBox.Show("congrats is the winner ", textBox1p3.Text);
                                // name of player playing red peice
                            }
                            Thread.Sleep(30);
                        }

                        red_4pos = red_4pos + (x - 1);
                    }
                    else
                    {
                        MessageBox.Show("illegal move");
                    }


                }

                else
                {
                    int i;
                    for (i = 0; i <= dice; i++)
                    {
                        pictureBox1redpiece4.Location = red_arr1[red_4pos + i];
                        //if (pictureBoxredpiece1.Location == p_outred)
                        //{
                        //    pictureBoxredpiece1.Hide();
                        //    win_red++;
                        //}


                        Thread.Sleep(30);
                    }
                    //if (win_red == 4)
                    //{
                    //    pictureBox1celebration.Visible = true;
                    //    MessageBox.Show("congrats is the winner ", textBox1p3.Text);
                    //    // name of player playing red peices
                    //}
                    red_4pos = red_4pos + (i - 1);
                    //string r = red_1pos.ToString();
                    //MessageBox.Show("red_1pos", r);
                    if (red_4pos > 38)
                    {
                        if ((red_4pos == blue_1pos + 39) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxbluepiece1.Location = new Point(270, 255);
                            blue_1pos = 0;
                        }
                        else if ((red_4pos == blue_2pos + 39) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxbluepiece2.Location = new Point(245, 230);
                            blue_2pos = 0;
                        }
                        else if ((red_4pos == blue_3pos + 39) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue)&&(pictureBoxbluepiece3.Location!=stopgreen)&&(pictureBoxbluepiece3.Location!=stopyellow)))
                        {
                            pictureBoxbluepiece3.Location = new Point(223, 260);
                            blue_3pos = 0;
                        }
                        else if ((red_4pos == blue_4pos + 39) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue)&&(pictureBoxbluepiece4.Location!=stopgreen)&&(pictureBoxbluepiece4.Location!=stopyellow)))
                        {
                            pictureBoxbluepiece4.Location = new Point(247, 280);
                            blue_4pos = 0;
                        }

                    }

                    else
                    {
                        if ((red_4pos == blue_1pos - 13) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxbluepiece1.Location = new Point(270, 255);
                            blue_1pos = 0;
                        }
                        else if ((red_4pos == blue_2pos - 13) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue)&&(pictureBoxbluepiece2.Location != stopgreen)&&(pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxbluepiece2.Location = new Point(245, 230);
                            blue_2pos = 0;
                        }
                        else if ((red_4pos == blue_3pos - 13) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue)&&(pictureBoxbluepiece3.Location!=stopgreen)&&(pictureBoxbluepiece3.Location!=stopyellow)))
                        {
                            pictureBoxbluepiece3.Location = new Point(223, 260);
                            blue_3pos = 0;
                        }
                        else if ((red_4pos == blue_4pos - 13) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue)&&(pictureBoxbluepiece4.Location!=stopgreen)&&(pictureBoxbluepiece4.Location!=stopyellow)))
                        {
                            pictureBoxbluepiece4.Location = new Point(247, 280);
                            blue_4pos = 0;
                        }
                    }
                    if (red_4pos < 26)
                    {
                        if ((red_4pos == yellow_1pos - 26) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece1.Location = new Point(277, 70);
                            yellow_1pos = 0;
                        }
                        else if ((red_4pos == yellow_2pos - 26) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece2.Location = new Point(230, 70);
                            yellow_2pos = 0;
                        }
                        else if ((red_4pos == yellow_3pos - 26) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece3.Location = new Point(253, 98);
                            blue_3pos = 0;
                        }
                        else if ((red_4pos == yellow_4pos - 26) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece4.Location = new Point(253, 51);
                            yellow_4pos = 0;
                        }

                    }

                    else
                    {
                        if ((red_4pos == yellow_1pos + 26) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece1.Location = new Point(277, 70);
                            yellow_1pos = 0;
                        }
                        else if ((red_4pos == yellow_2pos + 26) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece2.Location = new Point(230, 70);
                            yellow_2pos = 0;
                        }
                        else if ((red_4pos == yellow_3pos + 26) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece3.Location = new Point(253, 98);
                            yellow_3pos = 0;
                        }
                        else if ((red_4pos == yellow_4pos + 26) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece4.Location = new Point(253, 51);
                            yellow_4pos = 0;
                        }
                    }
                }
            }

        }


        //  blue area begins
        private void pictureBoxbluepiece1_Click(object sender, EventArgs e)
        {

            if (dice == 6 && pictureBoxbluepiece1.Location == new Point(270, 255))
            {

                //pictureBoxredpiece1.Location = new Point(132,284);
                pictureBoxbluepiece1.Location = new Point(288, 184);
                //redpiece1.active = true;

            }
            else if (pictureBoxbluepiece1.Location != new Point(270, 255))
            {
                if (blue_1pos >= 50)
                {
              
                    if ( dice <= 56 - blue_1pos) 
                    {
                        
                        int x= 0;
                        for (x = 0; x<= dice;x++)
                        {
                            pictureBoxbluepiece1.Location = blue_arr1[blue_1pos + x];

                            if (pictureBoxbluepiece1.Location == p_outblue)
                            {
                                pictureBoxbluepiece1.Hide();
                                win_blue++;
                            }

                            if (win_blue == 4)
                            {
                                pictureBox1celebration.Visible = true;
                                MessageBox.Show("congrats is the winner ", textBox1p4.Text);
                                // name of player playing red peice
                            }
                            Thread.Sleep(30);
                        }

                        blue_1pos = blue_1pos + (x - 1);
                    }
                    else
                    {
                        MessageBox.Show("illegal move");
                    }
                }



                else
                {
                    int b = 0;
                    for (b = 0; b <= dice; b++)
                    {
                        pictureBoxbluepiece1.Location = blue_arr1[blue_1pos + b];

                        //if (pictureBoxbluepiece1.Location == p_outblue)
                        //{
                        //    pictureBoxbluepiece1.Hide();
                        //    win_blue++;
                        //}


                        Thread.Sleep(30);
                    }



                    blue_1pos = blue_1pos + (b - 1);
                    //string s = blue_1pos.ToString();
                    //MessageBox.Show("blue_1pos", s);

                    if(blue_1pos<13)
                    {
                        if ((blue_1pos == red_1pos - 39) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxredpiece1.Location = new Point(80, 260);
                            red_1pos = 0;
                        }
                        else if ((blue_1pos == red_2pos - 39) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxredpiece2.Location = new Point(33, 260);
                            red_2pos = 0;
                        }
                        else if ((blue_1pos == red_3pos - 39) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBox1redpiece3.Location = new Point(55, 230);
                            red_3pos = 0;
                        }
                        else if ((blue_1pos == red_4pos - 39) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBox1redpiece4.Location = new Point(55, 276);
                            red_4pos = 0;
                        }
                    }

                    else
                    {
                        if ((blue_1pos == red_1pos + 13) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxredpiece1.Location = new Point(80, 260);
                            red_1pos = 0;
                        }
                        else if ((blue_1pos == red_2pos + 13) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxredpiece2.Location = new Point(33, 260);
                            red_2pos = 0;
                        }
                        else if ((blue_1pos == red_3pos + 13) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBox1redpiece3.Location = new Point(55, 230);
                            red_3pos = 0;
                        }
                        else if ((blue_1pos == red_4pos + 13) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBox1redpiece4.Location = new Point(55, 276);
                            red_4pos = 0;
                        }
                    }
                    if (blue_1pos < 39)
                    {
                        if ((blue_1pos == yellow_1pos - 13) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece1.Location = new Point(277, 70);
                            yellow_1pos = 0;
                        }
                        else if ((blue_1pos == yellow_2pos - 13) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece2.Location = new Point(230, 70);
                            yellow_2pos = 0;
                        }
                        else if ((blue_1pos == yellow_3pos - 13) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece3.Location = new Point(253, 98);
                            blue_3pos = 0;
                        }
                        else if ((blue_1pos == yellow_4pos - 13) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece4.Location = new Point(253, 51);
                            yellow_4pos = 0;
                        }

                    }

                    else
                    {
                        if ((blue_1pos == yellow_1pos + 39) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece1.Location = new Point(277, 70);
                            yellow_1pos = 0;
                        }
                        else if ((blue_1pos == yellow_2pos + 39) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece2.Location = new Point(230, 70);
                            yellow_2pos = 0;
                        }
                        else if ((blue_1pos == yellow_3pos + 39) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece3.Location = new Point(253, 98);
                            yellow_3pos = 0;
                        }
                        else if ((blue_1pos == yellow_4pos + 39) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece4.Location = new Point(253, 51);
                            yellow_4pos = 0;
                        }
                    }
                 

                }
            }
        }

        private void pictureBoxbluepiece2_Click(object sender, EventArgs e)
        {
            if (dice == 6 && pictureBoxbluepiece2.Location == new Point(248, 230))
            {

                //pictureBoxredpiece1.Location = new Point(132,284);
                pictureBoxbluepiece2.Location = new Point(288, 184);
                //redpiece1.active = true;

            }
            else if (pictureBoxbluepiece2.Location != new Point(248, 230))
            {


                if (blue_2pos >= 50)
                {

                    if (dice <= 56 - blue_2pos)
                    {

                        int x = 0;
                        for (x = 0; x <= dice; x++)
                        {
                            pictureBoxbluepiece2.Location = blue_arr1[blue_2pos + x];

                            if (pictureBoxbluepiece2.Location == p_outblue)
                            {
                                pictureBoxbluepiece2.Hide();
                                win_blue++;
                            }

                            if (win_blue == 4)
                            {
                                pictureBox1celebration.Visible = true;
                                MessageBox.Show("congrats is the winner ", textBox1p4.Text);
                                // name of player playing red peice
                            }
                            Thread.Sleep(30);
                        }

                        blue_2pos = blue_2pos + (x - 1);
                    }
                    else
                    {
                        MessageBox.Show("illegal move");
                    }
                }

                else
                {
                    int b;
                    for (b = 0; b <= dice; b++)
                    {
                        pictureBoxbluepiece2.Location = blue_arr1[blue_2pos + b];
                        //if (pictureBoxbluepiece2.Location == p_outblue)
                        //{
                        //    pictureBoxbluepiece2.Hide();
                        //    win_blue++;
                        //}


                        Thread.Sleep(30);
                    }
                    //if (win_blue == 4)
                    //{
                    //    pictureBox1celebration.Visible = true;
                    //    //MessageBox.Show("congrats is the winner ", textBox1p4.Text);
                    //    // name of player playing red peices
                    //}
                    blue_2pos = blue_2pos + (b - 1);
                    //string s = blue_2pos.ToString();
                    //MessageBox.Show("blue_2pos", s);
                    if(blue_2pos<13)
                    {
                        if ((blue_2pos == red_1pos - 39) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxredpiece1.Location = new Point(80, 260);
                            red_1pos = 0;
                        }
                        else if ((blue_2pos == red_2pos - 39) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxredpiece2.Location = new Point(33, 260);
                            red_2pos = 0;
                        }
                        else if ((blue_2pos == red_3pos - 39) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBox1redpiece3.Location = new Point(55, 230);
                            red_3pos = 0;
                        }
                        else if ((blue_2pos == red_4pos - 39) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBox1redpiece4.Location = new Point(55, 276);
                            red_4pos = 0;
                        }
                    }

                    else {
                        if ((blue_2pos == red_1pos + 13) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxredpiece1.Location = new Point(80, 260);
                            red_1pos = 0;
                        }
                        else if ((blue_2pos == red_2pos + 13) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxredpiece2.Location = new Point(33, 260);
                            red_2pos = 0;
                        }
                        else if ((blue_2pos == red_3pos + 13) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBox1redpiece3.Location = new Point(55, 230);
                            red_3pos = 0;
                        }
                        else if ((blue_2pos == red_4pos + 13) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBox1redpiece4.Location = new Point(55, 276);
                            red_4pos = 0;
                        }
                    }
                    if (blue_2pos < 39)
                    {
                        if ((blue_2pos == yellow_1pos - 13) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece1.Location = new Point(277, 70);
                            yellow_1pos = 0;
                        }
                        else if ((blue_2pos == yellow_2pos - 13) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece2.Location = new Point(230, 70);
                            yellow_2pos = 0;
                        }
                        else if ((blue_2pos == yellow_3pos - 13) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece3.Location = new Point(253, 98);
                            blue_3pos = 0;
                        }
                        else if ((blue_2pos == yellow_4pos - 13) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece4.Location = new Point(253, 51);
                            yellow_4pos = 0;
                        }

                    }

                    else
                    {
                        if ((blue_2pos == yellow_1pos + 39) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece1.Location = new Point(277, 70);
                            yellow_1pos = 0;
                        }
                        else if ((blue_2pos == yellow_2pos + 39) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece2.Location = new Point(230, 70);
                            yellow_2pos = 0;
                        }
                        else if ((blue_2pos == yellow_3pos + 39) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece3.Location = new Point(253, 98);
                            yellow_3pos = 0;
                        }
                        else if ((blue_2pos == yellow_4pos + 39) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece4.Location = new Point(253, 51);
                            yellow_4pos = 0;
                        }
                    }
                }
            }
        }

        private void pictureBoxbluepiece3_Click(object sender, EventArgs e)
        {
            if (dice == 6 && pictureBoxbluepiece3.Location == new Point(223, 260))
            {

                //pictureBoxredpiece1.Location = new Point(132,284);
                pictureBoxbluepiece3.Location = new Point(288, 184);
                //redpiece1.active = true;

            }
            else if (pictureBoxbluepiece3.Location != new Point(223, 260))
            {
                if (blue_3pos >= 50)
                {

                    if (dice <= 56 - blue_3pos)
                    {

                        int x = 0;
                        for (x = 0; x <= dice; x++)
                        {
                            pictureBoxbluepiece3.Location = blue_arr1[blue_3pos + x];

                            if (pictureBoxbluepiece3.Location == p_outblue)
                            {
                                pictureBoxbluepiece3.Hide();
                                win_blue++;
                            }

                            if (win_blue == 4)
                            {
                                pictureBox1celebration.Visible = true;
                                MessageBox.Show("congrats is the winner ", textBox1p4.Text);
                                // name of player playing red peice
                            }
                            Thread.Sleep(30);
                        }

                        blue_3pos = blue_3pos + (x - 1);
                    }
                    else
                    {
                        MessageBox.Show("illegal move");
                    }
                }
                else
                {
                    int b;
                    for (b = 0; b <= dice; b++)
                    {
                        pictureBoxbluepiece3.Location = blue_arr1[blue_3pos + b];
                        //if (pictureBoxbluepiece3.Location == p_outblue)
                        //{
                        //    pictureBoxbluepiece3.Hide();
                        //    win_blue++;
                        //}


                        Thread.Sleep(30);
                    }
                    //if (win_blue == 4)
                    //{
                    //    pictureBox1celebration.Visible = true;
                    //    MessageBox.Show("congrats is the winner ", textBox1p4.Text);
                    //    // name of player playing red peices
                    //}
                    blue_3pos = blue_3pos + (b - 1);
                    //string s = blue_3pos.ToString();
                    //MessageBox.Show("blue_3pos", s);
                    if (blue_3pos < 13)
                    {
                        if ((blue_3pos == red_1pos - 39) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                        {
                            pictureBoxredpiece1.Location = new Point(80, 260);
                            red_1pos = 0;
                        }
                        else if ((blue_3pos == red_2pos - 39) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                        {
                            pictureBoxredpiece2.Location = new Point(33, 260);
                            red_2pos = 0;
                        }
                        else if ((blue_3pos == red_3pos - 39) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                        {
                            pictureBox1redpiece3.Location = new Point(55, 230);
                            red_3pos = 0;
                        }
                        else if ((blue_3pos == red_4pos - 39) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                        {
                            pictureBox1redpiece4.Location = new Point(55, 276);
                            red_4pos = 0;
                        }
                    }

                    else
                    {
                        if ((blue_3pos == red_1pos + 13) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                    {
                        pictureBoxredpiece1.Location = new Point(80, 260);
                        red_1pos = 0;
                    }
                        else if ((blue_3pos == red_2pos + 13) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                    {
                        pictureBoxredpiece2.Location = new Point(33, 260);
                        red_2pos = 0;
                    }
                        else if ((blue_3pos == red_3pos + 13) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                    {
                        pictureBox1redpiece3.Location = new Point(55, 230);
                        red_3pos = 0;
                    }
                        else if ((blue_4pos == red_4pos + 13) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                    {
                        pictureBox1redpiece4.Location = new Point(55, 276);
                        red_4pos = 0;
                    }
                }
                    if (blue_3pos < 39)
                    {
                        if ((blue_3pos == yellow_1pos - 13) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece1.Location = new Point(277, 70);
                            yellow_1pos = 0;
                        }
                        else if ((blue_3pos == yellow_2pos - 13) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece2.Location = new Point(230, 70);
                            yellow_2pos = 0;
                        }
                        else if ((blue_3pos == yellow_3pos - 13) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece3.Location = new Point(253, 98);
                            blue_3pos = 0;
                        }
                        else if ((blue_3pos == yellow_4pos - 13) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece4.Location = new Point(253, 51);
                            yellow_4pos = 0;
                        }

                    }

                    else
                    {
                        if ((blue_3pos == yellow_1pos + 39) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece1.Location = new Point(277, 70);
                            yellow_1pos = 0;
                        }
                        else if ((blue_3pos == yellow_2pos + 39) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece2.Location = new Point(230, 70);
                            yellow_2pos = 0;
                        }
                        else if ((blue_3pos == yellow_3pos + 39) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece3.Location = new Point(253, 98);
                            yellow_3pos = 0;
                        }
                        else if ((blue_3pos == yellow_4pos + 39) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBoxyellowpiece4.Location = new Point(253, 51);
                            yellow_4pos = 0;
                        }
                    }
                }
            }
        }

        private void pictureBoxbluepiece4_Click(object sender, EventArgs e)
        {


            if (dice == 6 && pictureBoxbluepiece4.Location == new Point(247, 280))
            {

                //pictureBoxredpiece1.Location = new Point(132,284);
                pictureBoxbluepiece4.Location = new Point(288, 184);
                //redpiece1.active = true;

            }
            else if (pictureBoxbluepiece4.Location != new Point(247, 280))
            {
                if (blue_4pos >= 50)
                {

                    if (dice <= 56 - blue_4pos)
                    {

                        int x = 0;
                        for (x = 0; x <= dice; x++)
                        {
                            pictureBoxbluepiece4.Location = blue_arr1[blue_4pos + x];

                            if (pictureBoxbluepiece4.Location == p_outblue)
                            {
                                pictureBoxbluepiece4.Hide();
                                win_blue++;
                            }

                            if (win_blue == 4)
                            {
                                pictureBox1celebration.Visible = true;
                                MessageBox.Show("congrats is the winner ", textBox1p4.Text);
                                // name of player playing red peice
                            }
                            Thread.Sleep(30);
                        }

                        blue_4pos = blue_4pos + (x - 1);
                    }
                    else
                    {
                        MessageBox.Show("illegal move");
                    }
                }
               
                else
                {
                int b;
                for (b = 0; b <= dice; b++)
                {
                    pictureBoxbluepiece4.Location = blue_arr1[blue_4pos + b];
                    //if (pictureBoxbluepiece4.Location == p_outblue)
                    //{
                    //    pictureBoxbluepiece4.Hide();
                    //    win_blue++;
                    //}


                    Thread.Sleep(30);
                }
                //if (win_blue == 4)
                //{
                //    pictureBox1celebration.Visible = true;
                //    MessageBox.Show("congrats is the winner ", textBox1p4.Text);
                //    // name of player playing red peices
                //}
                blue_4pos = blue_4pos + (b - 1);
                //string s = blue_4pos.ToString();
                //MessageBox.Show("blue_4pos", s);
                if (blue_4pos < 13)
                {
                    if ((blue_4pos == red_1pos - 39) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                    {
                        pictureBoxredpiece1.Location = new Point(80, 260);
                        red_1pos = 0;
                    }
                    else if ((blue_4pos == red_2pos - 39) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                    {
                        pictureBoxredpiece2.Location = new Point(33, 260);
                        red_2pos = 0;
                    }
                    else if ((blue_4pos == red_3pos - 39) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                    {
                        pictureBox1redpiece3.Location = new Point(55, 230);
                        red_3pos = 0;
                    }
                    else if ((blue_4pos == red_4pos - 39) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                    {
                        pictureBox1redpiece4.Location = new Point(55, 276);
                        red_4pos = 0;
                    }
                }

                else
                {
                    if ((blue_4pos == red_1pos + 13) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                {
                    pictureBoxredpiece1.Location = new Point(80, 260);
                    red_1pos = 0;
                }
                    else if ((blue_4pos == red_2pos + 13) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                {
                    pictureBoxredpiece2.Location = new Point(33, 260);
                    red_2pos = 0;
                }
                    else if ((blue_4pos == red_3pos + 13) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                {
                    pictureBox1redpiece3.Location = new Point(55, 230);
                    red_3pos = 0;
                }
                    else if ((blue_4pos == red_4pos + 13) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                {
                    pictureBox1redpiece4.Location = new Point(55, 276);
                    red_4pos = 0;
                }
                }
                if (blue_4pos < 39)
                {
                    if ((blue_4pos == yellow_1pos - 13) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                    {
                        pictureBoxyellowpiece1.Location = new Point(277, 70);
                        yellow_1pos = 0;
                    }
                    else if ((blue_4pos == yellow_2pos - 13) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                    {
                        pictureBoxyellowpiece2.Location = new Point(230, 70);
                        yellow_2pos = 0;
                    }
                    else if ((blue_4pos == yellow_3pos - 13) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                    {
                        pictureBoxyellowpiece3.Location = new Point(253, 98);
                        blue_4pos = 0;
                    }
                    else if ((blue_4pos == yellow_4pos - 13) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                    {
                        pictureBoxyellowpiece4.Location = new Point(253, 51);
                        yellow_4pos = 0;
                    }

                }

                else
                {
                    if ((blue_4pos == yellow_1pos + 39) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                    {
                        pictureBoxyellowpiece1.Location = new Point(277, 70);
                        yellow_1pos = 0;
                    }
                    else if ((blue_4pos == yellow_2pos + 39) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                    {
                        pictureBoxyellowpiece2.Location = new Point(230, 70);
                        yellow_2pos = 0;
                    }
                    else if ((blue_4pos == yellow_3pos + 39) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                    {
                        pictureBoxyellowpiece3.Location = new Point(253, 98);
                        yellow_3pos = 0;
                    }
                    else if ((blue_4pos == yellow_4pos + 39) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                    {
                        pictureBoxyellowpiece4.Location = new Point(253, 51);
                        yellow_4pos = 0;
                    }
                }
            }
            }
        }

        private void pictureBox1celebration_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             if(no_ticks==0);
            pictureBoxrollingdice.Visible = true;
            no_ticks++;
            if(no_ticks==2)
            {
                pictureBox1dice.Visible = true;
                pictureBoxrollingdice.Visible = false;
               
                timer1.Stop();
                no_ticks = 0;
            }
        }

        private void pictureBoxyellowpiece1_Click(object sender, EventArgs e)
        {
            if (dice == 6 && pictureBoxyellowpiece1.Location == new Point(277, 70))// whatever house 1 pts
            {


                pictureBoxyellowpiece1.Location = new Point(175, 42);//175,42


            }
            else if (pictureBoxyellowpiece1.Location != new Point(277, 70))//whatever house1 pts
            {
                if (yellow_1pos >= 50)
                {
                    if (dice <= 56 - yellow_1pos)
                    {
                        int x = 0;
                        for (x = 0; x <= dice; x++)
                        {
                            pictureBoxyellowpiece1.Location = yellow_arr1[yellow_1pos + x];


                            if (pictureBoxyellowpiece1.Location == p_outyellow)
                            {

                                pictureBoxyellowpiece1.Hide();
                                win_yellow++;
                            }

                            if (win_yellow == 4)
                            {
                                pictureBox1celebration.Visible = true;
                                MessageBox.Show("congrats is the winner ", textBox1p2.Text);

                            }
                            Thread.Sleep(30);
                        }

                        yellow_1pos = yellow_1pos + (x - 1);
                        //string r = yellow_1pos.ToString();
                        //MessageBox.Show("yellow_1pos updated value", r);
                    }
                    else
                    {
                        MessageBox.Show("illegal move");
                    }


                }

                else
                {
                    int i;
                    for (i = 0; i <= dice; i++)
                    {
                        pictureBoxyellowpiece1.Location = yellow_arr1[yellow_1pos + i];
                        //if (pictureBoxyellowpiece1.Location ==p_outyellow)
                        //{
                        //    pictureBoxyellowpiece1.Hide();
                        //    win_yellow++;
                        //}


                        Thread.Sleep(30);
                    }

                    yellow_1pos = yellow_1pos + (i - 1);
                    //string r = yellow_1pos.ToString();
                    //MessageBox.Show("yellow_1pos", r);
                    if (yellow_1pos < 13)
                    {
                        if ((yellow_1pos == blue_1pos - 39) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxbluepiece1.Location = new Point(270, 255);
                            blue_1pos = 0;
                        }
                        else if ((yellow_1pos == blue_2pos - 39) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxbluepiece2.Location = new Point(245, 230);
                            blue_2pos = 0;
                        }
                        else if ((yellow_1pos == blue_3pos - 39) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                        {
                            pictureBoxbluepiece3.Location = new Point(223, 260);
                            blue_3pos = 0;
                        }
                        else if ((yellow_1pos == blue_4pos - 39) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                        {
                            pictureBoxbluepiece4.Location = new Point(247, 280);
                            blue_4pos = 0;
                        }

                    }

                    else
                    {
                        if ((yellow_1pos == blue_1pos + 13) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxbluepiece1.Location = new Point(270, 255);
                            blue_1pos = 0;
                        }
                        else if ((yellow_1pos == blue_2pos + 13) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxbluepiece2.Location = new Point(245, 230);
                            blue_2pos = 0;
                        }
                        else if ((yellow_1pos == blue_3pos + 13) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                        {
                            pictureBoxbluepiece3.Location = new Point(223, 260);
                            blue_3pos = 0;
                        }
                        else if ((yellow_1pos == blue_4pos + 13) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                        {
                            pictureBoxbluepiece4.Location = new Point(247, 280);
                            blue_4pos = 0;
                        }


                        // for killing red pieces

                           if(yellow_1pos<26)
                    {
                        if ((yellow_1pos == red_1pos - 26) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBoxredpiece1.Location = new Point(80, 260);
                            red_1pos = 0;
                        }
                        else if ((yellow_1pos == red_2pos - 26) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBoxredpiece2.Location = new Point(33, 260);
                            red_2pos = 0;
                        }
                        else if ((yellow_1pos == red_3pos - 26) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBox1redpiece3.Location = new Point(55, 230);
                            red_3pos = 0;
                        }
                        else if ((yellow_1pos == red_4pos - 26) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBox1redpiece4.Location = new Point(55, 276);
                            red_4pos = 0;
                        }
                    }

                    else
                    {
                        if ((yellow_1pos == red_1pos + 26) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBoxredpiece1.Location = new Point(80, 260);
                            red_1pos = 0;
                        }
                        else if ((yellow_1pos == red_2pos + 26) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBoxredpiece2.Location = new Point(33, 260);
                            red_2pos = 0;
                        }
                        else if ((yellow_1pos == red_3pos + 26) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBox1redpiece3.Location = new Point(55, 230);
                            red_3pos = 0;
                        }
                        else if ((yellow_1pos == red_4pos + 26) && ((pictureBoxyellowpiece1.Location != stopred) && (pictureBoxyellowpiece1.Location != stopblue) && (pictureBoxyellowpiece1.Location != stopgreen) && (pictureBoxyellowpiece1.Location != stopyellow)))
                        {
                            pictureBox1redpiece4.Location = new Point(55, 276);
                            red_4pos = 0;
                        }
                    }

                }
                    }
                }
            }

        private void pictureBoxyellowpiece2_Click(object sender, EventArgs e)
        {
            
            if (dice == 6 && pictureBoxyellowpiece2.Location == new Point(230, 70))
            {
                
                
                pictureBoxyellowpiece2.Location =new Point(175,42);
                

            }
            else if (pictureBoxyellowpiece2.Location != new Point(230, 70))
            {
                if (yellow_2pos >= 50)
                {
                    if (dice <= 56 - yellow_2pos)
                    {
                        int x = 0;
                        for (x = 0; x <= dice; x++)
                        {
                            pictureBoxyellowpiece2.Location = yellow_arr1[yellow_2pos + x];
                          

                            if (pictureBoxyellowpiece2.Location == p_outyellow)
                            {
                            
                                pictureBoxyellowpiece2.Hide();
                                win_yellow++;
                            }                                                        

                            if ( win_yellow == 4)
                            {
                                pictureBox1celebration.Visible = true;
                                MessageBox.Show("congrats is the winner ", textBox1p2.Text);
                                
                            }
                            Thread.Sleep(30);
                        }

                        yellow_2pos = yellow_2pos + (x - 1);
                        //string r = yellow_2pos.ToString();
                        //MessageBox.Show("yellow_2pos updated value", r);
                    }
                    else
                    {
                        MessageBox.Show("illegal move");
                    }


                }

                else
                {
                    int i;
                    for (i = 0; i <= dice; i++)
                    {
                        pictureBoxyellowpiece2.Location = yellow_arr1[yellow_2pos + i];
                        //if (pictureBoxyellowpiece2.Location ==p_outyellow)
                        //{
                        //    pictureBoxyellowpiece2.Hide();
                        //    win_yellow++;
                        //}


                        Thread.Sleep(30);
                    }
                 
                    yellow_2pos = yellow_2pos + (i - 1);
                    //string r = yellow_2pos.ToString();
                    //MessageBox.Show("yellow_2pos", r);
                    if(yellow_2pos<13)
                    {
                        if ((yellow_2pos == blue_1pos - 39) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxbluepiece1.Location = new Point(270, 255);
                            blue_1pos = 0;
                        }
                        else if ((yellow_2pos == blue_2pos - 39) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxbluepiece2.Location = new Point(245, 230);
                            blue_2pos = 0;
                        }
                        else if ((yellow_2pos == blue_3pos - 39) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                        {
                            pictureBoxbluepiece3.Location = new Point(223, 260);
                            blue_3pos = 0;
                        }
                        else if ((yellow_2pos == blue_4pos - 39) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                        {
                            pictureBoxbluepiece4.Location = new Point(247, 280);
                            blue_4pos = 0;
                        }
                     
                    }

                    else
                    {
                        if ((yellow_2pos == blue_1pos + 13) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxbluepiece1.Location = new Point(270, 255);
                            blue_1pos = 0;
                        }
                        else if ((yellow_2pos == blue_2pos + 13) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxbluepiece2.Location = new Point(245, 230);
                            blue_2pos = 0;
                        }
                        else if ((yellow_2pos == blue_3pos + 13) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                        {
                            pictureBoxbluepiece3.Location = new Point(223, 260);
                            blue_3pos = 0;
                        }
                        else if ((yellow_2pos == blue_4pos + 13) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                        {
                            pictureBoxbluepiece4.Location = new Point(247, 280);
                            blue_4pos = 0;
                        }
                    }
                          if(yellow_2pos<26)
                    {
                        if ((yellow_2pos == red_1pos - 26) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBoxredpiece1.Location = new Point(80, 260);
                            red_1pos = 0;
                        }
                        else if ((yellow_2pos == red_2pos - 26) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBoxredpiece2.Location = new Point(33, 260);
                            red_2pos = 0;
                        }
                        else if ((yellow_2pos == red_3pos - 26) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBox1redpiece3.Location = new Point(55, 230);
                            red_3pos = 0;
                        }
                        else if ((yellow_2pos == red_4pos - 26) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBox1redpiece4.Location = new Point(55, 276);
                            red_4pos = 0;
                        }
                    }

                    else
                    {
                        if ((yellow_2pos == red_1pos + 26) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBoxredpiece1.Location = new Point(80, 260);
                            red_1pos = 0;
                        }
                        else if ((yellow_2pos == red_2pos + 26) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBoxredpiece2.Location = new Point(33, 260);
                            red_2pos = 0;
                        }
                        else if ((yellow_2pos == red_3pos + 26) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBox1redpiece3.Location = new Point(55, 230);
                            red_3pos = 0;
                        }
                        else if ((yellow_2pos == red_4pos + 26) && ((pictureBoxyellowpiece2.Location != stopred) && (pictureBoxyellowpiece2.Location != stopblue) && (pictureBoxyellowpiece2.Location != stopgreen) && (pictureBoxyellowpiece2.Location != stopyellow)))
                        {
                            pictureBox1redpiece4.Location = new Point(55, 276);
                            red_4pos = 0;
                        }
                    }

                }

                }
            }
        

        private void pictureBoxyellowpiece3_Click(object sender, EventArgs e)
        {
               if (dice == 6 && pictureBoxyellowpiece3.Location == new Point(253, 98))
            {
                
                
                pictureBoxyellowpiece3.Location =new Point(175,42);
                

            }
            else if (pictureBoxyellowpiece3.Location != new Point(253, 98))
            {
                if (yellow_3pos >= 50)
                {
                    if (dice <= 56 - yellow_3pos)
                    {
                        int x = 0;
                        for (x = 0; x <= dice; x++)
                        {
                            pictureBoxyellowpiece3.Location = yellow_arr1[yellow_3pos + x];
                          

                            if (pictureBoxyellowpiece3.Location == p_outyellow)
                            {
                            
                                pictureBoxyellowpiece3.Hide();
                                win_yellow++;
                            }                                                        

                            if ( win_yellow == 4)
                            {
                                pictureBox1celebration.Visible = true;
                                MessageBox.Show("congrats is the winner ", textBox1p2.Text);
                                
                            }
                            Thread.Sleep(30);
                        }

                        yellow_3pos = yellow_3pos + (x - 1);
                        //string r = yellow_3pos.ToString();
                        //MessageBox.Show("yellow_3pos updated value", r);
                    }
                    else
                    {
                        MessageBox.Show("illegal move");
                    }


                }

                else
                {
                    int i;
                    for (i = 0; i <= dice; i++)
                    {
                        pictureBoxyellowpiece3.Location = yellow_arr1[yellow_3pos + i];
                        //if (pictureBoxyellowpiece3.Location ==p_outyellow)
                        //{
                        //    pictureBoxyellowpiece3.Hide();
                        //    win_yellow++;
                        //}


                        Thread.Sleep(30);
                    }
                 
                    yellow_3pos = yellow_3pos + (i - 1);
                    //string r = yellow_3pos.ToString();
                    //MessageBox.Show("yellow_3pos", r);
                    if(yellow_3pos<13)
                    {
                        if ((yellow_3pos == blue_1pos - 39) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxbluepiece1.Location = new Point(270, 255);
                            blue_1pos = 0;
                        }
                        else if ((yellow_3pos == blue_2pos - 39) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxbluepiece2.Location = new Point(245, 230);
                            blue_2pos = 0;
                        }
                        else if ((yellow_3pos == blue_3pos - 39) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                        {
                            pictureBoxbluepiece3.Location = new Point(223, 260);
                            blue_3pos = 0;
                        }
                        else if ((yellow_3pos == blue_4pos - 39) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                        {
                            pictureBoxbluepiece4.Location = new Point(247, 280);
                            blue_4pos = 0;
                        }
                     
                    }

                    else
                    {
                        if ((yellow_3pos == blue_1pos + 13) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxbluepiece1.Location = new Point(270, 255);
                            blue_1pos = 0;
                        }
                        else if ((yellow_3pos == blue_2pos + 13) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxbluepiece2.Location = new Point(245, 230);
                            blue_2pos = 0;
                        }
                        else if ((yellow_3pos == blue_3pos + 13) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                        {
                            pictureBoxbluepiece3.Location = new Point(223, 260);
                            blue_3pos = 0;
                        }
                        else if ((yellow_3pos == blue_4pos + 13) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                        {
                            pictureBoxbluepiece4.Location = new Point(247, 280);
                            blue_4pos = 0;
                        }
                    }
                          if(yellow_3pos<26)
                    {
                        if ((yellow_3pos == red_1pos - 26) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBoxredpiece1.Location = new Point(80, 260);
                            red_1pos = 0;
                        }
                        else if ((yellow_3pos == red_2pos - 26) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBoxredpiece2.Location = new Point(33, 260);
                            red_2pos = 0;
                        }
                        else if ((yellow_3pos == red_3pos - 26) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBox1redpiece3.Location = new Point(55, 230);
                            red_3pos = 0;
                        }
                        else if ((yellow_3pos == red_4pos - 26) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBox1redpiece4.Location = new Point(55, 276);
                            red_4pos = 0;
                        }
                    }

                    else
                    {
                        if ((yellow_3pos == red_1pos + 26) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBoxredpiece1.Location = new Point(80, 260);
                            red_1pos = 0;
                        }
                        else if ((yellow_3pos == red_2pos + 26) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBoxredpiece2.Location = new Point(33, 260);
                            red_2pos = 0;
                        }
                        else if ((yellow_3pos == red_3pos + 26) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBox1redpiece3.Location = new Point(55, 230);
                            red_3pos = 0;
                        }
                        else if ((yellow_3pos == red_4pos + 26) && ((pictureBoxyellowpiece3.Location != stopred) && (pictureBoxyellowpiece3.Location != stopblue) && (pictureBoxyellowpiece3.Location != stopgreen) && (pictureBoxyellowpiece3.Location != stopyellow)))
                        {
                            pictureBox1redpiece4.Location = new Point(55, 276);
                            red_4pos = 0;
                        }
                    }

                }

                }
            
        }

        private void pictureBoxyellowpiece4_Click(object sender, EventArgs e)
        {
             if (dice == 6 && pictureBoxyellowpiece4.Location == new Point(253, 51))
            {
                
                
                pictureBoxyellowpiece4.Location =new Point(175,42);
                

            }
            else if (pictureBoxyellowpiece4.Location != new Point(253, 51))
            {
                if (yellow_4pos >= 50)
                {
                    if (dice <= 56 - yellow_4pos)
                    {
                        int x = 0;
                        for (x = 0; x <= dice; x++)
                        {
                            pictureBoxyellowpiece4.Location = yellow_arr1[yellow_4pos + x];
                          

                            if (pictureBoxyellowpiece4.Location == p_outyellow)
                            {
                            
                                pictureBoxyellowpiece4.Hide();
                                win_yellow++;
                            }                                                        

                            if ( win_yellow == 4)
                            {
                                pictureBox1celebration.Visible = true;
                                MessageBox.Show("congrats is the winner ", textBox1p2.Text);
                                
                            }
                            Thread.Sleep(30);
                        }

                        yellow_4pos = yellow_4pos + (x - 1);
                        //string r = yellow_4pos.ToString();
                        //MessageBox.Show("yellow_4pos updated value", r);
                    }
                    else
                    {
                        MessageBox.Show("illegal move");
                    }


                }

                else
                {
                    int i;
                    for (i = 0; i <= dice; i++)
                    {
                        pictureBoxyellowpiece4.Location = yellow_arr1[yellow_4pos + i];
                        //if (pictureBoxyellowpiece4.Location ==p_outyellow)
                        //{
                        //    pictureBoxyellowpiece4.Hide();
                        //    win_yellow++;
                        //}


                        Thread.Sleep(30);
                    }
                 
                    yellow_4pos = yellow_4pos + (i - 1);
                    //string r = yellow_4pos.ToString();
                    //MessageBox.Show("yellow_4pos", r);
                    if(yellow_4pos<13)
                    {
                        if ((yellow_4pos == blue_1pos - 39) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxbluepiece1.Location = new Point(270, 255);
                            blue_1pos = 0;
                        }
                        else if ((yellow_4pos == blue_2pos - 39) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxbluepiece2.Location = new Point(245, 230);
                            blue_2pos = 0;
                        }
                        else if ((yellow_4pos == blue_3pos - 39) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                        {
                            pictureBoxbluepiece3.Location = new Point(223, 260);
                            blue_3pos = 0;
                        }
                        else if ((yellow_4pos == blue_4pos - 39) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                        {
                            pictureBoxbluepiece4.Location = new Point(247, 280);
                            blue_4pos = 0;
                        }
                     
                    }

                    else
                    {
                        if ((yellow_4pos == blue_1pos + 13) && ((pictureBoxbluepiece1.Location != stopred) && (pictureBoxbluepiece1.Location != stopblue) && (pictureBoxbluepiece1.Location != stopgreen) && (pictureBoxbluepiece1.Location != stopyellow)))
                        {
                            pictureBoxbluepiece1.Location = new Point(270, 255);
                            blue_1pos = 0;
                        }
                        else if ((yellow_4pos == blue_2pos + 13) && ((pictureBoxbluepiece2.Location != stopred) && (pictureBoxbluepiece2.Location != stopblue) && (pictureBoxbluepiece2.Location != stopgreen) && (pictureBoxbluepiece2.Location != stopyellow)))
                        {
                            pictureBoxbluepiece2.Location = new Point(245, 230);
                            blue_2pos = 0;
                        }
                        else if ((yellow_4pos == blue_3pos + 13) && ((pictureBoxbluepiece3.Location != stopred) && (pictureBoxbluepiece3.Location != stopblue) && (pictureBoxbluepiece3.Location != stopgreen) && (pictureBoxbluepiece3.Location != stopyellow)))
                        {
                            pictureBoxbluepiece3.Location = new Point(223, 260);
                            blue_3pos = 0;
                        }
                        else if ((yellow_4pos == blue_4pos + 13) && ((pictureBoxbluepiece4.Location != stopred) && (pictureBoxbluepiece4.Location != stopblue) && (pictureBoxbluepiece4.Location != stopgreen) && (pictureBoxbluepiece4.Location != stopyellow)))
                        {
                            pictureBoxbluepiece4.Location = new Point(247, 280);
                            blue_4pos = 0;
                        }
                    }
                          if(yellow_4pos<26)
                    {
                        if ((yellow_4pos == red_1pos - 26) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBoxredpiece1.Location = new Point(80, 260);
                            red_1pos = 0;
                        }
                        else if ((yellow_4pos == red_2pos - 26) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBoxredpiece2.Location = new Point(33, 260);
                            red_2pos = 0;
                        }
                        else if ((yellow_4pos == red_3pos - 26) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBox1redpiece3.Location = new Point(55, 230);
                            red_3pos = 0;
                        }
                        else if ((yellow_4pos == red_4pos - 26) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBox1redpiece4.Location = new Point(55, 276);
                            red_4pos = 0;
                        }
                    }

                    else
                    {
                        if ((yellow_4pos == red_1pos + 26) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBoxredpiece1.Location = new Point(80, 260);
                            red_1pos = 0;
                        }
                        else if ((yellow_4pos == red_2pos + 26) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBoxredpiece2.Location = new Point(33, 260);
                            red_2pos = 0;
                        }
                        else if ((yellow_4pos == red_3pos + 26) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBox1redpiece3.Location = new Point(55, 230);
                            red_3pos = 0;
                        }
                        else if ((yellow_4pos == red_4pos + 26) && ((pictureBoxyellowpiece4.Location != stopred) && (pictureBoxyellowpiece4.Location != stopblue) && (pictureBoxyellowpiece4.Location != stopgreen) && (pictureBoxyellowpiece4.Location != stopyellow)))
                        {
                            pictureBox1redpiece4.Location = new Point(55, 276);
                            red_4pos = 0;
                        }
                    }

                }

                }
            }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        }
        }

     

        
    

    

       
        
        
