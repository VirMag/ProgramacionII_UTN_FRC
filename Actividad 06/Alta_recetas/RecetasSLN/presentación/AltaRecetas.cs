using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace RecetasSLN
{
    public partial class AltaRecetas : Form
    {
        private IDaoRecetas

        private Receta nueva;
        public AltaRecetas()
        {
            InitializeComponent();
           
           // CargarProductos();
            nueva = new Receta();
        }

        private void lblNroReceta_Click(object sender, EventArgs e)
        {

        }

        private void AltaRecetas_Load(object sender, EventArgs e)
        {

        }
    }
}
