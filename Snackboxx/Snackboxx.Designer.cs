namespace Snackboxx
{
    partial class SnackboxxForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SnackboxxForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssinfoONE = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssinfoTWO = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssinfoTHREE = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssinfoFOUR = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.inputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.securityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.showpanel = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.tssinfoONE, this.tssinfoTWO, this.tssinfoTHREE, this.tssinfoFOUR});
            this.statusStrip1.Location = new System.Drawing.Point(0, 552);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(831, 25);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssinfoONE
            // 
            this.tssinfoONE.AutoSize = false;
            this.tssinfoONE.BorderSides =
                ((System.Windows.Forms.ToolStripStatusLabelBorderSides) ((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left |
                                                                            System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) |
                                                                           System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) |
                                                                          System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssinfoONE.Name = "tssinfoONE";
            this.tssinfoONE.Size = new System.Drawing.Size(400, 20);
            this.tssinfoONE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssinfoTWO
            // 
            this.tssinfoTWO.AutoSize = false;
            this.tssinfoTWO.Name = "tssinfoTWO";
            this.tssinfoTWO.Size = new System.Drawing.Size(100, 20);
            // 
            // tssinfoTHREE
            // 
            this.tssinfoTHREE.AutoSize = false;
            this.tssinfoTHREE.Name = "tssinfoTHREE";
            this.tssinfoTHREE.Size = new System.Drawing.Size(100, 20);
            // 
            // tssinfoFOUR
            // 
            this.tssinfoFOUR.AutoSize = false;
            this.tssinfoFOUR.BorderSides =
                ((System.Windows.Forms.ToolStripStatusLabelBorderSides) ((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left |
                                                                            System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) |
                                                                           System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) |
                                                                          System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.tssinfoFOUR.Name = "tssinfoFOUR";
            this.tssinfoFOUR.Size = new System.Drawing.Size(80, 20);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
                {this.toolStripMenuItem1, this.toolStripMenuItem2, this.toolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(831, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.closeToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::Snackboxx.Properties.Resources.Delete;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.inputToolStripMenuItem, this.userToolStripMenuItem, this.postenToolStripMenuItem, this.toolStripSeparator1, this.securityToolStripMenuItem,
                this.configToolStripMenuItem
            });
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem2.Text = "View";
            // 
            // inputToolStripMenuItem
            // 
            this.inputToolStripMenuItem.Name = "inputToolStripMenuItem";
            this.inputToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.inputToolStripMenuItem.Text = "Input";
            this.inputToolStripMenuItem.Click += new System.EventHandler(this.inputToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // postenToolStripMenuItem
            // 
            this.postenToolStripMenuItem.Name = "postenToolStripMenuItem";
            this.postenToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.postenToolStripMenuItem.Text = "Posten";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // securityToolStripMenuItem
            // 
            this.securityToolStripMenuItem.Name = "securityToolStripMenuItem";
            this.securityToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.securityToolStripMenuItem.Text = "Security";
            this.securityToolStripMenuItem.Click += new System.EventHandler(this.securityToolStripMenuItem_Click);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.configToolStripMenuItem.Text = "Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem3.Text = "?";
            // 
            // showpanel
            // 
            this.showpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showpanel.Location = new System.Drawing.Point(0, 24);
            this.showpanel.Name = "showpanel";
            this.showpanel.Size = new System.Drawing.Size(831, 528);
            this.showpanel.TabIndex = 2;
            this.showpanel.Resize += new System.EventHandler(this.showpanel_Resize);
            // 
            // SnackboxxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 577);
            this.Controls.Add(this.showpanel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "SnackboxxForm";
            this.Text = "Snackboxx v1.2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Snackboxx_FormClosing);
            this.Load += new System.EventHandler(this.Snackboxx_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Panel showpanel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem inputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postenToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripStatusLabel tssinfoONE;
        private System.Windows.Forms.ToolStripStatusLabel tssinfoTWO;
        private System.Windows.Forms.ToolStripStatusLabel tssinfoTHREE;
        private System.Windows.Forms.ToolStripStatusLabel tssinfoFOUR;
        private System.Windows.Forms.ToolStripMenuItem securityToolStripMenuItem;
    }
}