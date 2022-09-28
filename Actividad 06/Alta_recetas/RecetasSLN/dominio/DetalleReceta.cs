using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN
{
    public class DetalleReceta
    {
        public Ingredientes Ingrediente { get; set; }
        public int Cantidad { get; set; }  

        public DetalleReceta(Ingredientes ingrediente, int cantidad)
        {
            this.Ingrediente = ingrediente;
            Cantidad = cantidad;
        }
        public double CalcularSubTotal()
        {
            return Ingrediente.Unidad * Cantidad;
        }
    }
}
