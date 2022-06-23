Public Class SaldarDocumento
    Private Sub btnPagar_Click(sender As Object, e As EventArgs)
        Dim busca As New RegLlaveDoc()
        Dim doctoPagar As New RegLlaveDoc()
        Dim doctoPago As New RegLlaveDoc()
        Dim folioDocto As New tDocumento()

        busca.aCodConcepto = "21"
        busca.aSerie = ""
        'busca.folio = CDbl(txtFolioDocto.Text)

        Dim buscaDoc As Integer
        Dim fDocto As Integer

        buscaDoc = fBuscaDocumento(busca)

        If buscaDoc <> 0 Then
            MessageBox.Show("Error 34: " + SDK.rError(buscaDoc))
        End If

        folioDocto.aCodConcepto = "25"
        folioDocto.aSerie = ""
        folioDocto.aFecha = DateTime.Today.ToString("MM/dd/yyyy")
        folioDocto.aCodigoCteProv = "PR0004"
        folioDocto.aTipoCambio = 1
        folioDocto.aNumMoneda = 1
        'folioDocto.aImporte = CDbl(txtCantidadPagar.Text)
        folioDocto.aReferencia = ""

        '------------------------------------------------------------------------
        fDocto = fAltaDocumentoCargoAbono(folioDocto)
        If fDocto <> 0 Then
            MessageBox.Show("Error 1" + SDK.rError(fDocto))

        Else
            MessageBox.Show("Documento de abono creado exitosamente")
        End If

        ''MessageBox.Show("Documento " + busca.folio + " encontrado")

        doctoPagar.aCodConcepto = "21"
        'doctoPagar.folio = CDbl(txtFolioDocto.Text)
        doctoPagar.aSerie = ""


        ' alta de documento doctoPago

        Dim fFolio As Double = 0
        Dim nFolio As New System.Text.StringBuilder
        Dim sigFolio As Integer

        sigFolio = SDK.fSiguienteFolio("25", nFolio, fFolio)

        If sigFolio <> 0 Then
            MessageBox.Show("Error 2: " + SDK.rError(sigFolio))
        End If
        MessageBox.Show("Sin errores")
        '--------------------------------------------------------------------

        doctoPago.aCodConcepto = "25"
        doctoPago.folio = fFolio - 1 ' AQUI VA EL SIGUIENTE FOLIO
        doctoPago.aSerie = ""
        Dim importe As Double
        'importe = CDbl(txtCantidadPagar.Text)
        Dim fSalda As Integer

        fSalda = SDK.fSaldarDocumento(doctoPagar, doctoPago, importe, 1, DateTime.Today.ToString())

        If fSalda <> 0 Then
            MessageBox.Show("Error 35: " + SDK.rError(fSalda))
        End If

        MessageBox.Show("EXITO!!")

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles bttnCotizacion.Click
        Documento.EntradaCapas()
    End Sub
End Class