
namespace SDKContabilidadBancos
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.bttnRegistrarProveedor = new System.Windows.Forms.Button();
            this.bttnEgresoAsoc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bttnRegistrarProveedor
            // 
            this.bttnRegistrarProveedor.Location = new System.Drawing.Point(28, 13);
            this.bttnRegistrarProveedor.Name = "bttnRegistrarProveedor";
            this.bttnRegistrarProveedor.Size = new System.Drawing.Size(203, 30);
            this.bttnRegistrarProveedor.TabIndex = 0;
            this.bttnRegistrarProveedor.Text = "Nuevo Proveedor";
            this.bttnRegistrarProveedor.UseVisualStyleBackColor = true;
            this.bttnRegistrarProveedor.Click += new System.EventHandler(this.bttnRegistrarProveedor_Click);
            // 
            // bttnEgresoAsoc
            // 
            this.bttnEgresoAsoc.Location = new System.Drawing.Point(28, 65);
            this.bttnEgresoAsoc.Name = "bttnEgresoAsoc";
            this.bttnEgresoAsoc.Size = new System.Drawing.Size(203, 28);
            this.bttnEgresoAsoc.TabIndex = 1;
            this.bttnEgresoAsoc.Text = "Egreso con Asociación";
            this.bttnEgresoAsoc.UseVisualStyleBackColor = true;
            this.bttnEgresoAsoc.Click += new System.EventHandler(this.bttnEgresoAsoc_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 327);
            this.Controls.Add(this.bttnEgresoAsoc);
            this.Controls.Add(this.bttnRegistrarProveedor);
            this.Name = "MainForm";
            this.Text = "InicioSesion";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bttnRegistrarProveedor;
        private System.Windows.Forms.Button bttnEgresoAsoc;
    }
}

