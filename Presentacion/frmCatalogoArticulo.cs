using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Presentacion
{
    public partial class frmCatalogoArticulo : Form
    {

        private List<Articulo> lista;
        public frmCatalogoArticulo()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            cargarGrilla();

        }

        private void cargarGrilla()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            
            try
            {
                lista = negocio.Listar();
                dgvArticulos.DataSource = lista;
                dgvArticulos.Columns[0].Visible = false;
                dgvArticulos.Columns[3].Visible = false;
                dgvArticulos.Columns[6].Visible = false;
                dgvArticulos.Columns[7].Visible = false;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo alta = new frmAltaArticulo();
            alta.ShowDialog();
            cargarGrilla();
        }

        private void btnModificar_Click(object sender, EventArgs e) 
        {
                Articulo modificar;
                modificar = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                frmAltaArticulo frmModificar = new frmAltaArticulo(modificar);
                frmModificar.ShowDialog();
                cargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            try
            {
                DialogResult dialogResult = MessageBox.Show("¿Estas seguro de eliminar el articulo seleccionado?", "Confirmar",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dialogResult == DialogResult.Yes)
                {
                    int id = ((Articulo)dgvArticulos.CurrentRow.DataBoundItem).ID;
                    negocio.Eliminar(id);
                    cargarGrilla();

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }



        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            try
            {
                if (txtBusqueda.Text == "")
                {
                    listaFiltrada = lista;
                }
                else
                {

                    listaFiltrada = lista.FindAll(k => k.Codigo.ToLower().Contains(txtBusqueda.Text.ToLower()) || k.Nombre.ToLower().Contains(txtBusqueda.Text.ToLower()) || (k.Marca != null ? k.Marca.Nombre.ToLower().Contains(txtBusqueda.Text.ToLower()) : k.Nombre.Contains("")) || (k.Categoria != null ? k.Categoria.Nombre.ToLower().Contains(txtBusqueda.Text.ToLower()) : k.Nombre.Contains("") ) && k.Categoria != null );

                }
                dgvArticulos.DataSource = listaFiltrada;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            

            Articulo articuloSeleccionado;
            
            articuloSeleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            frmDetallesArticulo frmVerDetalle = new frmDetallesArticulo(articuloSeleccionado);
            frmVerDetalle.ShowDialog();
            

        }
    }
}
