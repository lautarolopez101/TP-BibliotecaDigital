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

namespace TP_BibliotecaDigital
{
    public partial class FRMSignup : Form
    {
        public FRMSignup()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(txtUser.Text) || !string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    string name = txtName.Text;
                    string lastname = txtLastName.Text;
                    string mail = txtMail.Text;
                    string user = txtUser.Text;
                    string password = txtPassword.Text;
                    bool rol = CHBXRol.Checked;
                    if (rol)
                    {
                        CLSUser newuser = new CLSUser(user, password, name, lastname, mail,rol);
                        using (StreamWriter sw = new StreamWriter("users.csv", true))
                        {
                            sw.WriteLine($"{newuser.User},{newuser.Password},{newuser.Name},{newuser.LastName},{newuser.Mail},{newuser.Rol}");
                        }
                        MessageBox.Show("Administrator created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else if (!rol)
                    {
                        CLSUser newuser = new CLSUser(user, password, name, lastname, mail, rol);
                        using (StreamWriter sw = new StreamWriter("users.csv", true))
                        {
                            sw.WriteLine($"{newuser.User},{newuser.Password},{newuser.Name},{newuser.LastName},{newuser.Mail},{newuser.Rol}");
                        }
                        MessageBox.Show("Lector created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                }
                else                // Check if any of the fields are empty
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                txtLastName.Clear();
                txtMail.Clear();
                txtName.Clear();
                txtPassword.Clear();
                txtUser.Clear();
                txtPassword_Confirmed.Clear();
                txtName.Focus();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtLastName.Clear();
            txtMail.Clear();
            txtName.Clear();
            txtPassword.Clear();
            txtUser.Clear();
            txtPassword_Confirmed.Clear();
            CHBXRol.Checked = false;
            this.Close();
        }
    }
}
