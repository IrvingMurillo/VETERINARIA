using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.FORMULARIOS;
using FontAwesome.Sharp;

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {

        private static Usuario usuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;
        public Inicio(Usuario objusuario = null)
        {
            if (objusuario == null)
                usuarioActual = new Usuario() { NombreCompleto = "ADMIN PREDEFINIDO", IdUsuario = 1 };
            else
                usuarioActual = objusuario;

            InitializeComponent();
        }

        private void Btnsalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void USUARIOS_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmUsuarios());
        }

        private void Submenucategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MANTENEDOR, new FrmCategoria());
        }

        private void Submenuproducto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MANTENEDOR, new FrmProducto());
        }

        private void Submenunegocio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(MANTENEDOR, new FrmNegocio());
        }

        private void Submenuregistrarventa_Click(object sender, EventArgs e)
        {
            AbrirFormulario(VENTAS, new FrmVentas());

        }

        private void Submenuverdetalleventa_Click(object sender, EventArgs e)
        {
            AbrirFormulario(VENTAS, new FrmDetalleVenta());
        }

        private void Submenuregistrarcompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(COMPRAS, new FrmCompras(usuarioActual));
        }

        private void Submenutverdetallecompra_Click(object sender, EventArgs e)
        {
            AbrirFormulario(COMPRAS, new FrmDetalleCompra());
        }

        private void CLIENTES_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmClientes());
        }

        private void PROVEEDORES_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FrmProveedores());
        }

        private void Submenureportecompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario(REPORTES, new FrmReporteCompras());
        }

        private void Submenureporteventas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(REPORTES, new FrmReporteVentas());
        }

        private void ACERCA_DE_Click(object sender, EventArgs e)
        {
            //mdAcercade md = new mdAcercade();
            //md.ShowDialog();
        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;
            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }
            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.RoyalBlue;
            contenedor.Controls.Add(formulario);
            formulario.Show();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> ListaPermisos = new CN_Permiso().Listar(usuarioActual.IdUsuario);

            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool encontrado = ListaPermisos.Any(m => m.NombreMenu == iconmenu.Name);
                if (encontrado == false)
                {
                    iconmenu.Visible = false;
                }
            }
            lblusuario.Text = usuarioActual.NombreCompleto;
        }
    }
}