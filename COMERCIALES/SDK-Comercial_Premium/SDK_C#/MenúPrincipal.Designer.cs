
namespace ConexiónSDKComercial
{
    partial class MenúPrincipal
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
            this.pnlPrincipalMenuPrincipal = new System.Windows.Forms.Panel();
            this.plnTrabajo = new System.Windows.Forms.Panel();
            this.pnlListas = new System.Windows.Forms.Panel();
            this.lViewListadoClientesProveedores = new System.Windows.Forms.ListView();
            this.pnlLateralIzquierdaAccesoDirectos = new System.Windows.Forms.Panel();
            this.pnlMenuSuperior = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.listadosDeSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesProveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conceptosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cotizaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlPrincipalMenuPrincipal.SuspendLayout();
            this.plnTrabajo.SuspendLayout();
            this.pnlListas.SuspendLayout();
            this.pnlMenuSuperior.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipalMenuPrincipal
            // 
            this.pnlPrincipalMenuPrincipal.Controls.Add(this.plnTrabajo);
            this.pnlPrincipalMenuPrincipal.Controls.Add(this.pnlLateralIzquierdaAccesoDirectos);
            this.pnlPrincipalMenuPrincipal.Controls.Add(this.pnlMenuSuperior);
            this.pnlPrincipalMenuPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipalMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.pnlPrincipalMenuPrincipal.Name = "pnlPrincipalMenuPrincipal";
            this.pnlPrincipalMenuPrincipal.Size = new System.Drawing.Size(1307, 673);
            this.pnlPrincipalMenuPrincipal.TabIndex = 0;
            // 
            // plnTrabajo
            // 
            this.plnTrabajo.Controls.Add(this.pnlListas);
            this.plnTrabajo.Location = new System.Drawing.Point(198, 45);
            this.plnTrabajo.Name = "plnTrabajo";
            this.plnTrabajo.Size = new System.Drawing.Size(1109, 628);
            this.plnTrabajo.TabIndex = 2;
            // 
            // pnlListas
            // 
            this.pnlListas.Controls.Add(this.lViewListadoClientesProveedores);
            this.pnlListas.Location = new System.Drawing.Point(0, 0);
            this.pnlListas.Name = "pnlListas";
            this.pnlListas.Size = new System.Drawing.Size(1109, 628);
            this.pnlListas.TabIndex = 0;
            // 
            // lViewListadoClientesProveedores
            // 
            this.lViewListadoClientesProveedores.HideSelection = false;
            this.lViewListadoClientesProveedores.Location = new System.Drawing.Point(56, 74);
            this.lViewListadoClientesProveedores.Name = "lViewListadoClientesProveedores";
            this.lViewListadoClientesProveedores.Size = new System.Drawing.Size(851, 474);
            this.lViewListadoClientesProveedores.TabIndex = 0;
            this.lViewListadoClientesProveedores.UseCompatibleStateImageBehavior = false;
            // 
            // pnlLateralIzquierdaAccesoDirectos
            // 
            this.pnlLateralIzquierdaAccesoDirectos.Location = new System.Drawing.Point(0, 45);
            this.pnlLateralIzquierdaAccesoDirectos.Name = "pnlLateralIzquierdaAccesoDirectos";
            this.pnlLateralIzquierdaAccesoDirectos.Size = new System.Drawing.Size(200, 628);
            this.pnlLateralIzquierdaAccesoDirectos.TabIndex = 1;
            // 
            // pnlMenuSuperior
            // 
            this.pnlMenuSuperior.Controls.Add(this.menuStrip1);
            this.pnlMenuSuperior.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuSuperior.Name = "pnlMenuSuperior";
            this.pnlMenuSuperior.Size = new System.Drawing.Size(1426, 46);
            this.pnlMenuSuperior.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listadosDeSistemaToolStripMenuItem,
            this.documentosToolStripMenuItem,
            this.conceptosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1426, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // listadosDeSistemaToolStripMenuItem
            // 
            this.listadosDeSistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesProveedoresToolStripMenuItem,
            this.productosToolStripMenuItem});
            this.listadosDeSistemaToolStripMenuItem.Name = "listadosDeSistemaToolStripMenuItem";
            this.listadosDeSistemaToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.listadosDeSistemaToolStripMenuItem.Text = "Listados de sistema";
            // 
            // clientesProveedoresToolStripMenuItem
            // 
            this.clientesProveedoresToolStripMenuItem.Name = "clientesProveedoresToolStripMenuItem";
            this.clientesProveedoresToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.clientesProveedoresToolStripMenuItem.Text = "Clientes/Proveedores";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(232, 26);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // documentosToolStripMenuItem
            // 
            this.documentosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturaToolStripMenuItem,
            this.pagoToolStripMenuItem,
            this.cotizaciónToolStripMenuItem});
            this.documentosToolStripMenuItem.Name = "documentosToolStripMenuItem";
            this.documentosToolStripMenuItem.Size = new System.Drawing.Size(107, 24);
            this.documentosToolStripMenuItem.Text = "Documentos";
            this.documentosToolStripMenuItem.Click += new System.EventHandler(this.documentosToolStripMenuItem_Click);
            // 
            // facturaToolStripMenuItem
            // 
            this.facturaToolStripMenuItem.Name = "facturaToolStripMenuItem";
            this.facturaToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.facturaToolStripMenuItem.Text = "Factura";
            this.facturaToolStripMenuItem.Click += new System.EventHandler(this.facturaToolStripMenuItem_Click);
            // 
            // pagoToolStripMenuItem
            // 
            this.pagoToolStripMenuItem.Name = "pagoToolStripMenuItem";
            this.pagoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.pagoToolStripMenuItem.Text = "Pago";
            this.pagoToolStripMenuItem.Click += new System.EventHandler(this.pagoToolStripMenuItem_Click);
            // 
            // conceptosToolStripMenuItem
            // 
            this.conceptosToolStripMenuItem.Name = "conceptosToolStripMenuItem";
            this.conceptosToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.conceptosToolStripMenuItem.Text = "Conceptos";
            this.conceptosToolStripMenuItem.Click += new System.EventHandler(this.conceptosToolStripMenuItem_Click);
            // 
            // cotizaciónToolStripMenuItem
            // 
            this.cotizaciónToolStripMenuItem.Name = "cotizaciónToolStripMenuItem";
            this.cotizaciónToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.cotizaciónToolStripMenuItem.Text = "Cotización";
            this.cotizaciónToolStripMenuItem.Click += new System.EventHandler(this.cotizaciónToolStripMenuItem_Click);
            // 
            // MenúPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 673);
            this.Controls.Add(this.pnlPrincipalMenuPrincipal);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenúPrincipal";
            this.Text = "MenúPrincipal";
            this.pnlPrincipalMenuPrincipal.ResumeLayout(false);
            this.plnTrabajo.ResumeLayout(false);
            this.pnlListas.ResumeLayout(false);
            this.pnlMenuSuperior.ResumeLayout(false);
            this.pnlMenuSuperior.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPrincipalMenuPrincipal;
        private System.Windows.Forms.Panel plnTrabajo;
        private System.Windows.Forms.Panel pnlLateralIzquierdaAccesoDirectos;
        private System.Windows.Forms.Panel pnlMenuSuperior;
        private System.Windows.Forms.Panel pnlListas;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem listadosDeSistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesProveedoresToolStripMenuItem;
        private System.Windows.Forms.ListView lViewListadoClientesProveedores;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem documentosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conceptosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cotizaciónToolStripMenuItem;
    }
}