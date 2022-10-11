using Entidades.DataBase;
using Entidades.Extension;
using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
    //    13.	Paciente, heredará de persona e implementará la interfaz IPaciente
    //a.Atender, cambiara el estado del paciente a True.
    //b.La propiedad Identificarse retornara un string con el texto “Paciente” + el HashCode de la instancia + el nombre y el apellido separados por coma.
    //c.Anunciarse, leerá desde la BD una paciente de manera aleatoria (entre 1 y 100), separara el nombre y apellido de la cadena y los asignará a los atributos de la instancia.
    //d.MostrarDatos retorna el nombre y el apellido separado por coma.
    //e.Sobrescribir el toString y exponer MostrarDatos.

    public class Paciente:Persona ,IPaciente
    {

        private bool estado;

        public Paciente()
        {
            this.estado = false;
        }
        public bool EstaAtendido => this.estado;

        public string Identificador {
            get
            {
                
                return "Paciente " + this.GetHashCode() +"  "+ this.nombre + "," + this.apellido;
            }
        } 

        public void Anunciarse()
        {
            Random rn =  new Random();     
            int idAleatorio = rn.Next(1, 100);
            try
            {
                string resultado = DataBaseManager.ObtenerUnPaciente(idAleatorio);
                List<string> datos = resultado.ObtenerNombreyApellido();
                this.nombre = datos[0].ToString();
                this.apellido = datos[1].ToString();
            }
            catch(Exception e)
            {
                throw e;
            }
            
           
        }

        public void Atender()
        {
            this.estado = true;
        }
        protected override string MostrarDatos()
        {
            return this.nombre+","+this.apellido+","+this.estado;
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        
    }
    public delegate void DelegadoDemoraAtencion(double demora);
    public delegate void DelegadoNuevoIngreso(IPaciente paciente);
}
