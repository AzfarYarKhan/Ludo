namespace ludostate1.cpp
{
    partial class Form2entername
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2entername));
            this.textBox1player1 = new System.Windows.Forms.TextBox();
            this.textBox1player2 = new System.Windows.Forms.TextBox();
            this.textBox1player3 = new System.Windows.Forms.TextBox();
            this.textBox1player4 = new System.Windows.Forms.TextBox();
            this.pictureBox1continue = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1continue)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1player1
            // 
            this.textBox1player1.Location = new System.Drawing.Point(142, 184);
            this.textBox1player1.Name = "textBox1player1";
            this.textBox1player1.Size = new System.Drawing.Size(92, 20);
            this.textBox1player1.TabIndex = 1;
            // 
            // textBox1player2
            // 
            this.textBox1player2.Location = new System.Drawing.Point(142, 210);
            this.textBox1player2.Name = "textBox1player2";
            this.textBox1player2.Size = new System.Drawing.Size(92, 20);
            this.textBox1player2.TabIndex = 2;
            // 
            // textBox1player3
            // 
            this.textBox1player3.Location = new System.Drawing.Point(142, 236);
            this.textBox1player3.Name = "textBox1player3";
            this.textBox1player3.Size = new System.Drawing.Size(92, 20);
            this.textBox1player3.TabIndex = 3;
            // 
            // textBox1player4
            // 
            this.textBox1player4.Location = new System.Drawing.Point(142, 262);
            this.textBox1player4.Name = "textBox1player4";
            this.textBox1player4.Size = new System.Drawing.Size(92, 20);
            this.textBox1player4.TabIndex = 4;
            // 
            // pictureBox1continue
            // 
            this.pictureBox1continue.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1continue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1continue.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1continue.Image")));
            this.pictureBox1continue.Location = new System.Drawing.Point(236, 248);
            this.pictureBox1continue.Name = "pictureBox1continue";
            this.pictureBox1continue.Size = new System.Drawing.Size(97, 65);
            this.pictureBox1continue.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1continue.TabIndex = 5;
            this.pictureBox1continue.TabStop = false;
            this.pictureBox1continue.Click += new System.EventHandler(this.pictureBox1continue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(149, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "ENTER NAMES";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form2entername
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(345, 314);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1continue);
            this.Controls.Add(this.textBox1player4);
            this.Controls.Add(this.textBox1player3);
            this.Controls.Add(this.textBox1player2);
            this.Controls.Add(this.textBox1player1);
            this.Name = "Form2entername";
            this.Text = "Form2entername";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveCaptionText;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1continue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1player1;
        private System.Windows.Forms.TextBox textBox1player2;
        private System.Windows.Forms.TextBox textBox1player3;
        private System.Windows.Forms.TextBox textBox1player4;
        private System.Windows.Forms.PictureBox pictureBox1continue;
        private System.Windows.Forms.Label label1;
    }
}