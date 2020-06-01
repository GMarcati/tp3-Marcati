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
        //public List<Articulo> listaCarrito { get; set; }
        public List<Dominio.Carrito> listaCarrito { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (listaCarrito == null)
                    listaCarrito = new List<Dominio.Carrito>();
                var artQuitar = Request.QueryString["idQuitar"];
                if (artQuitar != null)
                {
                    Dominio.Carrito articuloQuitar = listaCarrito.Find(J => J.ID == int.Parse(artQuitar));
                    listaCarrito.Remove(articuloQuitar);
                    Session[Session.SessionID + "listaCarrito"] = listaCarrito;
                }
                else if (Request.QueryString["idart"] != null)
                {

                    //obtengo lista original (el listado completo)
                    List<Articulo> listaOriginal = (List<Articulo>)Session[Session.SessionID + "listaArticulo"];
                    var artSeleccionado = Convert.ToInt32(Request.QueryString["idart"]);
                    Articulo articulo = listaOriginal.Find(J => J.ID == artSeleccionado);

                    Dominio.Carrito carrito = new Dominio.Carrito();

                    carrito.ID = articulo.ID;
                    carrito.Nombre = articulo.Nombre;
                    carrito.Precio = articulo.Precio;
                    carrito.Cantidad = 1;
                    
                    listaCarrito.Add(carrito);
                    Session[Session.SessionID + "listaCarrito"] = listaCarrito;

                }




            }
            catch (Exception ex)
            {
                Session["Error" + Session.SessionID] = "Aun no tenes productos en el carrito";
                Response.Redirect("Error.aspx");
            }


        }

    }
}

//listaCarrito = (List<Articulo>) Session[Session.SessionID + "listaCarrito"];

//var artQuitar = Request.QueryString["idQuitar"];
//                if (artQuitar != null)
//                {
//                    Articulo articuloQuitar = listaCarrito.Find(J => J.ID == int.Parse(artQuitar));
//listaCarrito.Remove(articuloQuitar);
//                    Session[Session.SessionID + "listaCarrito"] = listaCarrito;
//                }
//                else if (Request.QueryString["idart"] != null)
//                {
//                    //obtengo lista original (el listado completo)
//                    List<Articulo> listaOriginal = (List<Articulo>)Session[Session.SessionID + "listaArticulo"];
//var artSeleccionado = Convert.ToInt32(Request.QueryString["idart"]);
//Articulo articulo = listaOriginal.Find(J => J.ID == artSeleccionado);

//                    //obtengo la lista de carrito de la session
//                    if (listaCarrito == null)
//                        listaCarrito = new List<Articulo>();

//                    listaCarrito.Add(articulo);
//                    Session[Session.SessionID + "listaCarrito"] = listaCarrito;

//                }

//listaCarrito = (List<Dominio.Carrito>)Session[Session.SessionID + "listaCarrito"];


//listaCarrito = (List<Articulo>) Session[Session.SessionID + "listaCarrito"];

//var artQuitar = Request.QueryString["idQuitar"];
//                if (artQuitar != null)
//                {
//                    Articulo articuloQuitar = listaCarrito.Find(J => J.ID == int.Parse(artQuitar));
//listaCarrito.Remove(articuloQuitar);
//                    Session[Session.SessionID + "listaCarrito"] = listaCarrito;
//                }
//                else if (Request.QueryString["idart"] != null)
//                {
//                    //obtengo lista original (el listado completo)
//                    List<Articulo> listaOriginal = (List<Articulo>)Session[Session.SessionID + "listaArticulo"];
//var artSeleccionado = Convert.ToInt32(Request.QueryString["idart"]);
//Articulo articulo = listaOriginal.Find(J => J.ID == artSeleccionado);

//                    //obtengo la lista de carrito de la session
//                    if (listaCarrito == null)
//                        listaCarrito = new List<Articulo>();

//                    listaCarrito.Add(articulo);
//                    Session[Session.SessionID + "listaCarrito"] = listaCarrito;

//                }




//prueba2

//listaCarrito = (List<Articulo>) Session[Session.SessionID + "listaCarrito"];

//var artQuitar = Request.QueryString["idQuitar"];
//                if (artQuitar != null)
//                {
//                    Articulo articuloQuitar = listaCarrito.Find(J => J.ID == int.Parse(artQuitar));
//listaCarrito.Remove(articuloQuitar);
//                    Session[Session.SessionID + "listaCarrito"] = listaCarrito;
//                }
//                else if (Request.QueryString["idart"] != null)
//                {
//                    //obtengo lista original (el listado completo)
//                    List<Articulo> listaOriginal = (List<Articulo>)Session[Session.SessionID + "listaArticulo"];
//var artSeleccionado = Convert.ToInt32(Request.QueryString["idart"]);
//Articulo articulo = listaOriginal.Find(J => J.ID == artSeleccionado);




//                    //obtengo la lista de carrito de la session
//                    if (listaCarrito == null)
//                        listaCarrito = new List<Articulo>();

//                    listaCarrito.Add(articulo);
//                    Session[Session.SessionID + "listaCarrito"] = listaCarrito;

//                }