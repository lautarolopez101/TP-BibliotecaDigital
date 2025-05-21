using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_BibliotecaDigital.CLS;
using TP_BibliotecaDigital.Lector;

namespace TP_BibliotecaDigital
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public CLSUser userlogin { get; private set; }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string user = txtUser.Text;
                string password = txtPassword.Text;
                bool usernotfound = false;
                bool rol = false;
                if (!string.IsNullOrWhiteSpace(user) && !string.IsNullOrWhiteSpace(password))
                {
                    
                    foreach (var line in File.ReadLines("users.csv"))
                    {
                        var data = line.Split(',');

                        if (data[0] == user && data[1] == password)
                        {
                            userlogin = new CLSUser(
                                data[0], data[1], //User and Password
                                data[2], data[3], // Name and LastName
                                data[4], bool.Parse(data[5])); // Mail and Rol
                            rol = bool.Parse(data[5]);
                            usernotfound = true;
                            break;
                        }
                    }

                    if (usernotfound)
                    {
                        if (rol)
                        {
                            FRMAdministrador admin = new FRMAdministrador();
                            admin.ShowDialog();
                        }
                        else if(!rol)
                        {
                            FRMLector lector = new FRMLector();
                            lector.ShowDialog();
                        }
                    }
                    else if (!usernotfound)
                    {
                        MessageBox.Show("Cannot Found the User.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                            txtPassword.Clear();
                            txtUser.Clear();
                            txtUser.Focus();
                }
                else
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            FRMSignup signup = new FRMSignup();
            signup.ShowDialog();

        }
    }
}
