Imports System.Runtime.InteropServices
Imports System.Text
Module SDK
    ' Constantes y estructuras 
    Public Const kLongCodigo As Integer = 30 + 1
    Public Const kLongNombre As Integer = 60 + 1
    Public Const kLongNombreProducto As Integer = 255 + 1
    Public Const kLongFecha As Integer = 23 + 1
    Public Const kLongAbreviatura As Integer = 3 + 1
    Public Const kLongCodValorClasif As Integer = 3 + 1
    Public Const kLongTextoExtra As Integer = 50 + 1
    Public Const kLongNumSerie As Integer = 11 + 1
    Public Const kLongReferencia As Integer = 20 + 1
    Public Const kLongSeries As Integer = 30 + 1
    Public Const kLongDescripcion As Integer = 60 + 1
    Public Const kLongNumeroExtInt As Integer = 6 + 1
    Public Const kLongCodigoPostal As Integer = 6 + 1
    Public Const kLongTelefono As Integer = 15 + 1
    Public Const kLongEmailWeb As Integer = 50 + 1
    Public Const kLongRFC As Integer = 20 + 1
    Public Const kLongCURP As Integer = 20 + 1
    Public Const kLongDesCorta As Integer = 20 + 1
    Public Const kLongDenComercial As Integer = 50 + 1
    Public Const kLongRepLegal As Integer = 50 + 1
    Public Const kLongNumeroExpandido As Integer = 30 + 1
    Public Const kLongMsgError As Integer = 512

    ' Declaracion de estructuras del SDK

    Public Structure RegLlaveDoc
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public aCodConcepto As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongSeries)>'Ojo Serie o Series 
        Public aSerie As String
        Public folio As Double
    End Structure

    ' Estructura para Documentos

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)>
    Public Structure tDocumento
        Public aFolio As Double
        Public aNumMoneda As Integer
        Public aTipoCambio As Double
        Public aImporte As Double
        Public aDescuentoDoc1 As Double
        Public aDescuentoDoc2 As Double
        Public aSistemaOrigen As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)> Public aCodConcepto As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongNumSerie)> Public aSerie As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongFecha)> Public aFecha As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)> Public aCodigoCteProv As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)> Public aCodigoAgente As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongReferencia)> Public aReferencia As String
        Public aAfecta As Integer
        Public aGasto1 As Double
        Public aGasto2 As Double
        Public aGasto3 As Double
    End Structure


    ' Estructura Movimiento
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi,
Pack:=4)>
    Public Structure tMovimiento
        Public aConsecutivo As Integer
        Public aUnidades As Double
        Public aPrecio As Double
        Public aCosto As Double
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)> Public aCodProdSer As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)> Public aCodAlmacen As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongReferencia)> Public aReferencia As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public aCodClasificacion As String
    End Structure


    'Estructura SeriesCapas
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)>
    Public Structure tSeriesCapas
        Public aUnidades As Double
        Public aTipoCambio As Double
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)> Public aSeries As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDescripcion)> Public aPedimento As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDescripcion)> Public aAgencia As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongFecha)> Public aFechaPedimento As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDescripcion)> Public aNumeroLote As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongFecha)> Public aFechaFabricacion As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongFecha)> Public aFechaCaducidad As String
    End Structure

    ' Declaraciones de funciones del SDK

    Public Declare Function SetCurrentDirectory Lib "KERNEL32" Alias "SetCurrentDirectoryA" (ByVal pPtrDirActual As String) As Integer

    'Public Declare Function fInicializaSDK Lib "MGW_SDK.DLL" () As Integer
    Public Declare Function fSetNombrePAQ Lib "MGWSERVICIOS.DLL" (ByVal aNombrePAQ As String) As Integer
    Public Declare Function fInicializaSDK Lib "MGWSERVICIOS.DLL" () As Integer
    Public Declare Sub fTerminaSDK Lib "MGWSERVICIOS.DLL" ()
    Public Declare Sub fError Lib "MGWSERVICIOS.DLL" (ByVal aNumError As Integer, <MarshalAs(UnmanagedType.LPStr)> aMensaje As StringBuilder, ByVal aLen As Integer)
    Public Declare Sub fCierraEmpresa Lib "MGWSERVICIOS.DLL" ()
    Public Declare Function fAbreEmpresa Lib "MGWSERVICIOS.DLL" (ByVal aEmpresa As String) As Integer

    Public Declare Function fAltaDocumento Lib "MGWSERVICIOS.DLL" (ByRef aIdDocumento As Long, ByRef atDocumento As tDocumento) As Integer
    Public Declare Function fSiguienteFolio Lib "MGWSERVICIOS.DLL" (aCodigoConcepto As String, aSerie As StringBuilder, ByRef aFolio As Double) As Integer
    Public Declare Function fBuscaDocumento Lib "MGWSERVICIOS.DLL" (ByRef RegLlaveDoc As RegLlaveDoc) As Integer
    Public Declare Function fAltaDocumentoCargoAbono Lib "MGWSERVICIOS.DLL" (ByRef aDocumento As tDocumento) As Integer
    Public Declare Function fSaldarDocumento Lib "MGWSERVICIOS.DLL" (ByRef astDocAPagar As RegLlaveDoc, ByRef astDocPago As RegLlaveDoc, importe As Double, moneda As Integer, aFecha As String) As Integer
    Public Declare Function fBuscarDocumento Lib "MGWSERVICIOS.DLL" (ByVal aCodConcepto As String, ByVal aSerie As String, ByVal aFolio As String) As Integer
    Public Declare Function fEditarDocumento Lib "MGWSERVICIOS.DLL" () As Integer
    Public Declare Function fSetDatoDocumento Lib "MGWSERVICIOS.DLL" (aCampo As String, aValor As String) As Integer
    Public Declare Function fGuardaDocumento Lib "MGWSERVICIOS.DLL" () As Integer
    'fInsertarMovimiento
    Public Declare Function fBuscarIdMovimiento Lib "MGWSERVICIOS.DLL" (aIdMovimiento As Integer) As Integer
    Public Declare Function fInsertarMovimiento Lib "MGWSERVICIOS.DLL" () As Integer
    Public Declare Function fAltaMovimiento Lib "MGWSERVICIOS.DLL" (aIdDocumento As Integer, ByRef aIdMovimiento As Integer, ByRef astMovimiento As tMovimiento) As Integer
    Public Declare Function fPosPrimerMovimiento Lib "MGWSERVICIOS.DLL" () As Integer
    Public Declare Function fLeeDatoMovimiento Lib "MGWSERVICIOS.DLL" (ByVal aCampo As String, ByVal aValor As StringBuilder, ByVal aLen As Integer) As Integer
    Public Declare Function fEditarMovimiento Lib "MGWSERVICIOS.DLL" () As Integer
    Public Declare Function fSetDatoMovimiento Lib "MGWSERVICIOS.DLL" (aCampo As String, aValor As String) As Integer
    Public Declare Function fGuardaMovimiento Lib "MGWSERVICIOS.DLL" () As Integer
    Public Declare Function fRegresaExistencia Lib "MGWSERVICIOS.DLL" (ByVal aCodigoProducto As String, ByVal aCodigoAlmacen As String, ByVal aAnio As String, ByVal aMes As String, ByVal aDia As String, ByRef aExistencia As Double) As Integer
    Public Declare Function fRegresaCostoCapa Lib "MGWSERVICIOS.DLL" (ByVal aCodigoProducto As String, ByVal aCodigoAlmacen As String, ByVal aUnidades As Double, ByVal aImporteCosto As StringBuilder) As Integer


    'capas
    Public Declare Function fAltaMovimientoSeriesCapas Lib "MGWSERVICIOS.DLL" (ByVal aIdMovimiento As Integer, ByRef lSeries As tSeriesCapas) As Int32
    Public Declare Function mSDKDatosSeriesCapas Lib "MGWSERVICIOS.DLL" (ByVal aIdSeriesCapas As Integer, ByVal aIdMovimiento As Integer, ByVal aUnidades As Double, ByVal aTipoCambio As Double, ByVal aSeries As String, ByVal aPedimento As String, ByVal aAgencia As String, ByVal aFechaPedimento As String, ByVal aNumeroLote As String, ByVal aFechaFabricacion As String, ByVal aFechaCaducidad As String) As Int32



    ' Función para el manejo de errores en el SDK
    Public Function rError(ByRef aError As Integer) As String
        Dim aMensaje As StringBuilder = New StringBuilder(512)

        ' Recupera el mensaje de error del SDK
        fError(aError, aMensaje, 350)
        Return aMensaje.ToString()
    End Function
End Module
