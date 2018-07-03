using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    class Fruta
    {
        String nombre, color;
        int puntos;
        public Fruta(String minombre , String micolor, int mispuntos)
        {
            nombre = minombre;
            color = micolor;
            puntos = mispuntos;
        }
    }
}
