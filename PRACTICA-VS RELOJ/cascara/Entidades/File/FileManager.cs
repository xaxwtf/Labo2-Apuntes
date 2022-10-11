using Entidades.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entidades.Files
{

    //    4.	FileManager será estática.
    //a.En el constructor de clase realizar: 
    //i.En el atributo path se almacenará la referencia al escritorio de la pc.Y se le concatenara un el nombre de la carpeta del parcial: ej {path escritorio}
    //+\\20220811_Alumno\\
    //ii.Llamar al método ValidaExistenciaDeDirectorio.
    //b.	ValidaExistenciaDeDirectorio:
    //i.Si no existe el directorio almacenado en path, se creará.
    //ii.	En caso de producirse una excepción al momento de la creación, esta deberá ser capturada y relanzada en una nueva excepción denominada FileManagerException, la cual contendrá el mensaje: “Error al crear el directorio”.
    //c.	Guardar:
    //i.Será genérico y solo permitirá que los elementos a almacenar sean tipos por referencia.
    //ii.	Validar la extensión del nombre del archivo. En caso de que sea:
    //1.JSON, se serializará el elemento recibido.
    //2.	TXT, se almacena en texto plano.
    //3.	Cualquier otra extensión se lanzará una excepción denominada FileManagerException, la cual contendrá el mensaje “Extensión no permitida”.

    public static class FileManager
    {
        static string path;
        static FileManager()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "Parcial\\";
           
            
        }
        public static void Guardar<T>(T datos, string nombreArchivo)
        {
            if (Path.GetExtension(nombreArchivo) == ".json")
            {
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                using (StreamWriter writer = new StreamWriter(path + nombreArchivo))
                {
                    string cadenaJson = JsonSerializer.Serialize<T>(datos, options);

                    writer.Write(cadenaJson);
                }

            }
            else if (Path.GetExtension(nombreArchivo) == ".txt")
            {
                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                using (StreamWriter writer = new StreamWriter(path + nombreArchivo))
                {
                    string cadenaJson = JsonSerializer.Serialize<T>(datos, options);

                    writer.Write(cadenaJson);
                }
            }
            else
            {
                throw new FileManagerException("Extencion no permitida");
            }
           
            
           
        }
        private static void ValidaExistenciaDirectorio()
        {
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch(Exception e )
                {
                    throw new FileManagerException("Error, al crear el directorio", e);
                }
                
            }
        }
    }
}
