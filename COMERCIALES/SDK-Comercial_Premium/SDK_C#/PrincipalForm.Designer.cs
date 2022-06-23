
namespace ConexiónSDKComercial
{
    partial class PrincipalForm
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
            this.bttnIniciarConexion = new System.Windows.Forms.Button();
            this.bttnDetenerConexion = new System.Windows.Forms.Button();
            this.pnlCentralConexionSDK = new System.Windows.Forms.Panel();
            this.listVListaDeEmpresas = new System.Windows.Forms.ListView();
            this.clnEmpresaListV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnUbicacionEmpresa = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTituloConexiónSDK = new System.Windows.Forms.Label();
            this.bttnVerError = new System.Windows.Forms.Button();
            this.tboxCodigoError = new System.Windows.Forms.TextBox();
            this.pnlCentralConexionSDK.SuspendLayout();
            this.SuspendLayout();
            // 
            // bttnIniciarConexion
            // 
            this.bttnIniciarConexion.Location = new System.Drawing.Point(515, 401);
            this.bttnIniciarConexion.Name = "bttnIniciarConexion";
            this.bttnIniciarConexion.Size = new System.Drawing.Size(109, 37);
            this.bttnIniciarConexion.TabIndex = 0;
            this.bttnIniciarConexion.Text = "Iniciar";
            this.bttnIniciarConexion.UseVisualStyleBackColor = true;
            this.bttnIniciarConexion.Click += new System.EventHandler(this.bttnIniciarConexion_Click);
            // 
            // bttnDetenerConexion
            // 
            this.bttnDetenerConexion.Location = new System.Drawing.Point(654, 401);
            this.bttnDetenerConexion.Name = "bttnDetenerConexion";
            this.bttnDetenerConexion.Size = new System.Drawing.Size(104, 37);
            this.bttnDetenerConexion.TabIndex = 1;
            this.bttnDetenerConexion.Text = "Detener";
            this.bttnDetenerConexion.UseVisualStyleBackColor = true;
            this.bttnDetenerConexion.Click += new System.EventHandler(this.bttnDetenerConexion_Click);
            // 
            // pnlCentralConexionSDK
            // 
            this.pnlCentralConexionSDK.Controls.Add(this.listVListaDeEmpresas);
            this.pnlCentralConexionSDK.Location = new System.Drawing.Point(-1, 56);
            this.pnlCentralConexionSDK.Name = "pnlCentralConexionSDK";
            this.pnlCentralConexionSDK.Size = new System.Drawing.Size(770, 322);
            this.pnlCentralConexionSDK.TabIndex = 2;
            // 
            // listVListaDeEmpresas
            // 
            this.listVListaDeEmpresas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnEmpresaListV,
            this.clnUbicacionEmpresa});
            this.listVListaDeEmpresas.FullRowSelect = true;
            this.listVListaDeEmpresas.HideSelection = false;
            this.listVListaDeEmpresas.Location = new System.Drawing.Point(0, 0);
            this.listVListaDeEmpresas.Name = "listVListaDeEmpresas";
            this.listVListaDeEmpresas.Size = new System.Drawing.Size(770, 322);
            this.listVListaDeEmpresas.TabIndex = 0;
            this.listVListaDeEmpresas.UseCompatibleStateImageBehavior = false;
            this.listVListaDeEmpresas.View = System.Windows.Forms.View.Details;
            this.listVListaDeEmpresas.SelectedIndexChanged += new System.EventHandler(this.listVListaDeEmpresas_SelectedIndexChanged);
            // 
            // clnEmpresaListV
            // 
            this.clnEmpresaListV.Tag = "Empresa";
            this.clnEmpresaListV.Text = "Empresa";
            this.clnEmpresaListV.Width = 200;
            // 
            // clnUbicacionEmpresa
            // 
            this.clnUbicacionEmpresa.Text = "Ubicación";
            this.clnUbicacionEmpresa.Width = 500;
            // 
            // lblTituloConexiónSDK
            // 
            this.lblTituloConexiónSDK.AutoSize = true;
            this.lblTituloConexiónSDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloConexiónSDK.Location = new System.Drawing.Point(94, 20);
            this.lblTituloConexiónSDK.Name = "lblTituloConexiónSDK";
            this.lblTituloConexiónSDK.Size = new System.Drawing.Size(301, 20);
            this.lblTituloConexiónSDK.TabIndex = 3;
            this.lblTituloConexiónSDK.Text = "Conexión SDK Comercial Premium";
            // 
            // bttnVerError
            // 
            this.bttnVerError.Location = new System.Drawing.Point(348, 401);
            this.bttnVerError.Name = "bttnVerError";
            this.bttnVerError.Size = new System.Drawing.Size(152, 37);
            this.bttnVerError.TabIndex = 4;
            this.bttnVerError.Text = "Ver Error";
            this.bttnVerError.UseVisualStyleBackColor = true;
            this.bttnVerError.Click += new System.EventHandler(this.bttnVerError_Click);
            // 
            // tboxCodigoError
            // 
            this.tboxCodigoError.Location = new System.Drawing.Point(22, 408);
            this.tboxCodigoError.Name = "tboxCodigoError";
            this.tboxCodigoError.Size = new System.Drawing.Size(254, 22);
            this.tboxCodigoError.TabIndex = 5;
            // 
            // PrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 450);
            this.Controls.Add(this.tboxCodigoError);
            this.Controls.Add(this.bttnVerError);
            this.Controls.Add(this.lblTituloConexiónSDK);
            this.Controls.Add(this.pnlCentralConexionSDK);
            this.Controls.Add(this.bttnDetenerConexion);
            this.Controls.Add(this.bttnIniciarConexion);
            this.Name = "PrincipalForm";
            this.Text = "Conexión SDK";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrincipalForm_FormClosing);
            this.pnlCentralConexionSDK.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bttnIniciarConexion;
        private System.Windows.Forms.Button bttnDetenerConexion;
        private System.Windows.Forms.Panel pnlCentralConexionSDK;
        private System.Windows.Forms.Label lblTituloConexiónSDK;
        private System.Windows.Forms.ListView listVListaDeEmpresas;
        private System.Windows.Forms.ColumnHeader clnEmpresaListV;
        private System.Windows.Forms.ColumnHeader clnUbicacionEmpresa;
        private System.Windows.Forms.Button bttnVerError;
        private System.Windows.Forms.TextBox tboxCodigoError;
    }
}

