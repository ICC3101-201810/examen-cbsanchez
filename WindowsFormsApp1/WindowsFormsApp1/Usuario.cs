using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    class Usuario
    {
        String nombre;
        int puntaje_actual;
        public Usuario(String minombre, int mipuntaje)
        {
            nombre = minombre;
            puntaje_actual = mipuntaje;
        }

        public String  getnombre()
        {
            return nombre;
        }

        public int getpuntos()
        {
            return puntaje_actual;
        }
    }
}
