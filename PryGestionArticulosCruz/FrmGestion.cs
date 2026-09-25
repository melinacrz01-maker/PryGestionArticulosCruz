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

namespace PryGestionArticulosCruz
{
    public partial class FrmArticulos : Form
    {
        public FrmArticulos()
        {
            InitializeComponent();
        }

        private void grpDatos_Enter(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult respuesta;

            respuesta = MessageBox.Show(
                "¿Desea salir del programa?",
                "Confirmar salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FrmArticulos_Load(object sender, EventArgs e)
        {
            Clsarchivo archivo = new Clsarchivo();
            archivo.CargarRubros(cmbRubros);

            cmbRubros.SelectedIndex = 0;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            Clsarchivo archivo = new Clsarchivo();
            archivo.CargarArticulos(dgvGrilla, cmbRubros.Text);

            lblCantArticulos.Text = archivo.Cantidad.ToString();
            lblTotalStock.Text = "$ " + archivo.Total.ToString();

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivos CSV|*.csv";
            guardar.FileName = "ARTICULOS.csv";

            DialogResult respuesta;

            respuesta = guardar.ShowDialog();

            if (respuesta == DialogResult.OK)
            {
                Clsarchivo archivo = new Clsarchivo();
                archivo.Exportar(cmbRubros.Text, guardar.FileName);

                MessageBox.Show("El archivo se exporto correctamente.");
            }
        }

        private void linkTrabajoEvaluativo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDatos ventana = new FrmDatos();
            ventana.ShowDialog();

        }
    }


}
