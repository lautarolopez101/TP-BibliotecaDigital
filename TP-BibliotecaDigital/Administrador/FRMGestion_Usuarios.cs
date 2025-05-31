using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_BibliotecaDigital.CLS;

namespace TP_BibliotecaDigital.Administrador
{
    public partial class FRMGestion_Usuarios : Form
    {
        public FRMGestion_Usuarios()
        {
            InitializeComponent();
        }
        CLSUser user = new CLSUser();
        private List<CLSUser> listusers = new List<CLSUser>();

        private void FRMGestion_Usuarios_Load(object sender, EventArgs e)
        {
            user.Cargarlista(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                txtUser.Text = fila.Cells[0].Value.ToString();
                txtPassword.Text = fila.Cells[1].Value.ToString();
                txtName.Text = fila.Cells[2].Value.ToString();
                txtLastName.Text = fila.Cells[3].Value.ToString();
                txtMail.Text = fila.Cells[4].Value.ToString();
                CHBXAdministrator.Checked = Convert.ToBoolean(fila.Cells[5].Value);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    DataGridViewRow fila = dataGridView1.CurrentRow;
                    int index = fila.Index;

                    // Actualizar datos en la fila seleccionada
                    fila.Cells[0].Value = txtUser.Text;
                    fila.Cells[1].Value = txtPassword.Text;
                    fila.Cells[2].Value = txtName.Text;
                    fila.Cells[3].Value = txtLastName.Text;
                    fila.Cells[4].Value = txtMail.Text;
                    fila.Cells[5].Value = Convert.ToBoolean(CHBXAdministrator.Text);
                    user.Modificar(index, txtUser.Text, txtPassword.Text, txtName.Text, txtLastName.Text,txtMail.Text,Convert.ToBoolean(CHBXAdministrator.Text));
                    user.Cargarlista(dataGridView1);

                }

                else
                {
                    MessageBox.Show("Please select a book to modify.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    listusers.RemoveAt(dataGridView1.CurrentRow.Index);
                    MessageBox.Show("User are deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("Please select a User to modify.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
