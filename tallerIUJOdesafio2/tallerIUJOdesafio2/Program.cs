using System;
using System.IO;

namespace DesafioClonador
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** SISTEMA DE CLONACIÓN DE ARCHIVOS ***");

            string archivoPorDefecto = "avatar.jpg";
            
            if (!File.Exists(archivoPorDefecto))
            {
                byte[] datosPrueba = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }; 
                File.WriteAllBytes(archivoPorDefecto, datosPrueba);
                

                Console.WriteLine("[INFO]: Se ha generado 'avatar.jpg' automáticamente para la prueba.");
            }
            // ---------------------------------------

            Console.Write("\nIntroduce el nombre del archivo origen (ej: {0}): ", archivoPorDefecto);
            string origen = Console.ReadLine();

            Console.Write("Introduce el nombre del nuevo archivo (ej: respaldo.jpg): ");
            string destino = Console.ReadLine();


            if (!File.Exists(origen))
            {
                Console.WriteLine("\n[ERROR]: El archivo '{0}' no se encuentra.", origen);
            }
            else
            {
                try
                {

                    using (FileStream fsOrigen = new FileStream(origen, FileMode.Open, FileAccess.Read))
                    using (FileStream fsDestino = new FileStream(destino, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[1024];
                        int bytesLeidos;

                        Console.WriteLine("\nCopiando datos...");

                        while ((bytesLeidos = fsOrigen.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fsDestino.Write(buffer, 0, bytesLeidos);
                            Console.Write(".");
                        }
                    }

                    Console.WriteLine("\n\n¡Éxito! El archivo ha sido clonado correctamente.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nSucedió un error inesperado: " + ex.Message);
                }
            }

            Console.WriteLine("\nPresiona cualquier tecla para cerrar el programa...");
            Console.ReadKey();
        }
    }
}