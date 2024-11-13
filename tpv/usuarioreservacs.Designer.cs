namespace tpv
{
    partial class usuarioreservacs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(usuarioreservacs));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lista = new System.Windows.Forms.Button();
            this.reservar = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mesa1 = new System.Windows.Forms.Button();
            this.mesa2 = new System.Windows.Forms.Button();
            this.mesa4 = new System.Windows.Forms.Button();
            this.mesa5 = new System.Windows.Forms.Button();
            this.mesa3 = new System.Windows.Forms.Button();
            this.mesa6 = new System.Windows.Forms.Button();
            this.mesa7 = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.exit);
            this.panel1.Controls.Add(this.lista);
            this.panel1.Controls.Add(this.reservar);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(97, 678);
            this.panel1.TabIndex = 11;
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.lista.BackColor = System.Drawing.Color.White;
            this.lista.BackgroundImage = global::tpv.Properties.Resources.lista;
            this.lista.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lista.Location = new System.Drawing.Point(21, 364);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(59, 55);
            this.lista.TabIndex = 8;
            this.lista.UseVisualStyleBackColor = false;
            this.lista.Click += new System.EventHandler(this.lista_Click);
            // 
            // reservar
            // 
            this.reservar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reservar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reservar.BackColor = System.Drawing.Color.White;
            this.reservar.BackgroundImage = global::tpv.Properties.Resources.mesa;
            this.reservar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reservar.Location = new System.Drawing.Point(21, 248);
            this.reservar.Name = "reservar";
            this.reservar.Size = new System.Drawing.Size(59, 55);
            this.reservar.TabIndex = 7;
            this.reservar.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImage = global::tpv.Properties.Resources.image;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(21, 140);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(59, 55);
            this.button3.TabIndex = 6;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 85);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // mesa1
            // 
            this.mesa1.Location = new System.Drawing.Point(223, 163);
            this.mesa1.Name = "mesa1";
            this.mesa1.Size = new System.Drawing.Size(127, 63);
            this.mesa1.TabIndex = 12;
            this.mesa1.Text = "Mesa 1";
            this.mesa1.UseVisualStyleBackColor = true;
            this.mesa1.Click += new System.EventHandler(this.Mesa_Click);
            // 
            // mesa2
            // 
            this.mesa2.Location = new System.Drawing.Point(400, 163);
            this.mesa2.Name = "mesa2";
            this.mesa2.Size = new System.Drawing.Size(127, 63);
            this.mesa2.TabIndex = 13;
            this.mesa2.Text = "Mesa 2";
            this.mesa2.UseVisualStyleBackColor = true;
            this.mesa2.Click += new System.EventHandler(this.Mesa_Click);
            // 
            // mesa4
            // 
            this.mesa4.Location = new System.Drawing.Point(223, 276);
            this.mesa4.Name = "mesa4";
            this.mesa4.Size = new System.Drawing.Size(127, 63);
            this.mesa4.TabIndex = 14;
            this.mesa4.Text = "Mesa 4";
            this.mesa4.UseVisualStyleBackColor = true;
            this.mesa4.Click += new System.EventHandler(this.Mesa_Click);
            // 
            // mesa5
            // 
            this.mesa5.Location = new System.Drawing.Point(400, 276);
            this.mesa5.Name = "mesa5";
            this.mesa5.Size = new System.Drawing.Size(127, 63);
            this.mesa5.TabIndex = 15;
            this.mesa5.Text = "Mesa 5";
            this.mesa5.UseVisualStyleBackColor = true;
            this.mesa5.Click += new System.EventHandler(this.Mesa_Click);
            // 
            // mesa3
            // 
            this.mesa3.Location = new System.Drawing.Point(572, 163);
            this.mesa3.Name = "mesa3";
            this.mesa3.Size = new System.Drawing.Size(127, 63);
            this.mesa3.TabIndex = 16;
            this.mesa3.Text = "Mesa 3";
            this.mesa3.UseVisualStyleBackColor = true;
            this.mesa3.Click += new System.EventHandler(this.Mesa_Click);
            // 
            // mesa6
            // 
            this.mesa6.Location = new System.Drawing.Point(572, 276);
            this.mesa6.Name = "mesa6";
            this.mesa6.Size = new System.Drawing.Size(127, 63);
            this.mesa6.TabIndex = 17;
            this.mesa6.Text = "Mesa 6";
            this.mesa6.UseVisualStyleBackColor = true;
            this.mesa6.Click += new System.EventHandler(this.Mesa_Click);
            // 
            // mesa7
            // 
            this.mesa7.Location = new System.Drawing.Point(400, 383);
            this.mesa7.Name = "mesa7";
            this.mesa7.Size = new System.Drawing.Size(127, 63);
            this.mesa7.TabIndex = 18;
            this.mesa7.Text = "Mesa 7";
            this.mesa7.UseVisualStyleBackColor = true;
            this.mesa7.Click += new System.EventHandler(this.Mesa_Click);
            // 
            // exit
            // 
            this.exit.BackgroundImage = global::tpv.Properties.Resources.exit1;
            this.exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exit.Location = new System.Drawing.Point(21, 471);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(59, 55);
            this.exit.TabIndex = 19;
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // usuarioreservacs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::tpv.Properties.Resources.background1;
            this.ClientSize = new System.Drawing.Size(873, 565);
            this.Controls.Add(this.mesa7);
            this.Controls.Add(this.mesa6);
            this.Controls.Add(this.mesa3);
            this.Controls.Add(this.mesa5);
            this.Controls.Add(this.mesa4);
            this.Controls.Add(this.mesa2);
            this.Controls.Add(this.mesa1);
            this.Controls.Add(this.panel1);
            this.Name = "usuarioreservacs";
            this.Text = "usuarioreservacs";
            this.Load += new System.EventHandler(this.usuarioreservacs_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button reservar;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button mesa1;
        private System.Windows.Forms.Button mesa2;
        private System.Windows.Forms.Button mesa4;
        private System.Windows.Forms.Button mesa5;
        private System.Windows.Forms.Button mesa3;
        private System.Windows.Forms.Button mesa6;
        private System.Windows.Forms.Button mesa7;
        private System.Windows.Forms.Button lista;
        private System.Windows.Forms.Button exit;
    }
}