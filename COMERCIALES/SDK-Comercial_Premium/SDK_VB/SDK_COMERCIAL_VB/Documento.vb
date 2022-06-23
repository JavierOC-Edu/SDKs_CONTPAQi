Imports System.Text

Public Class Documento
    Private Shared Property codigoDeError As Object

    Public Shared Sub NuevoDocumentoEditaMovi()
        Dim Documento As tDocumento = New tDocumento() 'se genera una estructura de DOCUMENTO
        'se asignan los valores a las propiedades de la estructura documento
        Documento.aFolio = 57
        Documento.aNumMoneda = 2
        Documento.aTipoCambio = 19.34
        Documento.aImporte = 300
        Documento.aDescuentoDoc1 = 0
        Documento.aDescuentoDoc2 = 0
        Documento.aSistemaOrigen = 205
        Documento.aCodConcepto = "FPRUEBA3.3"
        Documento.aSerie = ""
        Documento.aFecha = DateTime.Now.ToString("MM/dd/yyyy")
        Documento.aCodigoCteProv = "CLL001"  'codigo del cliente-proveedor
        Documento.aCodigoAgente = ""
        Documento.aReferencia = "PRUEBA DESDE SDK" 'referencia a nivel documento
        Documento.aAfecta = 0
        Documento.aGasto1 = 0
        Documento.aGasto2 = 0
        Documento.aGasto3 = 0
        Dim idDocumento As Integer = 0 'se genera una variable local para utilizar el ID del documento
        codigoDeError = fAltaDocumento(idDocumento, Documento) 'se da de alta el nuevo documento

        If codigoDeError = 0 Then ' si no hay errores continuamos
#Region "OBSERVACION A NIVEL DOCUMENTO"
            'se reciben solo valores string
            fBuscarDocumento(Documento.aCodConcepto, Documento.aSerie, Documento.aFolio & "") 'Se busca el documento
            'si se encuentra el documento continuamos
            If codigoDeError = 0 Then
                fEditarDocumento() 'se abre documento para edición
                fSetDatoDocumento("COBSERVACIONES", "PRUEBA DESDE SDK") 'se edita el valor necesario, en este caso observaciones
                fGuardaDocumento() 'se guardan los cambios


                Dim Movimiento = New Movimiento()
                codigoDeError = Movimiento.NuevoMovimiento(idDocumento)

                If codigoDeError <> 0 Then
                    MessageBox.Show(rError(codigoDeError) & " movimiento ")
                End If

            End If
#End Region

        End If
    End Sub


    Public Shared Sub NuevoDocumentoEditaMoviBajoNivel()
        Dim aSerie As StringBuilder = New StringBuilder("")
        Dim Documento As tDocumento = New tDocumento()
        fSiguienteFolio("FPRUEBA3.3", aSerie, Documento.aFolio) 'funcion para consultar el folio que le corresponde.
        Documento.aNumMoneda = 2
        Documento.aTipoCambio = 19.34
        Documento.aImporte = 300
        Documento.aDescuentoDoc1 = 0
        Documento.aDescuentoDoc2 = 0
        Documento.aSistemaOrigen = 205
        Documento.aCodConcepto = "FPRUEBA3.3" 'CONCEPTO QUE SE QUIERA UTILIZAR, CAMBIAR POR FACTURA.ENTRADA.SALIDA
        Documento.aSerie = ""
        Documento.aFecha = DateTime.Now.ToString("MM/dd/yyyy")
        Documento.aCodigoCteProv = "CLL001"
        Documento.aCodigoAgente = ""
        Documento.aReferencia = "PRUEBA DESDE SDK"
        Documento.aAfecta = 0
        Documento.aGasto1 = 0
        Documento.aGasto2 = 0
        Documento.aGasto3 = 0
        Dim idDocumento As Integer = 0
        codigoDeError = fAltaDocumento(idDocumento, Documento)
        MessageBox.Show(rError(codigoDeError) & " documento ")

        If codigoDeError = 0 Then
            fBuscarDocumento(Documento.aCodConcepto, Documento.aSerie, Documento.aFolio & "")

            If codigoDeError = 0 Then
                fEditarDocumento()
                fSetDatoDocumento("COBSERVACIONES", "PRUEBA DESDE SDK")
                fGuardaDocumento()
            End If

            'AGREGAR MOVIMIENTOS POR BAJO NIVEL
            codigoDeError = fInsertarMovimiento()
            Console.WriteLine("Movimiento insertado : " & codigoDeError)

            If codigoDeError = 0 Then
                'Se insertan los datos para el movimiento,
                codigoDeError = fSetDatoMovimiento("CIDDOCUMENTO", idDocumento & "")
                codigoDeError = fSetDatoMovimiento("CNUMEROMOVIMIENTO", "1")
                codigoDeError = fSetDatoMovimiento("CIDPRODUCTO", "5")
                codigoDeError = fSetDatoMovimiento("CIDALMACEN", "3")
                codigoDeError = fSetDatoMovimiento("CUNIDADES", "4")
                codigoDeError = fSetDatoMovimiento("CREFERENCIA", "PRUEBA DESDE SDK")
                codigoDeError = fSetDatoMovimiento("CPRECIO", "100")
                codigoDeError = fSetDatoMovimiento("CPRECIOCAPTURADO", "100")
                codigoDeError = fSetDatoMovimiento("COBSERVAMOV", "PRUEBA DESDE SDK")
                codigoDeError = fGuardaMovimiento()
                Console.WriteLine("Movimiento guardado : " & codigoDeError & " " + rError(codigoDeError))
            End If
        End If
    End Sub

    Public Shared Sub EntradaDeAlmacen()
        Dim codigoDeError As Integer = 0
        Dim idDocumento As Integer = 0
        Dim folioDocumento As Double = 0
        Dim aSerie As StringBuilder = New StringBuilder("")
        Dim codigoConceptoDeCompra As String = "34"
        fSiguienteFolio(codigoConceptoDeCompra, aSerie, folioDocumento)
        Dim documento As tDocumento = New tDocumento()
        documento.aFolio = folioDocumento
        documento.aFecha = DateTime.Now.ToString("MM/dd/yyyy")
        documento.aSerie = ""
        documento.aNumMoneda = 1
        documento.aAfecta = 1
        documento.aCodConcepto = codigoConceptoDeCompra
        documento.aCodigoCteProv = "CTEPESO"
        documento.aAfecta = 1
        codigoDeError = fAltaDocumento(idDocumento, documento)

        If codigoDeError = 0 Then

            'AGREGAR MOVIMIENTOS POR BAJO NIVEL
            codigoDeError = fInsertarMovimiento()
            Console.WriteLine("Movimiento insertado : " & codigoDeError)

            If codigoDeError = 0 Then
                'Se insertan los datos para el movimiento,
                codigoDeError = fSetDatoMovimiento("CIDDOCUMENTO", idDocumento & "")
                codigoDeError = fSetDatoMovimiento("CNUMEROMOVIMIENTO", "1")
                'codigoDeError = fSetDatoMovimiento("CIDPRODUCTO", "311")
                codigoDeError = fSetDatoMovimiento("CIDPRODUCTO", "5")
                codigoDeError = fSetDatoMovimiento("CIDALMACEN", "3")
                codigoDeError = fSetDatoMovimiento("CUNIDADES", "4")
                codigoDeError = fSetDatoMovimiento("CREFERENCIA", "PRUEBA DESDE SDK")
                codigoDeError = fSetDatoMovimiento("CPRECIO", "100")
                codigoDeError = fSetDatoMovimiento("CPRECIOCAPTURADO", "100")
                codigoDeError = fSetDatoMovimiento("CCOSTOCAPTURADO", "100")
                codigoDeError = fSetDatoMovimiento("COBSERVAMOV", "PRUEBA DESDE SDK")
                codigoDeError = fGuardaMovimiento()
                Console.WriteLine("Movimiento guardado : " & codigoDeError & " " + rError(codigoDeError))
            End If

            If codigoDeError <> 0 Then
                MessageBox.Show(rError(codigoDeError) & " movimiento ")
            Else
                MessageBox.Show("Documento registrado")
            End If
        Else
            MessageBox.Show(rError(codigoDeError) & " documento ")
        End If
    End Sub

    Public Shared Sub SalidaDeAlmacen()
        Dim codigoDeError As Integer = 0
        Dim idDocumento As Integer = 0
        Dim folioDocumento As Double = 0
        Dim aSerie As StringBuilder = New StringBuilder("")
        Dim codigoConceptoDeCompra As String = "35"
        fSiguienteFolio(codigoConceptoDeCompra, aSerie, folioDocumento)
        Dim documento As tDocumento = New tDocumento()
        documento.aFolio = folioDocumento
        documento.aFecha = DateTime.Now.ToString("MM/dd/yyyy")
        documento.aSerie = ""
        documento.aNumMoneda = 1
        documento.aAfecta = 1
        documento.aCodConcepto = codigoConceptoDeCompra
        documento.aCodigoCteProv = "CTEPESO"
        documento.aAfecta = 1
        codigoDeError = fAltaDocumento(idDocumento, documento)

        If codigoDeError = 0 Then

            'AGREGAR MOVIMIENTOS POR BAJO NIVEL
            codigoDeError = fInsertarMovimiento()
            Console.WriteLine("Movimiento insertado : " & codigoDeError)

            If codigoDeError = 0 Then
                'Se insertan los datos para el movimiento,
                codigoDeError = fSetDatoMovimiento("CIDDOCUMENTO", idDocumento & "")
                codigoDeError = fSetDatoMovimiento("CNUMEROMOVIMIENTO", "1")
                codigoDeError = fSetDatoMovimiento("CIDPRODUCTO", "5")
                codigoDeError = fSetDatoMovimiento("CIDALMACEN", "3")
                codigoDeError = fSetDatoMovimiento("CUNIDADES", "4")
                codigoDeError = fSetDatoMovimiento("CREFERENCIA", "PRUEBA DESDE SDK")
                codigoDeError = fSetDatoMovimiento("CPRECIO", "100")
                codigoDeError = fSetDatoMovimiento("CPRECIOCAPTURADO", "100")
                codigoDeError = fSetDatoMovimiento("CCOSTOCAPTURADO", "100")
                codigoDeError = fSetDatoMovimiento("COBSERVAMOV", "PRUEBA DESDE SDK")
                codigoDeError = fGuardaMovimiento()
                Console.WriteLine("Movimiento guardado : " & codigoDeError & " " + rError(codigoDeError))
            End If

            If codigoDeError <> 0 Then
                MessageBox.Show(rError(codigoDeError) & " movimiento ")
            Else
                MessageBox.Show("Documento registrado")
            End If
        Else
            MessageBox.Show(rError(codigoDeError) & " documento ")
        End If

    End Sub


    Public Shared Sub CotizacionEditBajoN()
        Dim folio As Double = 0
        Dim serie As StringBuilder = New StringBuilder("")
        Dim idDocto As Integer = 0
        Dim codConcepto As String = "1"
        'buacamos el folio que le corresponde al nuevo documento segun los datos de concepto y serie que indiquemos
        fSiguienteFolio(codConcepto, serie, folio)
        'generamos una nueva estructura de tipo documento
        Dim documento As tDocumento = New tDocumento()
        'cargamos los valores de las variables del documento
        documento.aCodConcepto = codConcepto
        documento.aFolio = folio
        documento.aSerie = ""
        documento.aImporte = 2
        documento.aAfecta = 1
        documento.aCodigoCteProv = "CLSDK"
        documento.aFecha = DateTime.Today.ToString("MM/dd/yyyy")
        'damos de alta el nuevo documento
        codigoDeError = fAltaDocumento(idDocto, documento)
        'si el Alta se realiza de manera exitosa tendremos un codigo en 0 y entonces continuaremos
        If codigoDeError <> 0 Then
            rError(codigoDeError)
        Else
            'abrimos el puntero de edición para modificar algunos campos por bajo nivel

            codigoDeError = fEditarDocumento()
            'se indica ("nombre del campo en la BDD","valor que se le asignara al campo")
            'comenzamos a editar alfunos campos
            codigoDeError = fSetDatoDocumento("CREFERENCIA", "REF SDK")
            codigoDeError = fSetDatoDocumento("COBSERVACIONES", "OBSERVACIONES DOCTO")

            codigoDeError = fSetDatoDocumento("CDESTINATARIO", "DESTINATARIO SDK")
            codigoDeError = fSetDatoDocumento("CNUMEROGUIA", "NUM GUIA SDK")
            codigoDeError = fSetDatoDocumento("CMENSAJERIA", "MENSAJERIA SDK")
            codigoDeError = fSetDatoDocumento("CCUENTAMENSAJERIA", "CUENTA MENSAJERIA SDK")
            codigoDeError = fSetDatoDocumento("CNUMEROCAJAS", "521.00")
            codigoDeError = fSetDatoDocumento("CPESO", "111.00")

            codigoDeError = fSetDatoDocumento("CTEXTOEXTRA1", "Extra SDK 1")
            codigoDeError = fSetDatoDocumento("CTEXTOEXTRA2", "Extra SDK 2")
            codigoDeError = fSetDatoDocumento("CTEXTOEXTRA3", "Extra SDK 3")
            codigoDeError = fSetDatoDocumento("CFECHAEXTRA", DateTime.Today.ToString("MM/dd/yyyy"))
            codigoDeError = fSetDatoDocumento("CIMPORTEEXTRA1", "10")
            codigoDeError = fSetDatoDocumento("CIMPORTEEXTRA2", "20.00")
            codigoDeError = fSetDatoDocumento("CIMPORTEEXTRA3", "30.00")
            codigoDeError = fSetDatoDocumento("CIMPORTEEXTRA4", "40")
            codigoDeError = fSetDatoDocumento("CIMPORTEEXTRA5", "50")

            'una vez que terminamos la edición guardamos los cambios
            codigoDeError = fGuardaDocumento()
            'si no hubo errores al editar, continuamos con el regitro de movimientos
            If codigoDeError <> 0 Then
                rError(codigoDeError)
            Else
                Console.WriteLine("Documento generado")
                'creamos una variable para guardar el id del movimiento
                Dim idMovimiento As Integer = 0



                'creamos una nueva estructura de movimientos
                Dim Movimiento As tMovimiento = New tMovimiento()
                'cargamos valores a las variables de movimiento
                Movimiento.aCodAlmacen = "ALM003SDK"
                Movimiento.aCodClasificacion = ""
                Movimiento.aCodProdSer = "SDK"

                'En caso de tener mas de 1 movimiento se generara un nuevo registro y
                'este valor (aConsecutivo) sera el consecutivo siguiente

                Movimiento.aConsecutivo = 1
                Movimiento.aCosto = 40
                Movimiento.aPrecio = 50
                Movimiento.aReferencia = "Ref SDK"
                Movimiento.aUnidades = 1
                'registramos el alta del nuevo movimiento
                codigoDeError = fAltaMovimiento(idDocto, idMovimiento, Movimiento)
                'si no existe erroe en el alta del movimiento continuamos con la edición de ciertos campos
                If codigoDeError = 0 Then
                    'buscamos el movimiento a editar, en este caso con el ID que previamente guardamos
                    fBuscarIdMovimiento(idMovimiento)
                    'abrimos el puntero para edición
                    fEditarMovimiento()
                    'editamos los campos necesarios
                    fSetDatoMovimiento("COBSERVAMOV", "PRUEBA DESDE SDK")
                    fSetDatoMovimiento("CREFERENCIA", "PRUEBA DESDE SDK")
                    'guardamos los cambios
                    fGuardaMovimiento()
                End If



            End If
        End If
    End Sub


    Public Shared Sub EntradaCapas()
        Dim codigoDeError As Integer = 0
        Dim idDocumento As Integer = 0
        Dim folioDocumento As Double = 0
        Dim aSerie As StringBuilder = New StringBuilder("")
        Dim codigoConceptoDeCompra As String = "34"
        fSiguienteFolio(codigoConceptoDeCompra, aSerie, folioDocumento)
        Dim documento As tDocumento = New tDocumento()
        documento.aFolio = folioDocumento
        documento.aFecha = DateTime.Now.ToString("MM/dd/yyyy")
        documento.aSerie = ""
        documento.aNumMoneda = 1
        documento.aAfecta = 1
        documento.aCodConcepto = codigoConceptoDeCompra
        documento.aCodigoCteProv = "CTEPESO"
        documento.aAfecta = 1
        codigoDeError = fAltaDocumento(idDocumento, documento)

        If codigoDeError = 0 Then

            'AGREGAR MOVIMIENTOS

            If codigoDeError = 0 Then
                Dim Movimiento = New Movimiento()
                codigoDeError = Movimiento.NuevoMovimientoCapas(idDocumento)
            End If

            If codigoDeError <> 0 Then
                MessageBox.Show(rError(codigoDeError) & " movimiento ")
            Else
                MessageBox.Show("Documento registrado")
            End If
        Else
            MessageBox.Show(rError(codigoDeError) & " documento ")
        End If
    End Sub

End Class
