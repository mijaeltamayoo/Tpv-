using System.Drawing;
using System.Windows.Forms;

namespace tpv
{
    partial class adminform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(adminform));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.text_stock = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.text_precio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.text_producto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.edit = new System.Windows.Forms.Button();
            this.cross = new System.Windows.Forms.Button();
            this.check = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(97, 446);
            this.panel1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImage = global::tpv.Properties.Resources.image;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Location = new System.Drawing.Point(19, 245);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(59, 55);
            this.button3.TabIndex = 6;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Location = new System.Drawing.Point(19, 355);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 55);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(19, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 55);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(603, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(497, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(488, 343);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(210, 95);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(376, 273);
            this.dataGridView2.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel2.Controls.Add(this.edit);
            this.panel2.Controls.Add(this.text_stock);
            this.panel2.Controls.Add(this.cross);
            this.panel2.Controls.Add(this.check);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.text_precio);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.text_producto);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(644, 128);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(183, 203);
            this.panel2.TabIndex = 5;
            // 
            // text_stock
            // 
            this.text_stock.Location = new System.Drawing.Point(16, 163);
            this.text_stock.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.text_stock.Name = "text_stock";
            this.text_stock.Size = new System.Drawing.Size(76, 20);
            this.text_stock.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(14, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Stock";
            // 
            // text_precio
            // 
            this.text_precio.Location = new System.Drawing.Point(16, 99);
            this.text_precio.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.text_precio.Name = "text_precio";
            this.text_precio.Size = new System.Drawing.Size(76, 20);
            this.text_precio.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 76);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Precio";
            // 
            // text_producto
            // 
            this.text_producto.Location = new System.Drawing.Point(16, 41);
            this.text_producto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.text_producto.Name = "text_producto";
            this.text_producto.Size = new System.Drawing.Size(76, 20);
            this.text_producto.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Producto";
            // 
            // edit
            // 
            this.edit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.edit.BackColor = System.Drawing.Color.White;
            this.edit.BackgroundImage = global::tpv.Properties.Resources.edit;
            this.edit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.edit.Location = new System.Drawing.Point(130, 142);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(27, 27);
            this.edit.TabIndex = 11;
            this.edit.UseVisualStyleBackColor = false;
            // 
            // cross
            // 
            this.cross.BackColor = System.Drawing.Color.White;
            this.cross.BackgroundImage = global::tpv.Properties.Resources.cross;
            this.cross.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cross.Location = new System.Drawing.Point(130, 95);
            this.cross.Margin = new System.Windows.Forms.Padding(2);
            this.cross.Name = "cross";
            this.cross.Size = new System.Drawing.Size(27, 27);
            this.cross.TabIndex = 10;
            this.cross.UseVisualStyleBackColor = false;
            // 
            // check
            // 
            this.check.BackColor = System.Drawing.Color.White;
            this.check.BackgroundImage = global::tpv.Properties.Resources.check;
            this.check.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.check.Location = new System.Drawing.Point(130, 48);
            this.check.Margin = new System.Windows.Forms.Padding(2);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(27, 27);
            this.check.TabIndex = 9;
            this.check.UseVisualStyleBackColor = false;
            // 
            // adminform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(937, 448);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.panel1);
            this.Name = "adminform";
            this.Text = "adminform";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private Button button2;
        private Label label1;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Panel panel2;
        private Label label2;
        private TextBox text_precio;
        private Label label3;
        private TextBox text_producto;
        private TextBox text_stock;
        private Label label4;
        private Button button3;
        private Button edit;
        private Button cross;
        private Button check;
    }
}