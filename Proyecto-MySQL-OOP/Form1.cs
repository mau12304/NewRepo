using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_MySQL_OOP
{
    public partial class Frm1 : Form
    {
        public Frm1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FrmProd objFrmProd = new FrmProd();
            this.Hide();
            objFrmProd.Show();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            FrmInve objFrmInventario = new FrmInve();
            this.Hide();
            objFrmInventario.Show();
        }

        private void btnempleado_Click(object sender, EventArgs e)
        {
            FrmEmple objFrmEmpleado = new FrmEmple();
            this.Hide();
            objFrmEmpleado.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            FrmVentas objFrmVent = new FrmVentas();
            this.Hide();
            objFrmVent.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
