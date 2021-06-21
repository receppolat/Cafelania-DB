namespace CafeRestorantOtomasyonu
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.yoneticiIslemleri = new System.Windows.Forms.MenuStrip();
            this.menuUrun = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTur = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPersonel = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btncikis = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.yoneticiIslemleri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // yoneticiIslemleri
            // 
            this.yoneticiIslemleri.BackColor = System.Drawing.Color.Black;
            this.yoneticiIslemleri.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.yoneticiIslemleri.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUrun,
            this.menuTur,
            this.menuPersonel});
            this.yoneticiIslemleri.Location = new System.Drawing.Point(0, 0);
            this.yoneticiIslemleri.Name = "yoneticiIslemleri";
            this.yoneticiIslemleri.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.yoneticiIslemleri.Size = new System.Drawing.Size(1285, 24);
            this.yoneticiIslemleri.TabIndex = 0;
            this.yoneticiIslemleri.Text = "menuStrip1";
            // 
            // menuUrun
            // 
            this.menuUrun.ForeColor = System.Drawing.Color.White;
            this.menuUrun.Name = "menuUrun";
            this.menuUrun.Size = new System.Drawing.Size(92, 20);
            this.menuUrun.Text = "Ürün İşlemleri";
            this.menuUrun.Click += new System.EventHandler(this.menuUrun_Click);
            // 
            // menuTur
            // 
            this.menuTur.ForeColor = System.Drawing.Color.White;
            this.menuTur.Name = "menuTur";
            this.menuTur.Size = new System.Drawing.Size(84, 20);
            this.menuTur.Text = "Tür İşlemleri";
            this.menuTur.Click += new System.EventHandler(this.menuTur_Click);
            // 
            // menuPersonel
            // 
            this.menuPersonel.ForeColor = System.Drawing.Color.White;
            this.menuPersonel.Name = "menuPersonel";
            this.menuPersonel.Size = new System.Drawing.Size(153, 20);
            this.menuPersonel.Text = "Personel Ve Cafe İşlemleri";
            this.menuPersonel.Click += new System.EventHandler(this.menuPersonel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(90, 210);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(8);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(19, 20, 19, 20);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1402, 569);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(575, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "CAFELANIA | Masalar";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(32, 25);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1474, 116);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // btncikis
            // 
            this.btncikis.BackColor = System.Drawing.Color.Transparent;
            this.btncikis.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btncikis.BackgroundImage")));
            this.btncikis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btncikis.Location = new System.Drawing.Point(1444, 0);
            this.btncikis.Margin = new System.Windows.Forms.Padding(2);
            this.btncikis.Name = "btncikis";
            this.btncikis.Size = new System.Drawing.Size(32, 28);
            this.btncikis.TabIndex = 4;
            this.btncikis.UseVisualStyleBackColor = false;
            this.btncikis.Click += new System.EventHandler(this.btncikis_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(1144, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Gri Masa | Müsait";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(1144, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kırmızı Masa | Dolu";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1285, 640);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btncikis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.yoneticiIslemleri);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.yoneticiIslemleri;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cafelania | Masalar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.yoneticiIslemleri.ResumeLayout(false);
            this.yoneticiIslemleri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip yoneticiIslemleri;
        private System.Windows.Forms.ToolStripMenuItem menuUrun;
        private System.Windows.Forms.ToolStripMenuItem menuTur;
        private System.Windows.Forms.ToolStripMenuItem menuPersonel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btncikis;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}