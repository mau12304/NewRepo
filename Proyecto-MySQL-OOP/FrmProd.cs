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
    public partial class FrmProd : Form
    {
        public FrmProd()
        {
            InitializeComponent();
            ClasesDb.TbProductos objetoProducto = new ClasesDb.TbProductos();
            objetoProducto.VerProductos(dgtProductos);
        }
        private void llenarGenero()
        {
            TbProductos objeto = new TbProductos();
            cmbGnero.DataSource = objeto.ListarGenero();
            cmbGnero.DisplayMember = "Nombre";
            cmbGnero.ValueMember = "id_genero";
        }
        private void llenarTipo()
        {
            TbProductos objeto = new TbProductos(); 
            cmbTipo.DataSource = objeto.ListarTipo();
            cmbTipo.DisplayMember = "Nombre";
            cmbTipo.ValueMember = "id_tipo";  
        }
        private void llenarModelo()
        {
            TbProductos objeto = new TbProductos();
            cmbModelo.DataSource = objeto.ListarModelo();
            cmbModelo.DisplayMember = "Nombre";
            cmbModelo.ValueMember = "id_modelo";
        }
        private void btnVolverMenu_Click_1(object sender, EventArgs e)
        {
            Frm1 objFrmMenu = new Frm1();
            this.Hide();
            objFrmMenu.Show();
        }

        private void btnSalirVentas_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmProd_Load(object sender, EventArgs e)
        {
            llenarTipo();
            llenarGenero();
            llenarModelo();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            ClasesDb.TbProductos objetoProducto = new ClasesDb.TbProductos();//INSERTANDO REGISTROS EN ARCHIVO DE TEXTO CON UBICACION DESDE EMU8086
            string datos = $"id_producto: {txtid.Text}\r\nNombre:{txtNombre.Text}\r\nColor:{txtColor.Text}\r\nTalla:{txtTalla.Text}\r\nGenero:{cmbGnero.Text}\r\nTipo:{cmbTipo.Text}\r\nModelo:{cmbModelo.Text}\r\nPrecio:{txtPrecioPro.Text}\r\nComentarios:{txtComentarios.Text}\r\n";
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
            objetoProducto.insertarProductos(int.Parse(txtid.Text),txtNombre,txtColor,txtTalla, Convert.ToInt32(cmbGnero.SelectedValue), Convert.ToInt32(cmbTipo.SelectedValue), Convert.ToInt32(cmbModelo.SelectedValue),txtPrecioPro,txtComentarios);
            objetoProducto.VerProductos(dgtProductos);
        }

        private void dgtProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClasesDb.TbProductos objetoProducto = new ClasesDb.TbProductos();
            objetoProducto.seleccionarProductos(dgtProductos,txtid, txtNombre, txtColor, txtTalla, cmbGnero, cmbTipo, cmbModelo, txtPrecioPro, txtComentarios);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ClasesDb.TbProductos objetoProducto = new ClasesDb.TbProductos();
            objetoProducto.modificarProductos(int.Parse(txtid.Text), txtNombre, txtColor, txtTalla, Convert.ToInt32(cmbGnero.SelectedValue), Convert.ToInt32(cmbTipo.SelectedValue), Convert.ToInt32(cmbModelo.SelectedValue), txtPrecioPro, txtComentarios);
            objetoProducto.VerProductos(dgtProductos);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClasesDb.TbProductos objetoProducto = new ClasesDb.TbProductos();
            objetoProducto.eliminarProductos(txtid);
            objetoProducto.VerProductos(dgtProductos);
        }

        private void btnTipo_Click(object sender, EventArgs e)
        {
            FrmTipo obj = new FrmTipo();
            this.Hide();
            obj.Show();
        }

        private void btnGenero_Click(object sender, EventArgs e)
        {
            FrmGenero obj = new FrmGenero();
            this.Hide();
            obj.Show();
        }

        private void btnModelo_Click(object sender, EventArgs e)
        {
            FrmModelo obj = new FrmModelo();
            this.Hide();
            obj.Show();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtColor_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPrecioPro_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtid_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtid.Clear();
            txtNombre.Clear();
            txtPrecioPro.Clear();
            txtTalla.Clear();
            txtColor.Clear();
            cmbGnero.Text = "";
            cmbTipo.Text = "";
            cmbModelo.Text = "";
            txtComentarios.Clear();

        }
    }
}
