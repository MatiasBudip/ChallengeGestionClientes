using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.GestionClientes
{
    public class Utilidades
    {
        public static string UrlApiClientes(bool entorno = false)
        {
            if (entorno)
            {
                return "http://nanosystem-001-site3.htempurl.com/";
            }
            else
            {
                return "https://localhost:7073/";
            }
        }

        public static bool esProduccion()
        {
            //return false;
            return true;
        }
    }
}
