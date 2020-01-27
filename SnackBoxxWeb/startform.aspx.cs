using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Snackboxx.Core;
using System.Xml;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using SnackBoxxWeb.Controls;


namespace SnackBoxxWeb
{
    public partial class startform : System.Web.UI.Page
    {
        private DBConnection _dbconn = new DBConnection();
        private User _user;
        private enum menublockid { blockcontentleft, blockcontentcenter };

        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = Request.Params.Get(0).ToString();
            string session = Request.Params.Get(1).ToString();
            string sesstype = Request.Params.Get(2).ToString();

            if (session.Equals(Session["SessionID"]) && userid.Equals(Session["UserID"]))
            {
                _user = new User();


                //info.Text = "korrekte session!: "+DateTime.Now.ToString()+" SessionType:"+sesstype;
                this.CheckConnection();
                this.GetUser(userid);
                username.Text = "Welcome " + _user.username + " !";
                menucenter.Text = this.GetStartView();
                if (sesstype.Equals("posten")) { menucenter.Text = this.GetPositions(_user); }
                else if (sesstype.Equals("time")) { menucenter.Text = this.GetTimeBlock(_user); }
                else if (sesstype.Equals("topay")) { menucenter.Text = this.GetPayHistory(_user); }
                else if (sesstype.Equals("config")) { menucenter.Text = this.GetUserConfig(_user); }
                menuleft.Text = this.GetMenu(_user);

                //menu right
                menuright.Text = this.GetToPay(_user) + "<br><br>" + this.GetAllPostCount(_user);
                menuright.Text += this.GetUserInHouse(_user);
                menuright.Text += this.GetGebBlock();

            }
            else
            {
                Server.Transfer("Default.aspx?R=0");
                //info.Text = "!!! falsche Session :" + Request.Params.Get(1).ToString() + " | Session: " + Session["SessionID"];
            }
        }
       
        private void GetUser(string userid)
        {
            if (!userid.Equals("-999"))
            {
                if (_dbconn.GetState == System.Data.ConnectionState.Open)
                {
                    List<Dictionary<string, string>> table = _dbconn.GetResultList("Select * from VW_UserRights where UserID='" + userid + "'", null);
                    for (int i = 0; i < table.Count; ++i)
                    {
                        Dictionary<string, string> element = table[i];
                        _user.userid = element["UserID"];
                        _user.username = element["UserName"];
                        _user.rest = element["rest"];
                        _user.UserRight = new UserRight();
                        _user.UserRightID = element["UserRightID"];
                        _user.UserRight.userRightID = element["UserRightID"];
                        _user.UserRight.userRight = element["UserRight"];


                        string query = "Select KontoID from VW_UserKonto where UserID='" + _user.userid + "'";
                        SqlDataReader sqldr = _dbconn.GetResult(query, null);
                        while (sqldr.Read())
                        {
                            _user.TimeKontoID = sqldr.GetValue(0).ToString();
                        }
                        sqldr.Close();


                        if (!string.IsNullOrEmpty(element["AllowPosten"]))
                            _user.UserRight.allowposten = Convert.ToBoolean(element["AllowPosten"]);
                        else { _user.UserRight.allowposten = false; }
                        if (!string.IsNullOrEmpty(element["AllowTime"]))
                            _user.UserRight.allowtime = Convert.ToBoolean(element["AllowTime"]);
                        else { _user.UserRight.allowtime = false; }
                        if (!string.IsNullOrEmpty(element["AllowConfig"]))
                            _user.UserRight.allowconfig = Convert.ToBoolean(element["AllowConfig"]);
                        else { _user.UserRight.allowconfig = false; }
                        if (!string.IsNullOrEmpty(element["AllowAdministration"]))
                            _user.UserRight.allowadmin = Convert.ToBoolean(element["AllowAdministration"]);
                        else { _user.UserRight.allowadmin = false; }
                    }
                }
            }
            else
            {
                _user.userid = userid;
                _user.username = "Testuser";
                _user.rest = "0.00";
                _user.UserRight = new UserRight();
                _user.UserRight.allowtime = false;
                _user.UserRight.allowposten = false;
                _user.UserRight.allowconfig = false;
                _user.UserRight.allowadmin = false;
            }
        }
        
        private string GetMenu(User user)
        { 
            string header="Snackboxx Menu";
            string menu = "<a href=startform.aspx?ID=" + user.userid + "&SessionID=" + Session["SessionID"] + ">Home</a>";
            if (user.UserRight.allowposten)
                menu += "<br> <a href=startform.aspx?ID=" + user.userid + "&SessionID=" + Session["SessionID"] + "&posten>Positions</a>";
            if (user.UserRight.allowposten)
                menu += "<br> <a href=startform.aspx?ID=" + user.userid + "&SessionID=" + Session["SessionID"] + "&topay>ToPay History</a>";
            if (user.UserRight.allowtime)
                menu += "<br> <a href=startform.aspx?ID=" + user.userid + "&SessionID=" + Session["SessionID"] + "&time>Time Registration</a>";
            if (user.UserRight.allowconfig)
                menu += "<br><br><br> <a href=startform.aspx?ID=" + user.userid + "&SessionID=" + Session["SessionID"] + "&config>Config</a>";
            return GetMenuBlock(header, menu,menublockid.blockcontentcenter);
        }

        protected void refresh_Click(object sender, EventArgs e)
        {
                      
            //Server.Transfer("startform.aspx?ID=" + Session["UserID"] + "&SessionID=" + Session["SessionID"]);

        }
                
        private string GetMenuBlock(string strheader,string strcontent,menublockid blockid)
        {
            string strmenu=null;
            strmenu = "<div id=\"block\">"
                    + "<div id=\"blockheader\">"+strheader+"</div>"
                    + "<div id=\""+blockid.ToString()+"\">"+strcontent+"</div>"
                    + "</div>";
            return strmenu;
        }

        private string GetInnerBlock(string strheader, string strcontent)
        {
            string strmenu = null;
            strmenu = "<div id=\"innerblock\">"
                    + "<div id=\"blockheader\">" + strheader + "</div>"
                    + "<div id=\"blockcontent\">" + strcontent + "</div>"
                    + "</div>";
            return strmenu;
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
                        info.Text = "No Database connected...";                        
                    }
                }
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            this.Session.RemoveAll();
            Response.Redirect("Default.aspx?R=1",true);
        }

        private void SetCenterControl(Control control)
        {
            phcentercontent.Controls.Clear();
            phcentercontent.Controls.Add(control);
        }
        

        #region GetBlocks

        private string GetPositions(User user)
        {
            if (user.UserRight.allowposten)
            {
                List<Dictionary<string, string>> table = _dbconn.GetResultList("Select * from VW_Posten where UserID='" + user.userid + "' and IsSnackCode='True' order by Time desc", null);
                string content = "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\">";
                content += "<tr><td><u>Time</u></td><td><u>Preis (€)</u></td></tr>";
                content += "<tr><td>&nbsp;</td><td>&nbsp;</td></tr>";


                string month = null;
                string color = null;
                string color1 = "#5588DD";
                string color2 = "#ccAA22";
                bool change = false;
                decimal monthpreis = 0;
                decimal allpreis = 0;
                for (int i = 0; i < table.Count; ++i)
                {

                    Dictionary<string, string> element = table[i];
                    DateTime timer = Convert.ToDateTime(element["Time"]);
                    if (timer.Month.ToString() != month)
                    {
                        change = !change;
                        month = timer.Month.ToString();
                        if (i != 0)
                        {
                            content += "<tr><td style=\"background-color:" + color + "\">Monthresult:</td>";
                            content += "<td style=\"background-color:" + color + "\"><u>" + monthpreis.ToString() + "</u></td></tr>";
                            content += "<tr><td>&nbsp;</td><td>&nbsp;</td></tr>";
                        }
                        monthpreis = 0;
                    }
                    if (change) { color = color1; }
                    else { color = color2; }

                    decimal preis = Convert.ToDecimal(element["Preis"]);
                    monthpreis += preis;
                    allpreis += preis;

                    content += "<tr><td style=\"background-color:" + color + "\">" + timer.ToString() + "</td>";
                    content += "<td style=\"background-color:" + color + "\">" + preis.ToString() + "</td></tr>";
                }
                content += "<tr><td style=\"background-color:" + color + "\">Monthresult:</td>";
                content += "<td style=\"background-color:" + color + "\"><u>" + monthpreis.ToString() + "</u></td></tr>";
                content += "<tr><td>&nbsp;</td><td>&nbsp;</td></tr>";
                monthpreis = 0;
                content += "<tr><td>Result all Positions:</td>";
                content += "<td><u>" + allpreis.ToString() + "</u></td></tr>";
                content += "<tr><td>&nbsp;</td><td>&nbsp;</td></tr>";
                content += "</table>";

                return this.GetInnerBlock(table.Count + " Positions", content);
            }
            else
            {
                return this.GetNotRightBlock();
            }
        }
        private string GetPayHistory(User user)
        {
            if (user.UserRight.allowposten)
            {
                String query = "Select * from T_ToPay where UserID='" + user.userid + "' order by Time desc";
                List<Dictionary<string, string>> table = _dbconn.GetResultList(query, null);

                string header = "ToPay History";
                string content = "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"100%\">";
                content += "<tr><td><u>Time</u></td><td><u>Pay (€)</u></td><td><u>Type</u></td></tr>";
                content += "<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>";

                string color = null;
                string color1 = "#5588DD";
                string color2 = "#ccAA22";
                string type = "paid";
                for (int i = 0; i < table.Count; ++i)
                {
                    Dictionary<string, string> element = table[i];
                    decimal pay = Convert.ToDecimal(element["pay"]);
                    if (pay < 0) { type = "transfer"; }
                    else { type = "paid"; }
                    if (i % 2 == 0) { color = color1; }
                    else { color = color2; }

                    content += "<tr><td style=\"background-color:" + color + "\">" + element["Time"] + "</td>";
                    content += "<td style=\"background-color:" + color + "\">" + pay.ToString() + "</td>";
                    content += "<td style=\"background-color:" + color + "\">" + type + "</td></tr>";

                    
                }

                content += "<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>";
                content += "</table>";

                return this.GetInnerBlock(header, content);
            }
            return this.GetNotRightBlock();
        }
        
        private string GetUserInHouse(User user)
        {
            if (user.UserRight.allowtime)
            {
                string content = "<br>";
                string query = "Select UserName,InHouse,AllowAdministration from VW_UserKonto where InHouse is not null order by UserName";
                int countonline = 0;
                List<Dictionary<string, string>> table = _dbconn.GetResultList(query, null);

                string admcolor = "#6699FF";
                for (int i = 0; i < table.Count; ++i)
                {
                    Dictionary<string, string> element = table[i];
                    bool admin=false;
                    if(!string.IsNullOrEmpty(element["AllowAdministration"]))
                        admin = Convert.ToBoolean(element["AllowAdministration"]);
                    if (Convert.ToBoolean(element["InHouse"]))
                    {
                        countonline++;
                        if (admin && user.UserRight.allowadmin)
                            content += "<img alt=\"\" src=\"images/online.png\" /><font color=" + admcolor + "> " + element["UserName"] + "</font><br>";
                        else
                        content += "<img alt=\"\" src=\"images/online.png\" /> " + element["UserName"] + "<br>";
                    }
                    else
                    {
                        if(admin && user.UserRight.allowadmin)
                            content += "<img alt=\"\" src=\"images/offline.png\" /><font color="+admcolor+"> " + element["UserName"] + "</font><br>";
                        else
                        content += "<img alt=\"\" src=\"images/offline.png\" /> " + element["UserName"] + "<br>";
                    }
                }
                string header = "User InHouse (" + countonline + ")";


                return "<br><br>"+this.GetMenuBlock(header, content, menublockid.blockcontentleft);
            }
            return null;
        }
        private string GetToPay(User user)
        {
            string payheader = "unpaid invoice";

            string rest = _user.rest.Replace(".", ",");
            if (Convert.ToDecimal(rest) < 0)
            {
                payheader = "Assets";
                rest = rest.Replace("-", "");
            }
            return this.GetMenuBlock(payheader, rest + " €", menublockid.blockcontentcenter);
        }
        private string GetAllPostCount(User user)
        {
            string pos = "0 Positions";
            if (!user.userid.Equals("-999"))
            {
                SqlDataReader sqldr = null;
                try
                {
                    sqldr = _dbconn.GetResult("Select count(PostenID) as anz from T_Posten where UserID='" + user.userid + "'", null);
                    while (sqldr.Read())
                    {
                        if (user.UserRight.allowposten)
                            pos = "<a href=startform.aspx?ID=" + user.userid + "&SessionID=" + Session["SessionID"] + "&posten>" + sqldr.GetValue(0).ToString() + " Positions</a>";
                        else { pos = sqldr.GetValue(0).ToString() + " Positions"; }
                    }
                }
                catch (Exception exp) { }
                finally
                {
                    if (sqldr != null) sqldr.Close();
                }
            }
            return this.GetMenuBlock("Count Positions", pos, menublockid.blockcontentcenter);
        }
        private string GetNotRightBlock()
        {
            return this.GetInnerBlock("Not Allow !", "You have not enough Rights to show this page!");
        }
        private string GetStartView()
        {
            return this.GetInnerBlock("Info", "Welcome to Snackboxx Web Application!");
        }
        private string GetGebBlock()
        {
            string header = "Birthday List";
            string content = "";
            DateTime datenow = DateTime.Now;
            DateTime date10 = DateTime.Now.AddDays(10);            
            string query = "Select UserName,Geburtstag from T_User where IsGebFree='True' order by Geburtstag";
            List<Dictionary<string, string>> table = _dbconn.GetResultList(query, null);
            for (int i = 0; i < table.Count; ++i)
            {
                Dictionary<string, string> element = table[i];
                if (!string.IsNullOrEmpty(element["Geburtstag"]))
                {
                    DateTime geb = Convert.ToDateTime(element["Geburtstag"]);
                    if (datenow.Month == geb.Month || date10.Month == geb.Month)
                    {
                        if (datenow.Day <= geb.Day && date10.Day >= geb.Day)
                        {
                            if (datenow.Day == geb.Day && datenow.Month == geb.Month)
                                content += "<u>Happy Birthday</u><br><b><i>" + element["UserName"] + "</i></b><br>";
                            else { content += element["UserName"] + " (" + geb.Day + "." + geb.Month + ")" + "<br>"; }
                        }
                    }
                } 
            }
            if (string.IsNullOrEmpty(content))
            {
                content = "No birthday today!";
            }
            return "<br><br>"+this.GetMenuBlock(header, content, menublockid.blockcontentcenter);
        }
       
        private string GetTimeBlock(User user)
        {            
            if (user.UserRight.allowtime)
            {
                TimeRegistration timereg = (TimeRegistration)LoadControl("Controls/TimeRegistration.ascx");
                timereg.SetParams(user,this._dbconn);                
                this.SetCenterControl(timereg);

                return null; 
            }
            return GetNotRightBlock();
              
              
        }
        private string GetUserConfig(User user)
        {
            if (user.UserRight.allowconfig)
            {
                UserConfig userconf = (UserConfig)LoadControl("Controls/UserConfig.ascx");
                userconf.SetParams(user, this._dbconn);
                this.SetCenterControl(userconf);

                return null;
            }
            return GetNotRightBlock();
        }
        #endregion        
    }
}
