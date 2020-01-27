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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using Snackboxx.Forms;
using Textmail;


namespace Snackboxx.UserControls
{
    [SuppressMessage("ReSharper", "SpecifyACultureInStringConversionExplicitly")]
    public partial class Members : UserControl
    {
        private DBConnection _dbconn;
        private SnackboxxForm _form;
        private List<UserRight> _rights;
        private ToPayHistory _history;
        private string _cryptstr = "snack30xx";
        Crypt _crypt = new Crypt();
        private bool _saveButtonWasClicked = false;
        public string body;


        public Members(DBConnection dbconn, SnackboxxForm form, List<UserRight> rights)
        {
            InitializeComponent();
            _dbconn = dbconn;
            _form = form;
            _rights = rights;
        }

        private void User_Load(object sender, EventArgs e)
        {
            this.FillTreeView();
            this.SetUserRights();
            labsec.Text = "! Ohne Passwort wird nur das Recht \"Snackboxx User\" vergeben.\nDies hat später Auswirkung in der WebOberfläche.";
            labpas.Text = "! encrypted...";
            labdel.Text = "! Codes können nur gelöscht werden, wenn alle Posten beglichen sind.";
        }

        public void SetNewParams(DBConnection dbconn, List<UserRight> rights)
        {
            _dbconn = dbconn;
            _rights = rights;
            this.FillTreeView();
            this.SetUserRights();
        }

        private void SetUserRights()
        {
            for (int i = 0; i < _rights.Count; ++i)
            {
                cBUserRights.Items.Add(_rights[i]);
            }

            if (_rights.Count > 0)
            {
                cBUserRights.SelectedIndex = 0;
            }
        }

        private void FillTreeView()
        {
            tvuser.Nodes.Clear();
            string query = "Select * from T_User order by UserName";
            List<Dictionary<string, string>> userlist = _dbconn.GetResultList(query, null);
            for (int i = 0; i < userlist.Count; ++i)
            {
                TreeNode usernode = new TreeNode();
                Dictionary<string, string> user = userlist[i];
                Snackboxx.Core.User User = new Snackboxx.Core.User();
                User.userid = user["UserID"];
                usernode.Text = user["UserName"];
                User.username = user["UserName"];
                User.loginname = user["LoginName"];
                User.rest = user["rest"];
                User.EMail = user["EMail"];
                User.betragsLimit = user["BetragsLimit"];
                if (!string.IsNullOrEmpty(user["Password"]))
                    User.Password = _crypt.DecryptMessage(user["Password"], _cryptstr);
                User.UserRightID = user["UserRightID"];
                usernode.Tag = User;
                tvuser.Nodes.Add(usernode);
            }
        }

        private void ShowUserDetails(TreeNode node)
        {
            try
            {
                Snackboxx.Core.User user = (Snackboxx.Core.User) node.Tag;
                List<UserCode> UserCodelist = new List<UserCode>();
                tbuserid.Text = user.userid;
                tbusername.Text = user.username;
                tbloginname.Text = user.loginname;
                tbemail.Text = user.EMail;
                tbpassword.Text = user.Password;
                tb_userLimit.Text = user.betragsLimit;
                lbcodes.Items.Clear();

                string restquery = "Select rest from T_User where UserID='" + user.userid + "'";
                SqlDataReader dr = _dbconn.GetResult(restquery, null);
                while (dr.Read())
                {
                    user.rest = dr.GetValue(0).ToString();
                }

                dr.Close();

                //UserRights
                for (int i = 0; i < cBUserRights.Items.Count; ++i)
                {
                    if (((UserRight) cBUserRights.Items[i]).userRightID == user.UserRightID)
                        cBUserRights.SelectedIndex = i;
                }

                decimal rest = Convert.ToDecimal(user.rest);
                if (rest > 0)
                {
                    btndeleteselcode.Enabled = false;
                }
                else
                {
                    btndeleteselcode.Enabled = true;
                }


                string query = "Select * from T_UserCodes where UserID='" + user.userid + "'";
                List<Dictionary<string, string>> UserCodes = _dbconn.GetResultList(query, null);
                for (int i = 0; i < UserCodes.Count; ++i)
                {
                    Dictionary<string, string> UserCode = UserCodes[i];
                    UserCode Ucode = new UserCode();
                    Ucode.UserID = user.userid;
                    foreach (string key in UserCode.Keys)
                    {
                        if (key.Equals("CodeID"))
                        {
                            Ucode.CodeID = UserCode[key];
                        }

                        if (key.Equals("UserCode"))
                        {
                            Ucode.userCode = UserCode[key];
                        }

                        if (key.Equals("Preis"))
                        {
                            Ucode.Preis = UserCode[key].Replace(",", ".");
                        }

                        if (key.Equals("IsSnackCode"))
                        {
                            Ucode.Issnackcode = Convert.ToBoolean(UserCode[key]);
                        }
                    }

                    lbcodes.Items.Add(Ucode);
                    UserCodelist.Add(Ucode);
                }

                user.usercodes = UserCodelist;
                node.Tag = user;


                string sumquery = "Select * from T_Posten where UserID='" + user.userid + "'";
                List<Dictionary<string, string>> allposten = _dbconn.GetResultList(sumquery, null);
                labAllPosten.Text = allposten.Count.ToString();


                decimal openSum = 0;
                decimal closeSum = 0;
                decimal allSum = 0;
                for (int i = 0; i < allposten.Count; ++i)
                {
                    Dictionary<string, string> posten = allposten[i];
                    decimal preis = Convert.ToDecimal(posten["Preis"]);
                    allSum += preis;
                }

                closeSum = allSum - rest;
                openSum = rest;

                laballSum.Text = allSum.ToString().Replace(",", ".");
                labCloseSum.Text = closeSum.ToString().Replace(",", ".");
                labopenSum.Text = openSum.ToString().Replace(",", ".");
            }
            catch (Exception exp)
            {
                //this.WriteLog(exp.Message);
            }
        }

        private string InsertParameterCheck(string text)
        {
            return text.Replace("'", "").Replace(";", "").Replace("\\", "");
        }

        private void tvuser_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                this.ShowUserDetails(e.Node);
            }
        }

        private void toolStripMenuItemClear_Click(object sender, EventArgs e)
        {
            tbusername.Text = string.Empty;
            tbuserid.Text = string.Empty;
            tbpassword.Text = string.Empty;
            tbemail.Text = string.Empty;
            lbcodes.Items.Clear();
            tbpay.Text = "0.00";
            tb_userLimit.Text = SnackboxxForm.DEFAULT_LIMIT;
            labopenSum.Text = "0.00";
            labCloseSum.Text = "0.00";
            laballSum.Text = "0.00";
            labAllPosten.Text = "0";
            tbscancode.Text = "0000";
            tbpreis.Text = "0.00";
            if (cBUserRights.Items.Count > 0)
                cBUserRights.SelectedIndex = 0;
        }

        private void toolStripMenuItemSave_Click(object sender, EventArgs e)
        {
            try
            {
                _saveButtonWasClicked = true;
                Snackboxx.Core.User user = new Snackboxx.Core.User();
                user.userid = tbuserid.Text;
                user.username = this.InsertParameterCheck(tbusername.Text);
                user.loginname = this.InsertParameterCheck(tbloginname.Text);
                if (tb_userLimit.Text == "0.00" || tb_userLimit.Text == "")
                {
                    user.betragsLimit = SnackboxxForm.DEFAULT_LIMIT;
                    user.nextBetragsLimit = SnackboxxForm.DEFAULT_LIMIT;
                }
                else
                {
                    user.betragsLimit = tb_userLimit.Text;
                    user.nextBetragsLimit = tb_userLimit.Text;
                }

                string password = null;
                if (!string.IsNullOrEmpty(tbpassword.Text))
                    password = _crypt.EncryptMessage(this.InsertParameterCheck(tbpassword.Text), _cryptstr);
                user.Password = tbpassword.Text;
                user.EMail = this.InsertParameterCheck(tbemail.Text);
                if (cBUserRights.Items.Count > 0)
                    user.UserRightID = ((UserRight) cBUserRights.SelectedItem).userRightID;

                ParameterObj timeObj = new ParameterObj();
                timeObj.name = "@Timer";
                timeObj.type = SqlDbType.DateTime;
                timeObj.value = DateTime.Now;

                if (string.IsNullOrEmpty(tbuserid.Text)) //newUser
                {
                    #region newUser

                    if (!_dbconn.DataSetExists("Select * from T_User where UserName='" + user.username + "'", null))
                    {
                        string insert = "Insert into T_User(UserName,Password,EMail,UserRightID,LoginName,BetragsLimit,NextBetragsLimit)"
                                        + "values('" + user.username + "','" + password + "','" + user.EMail + "','" + user.UserRightID + "','" +
                                        user.loginname + "','" + user.betragsLimit + "','" + user.nextBetragsLimit + "')";
                        _dbconn.Execute(insert, null);
                        string query = "Select UserID from T_User where UserName='" + user.username + "'";
                        SqlDataReader dr = _dbconn.GetResult(query, null);
                        while (dr.Read())
                        {
                            user.userid = dr.GetValue(0).ToString();
                        }

                        dr.Close();
                        user.usercodes = new List<UserCode>();
                        for (int i = 0; i < lbcodes.Items.Count; ++i)
                        {
                            UserCode Ucode = (UserCode) lbcodes.Items[i];
                            user.usercodes.Add(Ucode);
                            string insertcode = "Insert into T_UserCodes(UserID,UserCode,Preis,IsSnackCode)"
                                                + "values('" + user.userid + "','" + Ucode.userCode + "','" + Ucode.Preis + "','" + Ucode.Issnackcode + "')";
                            _dbconn.Execute(insertcode, null);
                        }

                        List<ParameterObj> paramlist = new List<ParameterObj>();
                        paramlist.Add(timeObj);

                        string insertK = "Insert into T_UserTimeKonto(UserID,InHouse,UpdateTime)values('" + user.userid + "','false',@Timer)";
                        _dbconn.Execute(insertK, paramlist);

                        TreeNode node = new TreeNode();
                        node.Text = user.username;
                        node.Tag = user;
                        tvuser.Nodes.Add(node);
                        _form.SettssinfoONE("User Add... User " + user.username + " with follow ID " + user.userid + " is inserted...");
                        //this.WriteLog("User Add... User " + username + " with follow ID " + user.userid + " is inserted...");
                    }
                    else
                    {
                        _form.SettssinfoONE("User exists in the Database... " + user.username);
                        //this.WriteLog("User exists in the Database... " + username);
                    }

                    //this.btnclear_Click(sender, e);

                    #endregion
                }
                else //olduser
                {
                    #region olduser

                    string queryupd = "Update T_User set UserName='" + user.username
                                                                     + "',Password='" + password
                                                                     + "',LoginName='" + user.loginname
                                                                     + "',EMail='" + user.EMail
                                                                     + "',UserRightID='" + user.UserRightID
                                                                     + "',BetragsLimit ='" + user.betragsLimit
                                                                     + "' where UserID='" + user.userid + "'";

                    _dbconn.Execute(queryupd, null);


                    string query = "Select * from T_UserCodes where UserID='" + user.userid + "'";
                    List<Dictionary<string, string>> oldCodes = _dbconn.GetResultList(query, null);

                    string kquery = "Select * from T_UserTimeKonto where UserID='" + user.userid + "'";
                    if (!_dbconn.DataSetExists(kquery, null))
                    {
                        List<ParameterObj> paramlist = new List<ParameterObj>();
                        paramlist.Add(timeObj);

                        string insertK = "Insert into T_UserTimeKonto(UserID,InHouse,UpdateTime)values('" + user.userid + "','false',@Timer)";
                        _dbconn.Execute(insertK, paramlist);
                    }

                    for (int i = 0; i < oldCodes.Count; ++i)
                    {
                        bool exists = false;
                        string codeid = oldCodes[i]["CodeID"];
                        for (int j = 0; j < lbcodes.Items.Count; ++j)
                        {
                            UserCode code = (UserCode) lbcodes.Items[j];
                            if (codeid == code.CodeID)
                                exists = true;
                        }

                        if (!exists)
                        {
                            string check = "Select * from T_User where UserID='" + user.userid + "' and rest>=0";
                            if (!_dbconn.DataSetExists(check, null))
                            {
                                string delquery = "Delete from t_UserCodes where UserID='" + user.userid + "' and CodeID='" + codeid + "'";
                                _dbconn.Execute(delquery, null);
                            }
                        }
                    }

                    List<UserCode> UserCodelist = new List<UserCode>();
                    for (int i = 0; i < lbcodes.Items.Count; ++i)
                    {
                        UserCode code = (UserCode) lbcodes.Items[i];
                        if (string.IsNullOrEmpty(code.CodeID))
                        {
                            code.UserID = tbuserid.Text;
                            string insert = "Insert into T_UserCodes(UserID,UserCode,Preis,IsSnackCode)"
                                            + "values('" + code.UserID + "','" + code.userCode + "','" + code.Preis + "','" + code.Issnackcode + "')";
                            //this.WriteInfo(insert);
                            _dbconn.Execute(insert, null);
                        }
                    }

                    _form.SettssinfoONE("User Edit: User " + tbusername.Text + " was edit...");

                    //this.WriteLog("User Edit: User " + tbusername.Text + " was edit...");
                    tvuser.SelectedNode.ForeColor = Color.Black;
                    tvuser.SelectedNode.Tag = user;

                    #endregion
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message + "\n" + exp.StackTrace);
                //this.WriteLog("UserSave ... Exception: " + exp.Message);
            }
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbuserid.Text))
            {
                string checkquery = "Select UserID,UserName,KontoID from VW_UserKonto where UserID='" + tbuserid.Text + "' and rest>0";
                if (!_dbconn.DataSetExists(checkquery, null))
                {
                    string query = "Select UserID,UserName,KontoID from VW_UserKonto where UserID='" + tbuserid.Text + "'";
                    string kontoid = null;
                    string username = null;
                    string userid = null;
                    SqlDataReader sqldr = _dbconn.GetResult(query, null);
                    while (sqldr.Read())
                    {
                        userid = sqldr.GetValue(0).ToString();
                        username = sqldr.GetValue(1).ToString();
                        kontoid = sqldr.GetValue(2).ToString();
                    }

                    sqldr.Close();

                    DialogResult res = MessageBox.Show("Want to really delete the user " + username + " ?", "Delete User", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        _dbconn.Execute("Delete from T_Posten where UserID='" + tbuserid.Text + "'", null);
                        _dbconn.Execute("Delete from T_UserCodes where UserID='" + tbuserid.Text + "'", null);
                        _dbconn.Execute("Delete from T_ToPay where UserID='" + tbuserid.Text + "'", null);
                        _dbconn.Execute("Delete from T_Time where KontoID='" + kontoid + "'", null);
                        _dbconn.Execute("Delete from T_UserTimeKonto where KontoID='" + kontoid + "'", null);
                        _dbconn.Execute("Delete from T_User where UserID='" + tbuserid.Text + "'", null);
                        tvuser.Nodes.Remove(tvuser.SelectedNode);
                        _form.SettssinfoONE("User \"" + tbusername.Text + "\" is deleted...");
                        //this.WriteLog("User " + tvUser.SelectedNode.Text + " is deleted...");
                        this.toolStripMenuItemClear_Click(sender, e);
                    }
                }
                else
                {
                    _form.SettssinfoONE("User \"" + tbusername.Text + "\" can not deleted... User have open Posten!...");

                    //this.WriteLog("User Delete... User have open Posten! User can't deleted...");
                }
            }
        }

        private void btndeleteselcode_Click(object sender, EventArgs e)
        {
            if (lbcodes.SelectedIndex > -1)
            {
                lbcodes.Items.RemoveAt(lbcodes.SelectedIndex);
            }
        }

        private void btnpay_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbpay.Text) && tbpay.Text != "0.00")
                {
                    string tbtext = tbpay.Text;
                    string opentext = labopenSum.Text;
                    tbtext = tbtext.Replace(".", ",");
                    opentext = opentext.Replace(".", ",");
                    decimal zahlt = Convert.ToDecimal(tbtext);
                    decimal open = Convert.ToDecimal(opentext);
                    decimal rest = 0;
                    decimal defaultLimit = 0;

                    string userquery = "Select rest, BetragsLimit from T_User where UserID='" + tbuserid.Text + "'";
                    SqlDataReader sqldr = _dbconn.GetResult(userquery, null);
                    while (sqldr.Read())
                    {
                        string strrest = sqldr.GetValue(0).ToString().Replace(".", ",");
                        rest = Convert.ToDecimal(strrest);
                        string stBetragsLimit = sqldr.GetValue(1).ToString().Replace(".", ",");
                        defaultLimit = Convert.ToDecimal(stBetragsLimit);
                    }

                    sqldr.Close();
                    //tssInfoONE.Text = "Pay: " + zahlt + " Open: " + open;
                    rest = rest - zahlt;
                    string updateRest = "Update T_User set rest='" + rest.ToString().Replace(",", ".") + "' where UserID='" + tbuserid.Text + "'";
                    //this.WriteInfo(restupdate);
                    _dbconn.Execute(updateRest, null);

                    ParameterObj timeObj = new ParameterObj();
                    timeObj.name = "@Timer";
                    timeObj.type = SqlDbType.DateTime;
                    timeObj.value = DateTime.Now;

                    List<ParameterObj> paramlist = new List<ParameterObj>();
                    paramlist.Add(timeObj);

                    string topayquery = "Insert into T_ToPay(pay,Time,userid)values('" + tbtext.Replace(",", ".") + "',@Timer,'" + tbuserid.Text + "')";
                    _dbconn.Execute(topayquery, paramlist);


                    this.toolStripMenuItemClear_Click(null, null);
                    TreeNode node = tvuser.SelectedNode;
                    this.ShowUserDetails(node);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);

                //this.WriteLog(exp.Message);
            }
        }


        private void btnaddcode_Click(object sender, EventArgs e)
        {
            try
            {
                UserCode Ucode = new UserCode();
                Ucode.userCode = tbscancode.Text;
                Ucode.Preis = tbpreis.Text.Replace(",", ".");
                if (rbnTimeCode.Checked)
                {
                    Ucode.Issnackcode = false;
                }
                else
                {
                    Ucode.Issnackcode = true;
                }


                lbcodes.Items.Add(Ucode);
                if (!string.IsNullOrEmpty(tbuserid.Text))
                {
                    TreeNode node = tvuser.SelectedNode;
                    Snackboxx.Core.User user = (Snackboxx.Core.User) node.Tag;
                    Ucode.UserID = user.userid;
                    if (user.usercodes == null)
                        user.usercodes = new List<UserCode>();
                    user.usercodes.Add(Ucode);
                    node.Tag = user;
                    //node.ForeColor = _editcolor;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                //this.WriteLog(exp.Message);
            }
        }

        private void btndelallPos_Click(object sender, EventArgs e)
        {
            Snackboxx.Core.User user = (Snackboxx.Core.User) tvuser.SelectedNode.Tag;
        }

        private void tbpassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbpassword.Text))
            {
                cBUserRights.Enabled = false;
            }
            else
            {
                cBUserRights.Enabled = true;
            }
        }

        private void rbnSnackCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnSnackCode.Checked)
            {
                rbnTimeCode.Checked = false;
                tbpreis.Enabled = true;
            }
            else
            {
                rbnTimeCode.Checked = true;
                tbpreis.Enabled = false;
            }
        }

        private void rbnTimeCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rbnTimeCode.Checked)
            {
                rbnSnackCode.Checked = false;
                tbpreis.Enabled = false;
            }
            else
            {
                rbnSnackCode.Checked = true;
                tbpreis.Enabled = true;
            }
        }

        private void toolStripMenuItemTPHistory_Click(object sender, EventArgs e)
        {
            _history = new ToPayHistory(tbuserid.Text, _dbconn);
            _history.BringToFront();
            _history.Show();
        }

        private void sendMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _form.sendMail(tbemail.Text, labopenSum.Text);
        }


        public void AddPosten(decimal preis)
        {
            decimal rest = 0;
            var userid = tbuserid.Text;
            using (var sqldr = _dbconn.GetResult(string.Format("Select rest, BetragsLimit from T_User where UserID='{0}'", userid)))
            {
                while (sqldr.Read())
                    rest = Convert.ToDecimal(sqldr.GetValue(0).ToString());
            }

            rest += preis;
            _dbconn.Execute(string.Format("Insert into T_Posten(UserID,CodeID,Preis)values({0},-1,'{1}')", userid, preis.ToString().Replace(",", ".")));
            _dbconn.Execute(string.Format("Update T_User set rest='{0}' where UserID='{1}'", rest.ToString().Replace(",", "."), userid));

            string sumquery = "Select * from T_Posten where UserID='" + userid + "'";
            List<Dictionary<string, string>> allposten = _dbconn.GetResultList(sumquery, null);
            labAllPosten.Text = allposten.Count.ToString();


            decimal allSum = allposten.Sum(t => Convert.ToDecimal(t["Preis"]));
            var closeSum = allSum - rest;
            var openSum = rest;

            laballSum.Text = allSum.ToString().Replace(",", ".");
            labCloseSum.Text = closeSum.ToString().Replace(",", ".");
            labopenSum.Text = openSum.ToString().Replace(",", ".");
            _form.SendMailIfLimitReached(userid);
        }

        private void btnAdd010_Click(object sender, EventArgs e)
        {
            AddPosten((decimal) 0.10);
        }

        private void btnAdd015_Click(object sender, EventArgs e)
        {
            AddPosten((decimal) 0.15);
        }

        private void btnAdd030_Click(object sender, EventArgs e)
        {
            AddPosten((decimal) 0.30);
        }

        private void btnAdd040_Click(object sender, EventArgs e)
        {
            AddPosten((decimal) 0.40);
        }

        private void btnAdd050_Click(object sender, EventArgs e)
        {
            AddPosten((decimal) 0.50);
        }

        private void btnAdd100_Click(object sender, EventArgs e)
        {
            AddPosten((decimal) 1.00);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}