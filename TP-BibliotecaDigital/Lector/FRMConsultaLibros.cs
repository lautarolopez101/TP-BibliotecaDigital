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

namespace TP_BibliotecaDigital.Lector
{
    public partial class FRMConsultaLibros : Form
    {
        public FRMConsultaLibros()
        {
            InitializeComponent();
        }

        CLSBook book = new CLSBook();

        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                if (!string.IsNullOrEmpty(txtTitle.Text))
                {
                    book.Buscartitle(txtTitle.Text,dataGridView1);
                }
                else
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        Form1 formulario= new Form1();
        
        private void btnPedirPrestado_Click(object sender, EventArgs e)
        {

            // Verificar que se haya seleccionado una fila
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un libro.");
                return;
            }

          try
            {
              if(dataGridView1.SelectedRows.Count > 0)
                {
                    CLSUser usuario = CLSCurrentSession.CurrentUser;
                    CLSUser usuariopidiendoprestado = new CLSUser(usuario.Name,usuario.LastName,)
                } 


            }
            catch ( Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                txtTitle.Text = fila.Cells[0].Value.ToString();
                txtAuthor.Text = fila.Cells[1].Value.ToString();
            }
        }
    }
}
