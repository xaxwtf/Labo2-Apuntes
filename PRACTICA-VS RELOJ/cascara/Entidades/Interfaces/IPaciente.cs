using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface IPaciente
    {
        public abstract bool EstaAtendido{get;}
        public abstract string Identificador { get; }
        public abstract void Anunciarse();
        public abstract void Atender();
    }
}
