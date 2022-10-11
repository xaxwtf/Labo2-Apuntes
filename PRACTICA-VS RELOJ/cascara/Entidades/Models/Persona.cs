using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Models
{
    //    12.	Persona, será abstracta.
    //a.Sus dos atributos serán privados.
    //b.MostrarDatos protegido y abstracto.
    //c.Sobre escribir Equals y comparar las personas por apellido.

    public abstract class Persona 
    { 
        protected string apellido;
        protected string nombre;
        protected abstract string MostrarDatos();
        public override bool Equals(object obj)
        {
            bool r = false;
            if (obj != null)
            {
                if (this.apellido == obj.ToString()) 
                {
                    r = true;
                }
            }
            
            return r;
        }


    }
}
