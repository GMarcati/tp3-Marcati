using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {

        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.SetearQuery("Select A.Id ,A.Codigo, A.Nombre, A.Descripcion, M.Id AS idMarca, M.Descripcion AS Marca, C.Id AS idCategoria ,C.Descripcion AS Categoria, A.ImagenUrl, A.Precio " +
                                "From ARTICULOS AS A                                " +
                                "Left Join CATEGORIAS AS C ON A.IdCategoria = C.Id  " +
                                "Left Join MARCAS AS M ON A.IdMarca = M.Id ");
                datos.EjecutarLector();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.ID = datos.Lector.GetInt32(0);
                    aux.Codigo = datos.Lector.GetString(1);
                    aux.Nombre = datos.Lector.GetString(2);
                    aux.Descripcion = datos.Lector.GetString(3);


                    if (!Convert.IsDBNull(datos.Lector["idMarca"]))
                    {
                        aux.Marca = new Marca();
                        aux.Marca.ID = (int)datos.Lector["idMarca"];
                        aux.Marca.Nombre = (string)datos.Lector["Marca"];

                    }


                    if (!Convert.IsDBNull(datos.Lector["idCategoria"]))
                    {
                        aux.Categoria = new Categoria();
                        aux.Categoria.ID = (int)datos.Lector["idCategoria"];
                        aux.Categoria.Nombre = (string)datos.Lector["Categoria"];

                    }

                    aux.ImagenURL = datos.Lector.GetString(8);
                    aux.Precio = datos.Lector.GetDecimal(9);
                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }

        }
        public void Agregar(Articulo nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            


            try
            {
                conexion.ConnectionString = "data source= DESKTOP-GTFEEVH; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Insert Into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio) VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio) ";
                comando.Parameters.AddWithValue("@Codigo", nuevo.Codigo);
                comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", nuevo.Descripcion);
                comando.Parameters.AddWithValue("@IdMarca", nuevo.Marca.ID.ToString());
                comando.Parameters.AddWithValue("@IdCategoria", nuevo.Categoria.ID.ToString());
                comando.Parameters.AddWithValue("@ImagenUrl", nuevo.ImagenURL);
                comando.Parameters.AddWithValue("@Precio", nuevo.Precio);
                comando.Connection = conexion;

                conexion.Open();
                comando.ExecuteNonQuery();





            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conexion.Close();

            }
        }
        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearQuery("DELETE From ARTICULOS WHERE Id=" + id);
                datos.EjecturAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetearQuery("UPDATE ARTICULOS SET Codigo=@Codigo, Nombre=@Nombre, Descripcion=@Descripcion, IdMarca=@IdMarca, IdCategoria=@IdCategoria, ImagenUrl=@ImagenUrl, Precio=@Precio  WHERE Id=@Id");
                datos.AgregarParametro("@Id", articulo.ID);
                datos.AgregarParametro("@Codigo", articulo.Codigo);
                datos.AgregarParametro("@Nombre", articulo.Nombre);
                datos.AgregarParametro("@Descripcion", articulo.Descripcion);
                datos.AgregarParametro("@IdMarca", articulo.Marca.ID);
                datos.AgregarParametro("@IdCategoria", articulo.Categoria.ID);
                datos.AgregarParametro("@ImagenUrl", articulo.ImagenURL);
                datos.AgregarParametro("@Precio", articulo.Precio);
                datos.EjecturAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
