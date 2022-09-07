using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtraDelBanco.Dominio
{
    internal class Cuentas
    {
        private int IdCuenta;
        private int Cbu;
        private int IdTipos;
        private int UltimoMovimiento;
        private decimal Saldos;
        private int IdCliente;

        public int pIdCuenta { get; set; }
        public int pCbu { get; set; }
        public int pIdTipos { get; set; }
        public int pUltimoMovimiento { get; set; }
        public int pSaldos { get; set; }

        public int pIdCliente { get; set; }

    }
}
