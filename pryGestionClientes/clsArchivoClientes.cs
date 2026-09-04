using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace pryGestionClientes
{
    internal class clsArchivoClientes
    {
        public string NombreArchivo = "Clientes.csv";

        public void Grabar(string Cod, string Nom, string Deu, string Lim)
        {
            StreamWriter AD = new StreamWriter(NombreArchivo, true);

            AD.Write(Cod + ";" + Nom + ";" + Deu + ";");
            AD.WriteLine(Lim);



            AD.Close();
            AD.Dispose();

        }

        public void Listar(DataGridView Grilla)
        {
            string DatosLeidos = "";
            string[] VectorDatos = new string[4];


            StreamReader AD = new StreamReader(NombreArchivo);
            
            DatosLeidos = AD.ReadLine();
            
            Grilla.Rows.Clear();

            while (DatosLeidos != null)
            {
                

                VectorDatos = DatosLeidos.Split(';');
               

                Grilla.Rows.Add(VectorDatos[0], VectorDatos[1], VectorDatos[2], VectorDatos[3]);

                DatosLeidos = AD.ReadLine();

            }


            AD.Close();
            AD.Dispose();


        }
    }
}
