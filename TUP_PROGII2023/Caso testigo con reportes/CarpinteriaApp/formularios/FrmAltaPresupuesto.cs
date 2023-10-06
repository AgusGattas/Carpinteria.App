using CarpinteriaApp.datos;
using CarpinteriaApp.dominio;
using CarpinteriaApp.IServicios;
using CarpinteriaApp.IServicios.interfaces;

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services.Description;
using System.Windows.Forms;

namespace CarpinteriaApp.formularios
{
    public partial class FrmAltaPresupuesto : Form
    {
        //private HelperDB helper;
        private Presupuesto nuevo;
        IServicio servicio = null;
        public FrmAltaPresupuesto()
        {
            InitializeComponent();
            //helper = HelperDB.ObtenerInstancia();
            nuevo = new Presupuesto();
            servicio = new Servicios();

        }

        private void Frm_Alta_Presupuesto_Load(object sender, EventArgs e)
        {
            ProximoPresupuesto();
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtCliente.Text = "CONSUMIDOR FINAL";
            txtDto.Text = "0";
            this.ActiveControl = cboProductos; // Set foco al combo
            CargarProductos();
        }
        private void CargarProductos()
        {
            cboProductos.DataSource = servicio.ObtenerProductos();
            cboProductos.ValueMember = "ProductoNro";
            cboProductos.DisplayMember = "Nombre";
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboProductos.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe seleccionar un PRODUCTO!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtCantidad.Text == "" || !int.TryParse(txtCantidad.Text, out _))
            {
                MessageBox.Show("Debe ingresar una cantidad válida!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["colProd"].Value.ToString().Equals(cboProductos.Text))
                {
                    MessageBox.Show("PRODUCTO: " + cboProductos.Text + " ya se encuentra como detalle!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
            }
            Producto p = (Producto)cboProductos.SelectedItem;

            int cant = Convert.ToInt32(txtCantidad.Text);
            DetallePresupuesto detalle = new DetallePresupuesto(p, cant);

            nuevo.AgregarDetalle(detalle);
            
            dgvDetalles.Rows.Add(new object[] { p.ProductoNro, p.Nombre, p.Precio, cant, "Quitar" });

            CalcularTotal();
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 4)
            {
                nuevo.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                //click button:
                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
                //presupuesto.quitarDetalle();
                CalcularTotal();

            }
        }

        private void CalcularTotal()
        {
            double total = nuevo.CalcularTotal();
            txtTotal.Text = total.ToString();

            if (txtDto.Text != "")
            {
                double dto = (total * Convert.ToDouble(txtDto.Text)) / 100;
                txtFinal.Text = (total - dto).ToString();
            }
        }

        
        private void ProximoPresupuesto()
        {
            int next = servicio.ProximoPresupuesto();
            if (next > 0)
                lblNroPresupuesto.Text = "Presupuesto Nº: " + next.ToString();
            else
                MessageBox.Show("Error de datos. No se puede obtener Nº de presupuesto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void GuardarPresupuesto()
        {
            //datos del presupuesto:
            nuevo.Cliente = txtCliente.Text;
            nuevo.Descuento = Convert.ToDouble(txtDto.Text);
            nuevo.Fecha = Convert.ToDateTime(txtFecha.Text);

            if (servicio.CrearPresupuesto(nuevo))
            {
                MessageBox.Show("Presupuesto registrado", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo registrar el presupuesto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe ingresar un cliente!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos detalle!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GuardarPresupuesto();
        }
    }
}
