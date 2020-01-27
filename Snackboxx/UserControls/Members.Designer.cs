using System.Windows.Forms;

namespace Snackboxx.UserControls
{
    partial class Members
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
            this.toolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTPHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.sendMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tvuser = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbloginname = new System.Windows.Forms.TextBox();
            this.tbuserid = new System.Windows.Forms.TextBox();
            this.tbusername = new System.Windows.Forms.TextBox();
            this.labpas = new System.Windows.Forms.Label();
            this.tbpassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbemail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbnTimeCode = new System.Windows.Forms.RadioButton();
            this.rbnSnackCode = new System.Windows.Forms.RadioButton();
            this.labdel = new System.Windows.Forms.Label();
            this.btndeleteselcode = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.btnaddcode = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbcodes = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbpreis = new System.Windows.Forms.TextBox();
            this.tbscancode = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labsec = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cBUserRights = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAdd100 = new System.Windows.Forms.Button();
            this.btnAdd050 = new System.Windows.Forms.Button();
            this.btnAdd015 = new System.Windows.Forms.Button();
            this.btnAdd030 = new System.Windows.Forms.Button();
            this.btnAdd040 = new System.Windows.Forms.Button();
            this.btnAdd010 = new System.Windows.Forms.Button();
            this.lab_betragslimit = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_userLimit = new System.Windows.Forms.TextBox();
            this.btndelallPos = new System.Windows.Forms.Button();
            this.tbpay = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnpay = new System.Windows.Forms.Button();
            this.labAllPosten = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.labCloseSum = new System.Windows.Forms.Label();
            this.laballSum = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.labopenSum = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this.toolStripMenuItemClear, this.toolStripMenuItemSave, this.toolStripMenuItemDelete, this.toolStripMenuItemTPHistory,
                this.sendMailToolStripMenuItem
            });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(831, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItemClear
            // 
            this.toolStripMenuItemClear.Name = "toolStripMenuItemClear";
            this.toolStripMenuItemClear.Size = new System.Drawing.Size(46, 20);
            this.toolStripMenuItemClear.Text = "Clear";
            this.toolStripMenuItemClear.Click += new System.EventHandler(this.toolStripMenuItemClear_Click);
            // 
            // toolStripMenuItemSave
            // 
            this.toolStripMenuItemSave.Image = global::Snackboxx.Properties.Resources.Save;
            this.toolStripMenuItemSave.Name = "toolStripMenuItemSave";
            this.toolStripMenuItemSave.Size = new System.Drawing.Size(59, 20);
            this.toolStripMenuItemSave.Text = "Save";
            this.toolStripMenuItemSave.Click += new System.EventHandler(this.toolStripMenuItemSave_Click);
            // 
            // toolStripMenuItemDelete
            // 
            this.toolStripMenuItemDelete.Image = global::Snackboxx.Properties.Resources.Delete;
            this.toolStripMenuItemDelete.Name = "toolStripMenuItemDelete";
            this.toolStripMenuItemDelete.Size = new System.Drawing.Size(68, 20);
            this.toolStripMenuItemDelete.Text = "Delete";
            this.toolStripMenuItemDelete.Click += new System.EventHandler(this.toolStripMenuItemDelete_Click);
            // 
            // toolStripMenuItemTPHistory
            // 
            this.toolStripMenuItemTPHistory.Image = global::Snackboxx.Properties.Resources.Calender;
            this.toolStripMenuItemTPHistory.Name = "toolStripMenuItemTPHistory";
            this.toolStripMenuItemTPHistory.Size = new System.Drawing.Size(89, 20);
            this.toolStripMenuItemTPHistory.Text = "ToPay Log";
            this.toolStripMenuItemTPHistory.Click += new System.EventHandler(this.toolStripMenuItemTPHistory_Click);
            // 
            // sendMailToolStripMenuItem
            // 
            this.sendMailToolStripMenuItem.Name = "sendMailToolStripMenuItem";
            this.sendMailToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.sendMailToolStripMenuItem.Text = "SendMail";
            this.sendMailToolStripMenuItem.Click += new System.EventHandler(this.sendMailToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 332F));
            this.tableLayoutPanel1.Controls.Add(this.tvuser, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(30, 30, 30, 30);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 153F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(831, 493);
            this.tableLayoutPanel1.TabIndex = 34;
            // 
            // tvuser
            // 
            this.tvuser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvuser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvuser.Location = new System.Drawing.Point(3, 3);
            this.tvuser.Name = "tvuser";
            this.tableLayoutPanel1.SetRowSpan(this.tvuser, 3);
            this.tvuser.Size = new System.Drawing.Size(193, 487);
            this.tvuser.TabIndex = 33;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbloginname);
            this.panel1.Controls.Add(this.tbuserid);
            this.panel1.Controls.Add(this.tbusername);
            this.panel1.Controls.Add(this.labpas);
            this.panel1.Controls.Add(this.tbpassword);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbemail);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(202, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 159);
            this.panel1.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "UserID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 15);
            this.label8.TabIndex = 31;
            this.label8.Text = "LoginName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "User";
            // 
            // tbloginname
            // 
            this.tbloginname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbloginname.Location = new System.Drawing.Point(77, 69);
            this.tbloginname.Name = "tbloginname";
            this.tbloginname.Size = new System.Drawing.Size(184, 23);
            this.tbloginname.TabIndex = 30;
            // 
            // tbuserid
            // 
            this.tbuserid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbuserid.Enabled = false;
            this.tbuserid.Location = new System.Drawing.Point(77, 8);
            this.tbuserid.Name = "tbuserid";
            this.tbuserid.Size = new System.Drawing.Size(184, 23);
            this.tbuserid.TabIndex = 14;
            // 
            // tbusername
            // 
            this.tbusername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbusername.Location = new System.Drawing.Point(77, 38);
            this.tbusername.Name = "tbusername";
            this.tbusername.Size = new System.Drawing.Size(184, 23);
            this.tbusername.TabIndex = 2;
            // 
            // labpas
            // 
            this.labpas.AutoSize = true;
            this.labpas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,
                ((byte) (0)));
            this.labpas.ForeColor = System.Drawing.Color.DarkRed;
            this.labpas.Location = new System.Drawing.Point(268, 103);
            this.labpas.Name = "labpas";
            this.labpas.Size = new System.Drawing.Size(10, 13);
            this.labpas.TabIndex = 28;
            this.labpas.Text = ".";
            // 
            // tbpassword
            // 
            this.tbpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbpassword.Location = new System.Drawing.Point(77, 99);
            this.tbpassword.Name = "tbpassword";
            this.tbpassword.PasswordChar = '*';
            this.tbpassword.Size = new System.Drawing.Size(184, 23);
            this.tbpassword.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 15);
            this.label7.TabIndex = 27;
            this.label7.Text = "EMail";
            // 
            // tbemail
            // 
            this.tbemail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbemail.Location = new System.Drawing.Point(77, 129);
            this.tbemail.Name = "tbemail";
            this.tbemail.Size = new System.Drawing.Size(184, 23);
            this.tbemail.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "Password";
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.rbnTimeCode);
            this.groupBox1.Controls.Add(this.rbnSnackCode);
            this.groupBox1.Controls.Add(this.labdel);
            this.groupBox1.Controls.Add(this.btndeleteselcode);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.btnaddcode);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lbcodes);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbpreis);
            this.groupBox1.Controls.Add(this.tbscancode);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(202, 343);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(626, 147);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "UserCodes";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rbnTimeCode
            // 
            this.rbnTimeCode.AutoSize = true;
            this.rbnTimeCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbnTimeCode.Location = new System.Drawing.Point(148, 22);
            this.rbnTimeCode.Name = "rbnTimeCode";
            this.rbnTimeCode.Size = new System.Drawing.Size(81, 19);
            this.rbnTimeCode.TabIndex = 20;
            this.rbnTimeCode.TabStop = true;
            this.rbnTimeCode.Text = "Time Code";
            this.rbnTimeCode.UseVisualStyleBackColor = true;
            // 
            // rbnSnackCode
            // 
            this.rbnSnackCode.AutoSize = true;
            this.rbnSnackCode.Checked = true;
            this.rbnSnackCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rbnSnackCode.Location = new System.Drawing.Point(16, 22);
            this.rbnSnackCode.Name = "rbnSnackCode";
            this.rbnSnackCode.Size = new System.Drawing.Size(112, 19);
            this.rbnSnackCode.TabIndex = 19;
            this.rbnSnackCode.TabStop = true;
            this.rbnSnackCode.Text = "Snackboxx Code";
            this.rbnSnackCode.UseVisualStyleBackColor = true;
            // 
            // labdel
            // 
            this.labdel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,
                ((byte) (0)));
            this.labdel.ForeColor = System.Drawing.Color.DarkRed;
            this.labdel.Location = new System.Drawing.Point(13, 114);
            this.labdel.MaximumSize = new System.Drawing.Size(50, 0);
            this.labdel.Name = "labdel";
            this.labdel.Size = new System.Drawing.Size(10, 0);
            this.labdel.TabIndex = 18;
            this.labdel.Text = ".";
            this.labdel.Visible = false;
            // 
            // btndeleteselcode
            // 
            this.btndeleteselcode.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btndeleteselcode.Enabled = false;
            this.btndeleteselcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndeleteselcode.Location = new System.Drawing.Point(346, 87);
            this.btndeleteselcode.Name = "btndeleteselcode";
            this.btndeleteselcode.Size = new System.Drawing.Size(77, 27);
            this.btndeleteselcode.TabIndex = 9;
            this.btndeleteselcode.Text = "<< Delete";
            this.btndeleteselcode.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(232, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 15);
            this.label12.TabIndex = 5;
            this.label12.Text = "€";
            // 
            // btnaddcode
            // 
            this.btnaddcode.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnaddcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaddcode.Location = new System.Drawing.Point(346, 57);
            this.btnaddcode.Name = "btnaddcode";
            this.btnaddcode.Size = new System.Drawing.Size(77, 27);
            this.btnaddcode.TabIndex = 7;
            this.btnaddcode.Text = "Add  >>";
            this.btnaddcode.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(430, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "UserCodes";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "Preis";
            // 
            // lbcodes
            // 
            this.lbcodes.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbcodes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbcodes.FormattingEnabled = true;
            this.lbcodes.ItemHeight = 15;
            this.lbcodes.Location = new System.Drawing.Point(430, 33);
            this.lbcodes.Name = "lbcodes";
            this.lbcodes.Size = new System.Drawing.Size(184, 107);
            this.lbcodes.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "ScanCode";
            // 
            // tbpreis
            // 
            this.tbpreis.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbpreis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbpreis.Location = new System.Drawing.Point(86, 83);
            this.tbpreis.Name = "tbpreis";
            this.tbpreis.Size = new System.Drawing.Size(138, 23);
            this.tbpreis.TabIndex = 6;
            this.tbpreis.Text = "0.00";
            this.tbpreis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbscancode
            // 
            this.tbscancode.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbscancode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbscancode.Location = new System.Drawing.Point(86, 54);
            this.tbscancode.Name = "tbscancode";
            this.tbscancode.Size = new System.Drawing.Size(138, 23);
            this.tbscancode.TabIndex = 5;
            this.tbscancode.Text = "0000";
            this.tbscancode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labsec);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cBUserRights);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(202, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 164);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Web Security";
            // 
            // labsec
            // 
            this.labsec.AutoSize = true;
            this.labsec.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point,
                ((byte) (0)));
            this.labsec.ForeColor = System.Drawing.Color.DarkRed;
            this.labsec.Location = new System.Drawing.Point(13, 61);
            this.labsec.Name = "labsec";
            this.labsec.Size = new System.Drawing.Size(10, 13);
            this.labsec.TabIndex = 2;
            this.labsec.Text = ".";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 15);
            this.label9.TabIndex = 1;
            this.label9.Text = "Userright";
            // 
            // cBUserRights
            // 
            this.cBUserRights.Enabled = false;
            this.cBUserRights.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cBUserRights.FormattingEnabled = true;
            this.cBUserRights.Location = new System.Drawing.Point(86, 33);
            this.cBUserRights.Name = "cBUserRights";
            this.cBUserRights.Size = new System.Drawing.Size(184, 23);
            this.cBUserRights.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAdd100);
            this.groupBox3.Controls.Add(this.btnAdd050);
            this.groupBox3.Controls.Add(this.btnAdd015);
            this.groupBox3.Controls.Add(this.btnAdd030);
            this.groupBox3.Controls.Add(this.btnAdd040);
            this.groupBox3.Controls.Add(this.btnAdd010);
            this.groupBox3.Controls.Add(this.lab_betragslimit);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.tb_userLimit);
            this.groupBox3.Controls.Add(this.btndelallPos);
            this.groupBox3.Controls.Add(this.tbpay);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.btnpay);
            this.groupBox3.Controls.Add(this.labAllPosten);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.labCloseSum);
            this.groupBox3.Controls.Add(this.laballSum);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.labopenSum);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(502, 3);
            this.groupBox3.MaximumSize = new System.Drawing.Size(199, 0);
            this.groupBox3.Name = "groupBox3";
            this.tableLayoutPanel1.SetRowSpan(this.groupBox3, 2);
            this.groupBox3.Size = new System.Drawing.Size(199, 334);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Payment";
            // 
            // btnAdd100
            // 
            this.btnAdd100.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd100.Location = new System.Drawing.Point(119, 213);
            this.btnAdd100.Name = "btnAdd100";
            this.btnAdd100.Size = new System.Drawing.Size(50, 27);
            this.btnAdd100.TabIndex = 21;
            this.btnAdd100.Text = "1,00 €";
            this.btnAdd100.UseVisualStyleBackColor = true;
            // 
            // btnAdd050
            // 
            this.btnAdd050.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd050.Location = new System.Drawing.Point(63, 213);
            this.btnAdd050.Name = "btnAdd050";
            this.btnAdd050.Size = new System.Drawing.Size(50, 27);
            this.btnAdd050.TabIndex = 20;
            this.btnAdd050.Text = "0,50 €";
            this.btnAdd050.UseVisualStyleBackColor = true;
            // 
            // btnAdd015
            // 
            this.btnAdd015.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd015.Location = new System.Drawing.Point(62, 181);
            this.btnAdd015.Name = "btnAdd015";
            this.btnAdd015.Size = new System.Drawing.Size(50, 27);
            this.btnAdd015.TabIndex = 19;
            this.btnAdd015.Text = "0,15 €";
            this.btnAdd015.UseVisualStyleBackColor = true;
            // 
            // btnAdd030
            // 
            this.btnAdd030.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd030.Location = new System.Drawing.Point(118, 181);
            this.btnAdd030.Name = "btnAdd030";
            this.btnAdd030.Size = new System.Drawing.Size(50, 27);
            this.btnAdd030.TabIndex = 18;
            this.btnAdd030.Text = "0,30 €";
            this.btnAdd030.UseVisualStyleBackColor = true;
            // 
            // btnAdd040
            // 
            this.btnAdd040.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd040.Location = new System.Drawing.Point(7, 213);
            this.btnAdd040.Name = "btnAdd040";
            this.btnAdd040.Size = new System.Drawing.Size(50, 27);
            this.btnAdd040.TabIndex = 17;
            this.btnAdd040.Text = "0,40 €";
            this.btnAdd040.UseVisualStyleBackColor = true;
            // 
            // btnAdd010
            // 
            this.btnAdd010.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd010.Location = new System.Drawing.Point(6, 181);
            this.btnAdd010.Name = "btnAdd010";
            this.btnAdd010.Size = new System.Drawing.Size(50, 27);
            this.btnAdd010.TabIndex = 16;
            this.btnAdd010.Text = "0,10 €";
            this.btnAdd010.UseVisualStyleBackColor = true;
            // 
            // lab_betragslimit
            // 
            this.lab_betragslimit.AutoSize = true;
            this.lab_betragslimit.Location = new System.Drawing.Point(20, 264);
            this.lab_betragslimit.Name = "lab_betragslimit";
            this.lab_betragslimit.Size = new System.Drawing.Size(79, 15);
            this.lab_betragslimit.TabIndex = 15;
            this.lab_betragslimit.Text = "Betrags Limit:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(169, 264);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 15);
            this.label10.TabIndex = 14;
            this.label10.Text = "€";
            // 
            // tb_userLimit
            // 
            this.tb_userLimit.Location = new System.Drawing.Point(108, 261);
            this.tb_userLimit.Name = "tb_userLimit";
            this.tb_userLimit.Size = new System.Drawing.Size(53, 23);
            this.tb_userLimit.TabIndex = 2;
            this.tb_userLimit.Text = "0.00";
            this.tb_userLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btndelallPos
            // 
            this.btndelallPos.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btndelallPos.Enabled = false;
            this.btndelallPos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelallPos.Location = new System.Drawing.Point(51, 3382);
            this.btndelallPos.Name = "btndelallPos";
            this.btndelallPos.Size = new System.Drawing.Size(133, 27);
            this.btndelallPos.TabIndex = 12;
            this.btndelallPos.Text = "Delete All Pos";
            this.btndelallPos.UseVisualStyleBackColor = true;
            // 
            // tbpay
            // 
            this.tbpay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbpay.Location = new System.Drawing.Point(6, 152);
            this.tbpay.Name = "tbpay";
            this.tbpay.Size = new System.Drawing.Size(74, 23);
            this.tbpay.TabIndex = 10;
            this.tbpay.Text = "0.00";
            this.tbpay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(86, 153);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(13, 15);
            this.label20.TabIndex = 13;
            this.label20.Text = "€";
            // 
            // btnpay
            // 
            this.btnpay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpay.Location = new System.Drawing.Point(108, 148);
            this.btnpay.Name = "btnpay";
            this.btnpay.Size = new System.Drawing.Size(76, 27);
            this.btnpay.TabIndex = 11;
            this.btnpay.Text = "to pay";
            this.btnpay.UseVisualStyleBackColor = true;
            // 
            // labAllPosten
            // 
            this.labAllPosten.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point,
                ((byte) (0)));
            this.labAllPosten.Location = new System.Drawing.Point(105, 91);
            this.labAllPosten.Name = "labAllPosten";
            this.labAllPosten.Size = new System.Drawing.Size(76, 18);
            this.labAllPosten.TabIndex = 10;
            this.labAllPosten.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 93);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 15);
            this.label16.TabIndex = 9;
            this.label16.Text = "Positions:";
            // 
            // labCloseSum
            // 
            this.labCloseSum.Enabled = false;
            this.labCloseSum.Location = new System.Drawing.Point(97, 62);
            this.labCloseSum.Name = "labCloseSum";
            this.labCloseSum.Size = new System.Drawing.Size(62, 15);
            this.labCloseSum.TabIndex = 8;
            this.labCloseSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labCloseSum.Visible = false;
            // 
            // laballSum
            // 
            this.laballSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point,
                ((byte) (0)));
            this.laballSum.Location = new System.Drawing.Point(97, 123);
            this.laballSum.Name = "laballSum";
            this.laballSum.Size = new System.Drawing.Size(62, 15);
            this.laballSum.TabIndex = 7;
            this.laballSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Enabled = false;
            this.label19.Location = new System.Drawing.Point(166, 62);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(13, 15);
            this.label19.TabIndex = 6;
            this.label19.Text = "€";
            this.label19.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(166, 30);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(13, 15);
            this.label17.TabIndex = 4;
            this.label17.Text = "€";
            // 
            // labopenSum
            // 
            this.labopenSum.Location = new System.Drawing.Point(97, 30);
            this.labopenSum.Name = "labopenSum";
            this.labopenSum.Size = new System.Drawing.Size(62, 15);
            this.labopenSum.TabIndex = 3;
            this.labopenSum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(166, 123);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(13, 15);
            this.label18.TabIndex = 5;
            this.label18.Text = "€";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Enabled = false;
            this.label14.Location = new System.Drawing.Point(7, 62);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 15);
            this.label14.TabIndex = 1;
            this.label14.Text = "Close:";
            this.label14.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Open:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 123);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 15);
            this.label15.TabIndex = 2;
            this.label15.Text = "Price all Pos:";
            // 
            // Members
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Members";
            this.Size = new System.Drawing.Size(831, 517);
            this.Load += new System.EventHandler(this.User_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TreeView tvuser;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbpay;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnpay;
        private System.Windows.Forms.Label labAllPosten;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label labCloseSum;
        private System.Windows.Forms.Label laballSum;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label labopenSum;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnaddcode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbpreis;
        private System.Windows.Forms.TextBox tbscancode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbcodes;
        private System.Windows.Forms.TextBox tbusername;
        private System.Windows.Forms.TextBox tbuserid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbemail;
        private System.Windows.Forms.TextBox tbpassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btndeleteselcode;
        private System.Windows.Forms.Button btndelallPos;
        private System.Windows.Forms.Label labpas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label labsec;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cBUserRights;
        private System.Windows.Forms.Label labdel;
        private System.Windows.Forms.RadioButton rbnTimeCode;
        private System.Windows.Forms.RadioButton rbnSnackCode;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTPHistory;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbloginname;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClear;
        private System.Windows.Forms.ToolStripMenuItem sendMailToolStripMenuItem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_userLimit;
        private System.Windows.Forms.Label lab_betragslimit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAdd040;
        private System.Windows.Forms.Button btnAdd030;
        private System.Windows.Forms.Button btnAdd015;
        private System.Windows.Forms.Button btnAdd050;
        private System.Windows.Forms.Button btnAdd100;
        private System.Windows.Forms.Button btnAdd010;
    }
}
