using Proyecto_MySQL_OOP.Consultas;
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

        private void btnBusca_Click(object sender, EventArgs e)
        {
            Buscar_Prod busca = new Buscar_Prod();
            this.Hide();
            busca.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void areasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAreas objFrmAreas = new FrmAreas();
            this.Hide();
            objFrmAreas.Show();
        }

        private void puestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPuesto objeto = new FrmPuesto();
            this.Hide(); 
            objeto.Show();
        }

        private void tipoDeProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipo obj = new FrmTipo();
            this.Hide();
            obj.Show();
        }

        private void modelosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmModelo obj = new FrmModelo();    
            this.Hide(); 
            obj.Show();
        }

        private void generosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGenero obj = new FrmGenero();
            this.Hide();
            obj.Show(); 
        }

        private void metodoGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_IO obj = new Frm_IO();  
            this.Hide();    
            obj.Show(); 
        }
    }
}
