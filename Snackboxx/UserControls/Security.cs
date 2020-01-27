using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Snackboxx.Core;
using System.Data.SqlClient;
using System.Threading;
using Snackboxx.Forms;

namespace Snackboxx.UserControls
{
    public partial class Security : UserControl
    {
        private DBConnection _dbconn;
        private List<UserRight> _seclist;
        private SnackboxxForm _form;


        public Security(DBConnection dbconn,SnackboxxForm form, List<UserRight> securitylist)
        {
            InitializeComponent();
            _dbconn = dbconn;
            _seclist = securitylist;
            _form = form;
        }

        private void Security_Load(object sender, EventArgs e)
        {
            this.FillTreeView();
        }

        private void FillTreeView()
        {
            tVUserRights.Nodes.Clear();
            string query = "Select * from T_UserRights order by UserRight";
            List<Dictionary<string, string>> table = _dbconn.GetResultList(query, null);
            for (int i = 0; i < table.Count; ++i)
            {
                UserRight userright = new UserRight();                
                Dictionary<string, string> element = table[i];
                TreeNode node = new TreeNode(element["UserRight"]);
                userright.userRightID = element["UserRightID"];
                userright.userRight = element["UserRight"];
                if (!string.IsNullOrEmpty(element["GlobalMail"]))
                    userright.globalMail = Convert.ToBoolean(element["GlobalMail"]);
                else { userright.globalMail = false; }
                userright.mail = element["EMail"];
                userright.allowposten = Convert.ToBoolean(element["AllowPosten"]);
                userright.allowtime = Convert.ToBoolean(element["AllowTime"]);
                userright.allowconfig = Convert.ToBoolean(element["AllowConfig"]);
                userright.allowadmin = Convert.ToBoolean(element["AllowAdministration"]);
                node.Tag = userright;
                tVUserRights.Nodes.Add(node);
            }
        }


        private void cballadmin_CheckedChanged(object sender, EventArgs e)
        {

            cballowadmin.Checked = cballadmin.Checked;
            cballowadmin.Enabled = !cballadmin.Checked;
            cballowposten.Checked = cballadmin.Checked;
            cballowposten.Enabled = !cballadmin.Checked;
            cballowtime.Checked = cballadmin.Checked;
            cballowtime.Enabled = !cballadmin.Checked;
            cballowconfig.Checked = cballadmin.Checked;
            cballowconfig.Enabled = !cballadmin.Checked;

        }

        /// <summary>
        /// Show all infos from treeview nodes tag
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tVUserRights_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                UserRight right = (UserRight)e.Node.Tag;
                tbid.Text = right.userRightID;
                tbname.Text = right.userRight;
                tbmail.Text = right.mail;
                cbisglobalmail.Checked = right.globalMail;

                if (right.allowadmin && right.allowconfig && right.allowposten && right.allowtime)
                    cballadmin.Checked = true;
                else
                {
                    cballadmin.Checked = false;
                    cballowadmin.Checked = right.allowadmin;
                    cballowconfig.Checked = right.allowconfig;
                    cballowposten.Checked = right.allowposten;
                    cballowtime.Checked = right.allowtime;
                }
            }
        }       

        /// <summary>
        /// Clear all fields
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tbid.Text = string.Empty;
            tbmail.Text = string.Empty;
            tbname.Text = string.Empty;
            cballadmin.Checked = false;
            cbisglobalmail.Checked = false;
            cballowadmin.Checked = false;
            cballowconfig.Checked = false;
            cballowposten.Checked = false;
            cballowtime.Checked = false;
        }

        /// <summary>
        /// Save edit and new Right
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                ParameterObj param1 = new ParameterObj();
                param1.name = "@Name";
                param1.type = SqlDbType.NVarChar;
                param1.value = tbname.Text;
                ParameterObj param2 = new ParameterObj();
                param2.name = "@Mail";
                param2.type = SqlDbType.NVarChar;
                param2.value = tbmail.Text;
                List<ParameterObj> paramlist = new List<ParameterObj>();
                paramlist.Add(param1);
                paramlist.Add(param2);
                if (!string.IsNullOrEmpty(tbid.Text))//Edit
                {
                    if (!string.IsNullOrEmpty(tbname.Text))
                    {
                        string updatequery = "Update T_UserRights set UserRight=@Name,"
                                           + "GlobalMail='" + cbisglobalmail.Checked + "',"
                                           + "EMail=@Mail,"
                                           + "AllowPosten='" + cballowposten.Checked + "',"
                                           + "AllowTime='" + cballowtime.Checked + "',"
                                           + "AllowConfig='" + cballowconfig.Checked + "',"
                                           + "AllowAdministration='" + cballowadmin.Checked + "'"
                                           + " where UserRightID='" + tbid.Text + "'";
                        int result = _dbconn.Execute(updatequery, paramlist);
                        if (result > 0)
                            _form.SettssinfoONE("Save Right correct...");
                        this.toolStripMenuItem1_Click(sender, e);
                        this.FillTreeView();
                    }
                    else { _form.SettssinfoONE("Please set all informations..."); }
                }
                else//new right
                {
                    #region newright
                    if (!string.IsNullOrEmpty(tbname.Text))//has name
                    {
                        if (tVUserRights.Nodes.Find(tbname.Text, false).GetLength(0) <= 0)//if other right
                        {                            
                            string insertquery = "Insert into T_UserRights(UserRightID,UserRight,GlobalMail,EMail,AllowPosten,AllowTime,AllowConfig,AllowAdministration)values("
                                               + "'" + Guid.NewGuid() + "',@Name,"
                                               + "'" + cbisglobalmail.Checked + "',@Mail,"
                                               + "'" + cballowposten.Checked + "',"
                                               + "'" + cballowtime.Checked + "',"
                                               + "'" + cballowconfig.Checked + "',"
                                               + "'" + cballowadmin.Checked + "')";
                            int result=_dbconn.Execute(insertquery, paramlist);
                            if (result > 0)
                                _form.SettssinfoONE("Save new Right correct...");
                            this.toolStripMenuItem1_Click(sender, e);
                            this.FillTreeView();
                        }
                        else { _form.SettssinfoONE("UserRight exists..."); }
                    }
                    else { _form.SettssinfoONE("Please set all informations..."); }
                    #endregion
                }
            }
            catch (Exception exp)
            {
                _form.SettssinfoONE("Exception: " + exp.Message);
            }
        }
        
        /// <summary>
        /// Delete a right
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbid.Text))
            {
                string checkquery = "Select UserRight from VW_UserRights where UserRightID='" + tbid.Text + "'";
                if (!_dbconn.DataSetExists(checkquery, null))
                {
                    string deletequery = "Delete from T_UserRights where UserRightID='" + tbid.Text + "'";
                    _dbconn.Execute(deletequery, null);
                    this.toolStripMenuItem1_Click(sender, e);
                    this.FillTreeView();
                }
                else
                {
                    _form.SettssinfoONE("UserRight can not delete... User have this Right!");
                }
            
            }
        }      
    }
}
