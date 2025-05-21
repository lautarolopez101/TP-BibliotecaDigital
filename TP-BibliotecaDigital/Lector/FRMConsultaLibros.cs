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

    }
}
