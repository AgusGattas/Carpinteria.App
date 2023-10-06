using CarpinteriaApp.datos;
using CarpinteriaApp.dominio;
using CarpinteriaApp.IServicios.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.IServicios
{
    public class Servicios : IServicio
    {
        IDAOProducto dao;

        public Servicios()
        {
            dao = new ProductoDao();
        }

         public int ProximoPresupuesto()
        {
            return dao.ProximosPresupuestos();
        }

        public bool CrearPresupuesto(Presupuesto presupuesto)
        {
            return dao.Crear(presupuesto);
        }

        public List<Producto> ObtenerProductos()
        {
            return dao.TraerProductos();
        }
    }
}
