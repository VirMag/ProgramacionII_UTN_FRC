using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN
{
    public class Ingredientes
    {
        public int IngredienteID { get; set; }
        public string NombreIng { get; set; }
        public int Unidad { get; set; }

        public Ingredientes(int ingredienteID, string nombreIng, int unidad)
        {
            IngredienteID = ingredienteID;
            NombreIng = nombreIng;
            Unidad = unidad;
        }
        public override string ToString()
        {
            return NombreIng;
        }
    }
}
