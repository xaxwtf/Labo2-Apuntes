using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TP_3_Ventas
{
    public class DB
    {
        string connstr;
        public DB(string dir)
        {
            this.connstr = dir;
        }
        public Persona RetornarUnEmpleado(string cuil)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("select Nombre, Apellido, Cuil, Localidad from Table_Employes  where Cuil={0}", cuil);
            string consulta = sb.ToString();
            Persona persona = new Persona();
            SqlConnection cn = new SqlConnection(this.connstr);
            SqlCommand cm = new SqlCommand(consulta, cn);
            try
            {
                cn.Open();
                SqlDataReader sqlDataReader = cm.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    persona.Nombre = sqlDataReader["Nombre"].ToString();
                    persona.Apellido = sqlDataReader["Apellido"].ToString();
                    persona.Cuil = sqlDataReader["Cuil"].ToString();
                    persona.Localidad = sqlDataReader["Localidad"].ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return persona;
        }
        public List<Persona> RetornarTodosLosEmpleados()
        {
            string consulta = "select Nombre, Apellido, Cuil, Localidad from Table_Employes";
            List<Persona> personas = new List<Persona>();
            SqlConnection cn = new SqlConnection(this.connstr);
            SqlCommand cm = new SqlCommand(consulta, cn);
            try
            {
                cn.Open();
                SqlDataReader sqlDataReader = cm.ExecuteReader();
                while(sqlDataReader.Read())
                {
                    Persona nuevo = new Persona();
                    nuevo.Nombre = sqlDataReader["Nombre"].ToString();
                    nuevo.Apellido = sqlDataReader["Apellido"].ToString();
                    nuevo.Cuil = sqlDataReader["Cuil"].ToString();
                    nuevo.Localidad = sqlDataReader["Localidad"].ToString();
                    personas.Add(nuevo);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return personas;
        }
        public bool InsertarCliente(Persona cte)
        {
            bool r = false;
            string consulta = "insert into Table_Clientes (Nombre,Apellido,Cuil,Localidad) values(@Nombre, @Apellido, @CUil, @Localidad)";
            SqlConnection conexion = new SqlConnection(this.connstr);
            SqlCommand comando = new SqlCommand(consulta, conexion);
            
            try
            {
                conexion.Open();
                comando.Parameters.AddWithValue("@Nombre", cte.Nombre);
                comando.Parameters.AddWithValue("@Apellido", cte.Apellido);
                comando.Parameters.AddWithValue("@Cuil", cte.Cuil);
                comando.Parameters.AddWithValue("@Localidad", cte.Localidad);
                if (comando.ExecuteNonQuery() == 1)
                {
                    r = true;
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
            return r;
        }
    }
}
