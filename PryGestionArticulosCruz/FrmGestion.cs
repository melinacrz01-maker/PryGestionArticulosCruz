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
            StreamReader archivo = new StreamReader("Archivos/RUBROS.csv");

            string linea = archivo.ReadLine();

            while (linea != null)
            {
                cmbArticulos.Items.Add(linea);
                linea = archivo.ReadLine();
            }
            archivo.Close();

            cmbArticulos.SelectedIndex = 1;
        }
    }


}
