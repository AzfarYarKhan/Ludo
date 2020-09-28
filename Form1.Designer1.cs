namespace ludostate1.cpp
{
    partial class form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            //base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form1));
            this.pictureBoxintro = new System.Windows.Forms.PictureBox();
            this.picturebox1play = new System.Windows.Forms.PictureBox();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.pictureBox1exit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxintro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox1play)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1exit)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxintro
            // 
            this.pictureBoxintro.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxintro.Image")));
            this.pictureBoxintro.Location = new System.Drawing.Point(-6, -2);
            this.pictureBoxintro.Name = "pictureBoxintro";
            this.pictureBoxintro.Size = new System.Drawing.Size(291, 265);
            this.pictureBoxintro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxintro.TabIndex = 0;
            this.pictureBoxintro.TabStop = false;
            this.pictureBoxintro.Click += new System.EventHandler(this.pictureBoxintro_Click);
            // 
            // picturebox1play
            // 
            this.picturebox1play.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picturebox1play.Image = ((System.Drawing.Image)(resources.GetObject("picturebox1play.Image")));
            this.picturebox1play.Location = new System.Drawing.Point(150, 110);
            this.picturebox1play.Name = "picturebox1play";
            this.picturebox1play.Size = new System.Drawing.Size(122, 54);
            this.picturebox1play.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturebox1play.TabIndex = 1;
            this.picturebox1play.TabStop = false;
            this.picturebox1play.Visible = false;
            this.picturebox1play.Click += new System.EventHandler(this.picturebox1play_Click);
            // 
            // pictureBox1exit
            // 
            this.pictureBox1exit.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1exit.Image")));
            this.pictureBox1exit.Location = new System.Drawing.Point(150, 184);
            this.pictureBox1exit.Name = "pictureBox1exit";
            this.pictureBox1exit.Size = new System.Drawing.Size(110, 42);
            this.pictureBox1exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1exit.TabIndex = 2;
            this.pictureBox1exit.TabStop = false;
            this.pictureBox1exit.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.pictureBox1exit);
            this.Controls.Add(this.picturebox1play);
            this.Controls.Add(this.pictureBoxintro);
            this.Name = "form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxintro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturebox1play)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1exit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxintro;
        private System.Windows.Forms.PictureBox picturebox1play;
        private System.ServiceProcess.ServiceController serviceController1;
        private System.Windows.Forms.PictureBox pictureBox1exit;
    }
}

