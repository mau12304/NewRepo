using MySql.Data.MySqlClient;
using Proyecto_MySQL_OOP.ClasesDb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_MySQL_OOP
{
    public partial class FrmInve : Form
    {
        public FrmInve()
        {
            InitializeComponent();
            ClasesDb.TbInventario objetoInventario = new ClasesDb.TbInventario();
            objetoInventario.VerInventario(dgtinventario);
        }
        private void llenarid_producto()
        {
            TbInventario objeto = new TbInventario();
            cmbidproducto.DataSource = objeto.ListarProducto();
            cmbidproducto.DisplayMember = "Nombre";
            cmbidproducto.ValueMember = "id_producto";
        }
        private void llenarUbicacion()
        {
            TbInventario objeto = new TbInventario();
            cmbid_ubi.DataSource = objeto.ListarAreas();
            cmbid_ubi.DisplayMember = "Nombre";
            cmbid_ubi.ValueMember = "id_ubicacion";
        }
        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Frm1 objFrmMenu = new Frm1();
            this.Hide();
            objFrmMenu.Show();
        }

        private void btnSalirDiseño_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmInve_Load(object sender, EventArgs e)
        {
            llenarid_producto();
            llenarUbicacion();
        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            ClasesDb.TbInventario objetoInventario = new ClasesDb.TbInventario();//INSERTANDO REGISTROS EN ARCHIVO DE TEXTO CON UBICACION DESDE EMU8086
            string datos = $"id_producto: {cmbidproducto.Text}\r\nStock:{txtstock.Text}\r\nCant_Max:{txtCantMax.Text}\r\nCant_Mini:{txtCanMin.Text}\r\nComentarios:{txtComentarios.Text}\r\nFe_reorden:{mskFec_reorden}\r\nUbicacion:{cmbid_ubi}\r\n";
            string rutaArchivo = "C:\\emu8086\\vdrive\\C\\Prueba\\Archivo.txt";

            using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
            {
                if (File.Exists(rutaArchivo))
                {
                    writer.WriteLine(datos);
                }
                else
                {
                    File.WriteAllText(rutaArchivo, datos);
                }
            }
            objetoInventario.insertarInventario(Convert.ToInt32(cmbidproducto.SelectedValue), txtstock,txtCantMax,txtCanMin,txtComentarios,mskFec_reorden, Convert.ToInt32(cmbid_ubi.SelectedValue));
            objetoInventario.VerInventario(dgtinventario);
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            ClasesDb.TbInventario objetoInventario = new ClasesDb.TbInventario();
            objetoInventario.modificarInventario(Convert.ToInt32(cmbidproducto.SelectedValue), txtstock, txtCantMax, txtCanMin, txtComentarios, mskFec_reorden, Convert.ToInt32(cmbid_ubi.SelectedValue));
            objetoInventario.VerInventario(dgtinventario);
        }

        private void dgtinventario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClasesDb.TbInventario objetoInventario = new ClasesDb.TbInventario();
            objetoInventario.seleccionarInventario(dgtinventario,cmbidproducto, txtstock, txtCantMax, txtCanMin, txtComentarios, mskFec_reorden, cmbid_ubi);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClasesDb.TbInventario objetoInventario = new ClasesDb.TbInventario();
            objetoInventario.eliminarInventario(cmbidproducto);
            objetoInventario.VerInventario(dgtinventario);
        }

        private void txtstock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
         if (Char.IsControl(e.KeyChar))//Permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;//El resto de teclas pulsadas se desactivan
            }
        }

        private void txtCantMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
         if (Char.IsControl(e.KeyChar))//Permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;//El resto de teclas pulsadas se desactivan
            }
        }

        private void txtCanMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
         if (Char.IsControl(e.KeyChar))//Permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;//El resto de teclas pulsadas se desactivan
            }
        }

        private void txtComentarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) // Permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true; // El resto de teclas pulsadas se desactivan
            }
        }
    }
}
