using MySql.Data.MySqlClient;
using MySql.Data.Types;
using Proyecto_MySQL_OOP.ClasesDb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_MySQL_OOP.Consultas
{
    public partial class Buscar_Prod : Form
    {
        public Buscar_Prod()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ClasesDb.TbProductos objetoProducto = new ClasesDb.TbProductos();
            objetoProducto.ConsultarProducto(txtid,txtNombre,txtColor,txtTalla,txtGenero,txttipo,txtmodelo,txtPrecioPro,txtComentarios);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            Frm1 obj = new Frm1();
            this.Hide();
            obj.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtColor.Clear();   
            txtTalla.Clear();
            txtGenero.Clear();
            txtid.Clear();
            txtPrecioPro.Clear();
            txtmodelo.Clear();
            txtComentarios.Clear();
            txttipo.Clear();
        }
    }
}
