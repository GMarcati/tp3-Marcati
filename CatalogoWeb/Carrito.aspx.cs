using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace CatalogoWeb
{
    public partial class Carrito : System.Web.UI.Page
    {
        public List<Dominio.Carrito> listaCarrito { get; set; }

        public Dominio.Carrito carrito = new Dominio.Carrito();

        public decimal PrecioTotal=0;
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                //PrecioTotal = Convert.ToDecimal(Session[Session.SessionID + "PrecioTotal"]);

                listaCarrito = (List<Dominio.Carrito>)Session[Session.SessionID + "listaCarrito"];
                if (listaCarrito == null)
                    listaCarrito = new List<Dominio.Carrito>();

                var artQuitar = Request.QueryString["idQuitar"];
                if (artQuitar != null)
                {


                    Dominio.Carrito articuloQuitar = listaCarrito.Find(J => J.articulo.ID == int.Parse(artQuitar));

                    listaCarrito.Remove(articuloQuitar);

                        Session[Session.SessionID + "listaCarrito"] = listaCarrito;

                    foreach (var item in listaCarrito)
                    {
                        PrecioTotal = item.articulo.Precio - PrecioTotal;
                        
                    }
                    



                }
                else if (Request.QueryString["idart"] != null)
                {

                    //obtengo lista original (el listado completo)
                    List<Articulo> listaOriginal = (List<Articulo>)Session[Session.SessionID + "listaArticulo"];


                    var artSeleccionado = Convert.ToInt32(Request.QueryString["idart"]);
                    Articulo articulo = listaOriginal.Find(J => J.ID == artSeleccionado);

                    Dominio.Carrito auxCarrito = listaCarrito.Find(B => B.articulo.ID == articulo.ID);                                

                    if (auxCarrito == null)
                    {
                        foreach (var item in listaCarrito)
                        {
                            PrecioTotal += item.articulo.Precio;
                            
                        }
                        

                        carrito.articulo = articulo;
                        carrito.Cantidad++;
                        PrecioTotal += carrito.articulo.Precio;
                        listaCarrito.Add(carrito);
                        Session[Session.SessionID + "listaCarrito"] = listaCarrito;

                    }


                }


                Session[Session.SessionID + "PrecioTotal"] = PrecioTotal;

            }
            catch (Exception)
            {
                Session["Error" + Session.SessionID] = "Error en el carrito";
                Response.Redirect("Error.aspx");
            }
            

        }

    }
}
