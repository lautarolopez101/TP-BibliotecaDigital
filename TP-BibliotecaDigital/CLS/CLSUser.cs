using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public string LibroPrestado { get; set; }

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

        public CLSUser(string name, string lastname ,string libroprestado)
        {
            Name = name;
            LastName = lastname;
            LibroPrestado = libroprestado;
          
        }

        public List<CLSUser> listusers = new List<CLSUser>();
        public void Cargarlista(DataGridView dgv)
        {
            listusers.Clear();

            try
            {

                using (StreamReader sr = new StreamReader("users.csv"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var data = line.Split(',');
                        CLSUser user = new CLSUser(data[0], data[1], data[2], data[3], data[4], Convert.ToBoolean(data[5]) );
                        listusers.Add(user);
                        dgv.Rows.Add(data[0], data[1], data[2], data[3], data[4], Convert.ToBoolean(data[5]));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void Modificar(int index,string user,string password , string name,string lastname ,string mail, bool rol)
        {
            listusers[index].Name = name;
            listusers[index].LastName = lastname;
            listusers[index].Mail = mail;
            listusers[index].User = user;
            listusers[index].Password = password;
            listusers[index].Rol = rol;
            using (StreamWriter sw = new StreamWriter("books.csv", false))
            {
                foreach (var user1 in listusers)
                {
                    sw.WriteLine($"{user1.User},{user1.Password},{user1.Name},{user1.LastName},{user1.Mail},{user1.Rol}");
                }
            }
        }

        

    }
}
