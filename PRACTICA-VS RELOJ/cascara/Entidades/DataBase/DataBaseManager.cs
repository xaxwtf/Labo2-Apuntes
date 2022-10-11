using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades.Exceptions;
using System.Text.Json;
using Entidades.Interfaces;

namespace Entidades.DataBase
{
    //    8.	DataBaseManager será estática:
    //a.En el constructor de clase inicializar el string connection.
    //b.ObtenerPaciente, recibirá el id del paciente a obtener.Retornara un string que contendrá el nombre y apellido concatenado con un guion medio, Ej: $"{reader.GetString(2)}-{reader.GetString(1)}".
    //c.Si el id no existe se lanzará una excepción DataBaseManagerException, indicando Id inexistente.
    //d.Por cualquier otro error se capturara y se re lanzara en una excepción DataBaseManagerException indicando error al leer de la base de datos.

    public static class DataBaseManager
    {
        
        private static SqlConnection connexion;
        private static string stringConnexion; 

        static DataBaseManager()
        {
            connexion = new SqlConnection("Server=ROOT;Database=test2;Trusted_Connection=True;");


        }
        /*public int Insertar(EmpleadoFreelance dato)
        {
            int r = 0;
            if ((dato.Dni < 10000000 || dato.Dni > 45000000) || (dato.NombreCompleto == null || dato.NombreCompleto == ""))
            {
                throw new DatoErroneoException("La Informacion no es Valida");
            }
            string textCommand = "INSERT INTO empleados (dni, nombreCompleto, puestoAcubrir) VALUES(@dni, @nombreCompleto, @puestoAcubir)";
            this.comando = new SqlCommand(textCommand, this.connexion);

            this.comando.Parameters.AddWithValue("@dni", dato.Dni);
            this.comando.Parameters.AddWithValue("@nombreCompleto", dato.NombreCompleto);
            this.comando.Parameters.AddWithValue("@puestoAcubir", dato.Posicion);

            this.connexion.Open();
            r = this.comando.ExecuteNonQuery();//using in  insersiones/deletes and edit
            this.connexion.Close();

            return r;
        }*/
        public static string ObtenerUnPaciente(int id)
        {
            string r = "";
            SqlCommand comando = new SqlCommand("SELECT * FROM pacientes where id=@id", connexion);
            comando.Parameters.AddWithValue("@id", id);
            try
            {
                connexion.Open();
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    reader.Read();
                    r = reader["nombre"].ToString() + "-" + reader["apellido"].ToString();
                }
               
            }
            catch(Exception e)
            {
                throw new DataBaseManagerException("Error, al leer en base de datos", e);
            }
            finally
            {
                connexion.Close();
            }
            return r;
        }
    }
}
