using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snackboxx.Core
{
    public struct UserCode
    {
        public string CodeID;
        public string UserID;
        public string userCode;
        public string Preis;
        public bool Issnackcode;

        public override string ToString()
        {
            if (Issnackcode)
                return userCode + "; " + Preis + " €";
            else
                return userCode;
        }
    }

    public struct UserRight
    {
        public string userRightID;
        public string userRight;
        public bool globalMail;
        public string mail;
        public bool allowposten;
        public bool allowtime;
        public bool allowconfig;
        public bool allowadmin;

        public override string ToString()
        {
            return userRight;
        }
    }

    public struct User
    {
        public string userid;
        public string username;
        public string loginname;
        public List<UserCode> usercodes;
        public string rest;
        public string Password;
        public string EMail;
        public string UserRightID;
        public UserRight UserRight;
        public string TimeKontoID;
        public string betragsLimit;
        public string nextBetragsLimit;


        public override string ToString()
        {
            return username;
        }
    }

    public class UserClass
    {
        

    }
}
