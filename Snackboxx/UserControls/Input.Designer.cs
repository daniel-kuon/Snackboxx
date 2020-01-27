namespace Snackboxx.UserControls
{
    partial class Input
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlFortnite = new System.Windows.Forms.Panel();
            this.picFortnite = new System.Windows.Forms.PictureBox();
            this.lblFortnitePrice = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbmaxloglines = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.lablastinput = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbglobalkey = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbinput = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ClearLogtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrFlashError = new System.Windows.Forms.Timer(this.components);
            this.tmrSendErrorMail = new System.Windows.Forms.Timer(this.components);
            this.tmrFortnite = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.pnlFortnite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.picFortnite)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlFortnite);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbmaxloglines);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.rtbLog);
            this.groupBox1.Controls.Add(this.lablastinput);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbglobalkey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbinput);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(831, 493);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // pnlFortnite
            // 
            this.pnlFortnite.Controls.Add(this.picFortnite);
            this.pnlFortnite.Controls.Add(this.lblFortnitePrice);
            this.pnlFortnite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFortnite.Location = new System.Drawing.Point(3, 19);
            this.pnlFortnite.Name = "pnlFortnite";
            this.pnlFortnite.Size = new System.Drawing.Size(825, 471);
            this.pnlFortnite.TabIndex = 11;
            this.pnlFortnite.Visible = false;
            // 
            // picFortnite
            // 
            this.picFortnite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picFortnite.ImageLocation = "F:\\Tausch\\snackboxx\\DKU\\Steven\\Cover\\fortnite-steven.png";
            this.picFortnite.Location = new System.Drawing.Point(0, 0);
            this.picFortnite.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.picFortnite.Name = "picFortnite";
            this.picFortnite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picFortnite.TabIndex = 1;
            this.picFortnite.TabStop = false;
            // 
            // lblFortnitePrice
            // 
            this.lblFortnitePrice.BackColor = System.Drawing.Color.Transparent;
            this.lblFortnitePrice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblFortnitePrice.Font =
                new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.lblFortnitePrice.Location = new System.Drawing.Point(0, 448);
            this.lblFortnitePrice.Name = "lblFortnitePrice";
            this.lblFortnitePrice.Size = new System.Drawing.Size(825, 23);
            this.lblFortnitePrice.TabIndex = 0;
            this.lblFortnitePrice.Text = "0,30 €";
            this.lblFortnitePrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.BackColor = System.Drawing.Color.Red;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point,
                ((byte) (0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(250, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(307, 125);
            this.label6.TabIndex = 10;
            this.label6.Text = "Code nicht erkannt!\r\nBitte erneut scannen!";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(684, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "max Lines";
            // 
            // tbmaxloglines
            // 
            this.tbmaxloglines.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbmaxloglines.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbmaxloglines.Location = new System.Drawing.Point(754, 122);
            this.tbmaxloglines.Name = "tbmaxloglines";
            this.tbmaxloglines.Size = new System.Drawing.Size(70, 23);
            this.tbmaxloglines.TabIndex = 8;
            this.tbmaxloglines.TextChanged += new System.EventHandler(this.tbmaxloglines_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Log";
            // 
            // rtbLog
            // 
            this.rtbLog.Anchor =
                ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) |
                                                        System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLog.BackColor = System.Drawing.SystemColors.Control;
            this.rtbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbLog.Location = new System.Drawing.Point(10, 149);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.ReadOnly = true;
            this.rtbLog.Size = new System.Drawing.Size(812, 337);
            this.rtbLog.TabIndex = 6;
            this.rtbLog.Text = "";
            this.rtbLog.TextChanged += new System.EventHandler(this.rtbLog_TextChanged);
            // 
            // lablastinput
            // 
            this.lablastinput.AutoSize = true;
            this.lablastinput.Location = new System.Drawing.Point(79, 76);
            this.lablastinput.Name = "lablastinput";
            this.lablastinput.Size = new System.Drawing.Size(10, 15);
            this.lablastinput.TabIndex = 5;
            this.lablastinput.Text = ".";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last Input:";
            // 
            // cbglobalkey
            // 
            this.cbglobalkey.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbglobalkey.AutoSize = true;
            this.cbglobalkey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbglobalkey.Location = new System.Drawing.Point(704, 74);
            this.cbglobalkey.Name = "cbglobalkey";
            this.cbglobalkey.Size = new System.Drawing.Size(115, 19);
            this.cbglobalkey.TabIndex = 3;
            this.cbglobalkey.Text = "global Codeinput";
            this.cbglobalkey.UseVisualStyleBackColor = true;
            this.cbglobalkey.CheckedChanged += new System.EventHandler(this.cbglobalkey_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) |
                                                                        System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F,
                ((System.Drawing.FontStyle) ((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point,
                ((byte) (0)));
            this.label2.Location = new System.Drawing.Point(330, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Scanner Input";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Code Input:";
            // 
            // tbinput
            // 
            this.tbinput.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) |
                                                                         System.Windows.Forms.AnchorStyles.Right)));
            this.tbinput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbinput.Location = new System.Drawing.Point(83, 44);
            this.tbinput.Name = "tbinput";
            this.tbinput.Size = new System.Drawing.Size(740, 23);
            this.tbinput.TabIndex = 0;
            this.tbinput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbinput_KeyUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.ClearLogtoolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(831, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ClearLogtoolStripMenuItem
            // 
            this.ClearLogtoolStripMenuItem.Name = "ClearLogtoolStripMenuItem";
            this.ClearLogtoolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.ClearLogtoolStripMenuItem.Text = "Clear Log";
            this.ClearLogtoolStripMenuItem.Click += new System.EventHandler(this.ClearLogtoolStripMenuItem_Click);
            // 
            // tmrFlashError
            // 
            this.tmrFlashError.Interval = 500;
            this.tmrFlashError.Tick += new System.EventHandler(this.tmrFlashError_Tick);
            // 
            // tmrSendErrorMail
            // 
            this.tmrSendErrorMail.Enabled = true;
            this.tmrSendErrorMail.Tick += new System.EventHandler(this.tmrSendErrorMail_Tick);
            // 
            // tmrFortnite
            // 
            this.tmrFortnite.Interval = 5000;
            this.tmrFortnite.Tick += new System.EventHandler(this.tmrFortnite_Tick);
            // 
            // Input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Input";
            this.Size = new System.Drawing.Size(831, 517);
            this.Load += new System.EventHandler(this.Input_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlFortnite.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.picFortnite)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbinput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbglobalkey;
        private System.Windows.Forms.Label lablastinput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.ToolStripMenuItem ClearLogtoolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbmaxloglines;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel pnlFortnite;
        private System.Windows.Forms.Timer tmrFortnite;
        private System.Windows.Forms.Timer tmrSendErrorMail;
        private System.Windows.Forms.Timer tmrFlashError;
        private System.Windows.Forms.PictureBox picFortnite;
        private System.Windows.Forms.Label lblFortnitePrice;
    }
}
