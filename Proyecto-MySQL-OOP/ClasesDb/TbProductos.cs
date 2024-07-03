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
    internal class TbProductos
    {
        public ConexionDb conexion = new ConexionDb();
        public MySqlCommand comando = new MySqlCommand();
        public MySqlDataReader LeerFilas;

        public void VerProductos(DataGridView TablaProducto)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "select * from producto";
                TablaProducto.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, objetoConexion.EstablecerConexion());
                DataTable dtp = new DataTable();
                adapter.Fill(dtp);
                TablaProducto.DataSource = dtp;
                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se cargaron los datos del Producto" + ex.ToString());
            }
        }

        public DataTable ListarTipo()
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.EstablecerConexion();
            comando.CommandText = "ListarTipo";
            comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = comando.ExecuteReader();
            tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.cerrarconexion();
            return tabla;
        }
        public DataTable ListarModelo()
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.EstablecerConexion();
            comando.CommandText = "ListarModelo";
            comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = comando.ExecuteReader();
            tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.cerrarconexion();
            return tabla;
        }
        public DataTable ListarGenero()
        {
            DataTable tabla = new DataTable();
            comando.Connection = conexion.EstablecerConexion();
            comando.CommandText = "ListarGenero";
            comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = comando.ExecuteReader();
            tabla.Load(LeerFilas);
            LeerFilas.Close();
            conexion.cerrarconexion();
            return tabla;
        }

        public void insertarProductos(TextBox id_producto, TextBox Nombre, TextBox Color, TextBox Talla, int Genero, int Tipo, int Modelo,TextBox Precio,TextBox comentarios)
        {
            try
            {
                /*if(id_producto.Text == "" || Nombre.Text == "" || Color.Text == "" || Talla.Text == "" || Genero.Text == "" || Tipo.Text == ""  || Modelo.Text == "" || Precio.Text == "" || comentarios.Text == "")
                {
                    MessageBox.Show("Todos los campos son obligatorios, asegúrese de completarlos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Salir del método sin intentar la inserción
                }*/

                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "insert into producto (id_producto,Nombre,Color,Talla,id_genero,id_tipo,id_modelo,precio,comentarios)" +
                "values ('" + id_producto.Text + "','" + Nombre.Text + "','" + Color.Text + "','" 
                + Talla.Text + "','" + Genero + "','" + Tipo + "','"+ Modelo + "','"+ 
                Precio.Text + "','"+ comentarios.Text+ "');";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se inserto correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objetoConexion.cerrarconexion();
            }
            catch (MySqlException ex)
            {
                // Captura la excepción específica de MySQL relacionada con la duplicación de claves primarias
                if (ex.Number == 1062) // El código de error 1062 indica una violación de clave única
                {
                    MessageBox.Show("No se puede insertar el registro porque ya existe un registro con el mismo id_producto.", "Error de duplicación de clave primaria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Otras excepciones de MySQL
                    MessageBox.Show("Error al insertar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void seleccionarProductos(DataGridView TablaProducto,TextBox id_producto, TextBox Nombre, TextBox Color, TextBox Talla, ComboBox Genero, ComboBox Tipo, ComboBox Modelo, TextBox Precio, TextBox comentarios)
        {
            try
            {
                id_producto.Text = TablaProducto.CurrentRow.Cells[0].Value.ToString();
                Nombre.Text = TablaProducto.CurrentRow.Cells[1].Value.ToString();
                Color.Text = TablaProducto.CurrentRow.Cells[2].Value.ToString();
                Talla.Text = TablaProducto.CurrentRow.Cells[3].Value.ToString();
                Genero.Text = TablaProducto.CurrentRow.Cells[4].Value.ToString();
                Tipo.Text = TablaProducto.CurrentRow.Cells[5].Value.ToString();
                Modelo.Text = TablaProducto.CurrentRow.Cells[6].Value.ToString();
                Precio.Text = TablaProducto.CurrentRow.Cells[7].Value.ToString();
                comentarios.Text = TablaProducto.CurrentRow.Cells[8].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se logro seleccionar" + ex.ToString());
            }
        }

        public void ConsultarProducto(TextBox id_producto, TextBox Nombre, TextBox Color, TextBox Talla, TextBox Genero, TextBox Tipo, TextBox Modelo, TextBox Precio, TextBox comentarios)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                TbProductos objetoProducto = new TbProductos();
                string consulta = "SELECT * FROM producto WHERE id_producto = @idProducto";
                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MiComando.Parameters.AddWithValue("@idProducto", id_producto.Text);
                MySqlDataReader registros = MiComando.ExecuteReader();

                if (registros.Read())
                {
                    // Mostrar los datos en los TextBox y ComboBox correspondientes
                    Nombre.Text = registros["Nombre"].ToString();
                    Color.Text = registros["Color"].ToString();
                    Talla.Text = registros["Talla"].ToString();
                    int idGenero = Convert.ToInt32(registros["id_genero"]);
                    Genero.Text = objetoProducto.ObtenerNombreGenero(idGenero);
                    int idTipo = Convert.ToInt32(registros["id_tipo"]);
                    Tipo.Text = objetoProducto.ObtenerNombreTipo(idTipo);
                    int idModelo = Convert.ToInt32(registros["id_modelo"]);
                    Modelo.Text = objetoProducto.ObtenerNombreModelo(idModelo);
                    Precio.Text = registros["Precio"].ToString();
                    comentarios.Text = registros["comentarios"].ToString();
                }
                else
                {
                    MessageBox.Show("No se encontró un producto con el ID proporcionado.", "No encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Método para obtener el nombre del género según el ID
        public string ObtenerNombreGenero(int idGenero)
        {
            string nombreGenero = "";
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "SELECT nombre FROM genero WHERE id_genero = @idGenero";
                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MiComando.Parameters.AddWithValue("@idGenero", idGenero);
                nombreGenero = MiComando.ExecuteScalar()?.ToString() ?? ""; // Obtener el nombre del género
                objetoConexion.cerrarconexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al obtener el nombre del género: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return nombreGenero;
        }
        public string ObtenerNombreTipo(int idTipo)
        {
            string nombreGenero = "";
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "SELECT nombre FROM tipo WHERE id_tipo = @idTipo";
                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MiComando.Parameters.AddWithValue("@idTipo", idTipo);
                nombreGenero = MiComando.ExecuteScalar()?.ToString() ?? ""; // Obtener el nombre del género
                objetoConexion.cerrarconexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al obtener el nombre del género: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return nombreGenero;
        }
        public string ObtenerNombreModelo(int idModelo)
        {
            string nombreGenero = "";
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "SELECT nombre FROM modelo WHERE id_modelo = @idModelo";
                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MiComando.Parameters.AddWithValue("@idModelo", idModelo);
                nombreGenero = MiComando.ExecuteScalar()?.ToString() ?? ""; // Obtener el nombre del género
                objetoConexion.cerrarconexion();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al obtener el nombre del género: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return nombreGenero;
        }

        public void modificarProductos(TextBox id_producto, TextBox Nombre, TextBox Color, TextBox Talla, int Genero, int Tipo, int Modelo, TextBox Precio, TextBox comentarios)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "update producto set Nombre='"
                + Nombre.Text + "', Color='" + Color.Text +
                "', Talla='" + Talla.Text + "', id_genero='" + Genero +
                "', id_tipo='" + Tipo + "', id_modelo='" + Modelo + "', Precio='" + Precio.Text + "', comentarios='" + comentarios.Text + "' where id_producto ='" + id_producto.Text + "';";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se modifico correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se modificaron los datos del producto" + ex.ToString());
            }
        }
        public void eliminarProductos(TextBox id_producto)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "delete from producto where id_producto='" + id_producto.Text + "';";
                  
                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se elimino correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se eliminaron los datos del Producto" + ex.ToString());
            }
        }
    }
}
