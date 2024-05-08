using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_MySQL_OOP.ClasesDb
{
    internal class TbEmpleado
    {
        public ConexionDb conexion = new ConexionDb();
        public MySqlCommand comando = new MySqlCommand();
        public MySqlDataReader LeerFilas;

        public DataTable ListarPuesto()
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.EstablecerConexion();
            comando.CommandText = "ListarPuesto";
            comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = comando.ExecuteReader();
            tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.cerrarconexion();
            return tabla;
        }

        public void VerEmpleados(DataGridView TablaEmpleado)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "select id_empleado,Paterno,Materno,Nombre,date_format(Fecha_ingreso,\"%Y /%m /%d\"),id_puesto from empleado";
                TablaEmpleado.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, objetoConexion.EstablecerConexion());
                DataTable dte = new DataTable();
                adapter.Fill(dte);
                TablaEmpleado.DataSource = dte;
                objetoConexion.cerrarconexion();
            }catch (Exception ex)
            {
                MessageBox.Show("No se cargaron los datos del empleado" + ex.ToString());
            }
        }
        public void insertarEmpleados(TextBox id, TextBox Paterno, TextBox Materno, TextBox Nombre, MaskedTextBox Fecha_ingreso, int Puesto)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "insert into empleado (id_empleado,Paterno,Materno,Nombre,Fecha_ingreso,id_puesto)" +
                "values ('" + id.Text + "','" + Paterno.Text + "','" + Materno.Text + "','" + Nombre.Text + "','" + Fecha_ingreso.Text + "','" + Puesto + "');";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se inserto correctamente","Exit",MessageBoxButtons.OK,MessageBoxIcon.Information);
             
                objetoConexion.cerrarconexion();
            }
            catch (MySqlException ex)
            {
                // Captura la excepción específica de MySQL relacionada con la duplicación de claves primarias
                if (ex.Number == 1062) // El código de error 1062 indica una violación de clave única
                {
                    MessageBox.Show("No se puede insertar el registro porque ya existe un registro con el mismo id_empleado.", "Error de duplicación de clave primaria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Otras excepciones de MySQL
                    MessageBox.Show("Error al insertar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void seleccionarEmpleados(DataGridView TablaEmpleado, TextBox id, TextBox Paterno, TextBox Materno, TextBox Nombre, MaskedTextBox Fecha_ingreso, ComboBox Puesto)
        {
            try
            {
                id.Text = TablaEmpleado.CurrentRow.Cells[0].Value.ToString();
                Paterno.Text = TablaEmpleado.CurrentRow.Cells[1].Value.ToString();
                Materno.Text = TablaEmpleado.CurrentRow.Cells[2].Value.ToString();
                Nombre.Text = TablaEmpleado.CurrentRow.Cells[3].Value.ToString();
                Fecha_ingreso.Text = TablaEmpleado.CurrentRow.Cells[4].Value.ToString();
                Puesto.Text = TablaEmpleado.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se logro seleccionar" + ex.ToString());
            }
        }
        public void modificarEmpleados(TextBox id, TextBox Paterno, TextBox Materno, TextBox Nombre, MaskedTextBox Fecha_ingreso, int Puesto)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "update empleado set Paterno='"
                + Paterno.Text + "', Materno='" + Materno.Text +
                "', Nombre='" + Nombre.Text + "', Fecha_ingreso='" + Fecha_ingreso.Text +
                "', id_Puesto='" + Puesto + "' where id_empleado ='" + id.Text + "';";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se modifico correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se cargaron los datos del empleado" + ex.ToString());
            }
        }
        public void eliminarEmpleados(TextBox id)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "delete from empleado where id_empleado='"+id.Text + "';";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se elimino correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se eliminaron los datos del empleado" + ex.ToString());
            }
        }
    }
}
