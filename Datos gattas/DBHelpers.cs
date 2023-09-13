using CarpinteriaApp_1w3.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp_1w3.datos
{
    internal class DBHelper
    {
        private SqlConnection cnn;
        public DBHelper()
        {
            cnn = new SqlConnection(@"Data Source=LAPTOP-4G4CHMLJ\SQLEXPRESS;Initial Catalog=Carpinteria_2023;Integrated Security=True");
        }

        public int ProximoPresupuesto()
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_PROXIMO_ID";
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@next";
            param.SqlDbType = SqlDbType.Int;
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();
            cnn.Close();
            return (int)param.Value;
        }

        public DataTable Consultar(string sp)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;
            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();
            return tabla;
        }

        public DataTable Consultar(string sp, List<Parametro> lstParametros)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = sp;

            foreach (Parametro p in lstParametros)
            {
                cmd.Parameters.AddWithValue(p.Nombre, p.Valor);
            }

            DataTable tabla = new DataTable();
            tabla.Load(cmd.ExecuteReader());
            cnn.Close();
            return tabla;
        }

        public bool ConfirmarPresupuesto(Presupuesto presupuesto)
        {
            bool res = true;
            SqlTransaction t = null;

            try
            {
                cnn.Open();
                t = cnn.BeginTransaction();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.Transaction = t;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_INSERTAR_MAESTRO";


                //param entrada
                cmd.Parameters.AddWithValue("@cliente", presupuesto.Cliente);
                cmd.Parameters.AddWithValue("@dto", presupuesto.Descuento);
                cmd.Parameters.AddWithValue("@total", presupuesto.CalcularTotal());

                //param salida
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@presupuestro_nro";
                param.SqlDbType = SqlDbType.Int;
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                cmd.ExecuteNonQuery();

                int nroPresupuesto = (int)param.Value;
                int nroDetalle = 1;

                SqlCommand cmdDet;
                foreach (DetallePresupuesto dp in presupuesto.Detalles)
                {
                    cmdDet = new SqlCommand("SP_INSERTAR_DETALLE", cnn, t);
                    cmdDet.CommandType = CommandType.StoredProcedure;
                    cmdDet.Parameters.AddWithValue("@presupuesto_nro", nroPresupuesto);
                    cmdDet.Parameters.AddWithValue("@detalle", ++nroDetalle);
                    cmdDet.Parameters.AddWithValue("@id_producto", dp.Producto.ProductoNro);
                    cmdDet.Parameters.AddWithValue("@cantidad", dp.Cantidad);
                    nroDetalle++;
                    cmdDet.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch
            {
                if (t != null)
                    t.Rollback();
                res = false;
            }
            finally
            {
                if (cnn != null && cnn.State == ConnectionState.Open)
                    cnn.Close();
            }

            return res;
        }
    }
}
