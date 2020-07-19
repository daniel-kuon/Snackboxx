using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Core.Notifications
{
    public static class Mailings
    {
        private static bool _initiated = false;
        public static string SmtpServer { get; private set; }
        public static string MailAddress { get; private set; }
        public static string Password { get; private set; }

        public static void Init(string smtpServer, string mailAddress, string password)
        {
            SmtpServer = smtpServer;
            MailAddress = mailAddress;
            Password = password;
            _initiated = true;
        }

        public const string SnackboxUrl = "";

        public static void SendWelcomeMail()
        {
        }
    }
}