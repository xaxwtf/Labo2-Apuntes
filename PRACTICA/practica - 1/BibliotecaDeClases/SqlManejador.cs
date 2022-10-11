using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace BibliotecaDeClases
{

    // DESARROLLAR
    public  class SqlManejador
    {
        private  SqlCommand comando;
        private   SqlConnection connexion;
       
        public SqlManejador()
        {
            this.connexion = new SqlConnection("Server=ROOT;Database=utn_test;Trusted_Connection=True;");
            

        }
        public int Insertar(EmpleadoFreelance dato)
        {
            int r = 0;
            if((dato.Dni<10000000 || dato.Dni > 45000000) || (dato.NombreCompleto==null || dato.NombreCompleto==""))
            {
                throw new DatoErroneoException("La Informacion no es Valida");
            }
            string textCommand = "INSERT INTO empleados (dni, nombreCompleto, puestoAcubrir) VALUES(@dni, @nombreCompleto, @puestoAcubir)";
            this.comando = new SqlCommand(textCommand, this.connexion);

            this.comando.Parameters.AddWithValue("@dni", dato.Dni);
            this.comando.Parameters.AddWithValue("@nombreCompleto", dato.NombreCompleto);
            this.comando.Parameters.AddWithValue("@puestoAcubir", dato.Posicion);

            this.connexion.Open();
            r=this.comando.ExecuteNonQuery();//using in  insersiones/deletes and edit
            this.connexion.Close();

            return r;
        }
    }
}
