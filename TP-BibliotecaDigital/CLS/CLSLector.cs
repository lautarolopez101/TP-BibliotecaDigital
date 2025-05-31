using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_BibliotecaDigital.CLS;

namespace TP_BibliotecaDigital
{
    public class CLSLector : CLSUser
    {
        public CLSLector(string user, string password,string name,string lastname, string mail,bool rol)
        {
            User = user;
            Password = password;
            Name = name;
            LastName = lastname;
            Mail = mail;
            Rol = rol;
        }
    }
}
