using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Snackboxx.Core;

namespace Snackboxx.Forms
{
    public partial class ToPayHistory : Form
    {
        private string _userid=null;
        private DBConnection _dbconn;

        public ToPayHistory(string userid,DBConnection dbconn)
        {
            InitializeComponent();
            _userid = userid;
            _dbconn = dbconn;
        }

        private void ToPayHistory_Load(object sender, EventArgs e)
        {
            this.FillUserInfo();
            this.FillDGV();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillUserInfo()
        { 
            string query = "Select * from VW_UserKonto where UserID='" + _userid + "'";
            if (_dbconn.DataSetExists(query, null))
            { 
                 List<Dictionary<string,string>> table= _dbconn.GetResultList(query, null);
                 for (int i = 0; i < table.Count; ++i)
                 {
                     Dictionary<string, string> element = table[i];

                     this.Text = "ToPay Log (" + element["UserName"] + ")   " + element["EMail"];

                     if(!string.IsNullOrEmpty(element["InHouse"]))
                     {
                         if (Convert.ToBoolean(element["InHouse"]))
                         {
                             labinhouse.Text = "activ in House";
                             labinhouse.ForeColor = Color.DarkGreen;
                         }
                         else { labinhouse.Text = "inactive"; labinhouse.ForeColor = Color.DarkRed; }
                     }
                 }
            }
        }

        private void FillDGV()
        {
            dGVhistory.Rows.Clear();

            string query = "Select * from VW_UserToPay where UserID='" + _userid + "' order by Time desc";
            if (_dbconn.DataSetExists(query,null))
            {
                List<Dictionary<string,string>> table= _dbconn.GetResultList(query, null);
                for (int i = 0; i < table.Count; ++i)
                {
                    try
                    {
                        Dictionary<string, string> element = table[i];
                        if (!string.IsNullOrEmpty(element["pay"]))
                        {
                            DataGridViewRow dgvr = new DataGridViewRow();
                            DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
                            cell1.Value = element["UserID"];
                            DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                            cell2.Value = (i + 1).ToString();
                            DataGridViewTextBoxCell cell3 = new DataGridViewTextBoxCell();
                            cell3.Value = element["Time"].Replace(".","/");
                            DataGridViewTextBoxCell cell4 = new DataGridViewTextBoxCell();
                            cell4.Value = element["pay"];
                            DataGridViewTextBoxCell cell5 = new DataGridViewTextBoxCell();
                            cell5.Value = "paid";
                            if (Convert.ToDecimal(element["pay"]) < 0)
                                cell5.Value = "transfer";
                            dgvr.Cells.Add(cell1);
                            dgvr.Cells.Add(cell2);
                            dgvr.Cells.Add(cell3);
                            dgvr.Cells.Add(cell4);
                            dgvr.Cells.Add(cell5);
                            dGVhistory.Rows.Add(dgvr);
                        }
                    }
                    catch (Exception exp)
                    {
                        //MessageBox.Show(exp.Message);
                    }
                }
                labrows.Text = "Rows: " + (dGVhistory.Rows.Count-1);
                
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {            
            ParameterObj timeObj = new ParameterObj();
            timeObj.name = "@Timer";
            timeObj.type = SqlDbType.DateTime;
            timeObj.value = DateTime.Now;
            List<ParameterObj> paramlist = new List<ParameterObj>();
            paramlist.Add(timeObj);

            if (tbpay.Text != "0.00" && tbpay.Text != "0,00")
            {
                try
                {
                    string topayquery = "Insert into T_ToPay(pay,Time,userid)values('" + tbpay.Text.Replace(",", ".") + "',@Timer,'" + _userid + "')";
                    _dbconn.Execute(topayquery, paramlist);
                    this.FillDGV();
                    tbpay.Text = "0.00";
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }
    }
}
