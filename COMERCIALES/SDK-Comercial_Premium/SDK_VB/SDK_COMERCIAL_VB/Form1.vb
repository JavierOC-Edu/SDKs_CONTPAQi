Public Class Form1
    Private Sub btnInicia_Click(sender As Object, e As EventArgs) Handles btnInicia.Click
        Dim lResultado As Integer
        Dim sLlaveSis = "HKEY_LOCAL_MACHINE\SOFTWARE\Computación en Acción, SA CV\CONTPAQ I COMERCIAL"
        'Establece la ruta donde se encuentar el archivo MGWSERVICIOS.DLL
        Dim lRutaBinarios = My.Computer.Registry.GetValue(sLlaveSis, "DIRECTORIOBASE", Nothing)
        SetCurrentDirectory(lRutaBinarios)
        'Sistemas : CONTPAQi® Comercial
        lResultado = fSetNombrePAQ("CONTPAQ I COMERCIAL")
        If lResultado <> 0 Then
            Console.WriteLine(rError(lResultado))
            Exit Sub
        Else
            'Se abre empresa
            fAbreEmpresa("C:\\Compac\\Empresas\\adSDKPruebas")
            If lResultado <> 0 Then
                MessageBox.Show(rError(lResultado))
            Else
                MessageBox.Show("Se Abrio Empresa Correctamente...")
                SaldarDocumento.Show()
            End If
        End If

    End Sub

    Private Sub btnTermina_Click(sender As Object, e As EventArgs) Handles btnTermina.Click
        fCierraEmpresa()
        fTerminaSDK()
        MessageBox.Show("Terminaste SDK hasta pronto..")
        Close()
    End Sub

    Private Sub btnSaldar_Click(sender As Object, e As EventArgs)
        SaldarDocumento.Show()
    End Sub

    Private Sub TICKET_Click(sender As Object, e As EventArgs)
        Documento.NuevoDocumentoEditaMoviBajoNivel()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Documento.EntradaDeAlmacen()

    End Sub

    Private Sub BttnExistenciaCapa_Click(sender As Object, e As EventArgs)

        Interfaz.ConsultarCosto()
    End Sub

    Private Sub BttnExistencia_Click(sender As Object, e As EventArgs)
        Interfaz.ConsultarExistencia()
    End Sub
End Class
