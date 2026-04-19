using System;
using System.IO;

namespace DesafioBuscadorArchivos
{
	class Program
	{
		public static void Main(string[] args)
		{
			string rutaCarpeta = AppDomain.CurrentDomain.BaseDirectory;
			
			Console.WriteLine("Analizando carpeta: " + rutaCarpeta);
			Console.WriteLine("---------------------------------------------------");
			
			string[] archivos = Directory.GetFiles(rutaCarpeta);
			
			if (archivos.Length == 0)
			{
				Console.WriteLine("No se encontraron archivos en esta carpeta.");
			}
			
			foreach (string rutaArchivo in archivos)
			{
				FileInfo info = new FileInfo(rutaArchivo);
				
				if (info.Length > 5120)
				{
					Console.WriteLine("BORRANDO: " + info.Name + " (" + (info.Length / 1024.0).ToString("N2") + " KB)");
					
					try {
						info.Delete();
					} catch (Exception ex) {
						Console.WriteLine("Error al borrar: " + ex.Message);
					}
				}
				else
				{
					Console.WriteLine("CUMPLE: " + info.Name + " (" + info.Length + " bytes)");
				}
			}
			
			Console.WriteLine("---------------------------------------------------");
			Console.WriteLine("Proceso terminado.");
			Console.Write("Presione cualquier tecla para salir...");
			Console.ReadKey(true);
		}
	}
}