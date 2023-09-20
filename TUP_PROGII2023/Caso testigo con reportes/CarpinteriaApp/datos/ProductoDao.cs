using CarpinteriaApp.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.datos
{
    public class ProductoDao : IDAOProducto
    {
        public List<Producto> GetAll()
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
