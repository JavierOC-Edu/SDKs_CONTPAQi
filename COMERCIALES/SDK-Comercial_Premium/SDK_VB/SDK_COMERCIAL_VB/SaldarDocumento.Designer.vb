<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SaldarDocumento
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.bttnCotizacion = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'bttnCotizacion
        '
        Me.bttnCotizacion.Location = New System.Drawing.Point(12, 12)
        Me.bttnCotizacion.Name = "bttnCotizacion"
        Me.bttnCotizacion.Size = New System.Drawing.Size(147, 34)
        Me.bttnCotizacion.TabIndex = 0
        Me.bttnCotizacion.Text = "Cotización"
        Me.bttnCotizacion.UseVisualStyleBackColor = True
        '
        'SaldarDocumento
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 219)
        Me.Controls.Add(Me.bttnCotizacion)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "SaldarDocumento"
        Me.Text = "Menú"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents bttnCotizacion As Button
End Class
