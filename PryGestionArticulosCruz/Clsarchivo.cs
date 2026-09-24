using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace PryGestionArticulosCruz
{
    internal class Clsarchivo
    {
        public string NombreArchivoRubros = "Archivos/RUBROS.csv";

        public void CargarRubros(ComboBox comboBox)
        {
            StreamReader archivo = new StreamReader(NombreArchivoRubros);
            string linea = archivo.ReadLine();
            while (linea != null)
            {
                comboBox.Items.Add(linea);
                linea = archivo.ReadLine();
            }
            archivo.Close();
        }
        public void Exportar(string rubro, string ruta)
        {
            StreamReader archivo = new StreamReader("Archivos/ARTICULOS.csv");
            StreamWriter exportado = new StreamWriter(ruta);

            exportado.WriteLine("Codigo;Descripcion;Costo;Stock;Valor en Stock");

            string linea = archivo.ReadLine();

            while (linea != null)
            {
                string[] datos = linea.Split(';');

                string codigo = datos[0];
                string descripcion = datos[1];
                decimal costo = Convert.ToDecimal(datos[2]);
                string rubroArticulo = datos[3];
                int stock = Convert.ToInt32(datos[4]);

                if (rubroArticulo == rubro)
                {
                    decimal valorStock = costo * stock;

                    exportado.WriteLine(codigo + ";" + descripcion + ";" +
                                        costo + ";" + stock + ";" + valorStock);
                }

                linea = archivo.ReadLine();
            }

            archivo.Close();
            exportado.Close();
        }
    }
}

    


