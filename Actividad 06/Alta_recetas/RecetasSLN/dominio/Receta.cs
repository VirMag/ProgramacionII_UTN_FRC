using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN
{
    public class Receta
    {
        public int RecetaNro { get; set; }
        public string NombreReceta { get; set; }
        public int TipoReceta { get; set; }
        public string Cheff { get; set; }

        public List<DetalleReceta> Detalles { get; set; }


        public Receta()
        {
            Detalles = new List<DetalleReceta>();
        }

        public void AgregarDetalle(DetalleReceta detalle)
        {
            Detalles.Add(detalle);

        }
        public void QuitarDetalle(int Indice)
        {
            Detalles.RemoveAt(Indice);
        }
        public double CalcularTotal()
        {
            double total = 0;
            foreach (DetalleReceta item in Detalles)
                total += item.CalcularSubTotal();
            return total;
           // return lblTotalIng+' '+(string)total;
        }
        
    }
}
