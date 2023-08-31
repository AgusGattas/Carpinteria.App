using CarpinteriaApp_1w3.datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarpinteriaApp_1w3.Presentacion
{
    public partial class FrmConsultarPresupuesto : Form
    {
        public FrmConsultarPresupuesto()
        {
            InitializeComponent();
        }

        private void ConsultarPresupuesto_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Today.AddDays(-7);
            dtpHasta.Value = DateTime.Today;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //validar datos entrada
            List<Parametro> lista = new List<Parametro>();
            lista.Add(new Parametro("@fecha_desde", dtpDesde.Value));
            lista.Add(new Parametro("@fecha_hasta", dtpHasta.Value));
            lista.Add(new Parametro("@cliente", txtCliente.Text));

            DataTable tabla = new DBHelper().Consultar("SP_CONSULTAR_PRESUPUESTO", lista);

            dgvPresupuestos.Rows.Clear();
            foreach (DataRow fila in tabla.Rows)
            {
                dgvPresupuestos.Rows.Add(new object[] { fila["presupuesto_nro"].ToString(),
                                                        ((DateTime)fila["fecha"]).ToShortDateString(),
                                                        fila["cliente"].ToString(),
                                                        fila["total"].ToString(),
                                                        "Ver Detalle"});
            }
        }
    }
}
