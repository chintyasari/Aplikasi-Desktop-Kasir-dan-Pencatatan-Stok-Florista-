namespace ProjectPBOFlorista
{
    partial class master
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pengaturan = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kasirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pencatatanKeuanganToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pencatatanStokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pengaturan,
            this.floristaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pengaturan
            // 
            this.pengaturan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.pengaturan.Name = "pengaturan";
            this.pengaturan.Size = new System.Drawing.Size(80, 20);
            this.pengaturan.Text = "Pengaturan";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            // 
            // floristaToolStripMenuItem
            // 
            this.floristaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kasirToolStripMenuItem,
            this.pencatatanKeuanganToolStripMenuItem,
            this.pencatatanStokToolStripMenuItem});
            this.floristaToolStripMenuItem.Name = "floristaToolStripMenuItem";
            this.floristaToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.floristaToolStripMenuItem.Text = "Florista";
            // 
            // kasirToolStripMenuItem
            // 
            this.kasirToolStripMenuItem.Name = "kasirToolStripMenuItem";
            this.kasirToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.kasirToolStripMenuItem.Text = "Kasir ";
            // 
            // pencatatanKeuanganToolStripMenuItem
            // 
            this.pencatatanKeuanganToolStripMenuItem.Name = "pencatatanKeuanganToolStripMenuItem";
            this.pencatatanKeuanganToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.pencatatanKeuanganToolStripMenuItem.Text = "Pencatatan Keuangan";
            // 
            // pencatatanStokToolStripMenuItem
            // 
            this.pencatatanStokToolStripMenuItem.Name = "pencatatanStokToolStripMenuItem";
            this.pencatatanStokToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.pencatatanStokToolStripMenuItem.Text = "Pencatatan Stok";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Location = new System.Drawing.Point(240, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(890, 539);
            this.panel1.TabIndex = 12;
            // 
            // master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "master";
            this.Text = "master";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pengaturan;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floristaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kasirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pencatatanKeuanganToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pencatatanStokToolStripMenuItem;
        public System.Windows.Forms.Panel panel1;
    }
}