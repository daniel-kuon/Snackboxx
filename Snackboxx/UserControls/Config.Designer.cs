namespace Snackboxx.UserControls
{
    partial class Config
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.savetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtErrorMail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnscanlogpath = new System.Windows.Forms.Button();
            this.tbscanlogpath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labconnstat = new System.Windows.Forms.Label();
            this.tbdbpassword = new System.Windows.Forms.TextBox();
            this.tbdbuser = new System.Windows.Forms.TextBox();
            this.tbdbserver = new System.Windows.Forms.TextBox();
            this.tbdbdatabase = new System.Windows.Forms.TextBox();
            this.btndbcheck = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.savetoolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(831, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // savetoolStripMenuItem
            // 
            this.savetoolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.savetoolStripMenuItem.Image = global::Snackboxx.Properties.Resources.Save;
            this.savetoolStripMenuItem.Name = "savetoolStripMenuItem";
            this.savetoolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.savetoolStripMenuItem.Text = "Save";
            this.savetoolStripMenuItem.Click += new System.EventHandler(this.savetoolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtErrorMail);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnscanlogpath);
            this.groupBox1.Controls.Add(this.tbscanlogpath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(831, 493);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Config";
            // 
            // txtErrorMail
            // 
            this.txtErrorMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtErrorMail.Location = new System.Drawing.Point(91, 57);
            this.txtErrorMail.Name = "txtErrorMail";
            this.txtErrorMail.Size = new System.Drawing.Size(267, 23);
            this.txtErrorMail.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Error mail:";
            // 
            // btnscanlogpath
            // 
            this.btnscanlogpath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnscanlogpath.Location = new System.Drawing.Point(365, 24);
            this.btnscanlogpath.Name = "btnscanlogpath";
            this.btnscanlogpath.Size = new System.Drawing.Size(87, 27);
            this.btnscanlogpath.TabIndex = 4;
            this.btnscanlogpath.Text = "Search";
            this.btnscanlogpath.UseVisualStyleBackColor = true;
            this.btnscanlogpath.Click += new System.EventHandler(this.btnscanlogpath_Click);
            // 
            // tbscanlogpath
            // 
            this.tbscanlogpath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbscanlogpath.Location = new System.Drawing.Point(91, 27);
            this.tbscanlogpath.Name = "tbscanlogpath";
            this.tbscanlogpath.Size = new System.Drawing.Size(267, 23);
            this.tbscanlogpath.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Scanlogpath:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) |
                                                                           System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.labconnstat);
            this.groupBox2.Controls.Add(this.tbdbpassword);
            this.groupBox2.Controls.Add(this.tbdbuser);
            this.groupBox2.Controls.Add(this.tbdbserver);
            this.groupBox2.Controls.Add(this.tbdbdatabase);
            this.groupBox2.Controls.Add(this.btndbcheck);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,
                ((byte) (0)));
            this.groupBox2.Location = new System.Drawing.Point(463, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(367, 493);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Database";
            // 
            // labconnstat
            // 
            this.labconnstat.Anchor =
                ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) |
                                                       System.Windows.Forms.AnchorStyles.Right)));
            this.labconnstat.Location = new System.Drawing.Point(7, 196);
            this.labconnstat.Name = "labconnstat";
            this.labconnstat.Size = new System.Drawing.Size(353, 18);
            this.labconnstat.TabIndex = 10;
            // 
            // tbdbpassword
            // 
            this.tbdbpassword.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbdbpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbdbpassword.Location = new System.Drawing.Point(134, 111);
            this.tbdbpassword.Name = "tbdbpassword";
            this.tbdbpassword.PasswordChar = '*';
            this.tbdbpassword.Size = new System.Drawing.Size(227, 20);
            this.tbdbpassword.TabIndex = 9;
            this.tbdbpassword.Text = "#snack#";
            // 
            // tbdbuser
            // 
            this.tbdbuser.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbdbuser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbdbuser.Location = new System.Drawing.Point(134, 81);
            this.tbdbuser.Name = "tbdbuser";
            this.tbdbuser.Size = new System.Drawing.Size(227, 20);
            this.tbdbuser.TabIndex = 8;
            this.tbdbuser.Text = "Snackboxx";
            // 
            // tbdbserver
            // 
            this.tbdbserver.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbdbserver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbdbserver.Location = new System.Drawing.Point(134, 51);
            this.tbdbserver.Name = "tbdbserver";
            this.tbdbserver.Size = new System.Drawing.Size(227, 20);
            this.tbdbserver.TabIndex = 7;
            this.tbdbserver.Text = "10.2.10.122";
            // 
            // tbdbdatabase
            // 
            this.tbdbdatabase.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbdbdatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbdbdatabase.Location = new System.Drawing.Point(134, 22);
            this.tbdbdatabase.Name = "tbdbdatabase";
            this.tbdbdatabase.Size = new System.Drawing.Size(227, 20);
            this.tbdbdatabase.TabIndex = 6;
            this.tbdbdatabase.Text = "Snackboxx";
            // 
            // btndbcheck
            // 
            this.btndbcheck.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndbcheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndbcheck.Location = new System.Drawing.Point(274, 141);
            this.btndbcheck.Name = "btndbcheck";
            this.btndbcheck.Size = new System.Drawing.Size(87, 27);
            this.btndbcheck.TabIndex = 5;
            this.btndbcheck.Text = "Check";
            this.btndbcheck.UseVisualStyleBackColor = true;
            this.btndbcheck.Click += new System.EventHandler(this.btndbcheck_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Password";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "User";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Server";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Database";
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Config";
            this.Size = new System.Drawing.Size(831, 517);
            this.Load += new System.EventHandler(this.Config_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labconnstat;
        private System.Windows.Forms.TextBox tbdbpassword;
        private System.Windows.Forms.TextBox tbdbuser;
        private System.Windows.Forms.TextBox tbdbserver;
        private System.Windows.Forms.TextBox tbdbdatabase;
        private System.Windows.Forms.Button btndbcheck;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem savetoolStripMenuItem;
        private System.Windows.Forms.TextBox tbscanlogpath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnscanlogpath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtErrorMail;
    }
}
