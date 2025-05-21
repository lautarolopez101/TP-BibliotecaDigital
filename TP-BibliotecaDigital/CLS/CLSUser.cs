using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
                        CLSUser user = new CLSUser(data[0], data[1], data[2], data[3], data[4], Convert.ToBoolean(data[5]));
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

        public void Modificar(int index,string name, string lastname, string mail, string user, string password)
        {
            listusers[index].Name = name;
            listusers[index].LastName = lastname;
            listusers[index].Mail = mail;
            listusers[index].User = user;
            listusers[index].Password = password;
            using (StreamWriter sw = new StreamWriter("books.csv", false))
            {
                foreach (var book in listusers)
                {
                    sw.WriteLine($"{user.}");
                }
            }
        }


    }
}
