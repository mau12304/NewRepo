using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_MySQL_OOP.Consultas
{
    public partial class Detalle_V : Form
    {
        public Detalle_V()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ClasesDb.TbVentas obj = new ClasesDb.TbVentas();
            obj.ConsultarDetalleV(txtid,txtid_producto,txtcantidad,txtprecio,txtTotal);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            FrmVentas obj = new FrmVentas();
            this.Hide();
            obj.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtid.Clear();
            txtid_producto.Clear();
            txtcantidad.Clear();
            txtprecio.Clear();  
            txtTotal.Clear();   
        }
    }
}
