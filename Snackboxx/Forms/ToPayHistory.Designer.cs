namespace Snackboxx.Forms
{
    partial class ToPayHistory
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
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToPayHistory));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dGVhistory = new System.Windows.Forms.DataGridView();
            this.Col5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labrows = new System.Windows.Forms.Label();
            this.labinhouse = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbpay = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVhistory)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(608, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Image = global::Snackboxx.Properties.Resources.Delete;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // dGVhistory
            // 
            this.dGVhistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dGVhistory.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dGVhistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVhistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col5,
            this.Col1,
            this.Col2,
            this.Col3,
            this.Col4});
            this.dGVhistory.GridColor = System.Drawing.Color.Gold;
            this.dGVhistory.Location = new System.Drawing.Point(0, 24);
            this.dGVhistory.Name = "dGVhistory";
            this.dGVhistory.ReadOnly = true;
            this.dGVhistory.Size = new System.Drawing.Size(608, 337);
            this.dGVhistory.TabIndex = 1;
            // 
            // Col5
            // 
            this.Col5.HeaderText = "ID";
            this.Col5.Name = "Col5";
            this.Col5.ReadOnly = true;
            this.Col5.Visible = false;
            // 
            // Col1
            // 
            this.Col1.HeaderText = "Number";
            this.Col1.Name = "Col1";
            this.Col1.ReadOnly = true;
            // 
            // Col2
            // 
            this.Col2.HeaderText = "Time";
            this.Col2.Name = "Col2";
            this.Col2.ReadOnly = true;
            this.Col2.Width = 130;
            // 
            // Col3
            // 
            this.Col3.HeaderText = "Pay";
            this.Col3.Name = "Col3";
            this.Col3.ReadOnly = true;
            // 
            // Col4
            // 
            this.Col4.HeaderText = "Type";
            this.Col4.Name = "Col4";
            this.Col4.ReadOnly = true;
            // 
            // labrows
            // 
            this.labrows.AutoSize = true;
            this.labrows.BackColor = System.Drawing.Color.Transparent;
            this.labrows.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labrows.Location = new System.Drawing.Point(320, 8);
            this.labrows.Name = "labrows";
            this.labrows.Size = new System.Drawing.Size(41, 13);
            this.labrows.TabIndex = 2;
            this.labrows.Text = "Rows:";
            // 
            // labinhouse
            // 
            this.labinhouse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labinhouse.AutoSize = true;
            this.labinhouse.BackColor = System.Drawing.Color.Transparent;
            this.labinhouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labinhouse.Location = new System.Drawing.Point(499, 9);
            this.labinhouse.Name = "labinhouse";
            this.labinhouse.Size = new System.Drawing.Size(11, 13);
            this.labinhouse.TabIndex = 5;
            this.labinhouse.Text = ".";
            // 
            // btnadd
            // 
            this.btnadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Location = new System.Drawing.Point(166, 364);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(39, 23);
            this.btnadd.TabIndex = 6;
            this.btnadd.Text = "Add";
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Addition";
            // 
            // tbpay
            // 
            this.tbpay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbpay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbpay.Location = new System.Drawing.Point(64, 367);
            this.tbpay.Name = "tbpay";
            this.tbpay.Size = new System.Drawing.Size(77, 20);
            this.tbpay.TabIndex = 8;
            this.tbpay.Text = "0.00";
            this.tbpay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(147, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "€";
            // 
            // ToPayHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(608, 388);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbpay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.labinhouse);
            this.Controls.Add(this.labrows);
            this.Controls.Add(this.dGVhistory);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ToPayHistory";
            this.Text = "ToPay Log";
            this.Load += new System.EventHandler(this.ToPayHistory_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGVhistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.DataGridView dGVhistory;
        private System.Windows.Forms.Label labrows;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col4;
        private System.Windows.Forms.Label labinhouse;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbpay;
        private System.Windows.Forms.Label label2;
    }
}