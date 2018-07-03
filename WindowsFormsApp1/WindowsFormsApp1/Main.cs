using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    class Main
    {
        List<Usuario> usuarios = new List<Usuario>();
        public Main()
        {

        }
        
        public void agregarUsuario(Usuario u)
        {
            usuarios.Add(u);
        }
        
        public List<Usuario> Listaordenada()
        {
            //List<Usuario> listaO = new List<Usuario>();
            if (usuarios.Count() == 0)
            {
                List<Usuario> listaO = new List<Usuario>();
                return listaO;
            }
            else
            {
                List<Usuario> listaO = usuarios.OrderByDescending(u => u.getpuntos()).ToList();
                return listaO;
            }
           
        }
        


    }
}
