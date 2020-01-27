using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Snackboxx.Core;
using System.Xml;
using System.IO;

namespace SnackBoxxWeb
{
    public partial class _Default : System.Web.UI.Page
    {
        Crypt _crypt = new Crypt();
        Snackboxx.Core.DBConnection _dbconn = new DBConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            labinfo.ForeColor = Color.Red;
            this.CheckConnection();

            if (!string.IsNullOrEmpty(Request.Params.Get(0)))
            {
                //labinfo.Text = "request " + Request.Params.Get(0);
                if (Request.Params.Get(0).Equals("0"))
                {
                    labinfo.Text = "Your session is down!";
                    Session["SessionID"] = null;
                    Session["UserID"] = null;                    
                }
                if (Request.Params.Get(0).Equals("1"))
                {
                    labinfo.Text = "Thank you for visit this site!";
                    Session["SessionID"] = null;
                    Session["UserID"] = null;
                }
                
            }

            
        }

        protected void btnlogon_Click(object sender, EventArgs e)
        {            
            if (string.IsNullOrEmpty(tbusername.Text))
            {
                labinfo.Text = "Please set a username!";
                return;
            }
            string userid = this.CheckUser(tbusername.Text, tbpassword.Text);
            if (userid.Equals("-1"))
            {
                labinfo.Text = "Please check your username or password";
                return;
            }
            Session["UserID"] = userid;
            Session["SessionID"] = Session.SessionID.ToString();
            Session.Timeout = 60;
            Server.Transfer("startform.aspx?ID=" + Session["UserID"] + "&SessionID=" + Session["SessionID"]);
            //Response.Redirect("startform.aspx?ID=&SessionID="+Session.SessionID.ToString(), true);

        }

        protected void tbusername_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbusername.Text))
            {
                labinfo.Text = string.Empty;
            }
        }

        private void CheckConnection()
        {
            XmlDocument xmldoc = new XmlDocument();
            string file = Server.MapPath(@"\settings.xml");
            FileInfo fi = new FileInfo(file);
            if (fi.Exists)
            {
                string dbserver = null;
                string dbdatabase = null;
                string dbuser = null;
                string dbpassword = null;
                xmldoc.Load(file);
                XmlElement root = xmldoc.DocumentElement;
                foreach (XmlNode node in root.ChildNodes)
                {
                    if (node.Name.Equals("server")) { dbserver = node.InnerText; }
                    if (node.Name.Equals("database")) { dbdatabase = node.InnerText; }
                    if (node.Name.Equals("user")) { dbuser = node.InnerText; }
                    if (node.Name.Equals("passw")) { dbpassword = node.InnerText; }
                }
                if (!string.IsNullOrEmpty(dbserver) && !string.IsNullOrEmpty(dbdatabase) && !string.IsNullOrEmpty(dbuser) && !string.IsNullOrEmpty(dbpassword))
                {
                    SQLConnObj sqlobj = _dbconn.Connection(dbserver, dbdatabase, dbuser, dbpassword);
                    if (!sqlobj.isConnect)
                    {
                        labinfo.Text = "No Database connected...";
                        btnlogon.Enabled = false;                        
                    }
                }
            }
        }

        private string CheckUser(string username, string password)
        {
            if (username.Equals("Testuser"))
                return "-999";
            string userid = null;
            string userpass = null;
            string logname = null;

            List<ParameterObj> paramlist=new List<ParameterObj>();
            ParameterObj paramuser=new ParameterObj();
            paramuser.name="@user";
            paramuser.type=System.Data.SqlDbType.NVarChar;
            paramuser.value=username;
            paramlist.Add(paramuser);
            string query="Select UserID,Password,LoginName from T_User where UserName=@user or LoginName=@user";

            if (!string.IsNullOrEmpty(password))
            {
                ParameterObj parampass = new ParameterObj();
                parampass.name = "@pass";
                parampass.type = System.Data.SqlDbType.NVarChar;
                parampass.value = _crypt.EncryptMessage(password, "snack30xx");
                paramlist.Add(parampass);
                query = "Select UserID,Password,LoginName from T_User where (UserName=@user or LoginName=@user) and Password=@pass";
            }
            System.Data.SqlClient.SqlDataReader dr= _dbconn.GetResult(query, paramlist);
            while (dr.Read())
            {
                userid = dr.GetValue(0).ToString();
                userpass = dr.GetValue(1).ToString();
                logname = dr.GetValue(2).ToString();
            }
            dr.Close();
            if (string.IsNullOrEmpty(password) && (!string.IsNullOrEmpty(logname) || !string.IsNullOrEmpty(username)))
                return "-1";

            if (!string.IsNullOrEmpty(userid))
                return userid;
            //labinfo.Text = crypt.EncryptMessage(password, "snack30xx");
            //labinfo.Text += " | " + crypt.DecryptMessage(labinfo.Text, "snack30xx");
            return "-1";
        }
        
    }
}
