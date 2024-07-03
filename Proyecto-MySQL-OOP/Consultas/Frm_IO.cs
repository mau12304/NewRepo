using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Proyecto_MySQL_OOP.Consultas
{
    public partial class Frm_IO : Form
    {
        public Frm_IO()
        {
            InitializeComponent();
        }

        private void btncalcular_Click(object sender, EventArgs e)
        {
            double c1 = double.Parse(txtx.Text);
            double c2 = double.Parse(txty.Text);

            // Coeficientes y valor del lado derecho de las restricciones
            double[,] restricciones = new double[2, 2];
            double[] valoresB = new double[2];

            restricciones[0, 0] = double.Parse(txtx11.Text);
            restricciones[0, 1] = double.Parse(txty12.Text);
            valoresB[0] = double.Parse(txtb1.Text);

            restricciones[1, 0] = double.Parse(txtx21.Text);
            restricciones[1, 1] = double.Parse(txty22.Text);
            valoresB[1] = double.Parse(txtb2.Text);

            // Puntos de intersección de las restricciones
            double x1 = (valoresB[0] - restricciones[0, 1] * valoresB[1] / restricciones[1, 1]) / (restricciones[0, 0] - restricciones[0, 1] * restricciones[1, 0] / restricciones[1, 1]);
            double y1 = (valoresB[1] - restricciones[1, 0] * x1) / restricciones[1, 1];

            // Punto óptimo
            double xOpt = x1;
            double yOpt = y1;
            double zOpt = c1 * xOpt + c2 * yOpt;
            // Mostrar punto óptimo en MessageBox
            MessageBox.Show($"Punto óptimo:\n x = {xOpt}\n y = {yOpt}\n z = {zOpt}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);


            // Creando gráfica
            Chart grafico = new Chart();
            grafico.Size = new System.Drawing.Size(400, 300);
            grafico.ChartAreas.Add(new ChartArea("PlanoCartesiano"));

           // Agregando las líneas de las restricciones
            for (int i = 0; i < 2; i++)
            {
                Series lineaRestriccion = new Series
                {
                    ChartType = SeriesChartType.Line
                };
                lineaRestriccion.Points.AddXY(0, valoresB[i] / restricciones[i, 1]);
                lineaRestriccion.Points.AddXY(valoresB[i] / restricciones[i, 0], 0);

                grafico.Series.Add(lineaRestriccion);
            }

            // Agregando puntos de intersección y punto óptimo
            grafico.Series.Add(new Series
            {
                ChartType = SeriesChartType.Point,
                Points = {
                new DataPoint(x1, y1),
                new DataPoint(xOpt, yOpt)
                }
            } );

            // Mostrar gráfica
            Form formularioGrafico = new Form();
            formularioGrafico.Text = "Gráfico";
            formularioGrafico.Controls.Add(grafico);
            formularioGrafico.ShowDialog();
        }
        private void btnMenu_Click(object sender, EventArgs e)
        {
            Frm1 obj = new Frm1();
            this.Hide();    
            obj.Show();   
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtb1.Clear();
            txtb2.Clear();
            txtx.Clear();
            txty.Clear();
            txtx11.Clear();
            txtx21.Clear();
            txty12.Clear(); 
            txty22.Clear();

        }
    }
}
