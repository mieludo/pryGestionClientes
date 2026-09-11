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

        public void Grabar(string Cod, string Nom, string Lim, string Deu)
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


                Grilla.Rows.Add(VectorDatos[0], VectorDatos[1], VectorDatos[3], VectorDatos[2]);

                DatosLeidos = AD.ReadLine();

            }


            AD.Close();
            AD.Dispose();


        }

        public int CantidadClientes()
        {
            int c = 0;
            string DatosLeidos = "";

            StreamReader AD = new StreamReader(NombreArchivo);

            DatosLeidos = AD.ReadLine();

            while (DatosLeidos != null)
            {
                c++;
                DatosLeidos = AD.ReadLine();
            }

            AD.Close();
            AD.Dispose();

            return c;
        }
        public Decimal DeudaClientes()
        {
            string DatosLeidos = "";
            string[] VectorDatos = new string[4];
            Decimal Total = 0;


            StreamReader AD = new StreamReader(NombreArchivo);

            DatosLeidos = AD.ReadLine();



            while (DatosLeidos != null)
            {


                VectorDatos = DatosLeidos.Split(';');


                Total = Total + Convert.ToDecimal(VectorDatos[2]);

                DatosLeidos = AD.ReadLine();

            }


            AD.Close();
            AD.Dispose();

            return Total;

        }
        public decimal Promedio()
        {
            string DatosLeidos = "";
            string[] VectorDatos = new string[4];
            decimal Total = 0;
            Int32 c = 0;


            StreamReader AD = new StreamReader(NombreArchivo);

            DatosLeidos = AD.ReadLine();

            while (DatosLeidos != null)
            {
                VectorDatos = DatosLeidos.Split(';');

                c++;
                Total = Total + Convert.ToDecimal(VectorDatos[2]);
                

                DatosLeidos = AD.ReadLine();
            }
            AD.Close();
            AD.Dispose();

            return Total / c;
        }

        public void ListarDeudores(DataGridView Grilla)
        {
            string DatosLeidos = "";
            string[] VectorDatos = new string[4];

            StreamReader AD = new StreamReader(NombreArchivo);

            DatosLeidos = AD.ReadLine();
            Grilla.Rows.Clear();

            while (DatosLeidos != null)
            {
                VectorDatos = DatosLeidos.Split(';');

                if (Convert.ToDecimal(VectorDatos[2]) > 0)
                {
                    Grilla.Rows.Add(
                        VectorDatos[0],
                        VectorDatos[1],
                        VectorDatos[3],
                        VectorDatos[2]
                    );
                }

                DatosLeidos = AD.ReadLine();
            }

            AD.Close();
            AD.Dispose();
        }
        public decimal CantidadDeudores()
        {
            string DatosLeidos = "";
            string[] VectorDatos = new string[4];
            
            Int32 c = 0;


            StreamReader AD = new StreamReader(NombreArchivo);

            DatosLeidos = AD.ReadLine();

            while (DatosLeidos != null)
            {
                VectorDatos = DatosLeidos.Split(';');

                if(Convert.ToDecimal(VectorDatos[2]) > 0)
                { 
                    c++;
                }
                DatosLeidos = AD.ReadLine();
            }
            AD.Close();
            AD.Dispose();

            return c;
        }
        public decimal PromedioDeudores()
        {
            string DatosLeidos = "";
            string[] VectorDatos = new string[4];
            decimal Total = 0;
            Int32 c = 0;


            StreamReader AD = new StreamReader(NombreArchivo);

            DatosLeidos = AD.ReadLine();

            while (DatosLeidos != null)
            {
                VectorDatos = DatosLeidos.Split(';');

                if(Convert.ToDecimal(VectorDatos[2]) > 0)
                {
                    c++;
                    Total = Total + Convert.ToDecimal(VectorDatos[2]);
                }

                DatosLeidos = AD.ReadLine();
            }
            
            AD.Close();
            AD.Dispose();

            return Total / c;
        }

        public void GenerarReporte()
        {
            string DatosLeidos = "";
            string[] VectorDatos = new string[4];

            Int32 cantidad = 0;
            Decimal total = 0;

            StreamWriter Reporte = new StreamWriter("Reporte.csv",false,Encoding.UTF8);

            Reporte.WriteLine("");
            Reporte.WriteLine("Listado de Clientes");
            Reporte.WriteLine("");
            Reporte.WriteLine("Código;Nombre;Límite;Deuda");

            StreamReader AD = new StreamReader(NombreArchivo);

            DatosLeidos = AD.ReadLine();

            while (DatosLeidos != null)
            {
                VectorDatos = DatosLeidos.Split(';');

                Reporte.Write(VectorDatos[0]);
                Reporte.Write(";");
                Reporte.Write(VectorDatos[1]);
                Reporte.Write(";");
                Reporte.Write(VectorDatos[3]);
                Reporte.Write(";");
                Reporte.WriteLine(VectorDatos[2]);

                cantidad++;
                total = total + Convert.ToDecimal(VectorDatos[2]);

                DatosLeidos = AD.ReadLine();
            }

            AD.Close();
            AD.Dispose();

            Reporte.WriteLine("");
            Reporte.Write("Total de Deuda:;;");
            Reporte.WriteLine(total);
            Reporte.Write("Cantidad de Clientes:;;");
            Reporte.WriteLine(cantidad);
            Reporte.Write("Promedio de Deuda:;;");
            Reporte.WriteLine(total / cantidad);

            Reporte.Close();
            Reporte.Dispose();
        }
        public void CargarDatosIniciales()
        {
            if (CantidadClientes() == 0)
            {
                Grabar("1", "Joa", "1000", "500");
                Grabar("2", "Gise", "2000", "0");
                Grabar("3", "Lau", "2000", "1000");
                Grabar("4", "Ariel", "3000", "0");
            }
        }
    }
}
