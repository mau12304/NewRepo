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
    public partial class FrmVentas : Form
    {
        public FrmVentas()
        {
            InitializeComponent();
            ClasesDb.TbVentas objetoVentas = new ClasesDb.TbVentas();
            objetoVentas.VerVentas(dgtVentas);
        }
        private void llenarRepresentante()
        {
            TbVentas objeto = new TbVentas();
            cmbRepresentante.DataSource = objeto.ListarEmpleado();
            cmbRepresentante.DisplayMember = "Nombre";
            cmbRepresentante.ValueMember = "id_Empleado";
        }
        private void llenarUbicacion()
        {
            TbVentas objeto = new TbVentas();
            cmbUbicacion.DataSource = objeto.ListarAreas();
            cmbUbicacion.DisplayMember = "Nombre";
            cmbUbicacion.ValueMember = "id_ubicacion";
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Frm1 objFrmMenu = new Frm1();
            this.Hide();
            objFrmMenu.Show();
        }

        private void btnSalirVentas_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {
            llenarRepresentante();
            llenarUbicacion();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            ClasesDb.TbVentas objetoVentas = new ClasesDb.TbVentas();//INSERTANDO REGISTROS EN ARCHIVO DE TEXTO CON UBICACION DESDE EMU8086
            string datos = $"id_venta: {txtid.Text}\r\nFecha_venta:{mskFechaVenta.Text}\r\nTotal_Venta:{txtTotalVenta.Text}\r\nRepresentante:{cmbRepresentante.Text}\r\nFecha_reorden:{mskFechaReorden.Text}\r\nUbicacion:{cmbUbicacion.Text}\r\nComentarios:{txtcomentarios.Text}\r\n";
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
            objetoVentas.insertarVentas(txtid,mskFechaVenta,txtTotalVenta, Convert.ToInt32(cmbRepresentante.SelectedValue), mskFechaReorden, Convert.ToInt32(cmbUbicacion.SelectedValue), txtcomentarios);
            objetoVentas.VerVentas(dgtVentas);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ClasesDb.TbVentas objetoVentas = new ClasesDb.TbVentas();
            objetoVentas.modificarVentas(txtid, mskFechaVenta, txtTotalVenta, Convert.ToInt32(cmbRepresentante.SelectedValue), mskFechaReorden, Convert.ToInt32(cmbUbicacion.SelectedValue), txtcomentarios);
            objetoVentas.VerVentas(dgtVentas);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClasesDb.TbVentas objetoVentas = new ClasesDb.TbVentas();
            objetoVentas.eliminarVentas(txtid);
            objetoVentas.VerVentas(dgtVentas);
        }

        private void dgtVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClasesDb.TbVentas objetoVentas = new ClasesDb.TbVentas();
            objetoVentas.seleccionarVentas(dgtVentas,txtid, mskFechaVenta, txtTotalVenta, cmbRepresentante, mskFechaReorden, cmbUbicacion, txtcomentarios);

        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            FrmAreas obj = new FrmAreas();
            this.Hide();
            obj.Show();
        }

        private void txtcomentarios_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTotalVenta_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
