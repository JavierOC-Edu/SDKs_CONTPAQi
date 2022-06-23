Imports System.Runtime.InteropServices
Imports System.Text
Imports System
Module MGW_SDK_F
    Public Const kLogitudLugarExpedicion As Integer = 401
    Public Const kLongAbreviatura As Integer = 4
    Public Const kLongCadOrigComplSAT As Integer = 501
    Public Const kLongCodigo As Integer = 31
    Public Const kLongCodigoPostal As Integer = 7
    Public Const kLongCodValorClasif As Integer = 4
    Public Const kLongCuenta As Integer = 101
    Public Const kLongCURP As Integer = 21
    Public Const kLongDenComercial As Integer = 51
    Public Const kLongDesCorta As Integer = 21
    Public Const kLongDescripcion As Integer = 61
    Public Const kLongEmailWeb As Integer = 51
    Public Const kLongFecha As Integer = 24
    Public Const kLongFechaHora As Integer = 36
    Public Const kLongitudFolio As Integer = 17
    Public Const kLongitudMoneda As Integer = 61
    Public Const kLongitudMonto As Integer = 31
    Public Const kLongitudRegimen As Integer = 101
    Public Const kLongitudUUID As Integer = 37
    Public Const kLongMensaje As Integer = 3001
    Public Const kLongNombre As Integer = 61
    Public Const kLongNombreProducto As Integer = 256
    Public Const kLongNumeroExpandido As Integer = 31
    Public Const kLongNumeroExtInt As Integer = 7
    Public Const kLongReferencia As Integer = 21
    Public Const kLongRepLegal As Integer = 51
    Public Const kLongRFC As Integer = 21
    Public Const kLongRuta As Integer = 254
    Public Const kLongSelloCFDI As Integer = 691
    Public Const kLongSelloSat As Integer = 691
    Public Const kLongSerie As Integer = 12
    Public Const kLongTelefono As Integer = 16
    Public Const kLongTextoExtra As Integer = 51
    Public Const kLonSerieCertSAT As Integer = 21
    Public Const kSDKLonSerieCertSAT As Integer = 190
    Public Const kSDKLongitudUUID As Integer = 206
    Public Const kLongitudNomBanExtranjero As Integer = 255
    Public lError As Integer = 0
    Public bLicencia As Byte

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)>
    Public Structure tCaracteristicas
        Public aUnidades As Double
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDescripcion)>
        Public aValorCaracteristica1 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDescripcion)>
        Public aValorCaracteristica2 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDescripcion)>
        Public aValorCaracteristica3 As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)>
    Public Structure tCteProv
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public cCodigoCliente As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongNombre)>
        Public cRazonSocial As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongFecha)>
        Public cFechaAlta As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongRFC)>
        Public cRFC As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCURP)>
        Public cCURP As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDenComercial)>
        Public cDenComercial As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongRepLegal)>
        Public cRepLegal As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongNombre)>
        Public cNombreMoneda As String
        Public cListaPreciosCliente As Integer
        Public cDescuentoMovto As Double
        Public cBanVentaCredito As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacionCliente1 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacionCliente2 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacionCliente3 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacionCliente4 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacionCliente5 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacionCliente6 As String
        Public cTipoCliente As Integer
        Public cEstatus As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongFecha)>
        Public cFechaBaja As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongFecha)>
        Public cFechaUltimaRevision As String
        Public cLimiteCreditoCliente As Double
        Public cDiasCreditoCliente As Integer
        Public cBanExcederCredito As Integer
        Public cDescuentoProntoPago As Double
        Public cDiasProntoPago As Integer
        Public cInteresMoratorio As Double
        Public cDiaPago As Integer
        Public cDiasRevision As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDesCorta)>
        Public cMensajeria As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDescripcion)>
        Public cCuentaMensajeria As String
        Public cDiasEmbarqueCliente As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public cCodigoAlmacen As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public cCodigoAgenteVenta As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public cCodigoAgenteCobro As String
        Public cRestriccionAgente As Integer
        Public cImpuesto1 As Double
        Public cImpuesto2 As Double
        Public cImpuesto3 As Double
        Public cRetencionCliente1 As Double
        Public cRetencionCliente2 As Double
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacionProveedor1 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacionProveedor2 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacionProveedor3 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacionProveedor4 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacionProveedor5 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacionProveedor6 As String
        Public cLimiteCreditoProveedor As Double
        Public cDiasCreditoProveedor As Integer
        Public cTiempoEntrega As Integer
        Public cDiasEmbarqueProveedor As Integer
        Public cImpuestoProveedor1 As Double
        Public cImpuestoProveedor2 As Double
        Public cImpuestoProveedor3 As Double
        Public cRetencionProveedor1 As Double
        Public cRetencionProveedor2 As Double
        Public cBanInteresMoratorio As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongTextoExtra)>
        Public cTextoExtra1 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongTextoExtra)>
        Public cTextoExtra2 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongTextoExtra)>
        Public cTextoExtra3 As String
        Public cImporteExtra1 As Double
        Public cImporteExtra2 As Double
        Public cImporteExtra3 As Double
        Public cImporteExtra4 As Double
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)>
    Public Structure tDireccion
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public cCodCteProv As String
        Public cTipoCatalogo As Integer
        Public cTipoDireccion As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDescripcion)>
        Public cNombreCalle As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongNumeroExtInt)>
        Public cNumeroExterior As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongNumeroExtInt)>
        Public cNumeroInterior As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDescripcion)>
        Public cColonia As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigoPostal)>
        Public cCodigoPostal As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongTelefono)>
        Public cTelefono1 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongTelefono)>
        Public cTelefono2 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongTelefono)>
        Public cTelefono3 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongTelefono)>
        Public cTelefono4 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongEmailWeb)>
        Public cEmail As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongEmailWeb)>
        Public cDireccionWeb As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDescripcion)>
        Public cCiudad As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDescripcion)>
        Public cEstado As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDescripcion)>
        Public cPais As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDescripcion)>
        Public cTextoExtra As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)>
    Public Structure tDocumento
        Public aFolio As Double
        Public aNumMoneda As Integer
        Public aTipoCambio As Double
        Public aImporte As Double
        Public aDescuentoDoc1 As Double
        Public aDescuentoDoc2 As Double
        Public aSistemaOrigen As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public aCodConcepto As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongSerie)>
        Public aSerie As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongFecha)>
        Public aFecha As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public aCodigoCteProv As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public aCodigoAgente As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongReferencia)>
        Public aReferencia As String
        Public aAfecta As Integer
        Public aGasto1 As Double
        Public aGasto2 As Double
        Public aGasto3 As Double
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)>
    Public Structure tLlaveAper
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public aCodCaja As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongFecha)>
        Public aFechaApe As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)>
    Public Structure tLlaveDoc
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public aCodConcepto As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongSerie)>
        Public aSerie As String
        Public aFolio As Double
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)>
    Public Structure tMovimiento
        Public aConsecutivo As Integer
        Public aUnidades As Double
        Public aPrecio As Double
        Public aCosto As Double
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public aCodProdSer As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public aCodAlmacen As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongReferencia)>
        Public aReferencia As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public aCodClasificacion As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)>
    Public Structure tMovimientoDesc
        Public aConsecutivo As Integer
        Public aUnidades As Double
        Public aPrecio As Double
        Public aCosto As Double
        Public aPorcDescto1 As Double
        Public aImporteDescto1 As Double
        Public aPorcDescto2 As Double
        Public aImporteDescto2 As Double
        Public aPorcDescto3 As Double
        Public aImporteDescto3 As Double
        Public aPorcDescto4 As Double
        Public aImporteDescto4 As Double
        Public aPorcDescto5 As Double
        Public aImporteDescto5 As Double
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public aCodProdSer As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public aCodAlmacen As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongReferencia)>
        Public aReferencia As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public aCodClasificacion As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)>
    Public Structure tProducto
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public cCodigoProducto As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongNombre)>
        Public cNombreProducto As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongNombreProducto)>
        Public cDescripcionProducto As String
        Public cTipoProducto As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongFecha)>
        Public cFechaAltaProducto As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongFecha)>
        Public cFechaBaja As String
        Public cStatusProducto As Integer
        Public cControlExistencia As Integer
        Public cMetodoCosteo As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public cCodigoUnidadBase As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public cCodigoUnidadNoConvertible As String
        Public cPrecio1 As Double
        Public cPrecio2 As Double
        Public cPrecio3 As Double
        Public cPrecio4 As Double
        Public cPrecio5 As Double
        Public cPrecio6 As Double
        Public cPrecio7 As Double
        Public cPrecio8 As Double
        Public cPrecio9 As Double
        Public cPrecio10 As Double
        Public cImpuesto1 As Double
        Public cImpuesto2 As Double
        Public cImpuesto3 As Double
        Public cRetencion1 As Double
        Public cRetencion2 As Double
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongNombre)>
        Public cNombreCaracteristica1 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongNombre)>
        Public cNombreCaracteristica2 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongNombre)>
        Public cNombreCaracteristica3 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacion1 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacion2 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacion3 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacion4 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacion5 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacion6 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongTextoExtra)>
        Public cTextoExtra1 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongTextoExtra)>
        Public cTextoExtra2 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongTextoExtra)>
        Public cTextoExtra3 As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongFecha)>
        Public cFechaExtra As String
        Public cImporteExtra1 As Double
        Public cImporteExtra2 As Double
        Public cImporteExtra3 As Double
        Public cImporteExtra4 As Double
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)>
    Public Structure tSeriesCapas
        Public aUnidades As Double
        Public aTipoCambio As Double
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodigo)>
        Public aSeries As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDescripcion)>
        Public aPedimento As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDescripcion)>
        Public aAgencia As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongFecha)>
        Public aFechaPedimento As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDescripcion)>
        Public aNumeroLote As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongFecha)>
        Public aFechaFabricacion As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongFecha)>
        Public aFechaCaducidad As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)>
    Public Structure tTipoProducto
        Public aSeriesCapas As tSeriesCapas
        Public aCaracteristicas As tCaracteristicas
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)>
    Public Structure tUnidad
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongNombre)>
        Public cNombreUnidad As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongAbreviatura)>
        Public cAbreviatura As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongAbreviatura)>
        Public cDespliegue As String
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)>
    Public Structure tValorClasificacion
        Public cClasificacionDe As Integer
        Public cNumClasificacion As Integer
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongCodValorClasif)>
        Public cCodigoValorClasificacion As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=kLongDescripcion)>
        Public cValorClasificacion As String
    End Structure

    ' Declaraciones de funciones de Windows
    Public Declare Function SetCurrentDirectory Lib "KERNEL32" Alias "SetCurrentDirectoryA" (ByVal pPtrDirActual As String) As Integer
    Public Declare Function RegOpenKeyEx Lib "advapi32" Alias "RegOpenKeyEx" (ByVal hKey As UIntPtr, ByVal subKey As String, ByVal ulOptions As Integer, ByVal samDesired As Integer, <Out> ByRef hkResult As UIntPtr) As Integer
    Public Declare Function RegCloseKey Lib "advapi32" Alias "RegCloseKey" (ByVal hKey As UIntPtr) As Integer
    Public Declare Function RegQueryValueEx Lib "advapi32" Alias "RegQueryValueEx" (ByVal hKey As UIntPtr, ByVal lpValueName As String, ByVal lpReserved As Integer, <Out> ByRef lpType As UInteger, ByVal lpData As StringBuilder, ByRef lpcbData As UInteger) As Integer

    'funciones para iniciar SDK
    Public Declare Function fSetNombrePAQ Lib "MGW_SDK.DLL" (ByVal aNombrePAQ As String) As Integer
    Public Declare Function fInicializaSDK Lib "MGW_SDK.DLL" () As Integer
    Public Declare Sub fTerminaSDK Lib "MGW_SDK.DLL" ()
    Public Declare Sub fError Lib "MGW_SDK.DLL" (ByVal aNumError As Integer, <MarshalAs(UnmanagedType.LPStr)> aMensaje As StringBuilder, ByVal aLen As Integer)
    Public Declare Sub fCierraEmpresa Lib "MGW_SDK.DLL" ()
    Public Declare Function fAbreEmpresa Lib "MGW_SDK.DLL" (ByVal aEmpresa As String) As Integer

    'funciones de timbrado
    Public Declare Function fInicializaLicenseInfo Lib "MGW_SDK.DLL" (ByVal aSistema As Byte) As Integer
    Public Declare Function fTimbraComplementoPagoXML Lib "MGW_SDK.DLL" (ByVal aRutaXML As String, ByVal aCodConcepto As String, ByVal aUUID As StringBuilder, ByVal aRutaDDA As String, ByVal aRutaResultado As String, ByVal aPass As String, ByVal aRutaFormato As String) As Integer
    Public Declare Function fTimbraComplementoXML Lib "MGW_SDK.DLL" (ByVal aRutaXML As String, ByVal aCodCOncepto As String, ByVal aUUID As StringBuilder, ByVal aRutaDDA As String, ByVal aRutaResultado As String, ByVal aPass As String, ByVal aRutaFormato As String, ByVal aComplemento As Integer) As Integer
    Public Declare Function fTimbraXML Lib "MGW_SDK.DLL" (ByVal aRutaXML As String, ByVal aCodCOncepto As String, ByVal aUUID As StringBuilder, ByVal aRutaDDA As String, ByVal aRutaResultado As String, ByVal aPass As String, ByVal aRutaFormato As String) As Integer



    Public Function fErrorDescripcion(ByVal cError As Integer) As String
        Dim descripcion As StringBuilder = New StringBuilder(512)
        fError(cError, descripcion, 512)
        Return descripcion.ToString()

    End Function
End Module

