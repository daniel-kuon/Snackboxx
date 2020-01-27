namespace Snackboxx.UserControls
{
    partial class Security
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
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tVUserRights = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cballadmin = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cballowtime = new System.Windows.Forms.CheckBox();
            this.cballowconfig = new System.Windows.Forms.CheckBox();
            this.cballowposten = new System.Windows.Forms.CheckBox();
            this.cballowadmin = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbid = new System.Windows.Forms.TextBox();
            this.tbname = new System.Windows.Forms.TextBox();
            this.tbmail = new System.Windows.Forms.TextBox();
            this.cbisglobalmail = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Gold;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.tVUserRights);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(712, 424);
            this.splitContainer1.SplitterDistance = 163;
            this.splitContainer1.TabIndex = 0;
            // 
            // tVUserRights
            // 
            this.tVUserRights.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tVUserRights.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tVUserRights.Location = new System.Drawing.Point(0, 0);
            this.tVUserRights.Name = "tVUserRights";
            this.tVUserRights.Size = new System.Drawing.Size(163, 424);
            this.tVUserRights.TabIndex = 0;
            this.tVUserRights.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tVUserRights_NodeMouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cballadmin);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Location = new System.Drawing.Point(3, 118);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 303);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Right Details";
            // 
            // cballadmin
            // 
            this.cballadmin.AutoSize = true;
            this.cballadmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cballadmin.Location = new System.Drawing.Point(15, 19);
            this.cballadmin.Name = "cballadmin";
            this.cballadmin.Size = new System.Drawing.Size(83, 17);
            this.cballadmin.TabIndex = 9;
            this.cballadmin.Text = "Administrator";
            this.cballadmin.UseVisualStyleBackColor = true;
            this.cballadmin.CheckedChanged += new System.EventHandler(this.cballadmin_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.cballowtime);
            this.groupBox3.Controls.Add(this.cballowconfig);
            this.groupBox3.Controls.Add(this.cballowposten);
            this.groupBox3.Controls.Add(this.cballowadmin);
            this.groupBox3.Location = new System.Drawing.Point(6, 42);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(527, 255);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Rights";
            // 
            // cballowtime
            // 
            this.cballowtime.AutoSize = true;
            this.cballowtime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cballowtime.Location = new System.Drawing.Point(9, 48);
            this.cballowtime.Name = "cballowtime";
            this.cballowtime.Size = new System.Drawing.Size(135, 17);
            this.cballowtime.TabIndex = 5;
            this.cballowtime.Text = "Show Time Registration";
            this.cballowtime.UseVisualStyleBackColor = true;
            // 
            // cballowconfig
            // 
            this.cballowconfig.AutoSize = true;
            this.cballowconfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cballowconfig.Location = new System.Drawing.Point(9, 72);
            this.cballowconfig.Name = "cballowconfig";
            this.cballowconfig.Size = new System.Drawing.Size(108, 17);
            this.cballowconfig.TabIndex = 6;
            this.cballowconfig.Text = "Show User Config";
            this.cballowconfig.UseVisualStyleBackColor = true;
            // 
            // cballowposten
            // 
            this.cballowposten.AutoSize = true;
            this.cballowposten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cballowposten.Location = new System.Drawing.Point(9, 24);
            this.cballowposten.Name = "cballowposten";
            this.cballowposten.Size = new System.Drawing.Size(95, 17);
            this.cballowposten.TabIndex = 4;
            this.cballowposten.Text = "Show Positions";
            this.cballowposten.UseVisualStyleBackColor = true;
            // 
            // cballowadmin
            // 
            this.cballowadmin.AutoSize = true;
            this.cballowadmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cballowadmin.Location = new System.Drawing.Point(9, 96);
            this.cballowadmin.Name = "cballowadmin";
            this.cballowadmin.Size = new System.Drawing.Size(142, 17);
            this.cballowadmin.TabIndex = 7;
            this.cballowadmin.Text = "Allow Web Administration";
            this.cballowadmin.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbid);
            this.groupBox1.Controls.Add(this.tbname);
            this.groupBox1.Controls.Add(this.tbmail);
            this.groupBox1.Controls.Add(this.cbisglobalmail);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(539, 109);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Header";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // tbid
            // 
            this.tbid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbid.Location = new System.Drawing.Point(55, 22);
            this.tbid.Name = "tbid";
            this.tbid.ReadOnly = true;
            this.tbid.Size = new System.Drawing.Size(193, 20);
            this.tbid.TabIndex = 0;
            // 
            // tbname
            // 
            this.tbname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbname.Location = new System.Drawing.Point(55, 48);
            this.tbname.Name = "tbname";
            this.tbname.Size = new System.Drawing.Size(193, 20);
            this.tbname.TabIndex = 1;
            // 
            // tbmail
            // 
            this.tbmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbmail.Location = new System.Drawing.Point(335, 22);
            this.tbmail.Name = "tbmail";
            this.tbmail.Size = new System.Drawing.Size(198, 20);
            this.tbmail.TabIndex = 2;
            // 
            // cbisglobalmail
            // 
            this.cbisglobalmail.AutoSize = true;
            this.cbisglobalmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbisglobalmail.Location = new System.Drawing.Point(335, 52);
            this.cbisglobalmail.Name = "cbisglobalmail";
            this.cbisglobalmail.Size = new System.Drawing.Size(80, 17);
            this.cbisglobalmail.TabIndex = 3;
            this.cbisglobalmail.Text = "IsGlobalMail";
            this.cbisglobalmail.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(712, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::Snackboxx.Properties.Resources.Run;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(84, 20);
            this.toolStripMenuItem1.Text = "New Right";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::Snackboxx.Properties.Resources.Delete;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(66, 20);
            this.toolStripMenuItem2.Text = "Delete";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::Snackboxx.Properties.Resources.Save;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItem3.Text = "Save";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // Security
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Security";
            this.Size = new System.Drawing.Size(712, 448);
            this.Load += new System.EventHandler(this.Security_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TreeView tVUserRights;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cballowtime;
        private System.Windows.Forms.CheckBox cballowposten;
        private System.Windows.Forms.CheckBox cballowadmin;
        private System.Windows.Forms.CheckBox cballowconfig;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbid;
        private System.Windows.Forms.TextBox tbname;
        private System.Windows.Forms.TextBox tbmail;
        private System.Windows.Forms.CheckBox cbisglobalmail;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cballadmin;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}
