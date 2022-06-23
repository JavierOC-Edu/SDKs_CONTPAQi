Public Class Movimiento
    Private Shared Property codigoDeError As Integer

    Public Shared Sub EditaMovimiento()

        Dim idDocumento As Integer = Nothing
        'CONCEPTO - SERIE - FOLIO
        codigoDeError = SDK.fBuscarDocumento("FPRUEBA3.3", "", 50 & "")

        If codigoDeError = 0 Then
            codigoDeError = SDK.fPosPrimerMovimiento()


            MessageBox.Show(SDK.rError(codigoDeError) & " Movimiento  Producto")

            codigoDeError = SDK.fEditarMovimiento()
            MessageBox.Show(SDK.rError(codigoDeError) & " Editando ")

            codigoDeError = SDK.fSetDatoMovimiento("CCODIGOPRODUCTO", "PR001")
            MessageBox.Show(SDK.rError(codigoDeError) & " Movimiento  Producto")

            codigoDeError = SDK.fSetDatoMovimiento("CUNIDADES", "8")
            MessageBox.Show(SDK.rError(codigoDeError) & " Movimiento  Unidades")

            codigoDeError = SDK.fGuardaMovimiento()
            MessageBox.Show(SDK.rError(codigoDeError) & " Guardado  ")

        End If
    End Sub


#Region "MOVIMIENTO CAPAS"
    Public Function NuevoMovimientoCapas(idDocumento As Integer) As Integer

        'DATOS DE MOVIMIENTO '
        'se genera una estructura de movimiento y una variable local para accedes al ID
        Dim idMovimiento As Integer = 0
        Dim Movimiento As tMovimiento = New SDK.tMovimiento()
        'le llenan los valores del movimiento
        Movimiento.aCodAlmacen = "ALM003SDK"
        Movimiento.aCodClasificacion = ""
        Movimiento.aCodProdSer = "PP"
        Movimiento.aConsecutivo = 1
        Movimiento.aCosto = 10
        Movimiento.aPrecio = 20
        Movimiento.aReferencia = "Ref SDK" 'referencia a nivel movimiento
        Movimiento.aUnidades = 100
        codigoDeError = fAltaMovimiento(idDocumento, idMovimiento, Movimiento) 'de da de alta el movimineto

        'DATOS DE SERIE-CAPA'
        Dim idSerieCapa As Integer = 0
        Dim SerieCapa As tSeriesCapas = New SDK.tSeriesCapas()

        SerieCapa.aUnidades = "10"
        SerieCapa.aTipoCambio = "1"
        SerieCapa.aSeries = ""
        SerieCapa.aPedimento = "22222222222"
        SerieCapa.aAgencia = "2"
        SerieCapa.aFechaPedimento = DateTime.Now.ToString("MM/dd/yyyy")
        SerieCapa.aNumeroLote = "111111111111111"
        SerieCapa.aFechaFabricacion = "20/05/2022"
        SerieCapa.aFechaCaducidad = "26/06/2022"

        'Alta de la serie'
        codigoDeError = fAltaMovimientoSeriesCapas(idMovimiento, SerieCapa)

        If codigoDeError = 0 Then 'si todo sale bien continuamos
            Return 0
        Else
            Return codigoDeError 'se retorna codigo de error
        End If
    End Function
#End Region


#Region "MOVIMIENTO BAJO NIVEL"

    Public Function NuevoMovimiento(idDocumento As Integer) As Integer
        'se genera una estructura de movimiento y una variable local para accedes al ID
        Dim idMovimiento As Integer = 0
        Dim Movimiento As tMovimiento = New SDK.tMovimiento()
        'le llenan los valores del movimiento
        Movimiento.aCodAlmacen = "ALM003SDK"
        Movimiento.aCodClasificacion = ""
        Movimiento.aCodProdSer = "SDK"
        Movimiento.aConsecutivo = 1
        Movimiento.aCosto = 40
        Movimiento.aPrecio = 60
        Movimiento.aReferencia = "Ref SDK" 'referencia a nivel movimiento
        Movimiento.aUnidades = 1
        codigoDeError = fAltaMovimiento(idDocumento, idMovimiento, Movimiento) 'de da de alta el movimineto

        If codigoDeError = 0 Then 'si todo sale bien continuamos
            fBuscarIdMovimiento(idMovimiento) 'se busca el movimiento mediante el ID
            If codigoDeError = 0 Then 'si todo sale bien continuamos
                fEditarMovimiento() 'abrimos la edición del movimiento
                'para utilizar la observación a niver movimiento debe estar habilitada la funcionalidad en el sistema
                fSetDatoMovimiento("COBSERVAMOV", "PRUEBA DESDE SDK") 'se hacen las modificaciones necesarias
                fGuardaMovimiento() 'se guardan cambios
                'Retornamos 0, verificando que no hay error
                Return 0
            Else
                Return codigoDeError 'se retorna codigo de error
            End If
        Else
            Return codigoDeError 'se retorna codigo de error
        End If
    End Function
#End Region


End Class



