using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace BibliotecaDeClases
{


    // DESARROLLAR
    public static class Serializador
    {
        public static void Escribir<T>(T datos, string ruta, string nombreArchivo, Action<string> mostrarElementos)
        {
            //string rutaEscritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//ruta al escritorio
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }
            string path = ruta + nombreArchivo+".json";
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.WriteIndented = true;
            using (StreamWriter writer = new StreamWriter(path))
            {
                string cadenaJson = JsonSerializer.Serialize<T>(datos, options);

                writer.Write(cadenaJson);
            }
            mostrarElementos.Invoke("el Empleado a Sido Serializado Correctamente");
        }
      
    }
}
