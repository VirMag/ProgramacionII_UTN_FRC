using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OtraDelBanco
{
    public partial class Form1 : Form
    {
        Conexiones oBD = new Conexiones();
        public Form1()
        {
            InitializeComponent();
            cargarCombo();
            CargaDGV();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void cargarCombo()
        {
            DataTable tabla = oBD.ConsultarBD("SP_CARGA_COMB");


            cboTipoCta.DataSource = tabla;
            cboTipoCta.ValueMember = tabla.Columns[0].ColumnName;
            cboTipoCta.DisplayMember = tabla.Columns[1].ColumnName;
            cboTipoCta.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            string nombreSP;
            Clientes C = new Clientes();
            C.pNombre = txtNombre.Text;
            C.pApellido = txtApellido.Text;
            C.pDNI = Convert.ToInt32(txtDNI.Text);


            nombreSP = "SP_INSERT_BCO";
            List<Parametro> lista = new List<Parametro>();
            lista.Add(new Parametro("@nombre", C.pNombre));
            lista.Add(new Parametro("@apellido", C.pApellido));
            lista.Add(new Parametro("@DNI", C.pDNI));

            oBD.ActualizarBD(nombreSP, lista);
            //CargarLista();
            //Habilitar(false);
        }
        public void CargaDGV()
        {
            DataTable Tabla = oBD.ConsultarBD("SP_cargar_dgv");

            foreach (DataRow row in Tabla.Rows)
            {
                Clientes oCliente = new Clientes();
                oCliente.pId_cliente = Convert.ToInt32(row["id_cliente"]);
                // oCliente.pNCliente = Convert.ToInt32(row["id_cliente"].ToString());
                oCliente.pNombre = (row["nombre"].ToString());
                oCliente.pDNI = Convert.ToInt32(row["DNI"].ToString());
                //oCliente.pId_cuenta = Convert.ToInt32(row["id_cuenta"].ToString());
                //Tabla.Rows.Add(oCliente);
                dgvClientes.Rows.Add(new object[] { oCliente.pId_cliente, oCliente.pNombre, oCliente.pDNI });
            }
            //Tabla = conexion.SPLevantaBD; //es un select * from clientes

            //dgvClientes.DataSource = Tabla;

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvClientes.CurrentRow.Index > 0)
            {
                //txtNcliente.Text = dgvClientes.CurrentRow.Cells["id_cliente"].Value.ToString();
                txtNombre.Text = dgvClientes.CurrentRow.Cells["nombre"].Value.ToString();
                txtApellido.Text = dgvClientes.CurrentRow.Cells["apellido"].Value.ToString();
                txtDNI.Text = dgvClientes.CurrentRow.Cells["DNI"].Value.ToString();


            }
        }
    }
}

