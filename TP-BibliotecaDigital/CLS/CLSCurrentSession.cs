using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TP_BibliotecaDigital.CLS
{
    public static class CLSCurrentSession
    {
        public static CLSUser CurrentUser { get; private set; }

        public static void Login(CLSUser user)
        {
            CurrentUser = user;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }

        public static bool IsLoggedIn => CurrentUser != null;
    }
}
