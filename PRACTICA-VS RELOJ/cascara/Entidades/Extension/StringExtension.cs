using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Extension
{
    //9.	Extenderá la clase String la cual adicionará un método denominado
    //    ObtenerNombreYApellido en el cual su función principal será devolver un
    //    array de strings, mediante la separación de la cadena en subcadenas.
    //    El carácter para determinar la separación será el guion medio.
    public static  class StringExtension 
    {
        public static List<string> ObtenerNombreyApellido(this string  txt)
        {
            List<string> lista=new List<string>();
            for(int i = 0; i < txt.Length; i++)
            {
                
                if (txt[i] == '-')
                {
                 
                    lista.Add(txt.Substring(0,(i-1)));
                    lista.Add(txt.Substring(i+1,txt.Length-i-1));
                    break;
                }
            }
            
            return lista;
        }

        
    }
}
