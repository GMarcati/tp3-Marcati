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
    public partial class frmDetallesArticulo : Form
    {
        private Articulo articulo = null;
        
        public frmDetallesArticulo()
        {
            InitializeComponent();
        }
        public frmDetallesArticulo(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;

        }

        private void frmDetallesArticulo_Load(object sender, EventArgs e)
        {

            try
            {

                if (articulo != null)
                {
                    Text = "Detalles Articulo";
                    
                    txtID.Text = articulo.ID.ToString();
                    txtCodigo.Text = articulo.Codigo;
                    txtNombre.Text = articulo.Nombre;
                    txtDescripcion.Text = articulo.Descripcion;
                    if (articulo.Marca != null)
                        txtMarca.Text = articulo.Marca.Nombre;
                    if (articulo.Categoria != null)
                        txtCategoria.Text = articulo.Categoria.Nombre;
                    txtImagenURL.Text = articulo.ImagenURL;
                    string precio = Convert.ToString(articulo.Precio);
                    txtPrecio.Text = precio;


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void btnVerImagen_Click(object sender, EventArgs e)
        {

            try
            {
                picArticulo.Load(txtImagenURL.Text);
            }
            catch (Exception)
            {

                MessageBox.Show("La Imagen URL no es valida.","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            
        }
    }
}
