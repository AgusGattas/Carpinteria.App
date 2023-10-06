using CarpinteriaApp.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarpinteriaApp.IServicios.interfaces
{
     interface IServicio
    {
        List<Producto> ObtenerProductos();

        bool CrearPresupuesto(Presupuesto presupuesto);

         int ProximoPresupuesto();
        

    }
}
