using CarpinteriaApp.datos;
using CarpinteriaApp.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.Servicios
{
    internal class GestorProducto
    {
        ProductoDao dao;

        public GestorProducto(ProductoDao dao)
        {
            this.dao = dao;
        }
        public List<Producto> ObtenerProductos()
        {
            return dao.GetAll();
        }
    }
}
