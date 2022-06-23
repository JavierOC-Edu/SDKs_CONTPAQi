<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnInicia = New System.Windows.Forms.Button()
        Me.btnTermina = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnInicia
        '
        Me.btnInicia.Location = New System.Drawing.Point(13, 13)
        Me.btnInicia.Margin = New System.Windows.Forms.Padding(4)
        Me.btnInicia.Name = "btnInicia"
        Me.btnInicia.Size = New System.Drawing.Size(200, 40)
        Me.btnInicia.TabIndex = 0
        Me.btnInicia.Text = "Iniciar SDK"
        Me.btnInicia.UseVisualStyleBackColor = True
        '
        'btnTermina
        '
        Me.btnTermina.Location = New System.Drawing.Point(257, 228)
        Me.btnTermina.Margin = New System.Windows.Forms.Padding(4)
        Me.btnTermina.Name = "btnTermina"
        Me.btnTermina.Size = New System.Drawing.Size(210, 41)
        Me.btnTermina.TabIndex = 1
        Me.btnTermina.Text = "Terminar SDK"
        Me.btnTermina.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(480, 282)
        Me.Controls.Add(Me.btnTermina)
        Me.Controls.Add(Me.btnInicia)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnInicia As Button
    Friend WithEvents btnTermina As Button
End Class
