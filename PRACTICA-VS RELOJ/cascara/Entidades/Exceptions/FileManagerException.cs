﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class FileManagerException:Exception
    {
        public FileManagerException(string mensaje) : base(mensaje)
        {

        }
        public FileManagerException(string mensaje, Exception innerExeption) : this(mensaje)
        {
            throw innerExeption;
        }
    }
}
