using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtraDelBanco
{
    internal class Clientes
    {
        private int id_cliente;
       // private int NCliente;
        private string nombre;
        private string apellido;
        private int DNI;

        public int pId_cliente { get; set; }
      //  public int pNCliente { get; set; }
        public string pNombre { get; set; }
        public string pApellido { get; set; }
        public int pDNI { get; set; }

        public int pId_cuenta { get; set; }


    }
}
