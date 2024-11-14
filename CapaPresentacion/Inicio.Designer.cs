
namespace CapaPresentacion
{
    partial class Inicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.USUARIOS = new FontAwesome.Sharp.IconMenuItem();
            this.MANTENEDOR = new FontAwesome.Sharp.IconMenuItem();
            this.submenucategoria = new FontAwesome.Sharp.IconMenuItem();
            this.submenuproducto = new FontAwesome.Sharp.IconMenuItem();
            this.submenunegocio = new FontAwesome.Sharp.IconMenuItem();
            this.VENTAS = new FontAwesome.Sharp.IconMenuItem();
            this.submenuregistrarventa = new FontAwesome.Sharp.IconMenuItem();
            this.submenuverdetalleventa = new FontAwesome.Sharp.IconMenuItem();
            this.COMPRAS = new FontAwesome.Sharp.IconMenuItem();
            this.submenuregistrarcompra = new FontAwesome.Sharp.IconMenuItem();
            this.submenutverdetallecompra = new FontAwesome.Sharp.IconMenuItem();
            this.CLIENTES = new FontAwesome.Sharp.IconMenuItem();
            this.PROVEEDORES = new FontAwesome.Sharp.IconMenuItem();
            this.REPORTES = new FontAwesome.Sharp.IconMenuItem();
            this.submenureportecompras = new FontAwesome.Sharp.IconMenuItem();
            this.submenureporteventas = new FontAwesome.Sharp.IconMenuItem();
            this.ACERCA_DE = new FontAwesome.Sharp.IconMenuItem();
            this.menutitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.btnsalir = new FontAwesome.Sharp.IconButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lblusuario = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.USUARIOS,
            this.MANTENEDOR,
            this.VENTAS,
            this.COMPRAS,
            this.CLIENTES,
            this.PROVEEDORES,
            this.REPORTES,
            this.ACERCA_DE});
            this.menu.Location = new System.Drawing.Point(0, 108);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1703, 104);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // USUARIOS
            // 
            this.USUARIOS.AutoSize = false;
            this.USUARIOS.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.USUARIOS.ForeColor = System.Drawing.Color.Black;
            this.USUARIOS.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.USUARIOS.IconColor = System.Drawing.Color.RoyalBlue;
            this.USUARIOS.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.USUARIOS.IconSize = 50;
            this.USUARIOS.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.USUARIOS.Name = "USUARIOS";
            this.USUARIOS.Size = new System.Drawing.Size(130, 100);
            this.USUARIOS.Text = "USUARIOS";
            this.USUARIOS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.USUARIOS.Click += new System.EventHandler(this.USUARIOS_Click);
            // 
            // MANTENEDOR
            // 
            this.MANTENEDOR.AutoSize = false;
            this.MANTENEDOR.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenucategoria,
            this.submenuproducto,
            this.submenunegocio});
            this.MANTENEDOR.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MANTENEDOR.ForeColor = System.Drawing.Color.Black;
            this.MANTENEDOR.IconChar = FontAwesome.Sharp.IconChar.Wrench;
            this.MANTENEDOR.IconColor = System.Drawing.Color.RoyalBlue;
            this.MANTENEDOR.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.MANTENEDOR.IconSize = 50;
            this.MANTENEDOR.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MANTENEDOR.Name = "MANTENEDOR";
            this.MANTENEDOR.Size = new System.Drawing.Size(130, 100);
            this.MANTENEDOR.Text = "MANTENEDOR";
            this.MANTENEDOR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenucategoria
            // 
            this.submenucategoria.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenucategoria.IconColor = System.Drawing.Color.Black;
            this.submenucategoria.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenucategoria.Name = "submenucategoria";
            this.submenucategoria.Size = new System.Drawing.Size(192, 34);
            this.submenucategoria.Text = "CATEGORIA";
            this.submenucategoria.Click += new System.EventHandler(this.Submenucategoria_Click);
            // 
            // submenuproducto
            // 
            this.submenuproducto.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuproducto.IconColor = System.Drawing.Color.Black;
            this.submenuproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuproducto.Name = "submenuproducto";
            this.submenuproducto.Size = new System.Drawing.Size(192, 34);
            this.submenuproducto.Text = "PRODUCTO";
            this.submenuproducto.Click += new System.EventHandler(this.Submenuproducto_Click);
            // 
            // submenunegocio
            // 
            this.submenunegocio.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenunegocio.IconColor = System.Drawing.Color.Black;
            this.submenunegocio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenunegocio.Name = "submenunegocio";
            this.submenunegocio.Size = new System.Drawing.Size(192, 34);
            this.submenunegocio.Text = "NEGOCIO";
            this.submenunegocio.Click += new System.EventHandler(this.Submenunegocio_Click);
            // 
            // VENTAS
            // 
            this.VENTAS.AutoSize = false;
            this.VENTAS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuregistrarventa,
            this.submenuverdetalleventa});
            this.VENTAS.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VENTAS.ForeColor = System.Drawing.Color.Black;
            this.VENTAS.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.VENTAS.IconColor = System.Drawing.Color.RoyalBlue;
            this.VENTAS.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.VENTAS.IconSize = 50;
            this.VENTAS.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.VENTAS.Name = "VENTAS";
            this.VENTAS.Size = new System.Drawing.Size(130, 100);
            this.VENTAS.Text = "VENTAS";
            this.VENTAS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuregistrarventa
            // 
            this.submenuregistrarventa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuregistrarventa.IconColor = System.Drawing.Color.Black;
            this.submenuregistrarventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuregistrarventa.Name = "submenuregistrarventa";
            this.submenuregistrarventa.Size = new System.Drawing.Size(202, 34);
            this.submenuregistrarventa.Text = "REGISTRAR";
            this.submenuregistrarventa.Click += new System.EventHandler(this.Submenuregistrarventa_Click);
            // 
            // submenuverdetalleventa
            // 
            this.submenuverdetalleventa.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuverdetalleventa.IconColor = System.Drawing.Color.Black;
            this.submenuverdetalleventa.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuverdetalleventa.Name = "submenuverdetalleventa";
            this.submenuverdetalleventa.Size = new System.Drawing.Size(202, 34);
            this.submenuverdetalleventa.Text = "VER DETALLE";
            this.submenuverdetalleventa.Click += new System.EventHandler(this.Submenuverdetalleventa_Click);
            // 
            // COMPRAS
            // 
            this.COMPRAS.AutoSize = false;
            this.COMPRAS.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenuregistrarcompra,
            this.submenutverdetallecompra});
            this.COMPRAS.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.COMPRAS.ForeColor = System.Drawing.Color.Black;
            this.COMPRAS.IconChar = FontAwesome.Sharp.IconChar.CartPlus;
            this.COMPRAS.IconColor = System.Drawing.Color.RoyalBlue;
            this.COMPRAS.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.COMPRAS.IconSize = 50;
            this.COMPRAS.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.COMPRAS.Name = "COMPRAS";
            this.COMPRAS.Size = new System.Drawing.Size(130, 100);
            this.COMPRAS.Text = "COMPRAS";
            this.COMPRAS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenuregistrarcompra
            // 
            this.submenuregistrarcompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenuregistrarcompra.IconColor = System.Drawing.Color.Black;
            this.submenuregistrarcompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenuregistrarcompra.Name = "submenuregistrarcompra";
            this.submenuregistrarcompra.Size = new System.Drawing.Size(202, 34);
            this.submenuregistrarcompra.Text = "REGISTRAR";
            this.submenuregistrarcompra.Click += new System.EventHandler(this.Submenuregistrarcompra_Click);
            // 
            // submenutverdetallecompra
            // 
            this.submenutverdetallecompra.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenutverdetallecompra.IconColor = System.Drawing.Color.Black;
            this.submenutverdetallecompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenutverdetallecompra.Name = "submenutverdetallecompra";
            this.submenutverdetallecompra.Size = new System.Drawing.Size(202, 34);
            this.submenutverdetallecompra.Text = "VER DETALLE";
            this.submenutverdetallecompra.Click += new System.EventHandler(this.Submenutverdetallecompra_Click);
            // 
            // CLIENTES
            // 
            this.CLIENTES.AutoSize = false;
            this.CLIENTES.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLIENTES.ForeColor = System.Drawing.Color.Black;
            this.CLIENTES.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.CLIENTES.IconColor = System.Drawing.Color.RoyalBlue;
            this.CLIENTES.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.CLIENTES.IconSize = 50;
            this.CLIENTES.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CLIENTES.Name = "CLIENTES";
            this.CLIENTES.Size = new System.Drawing.Size(130, 100);
            this.CLIENTES.Text = "CLIENTES";
            this.CLIENTES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.CLIENTES.Click += new System.EventHandler(this.CLIENTES_Click);
            // 
            // PROVEEDORES
            // 
            this.PROVEEDORES.AutoSize = false;
            this.PROVEEDORES.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PROVEEDORES.ForeColor = System.Drawing.Color.Black;
            this.PROVEEDORES.IconChar = FontAwesome.Sharp.IconChar.Truck;
            this.PROVEEDORES.IconColor = System.Drawing.Color.RoyalBlue;
            this.PROVEEDORES.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.PROVEEDORES.IconSize = 50;
            this.PROVEEDORES.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.PROVEEDORES.Name = "PROVEEDORES";
            this.PROVEEDORES.Size = new System.Drawing.Size(130, 100);
            this.PROVEEDORES.Text = "PROVEEDORES";
            this.PROVEEDORES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.PROVEEDORES.Click += new System.EventHandler(this.PROVEEDORES_Click);
            // 
            // REPORTES
            // 
            this.REPORTES.AutoSize = false;
            this.REPORTES.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.submenureportecompras,
            this.submenureporteventas});
            this.REPORTES.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.REPORTES.ForeColor = System.Drawing.Color.Black;
            this.REPORTES.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.REPORTES.IconColor = System.Drawing.Color.RoyalBlue;
            this.REPORTES.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.REPORTES.IconSize = 50;
            this.REPORTES.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.REPORTES.Name = "REPORTES";
            this.REPORTES.Size = new System.Drawing.Size(130, 100);
            this.REPORTES.Text = "REPORTES";
            this.REPORTES.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // submenureportecompras
            // 
            this.submenureportecompras.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenureportecompras.IconColor = System.Drawing.Color.Black;
            this.submenureportecompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenureportecompras.Name = "submenureportecompras";
            this.submenureportecompras.Size = new System.Drawing.Size(252, 34);
            this.submenureportecompras.Text = "REPORTE COMPRAS";
            this.submenureportecompras.Click += new System.EventHandler(this.Submenureportecompras_Click);
            // 
            // submenureporteventas
            // 
            this.submenureporteventas.IconChar = FontAwesome.Sharp.IconChar.None;
            this.submenureporteventas.IconColor = System.Drawing.Color.Black;
            this.submenureporteventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submenureporteventas.Name = "submenureporteventas";
            this.submenureporteventas.Size = new System.Drawing.Size(252, 34);
            this.submenureporteventas.Text = "REPORTE VENTAS";
            this.submenureporteventas.Click += new System.EventHandler(this.Submenureporteventas_Click);
            // 
            // ACERCA_DE
            // 
            this.ACERCA_DE.AutoSize = false;
            this.ACERCA_DE.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ACERCA_DE.ForeColor = System.Drawing.Color.Black;
            this.ACERCA_DE.IconChar = FontAwesome.Sharp.IconChar.Info;
            this.ACERCA_DE.IconColor = System.Drawing.Color.RoyalBlue;
            this.ACERCA_DE.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ACERCA_DE.IconSize = 50;
            this.ACERCA_DE.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ACERCA_DE.Name = "ACERCA_DE";
            this.ACERCA_DE.Size = new System.Drawing.Size(130, 100);
            this.ACERCA_DE.Text = "ACERCA DE";
            this.ACERCA_DE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ACERCA_DE.Click += new System.EventHandler(this.ACERCA_DE_Click);
            // 
            // menutitulo
            // 
            this.menutitulo.AutoSize = false;
            this.menutitulo.BackColor = System.Drawing.Color.RoyalBlue;
            this.menutitulo.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menutitulo.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menutitulo.Location = new System.Drawing.Point(0, 0);
            this.menutitulo.Name = "menutitulo";
            this.menutitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menutitulo.Size = new System.Drawing.Size(1703, 108);
            this.menutitulo.TabIndex = 1;
            this.menutitulo.Text = "menuStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.RoyalBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(500, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "VETERINARIA CAT-DOG";
            // 
            // contenedor
            // 
            this.contenedor.BackColor = System.Drawing.Color.White;
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 212);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1703, 632);
            this.contenedor.TabIndex = 3;
            // 
            // btnsalir
            // 
            this.btnsalir.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnsalir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnsalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsalir.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.btnsalir.IconColor = System.Drawing.Color.White;
            this.btnsalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnsalir.IconSize = 52;
            this.btnsalir.Location = new System.Drawing.Point(1602, 14);
            this.btnsalir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnsalir.Name = "btnsalir";
            this.btnsalir.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.btnsalir.Size = new System.Drawing.Size(88, 78);
            this.btnsalir.TabIndex = 6;
            this.btnsalir.UseVisualStyleBackColor = false;
            this.btnsalir.Click += new System.EventHandler(this.Btnsalir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.RoyalBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(926, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "USUARIO:";
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.ForeColor = System.Drawing.Color.White;
            this.lblusuario.Location = new System.Drawing.Point(1048, 45);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(134, 29);
            this.lblusuario.TabIndex = 8;
            this.lblusuario.Text = "USUARIO:";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1703, 844);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnsalir);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menutitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menu;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menutitulo;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem USUARIOS;
        private FontAwesome.Sharp.IconMenuItem MANTENEDOR;
        private FontAwesome.Sharp.IconMenuItem VENTAS;
        private FontAwesome.Sharp.IconMenuItem COMPRAS;
        private FontAwesome.Sharp.IconMenuItem CLIENTES;
        private FontAwesome.Sharp.IconMenuItem ACERCA_DE;
        private FontAwesome.Sharp.IconMenuItem REPORTES;
        private FontAwesome.Sharp.IconMenuItem PROVEEDORES;
        private System.Windows.Forms.Panel contenedor;
        private FontAwesome.Sharp.IconMenuItem submenucategoria;
        private FontAwesome.Sharp.IconMenuItem submenuproducto;
        private FontAwesome.Sharp.IconMenuItem submenunegocio;
        private FontAwesome.Sharp.IconMenuItem submenuregistrarventa;
        private FontAwesome.Sharp.IconMenuItem submenuverdetalleventa;
        private FontAwesome.Sharp.IconMenuItem submenuregistrarcompra;
        private FontAwesome.Sharp.IconMenuItem submenutverdetallecompra;
        private FontAwesome.Sharp.IconMenuItem submenureportecompras;
        private FontAwesome.Sharp.IconMenuItem submenureporteventas;
        private FontAwesome.Sharp.IconButton btnsalir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblusuario;
    }
}