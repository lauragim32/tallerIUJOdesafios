using System;
using System.IO;

namespace tallerIUJOdesafio1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== VALIDADOR DE SEGURIDAD IUJO ===");
            Console.Write("Ingrese los datos (usuario;clave): ");
            string entrada = Console.ReadLine();

            // Dividimos la entrada para obtener el nombre y la clave que sea
            string[] partes = entrada.Split(';');

            // Verificamos que al menos haya escrito el separador para poder evaluar
            if (partes.Length >= 2)
            {
                string usuario = partes[0].Trim();
                string clave = partes[1].Trim();

                // Aquí está la condición clave:
                if (clave.Contains("123"))
                {
                    // Si la clave tiene "123", guardamos el aviso con el nombre que el usuario puso
                    using (StreamWriter sw = new StreamWriter("seguridad.txt", false))
                    {
                        sw.WriteLine("Clave Débil detectada para el usuario: " + usuario);
                    }
                    Console.WriteLine("\n RESULTADO: Clave Débil detectada.");
                }
                else
                {
                    // Si la clave NO tiene "123", no importa el usuario, es segura
                    Console.WriteLine("\n RESULTADO: Clave segura.");
                    
                    // Borramos archivos de alertas anteriores para que la inspección esté limpia
                    if (File.Exists("seguridad.txt")) { File.Delete("seguridad.txt"); }
                }
            }
            else 
            {
                // Este mensaje solo sale si no usas el ";" (que es necesario para separar usuario de clave)
                Console.WriteLine("\n Formato no reconocido. Asegúrese de usar ';'");
            }

            // Bloque de inspección
            Console.WriteLine("\n Inspeccionando seguridad.txt:");
            if (File.Exists("seguridad.txt"))
            {
                using (StreamReader sr = new StreamReader("seguridad.txt"))
                {
                    Console.WriteLine(" CONTENIDO: " + sr.ReadToEnd());
                }
            }
            else
            {
                Console.WriteLine(" (El archivo está vacío, no hay claves débiles)");
            }

            Console.WriteLine("\n=== PROCESO FINALIZADO. ===");
            Console.ReadKey(true);
        }
    }
}