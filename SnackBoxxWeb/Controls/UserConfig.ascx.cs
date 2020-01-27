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
namespace SnackBoxxWeb.Controls
{
    public partial class UserConfig : System.Web.UI.UserControl
    {
        private User _user;
        private DBConnection _dbconn;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetParams(User user, DBConnection dbconn)
        {
            _user = user;
            _dbconn = dbconn;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.ToString();
        }
    }
}