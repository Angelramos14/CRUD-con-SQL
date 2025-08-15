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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Peliculas p = new Peliculas();
            p.Nombre = txtNombre.Text;
            p.Director = txtDirector.Text;
            p.FechaLanzamiento = dtpFecha.Value;
            p.Id = int.Parse(dgvPeliculas.CurrentRow.Cells[0].Value.ToString());

            if (p.ActualizarPeliculas() == true)
            {
                MostrarPeliculas();
            }
            else
            {
                MessageBox.Show("Hubo un error", "Error");
            }
        }
     

        private void dgvPeliculas_DoubleClick(object sender, EventArgs e)
        {
            txtNombre.Text = dgvPeliculas.CurrentRow.Cells[1].Value.ToString();
            txtDirector.Text = dgvPeliculas.CurrentRow.Cells[2].Value.ToString();
            dtpFecha.Value = DateTime.Parse(dgvPeliculas.CurrentRow.Cells[3].Value.ToString());
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Peliculas peliculaEliminar = new Peliculas();
            int id = int.Parse(dgvPeliculas.CurrentRow.Cells[0].Value.ToString());
            string registroAEliminar = dgvPeliculas.CurrentRow.Cells[1].Value.ToString();
            DialogResult respuesta = MessageBox.Show("Quieres eliminar este registro?\n" + registroAEliminar, "Advertencia eliminmaras un registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
