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
    public partial class FrmEmple : Form
    {
        public FrmEmple()
        {
            InitializeComponent();
            ClasesDb.TbEmpleado objetoEmpleado = new ClasesDb.TbEmpleado();
            objetoEmpleado.VerEmpleados(dgbEmpleado);
            
        }
        private void llenarPuesto()
        {
            TbEmpleado objeto = new TbEmpleado();
            cmbPuesto.DataSource = objeto.ListarPuesto();
            cmbPuesto.DisplayMember = "Nombre";
            cmbPuesto.ValueMember = "id_puesto";
        }

        private void btnVolverMenu_Click(object sender, EventArgs e)
        {
            Frm1 objFrmMenu = new Frm1();
            this.Hide();
            objFrmMenu.Show();
        }

        private void btnSalirEmple_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            ClasesDb.TbEmpleado objetoEmpleado = new ClasesDb.TbEmpleado();//INSERTANDO REGISTROS EN ARCHIVO DE TEXTO CON UBICACION DESDE EMU8086
            string datos = $"id_tipo: {txtid.Text}\r\nPaterno:{txtPaterno.Text}\r\nMaterno:{txtMaterno.Text}\r\nNombre:{txtNombre.Text}\r\nFecha:{mstFecha.Text}\r\nPuesto:{cmbPuesto.Text}\r\n";
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
            objetoEmpleado.insertarEmpleados(txtid, txtPaterno,txtMaterno,txtNombre,mstFecha, Convert.ToInt32(cmbPuesto.SelectedValue));
            objetoEmpleado.VerEmpleados(dgbEmpleado);


        }

        private void FrmEmple_Load(object sender, EventArgs e)
        {
            llenarPuesto();
        }

        private void dgbEmpleado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ClasesDb.TbEmpleado objetoEmpleado = new ClasesDb.TbEmpleado();
            objetoEmpleado.seleccionarEmpleados(dgbEmpleado,txtid, txtPaterno, txtMaterno, txtNombre, mstFecha, cmbPuesto);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ClasesDb.TbEmpleado objetoEmpleado = new ClasesDb.TbEmpleado();
            objetoEmpleado.modificarEmpleados(txtid, txtPaterno, txtMaterno, txtNombre, mstFecha, Convert.ToInt32(cmbPuesto.SelectedValue));
            objetoEmpleado.VerEmpleados(dgbEmpleado);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClasesDb.TbEmpleado objetoEmpleado = new ClasesDb.TbEmpleado();
            objetoEmpleado.eliminarEmpleados(txtid);
            objetoEmpleado.VerEmpleados(dgbEmpleado);
        }

        private void btnPuesto_Click(object sender, EventArgs e)
        {
            FrmPuesto obj = new FrmPuesto();
            this.Hide();
            obj.Show();
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

        private void txtPaterno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtMaterno_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
