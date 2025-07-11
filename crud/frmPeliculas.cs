using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modelos;

namespace crud
{
    public partial class frmPeliculas : Form
    {
        public frmPeliculas()
        {
            InitializeComponent();
        }

        private void frmPeliculas_Load_1(object sender, EventArgs e)
        {
            MostrarPeliculas();
        }
        private void MostrarPeliculas()
        {
            // Cargar las peliculas al DataGridView
            dgvPeliculas.DataSource = null;
            dgvPeliculas.DataSource = Peliculas.CargarPeliculas();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Peliculas p = new Peliculas();
            p.Nombre = txtNombre.Text;
            p.FechaLanzamiento =dtpFecha.Value;
            p.Director = txtDirector.Text;

            p.InsertarPeliculas();
            MostrarPeliculas();
        }
    }
}
