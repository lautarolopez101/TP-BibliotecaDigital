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

namespace TP_BibliotecaDigital.Administrador
{
    public partial class FRMGestion_Libros : Form
    {
        public FRMGestion_Libros()
        {
            InitializeComponent();
        }


        private void FRMGestion_Libros_Load(object sender, EventArgs e)
        {
            book.Cargarlista(dataGridView1);
        }


        public CLSBook book = new CLSBook();
        private List<CLSBook> listbooks = new List<CLSBook>();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtISBN.Text) && !string.IsNullOrEmpty(txtAuthor.Text) && !string.IsNullOrEmpty(txtTitle.Text))
                {
                    CLSBook newbook = new CLSBook(txtTitle.Text, txtAuthor.Text,Convert.ToInt16(txtYear.Text) ,Convert.ToInt32(txtISBN.Text));
                    using (StreamWriter sw = new StreamWriter("books.csv", true))
                    {
                        sw.WriteLine($"{newbook.Title},{newbook.Author},{newbook.Year},{newbook.ISBN}");
                    }
                    MessageBox.Show("Book added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    book.Cargarlista(dataGridView1);
                    return;
                }
                else
                {
                    MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                txtAuthor.Clear();
                txtISBN.Clear();
                txtTitle.Clear();
                txtTitle.Focus();

            }
            catch (Exception ex)
            {
                 MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    fila.Cells[0].Value = txtTitle.Text;
                    fila.Cells[1].Value = txtAuthor.Text;
                    fila.Cells[2].Value = txtYear.Text;
                    fila.Cells[3].Value = txtISBN.Text;
                    book.Modificar(index,txtTitle.Text,txtAuthor.Text,Convert.ToInt16(txtYear.Text),Convert.ToInt32(txtISBN.Text));
                    book.Cargarlista(dataGridView1);

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 )
            {
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                txtTitle.Text = fila.Cells[0].Value.ToString();
                txtAuthor.Text = fila.Cells[1].Value.ToString();
                txtYear.Text = fila.Cells[2].Value.ToString();
                txtISBN.Text = fila.Cells[3].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    listbooks.RemoveAt(dataGridView1.CurrentRow.Index);
                    MessageBox.Show("Book are deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
