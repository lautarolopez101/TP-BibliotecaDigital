using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_BibliotecaDigital.Lector
{
    public partial class FRMLector : Form
    {
        public FRMLector()
        {
            InitializeComponent();
        }

        private void FRMLector_Load(object sender, EventArgs e)
        {
            FRMConsultaLibros consultalibros = new FRMConsultaLibros();
            consultalibros.TopLevel = false;
            consultalibros.FormBorderStyle = FormBorderStyle.None;
            consultalibros.Dock = DockStyle.Fill;
            consultalibros.MdiParent = this;
            consultalibros.Show();
        }

        private void consultaDeLibrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMConsultaLibros consultalibros = new FRMConsultaLibros();
            consultalibros.TopLevel = false;
            consultalibros.FormBorderStyle = FormBorderStyle.None;
            consultalibros.Dock = DockStyle.Fill;
            consultalibros.MdiParent = this;
            consultalibros.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
