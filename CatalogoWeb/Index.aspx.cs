using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace CatalogoWeb
{
    public partial class Index : System.Web.UI.Page
    {

        public List<Articulo> listaArticulo { get; set; }       
        public List<Categoria> listaCategorias = new List<Categoria>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                listaArticulo = negocio.Listar();

                Session[Session.SessionID + "listaArticulo"] = listaArticulo;

            }
            catch (Exception)
            {
                Session["Error" + Session.SessionID] = "Error inesperado";
                Response.Redirect("Error.aspx"); 
            }
        }
    }
}