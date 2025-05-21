using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_BibliotecaDigital.Administrador;

namespace TP_BibliotecaDigital
{
    public partial class FRMAdministrador : Form
    {
        public FRMAdministrador()
        {
            InitializeComponent();
        }

        private void gestionDeLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMGestion_Libros gestionlibros = new FRMGestion_Libros();
            gestionlibros.MdiParent = this;
            gestionlibros.TopLevel = false;
            gestionlibros.FormBorderStyle = FormBorderStyle.None;
            gestionlibros.Dock = DockStyle.Fill;
            gestionlibros.Show();
        }

        private void gestionDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultaDeLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
