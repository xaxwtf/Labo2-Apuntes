using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class DataBaseManagerException: Exception
    {
        public DataBaseManagerException(string mensaje) : base(mensaje)
        {

        }
        public DataBaseManagerException(string mensaje, Exception innerExeption) : this(mensaje)
        {
            throw innerExeption;
        }
    }
}
