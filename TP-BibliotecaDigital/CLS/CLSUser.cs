using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_BibliotecaDigital.CLS
{
    public class CLSUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public bool Rol { get; set; }

        public CLSUser()
        {
            
        }

        public CLSUser(string user, string password, string name, string lastname, string mail,bool rol)
        {
            Name = name;
            LastName = lastname;
            Mail = mail;
            User = user;
            Password = password;
            Rol = rol;
        }
    }
}
