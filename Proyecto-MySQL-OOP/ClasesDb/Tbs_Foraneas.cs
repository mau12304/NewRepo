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
    internal class Tbs_Foraneas
    {               //   TABLA GENERO
        public void VerGenero(DataGridView TablaGenero)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "select * from genero";
                TablaGenero.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, objetoConexion.EstablecerConexion());
                DataTable dtg = new DataTable();
                adapter.Fill(dtg);
                TablaGenero.DataSource = dtg;
                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se cargo la tabla genero" + ex.ToString());
            }
        }
        public void seleccionarGenero(DataGridView TablaGenero,TextBox id, TextBox Nombre)
        {
            try
            {
                id.Text = TablaGenero.CurrentRow.Cells[0].Value.ToString();
                Nombre.Text = TablaGenero.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se logro seleccionar" + ex.ToString());
            }
        }
        public void insertarGenero(TextBox id, TextBox Nombre)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "insert into genero (id_genero,Nombre)" +
                "values ('" + id.Text + "','"+ Nombre.Text + "');";
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
                    MessageBox.Show("No se puede insertar el registro porque ya existe un registro con el mismo id_genero.", "Error de duplicación de clave primaria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Otras excepciones de MySQL
                    MessageBox.Show("Error al insertar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        public void modificarGenero(TextBox id, TextBox Nombre)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "update genero set Nombre='"
                + Nombre.Text + "' where id_genero ='" + id.Text + "';";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se modifico correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se cargaron los datos" + ex.ToString());
            }
        }
        public void eliminarGenero(TextBox id)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "delete from genero where id_genero='" + id.Text + "';";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se elimino correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se eliminaron los datos de la tabla" + ex.ToString());
            }
        }
        //TABLA TIPOOOOOO

        public void VerTipo(DataGridView TablaTipo)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "select * from Tipo";
                TablaTipo.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, objetoConexion.EstablecerConexion());
                DataTable dti = new DataTable();
                adapter.Fill(dti);
                TablaTipo.DataSource = dti;
                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se cargo la tabla Tipo" + ex.ToString());
            }
        }
        public void seleccionarTipo(DataGridView TablaTipo, TextBox id, TextBox Nombre)
        {
            try
            {
                id.Text = TablaTipo.CurrentRow.Cells[0].Value.ToString();
                Nombre.Text = TablaTipo.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se logro seleccionar" + ex.ToString());
            }
        }
        public void insertarTipo(TextBox id, TextBox Nombre)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "insert into Tipo (id_tipo,Nombre)" +
                "values ('" + id.Text + "','" + Nombre.Text + "');";

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
                    MessageBox.Show("No se puede insertar el registro porque ya existe un registro con el mismo id_Tipo.", "Error de duplicación de clave primaria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Otras excepciones de MySQL
                    MessageBox.Show("Error al insertar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void modificarTipo(TextBox id, TextBox Nombre)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "update tipo set Nombre='"
                + Nombre.Text + "' where id_tipo ='" + id.Text + "';";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se modifico correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se cargaron los datos" + ex.ToString());
            }
        }
        public void eliminarTipo(TextBox id)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "delete from tipo where id_tipo='" + id.Text + "';";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se elimino correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se eliminaron los datos de la tabla" + ex.ToString());
            }
        }
        //TABLA MODELOOO

        public void VerModelo(DataGridView TablaModelo)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "select * from Modelo";
                TablaModelo.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, objetoConexion.EstablecerConexion());
                DataTable dtm = new DataTable();
                adapter.Fill(dtm);
                TablaModelo.DataSource = dtm;
                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se cargo la tabla Modelo" + ex.ToString());
            }
        }
        public void seleccionarModelo(DataGridView TablaModelo, TextBox id, TextBox Nombre)
        {
            try
            {
                id.Text = TablaModelo.CurrentRow.Cells[0].Value.ToString();
                Nombre.Text = TablaModelo.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se logro seleccionar" + ex.ToString());
            }
        }
        public void insertarModelo(TextBox id, TextBox Nombre)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "insert into Modelo (id_Modelo,Nombre)" +
                "values ('" + id.Text + "','" + Nombre.Text + "');";

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
                    MessageBox.Show("No se puede insertar el registro porque ya existe un registro con el mismo id_Modelo.", "Error de duplicación de clave primaria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Otras excepciones de MySQL
                    MessageBox.Show("Error al insertar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void modificarModelo(TextBox id, TextBox Nombre)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "update Modelo set Nombre='"
                + Nombre.Text + "' where id_modelo ='" + id.Text + "';";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se modifico correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se cargaron los datos" + ex.ToString());
            }
        }
        public void eliminarModelo(TextBox id)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "delete from Modelo where id_modelo='" + id.Text + "';";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se elimino correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se eliminaron los datos de la tabla" + ex.ToString());
            }
        }
        //  TABLA AREAS 
        public void VerAreas(DataGridView TablaAreas)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "select * from areas";
                TablaAreas.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, objetoConexion.EstablecerConexion());
                DataTable dta = new DataTable();
                adapter.Fill(dta);
                TablaAreas.DataSource = dta;
                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se cargo la tabla areas" + ex.ToString());
            }
        }
        public void seleccionarAreas(DataGridView TablaAreas, TextBox id, TextBox Nombre, TextBox seccion)
        {
            try
            {
                id.Text = TablaAreas.CurrentRow.Cells[0].Value.ToString();
                Nombre.Text = TablaAreas.CurrentRow.Cells[1].Value.ToString();
                seccion.Text = TablaAreas.CurrentRow.Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se logro seleccionar" + ex.ToString());
            }
        }
        public void insertarAreas(TextBox id, TextBox Nombre, TextBox seccion)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "insert into areas (id_ubicacion,Nombre,seccion)" +
                "values ('" + id.Text + "','" + Nombre.Text + "','"+ seccion.Text + "');";

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
                    MessageBox.Show("No se puede insertar el registro porque ya existe un registro con el mismo id_ubicacion.", "Error de duplicación de clave primaria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Otras excepciones de MySQL
                    MessageBox.Show("Error al insertar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void modificarAreas(TextBox id, TextBox Nombre, TextBox seccion)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "update areas set Nombre='"
                + Nombre.Text + "', seccion='"+seccion.Text+"' where id_ubicacion='" + id.Text + "';";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se modifico correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se cargaron los datos" + ex.ToString());
            }
        }
        public void eliminarAreas(TextBox id)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "delete from areas where id_ubicacion='" + id.Text + "';";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se elimino correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se eliminaron los datos de la tabla" + ex.ToString());
            }
        }
        //TABLA PUESTO 
        public void VerPuesto(DataGridView TablaPuesto)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "select * from Puesto";
                TablaPuesto.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(consulta, objetoConexion.EstablecerConexion());
                DataTable dtp = new DataTable();
                adapter.Fill(dtp);
                TablaPuesto.DataSource = dtp;
                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se cargo la tabla Puesto" + ex.ToString());
            }
        }
        public void seleccionarPuesto(DataGridView TablaPuesto, TextBox id, TextBox Nombre, TextBox sueldo, TextBox comentario)
        {
            try
            {
                id.Text = TablaPuesto.CurrentRow.Cells[0].Value.ToString();
                Nombre.Text = TablaPuesto.CurrentRow.Cells[1].Value.ToString();
                sueldo.Text = TablaPuesto.CurrentRow.Cells[2].Value.ToString();
                comentario.Text = TablaPuesto.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se logro seleccionar" + ex.ToString());
            }
        }
        public void insertarPuesto(TextBox id, TextBox Nombre, TextBox sueldo,TextBox comentario)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "insert into puesto (id_puesto,Nombre,sueldo,comentarios)" +
                "values ('" + id.Text + "','" + Nombre.Text + "','" + sueldo.Text + "','" + comentario.Text + "');";

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
                    MessageBox.Show("No se puede insertar el registro porque ya existe un registro con el mismo id_Puesto.", "Error de duplicación de clave primaria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Otras excepciones de MySQL
                    MessageBox.Show("Error al insertar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void modificarPuesto(TextBox id, TextBox Nombre,TextBox sueldo,TextBox comentario)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "update Puesto set Nombre='"
                + Nombre.Text + "', sueldo='" + sueldo.Text  + "', comentarios='" + comentario.Text + "' where id_puesto='" + id.Text + "';";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se modifico correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se cargaron los datos" + ex.ToString());
            }
        }
        public void eliminarPuesto(TextBox id)
        {
            try
            {
                ConexionDb objetoConexion = new ConexionDb();
                string consulta = "delete from Puesto where id_puesto='" + id.Text + "';";

                MySqlCommand MiComando = new MySqlCommand(consulta, objetoConexion.EstablecerConexion());
                MySqlDataReader registros = MiComando.ExecuteReader();
                MessageBox.Show("Se elimino correctamente", "Exit", MessageBoxButtons.OK, MessageBoxIcon.Information);

                objetoConexion.cerrarconexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se eliminaron los datos de la tabla" + ex.ToString());
            }
        }
    }
}
