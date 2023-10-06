using CarpinteriaApp.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.datos
{
    public class ProductoDao : IDAOProducto
    {
        public bool Crear(Presupuesto presupuesto)
        {
            {
                bool ok = true;
                SqlConnection cnn = HelperDB.ObtenerInstancia().ObtenerConexion();
                SqlTransaction t = null;
                SqlCommand cmd = new SqlCommand();
                try
                {
                    cnn.Open();
                    t = cnn.BeginTransaction();
                    cmd.Connection = cnn;
                    cmd.Transaction = t;
                    cmd.CommandText = "SP_INSERTAR_MAESTRO";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cliente", presupuesto.Cliente);
                    cmd.Parameters.AddWithValue("@dto", presupuesto.Descuento);
                    cmd.Parameters.AddWithValue("@total", presupuesto.CalcularTotalConDescuento());

                    //parámetro de salida:
                    SqlParameter pOut = new SqlParameter();
                    pOut.ParameterName = "@presupuesto_nro";
                    pOut.DbType = DbType.Int32;
                    pOut.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(pOut);
                    cmd.ExecuteNonQuery();

                    int presupuestoNro = (int)pOut.Value;

                    SqlCommand cmdDetalle;
                    int detalleNro = 1;
                    foreach (DetallePresupuesto item in presupuesto.Detalles)
                    {
                        cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t);
                        cmdDetalle.CommandType = CommandType.StoredProcedure;
                        cmdDetalle.Parameters.AddWithValue("@presupuesto_nro", presupuestoNro);
                        cmdDetalle.Parameters.AddWithValue("@detalle", detalleNro);
                        cmdDetalle.Parameters.AddWithValue("@id_producto", item.Producto.ProductoNro);
                        cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                        cmdDetalle.ExecuteNonQuery();

                        detalleNro++;
                    }
                    t.Commit();
                }

                catch (Exception)
                {
                    if (t != null)
                        t.Rollback();
                    ok = false;
                }

                finally
                {
                    if (cnn != null && cnn.State == ConnectionState.Open)
                        cnn.Close();
                }

                return ok;
            }
        }

        public int ProximosPresupuestos()
        {
            SqlConnection cnn = HelperDB.ObtenerInstancia().ObtenerConexion();

            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SP_PROXIMO_ID";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pOut = new SqlParameter();
            pOut.ParameterName = "@next";
            pOut.SqlDbType = SqlDbType.Int;
            pOut.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pOut);
            cmd.ExecuteNonQuery();

            cnn.Close();
            return (int)pOut.Value;

        }

        public List<Producto> TraerProductos()
        {
            List<Producto> lst = new List<Producto>();
            DataTable t = HelperDB.ObtenerInstancia().Consultar("SP_CONSULTAR_PRODUCTOS");

            Producto aux = null;
            foreach (DataRow row in t.Rows)
            {
                aux = new Producto();
                aux.ProductoNro = int.Parse(row["id_producto"].ToString());
                aux.Nombre = row["n_producto"].ToString();
                aux.Precio = float.Parse(row["precio"].ToString());
                aux.Activo = row["activo"].ToString().Equals("1");
                lst.Add(aux);
            }
            return lst;

        }
    }
}
