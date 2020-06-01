using System;
using System.Collections.Generic;
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
    public partial class frmAltaArticulo : Form
    {
        private Articulo articulo = null;
        public frmAltaArticulo()
        {
            InitializeComponent();
        }
        public frmAltaArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }
        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {

            CategoriaNegocio categoria = new CategoriaNegocio();
            MarcaNegocio marca = new MarcaNegocio();


            try
            {

                
                cboMarca.DataSource = marca.Listar();
                cboMarca.ValueMember = "ID";
                cboMarca.DisplayMember = "Nombre";
                
                cboCategoria.DataSource = categoria.Listar();
                cboCategoria.ValueMember = "ID";
                cboCategoria.DisplayMember = "Nombre";

                if (articulo != null)
                {
                    Text = "Modificar Articulo";
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    if (articulo.Marca != null)
                        cboMarca.SelectedValue = articulo.Marca.ID;
                    if (articulo.Categoria != null)
                        cboCategoria.SelectedValue = articulo.Categoria.ID;
                    txtImagenURL.Text = articulo.ImagenURL;
                    string precio=Convert.ToString(articulo.Precio);
                    txtPrecio.Text = precio;
                    

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            ArticuloNegocio negocio = new ArticuloNegocio();
      

            try
            {

                if (articulo == null)
                    articulo = new Articulo();
                
                if(txtCodigo.Text == "" || txtDescripcion.Text == "" || txtImagenURL.Text == "" || txtNombre.Text == "" || txtPrecio.Text == "")
                {
                    MessageBox.Show("Faltan llenar campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                } else
                {
                    articulo.Codigo = txtCodigo.Text.Trim();
                    articulo.Nombre = txtNombre.Text.Trim();
                    articulo.Descripcion = txtDescripcion.Text.Trim();
                    articulo.Marca = (Marca)cboMarca.SelectedItem;
                    articulo.Categoria = (Categoria)cboCategoria.SelectedItem;
                    articulo.ImagenURL = txtImagenURL.Text.Trim();
                    if (txtPrecio.Text != "")
                        articulo.Precio = Convert.ToDecimal(txtPrecio.Text.Trim());

                    if (articulo.ID != 0)
                        negocio.Modificar(articulo);
                    else
                        negocio.Agregar(articulo);
                    Dispose();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && (e.KeyChar != (char)Keys.Back) && !(e.KeyChar == ','))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
            }

        }
    }
}
