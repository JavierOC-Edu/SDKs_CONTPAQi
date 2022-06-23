


Public Class Interfaz_DLL

#Region "VARIABLES GLOBALES"
    Private Shared Property codigoDeError As Object
    Private Shared rutaBinarios As String = "C:\\Program Files (x86)\\Compacw\\Facturacion\\"
    Private Shared sistema As String = "CONTPAQ I Facturacion"
    Private Shared rutaEmpresas As String = "C:\\Compacw\\Empresas\\"
    Private Shared empresa As String = "FAC_Pruebas"
    Private Shared rutaDoctosTimbrados As String = "C:\\Compacw\\Empresas\\FAC_Pruebas\\Doctos\\Timbrados\\"
    Private Shared claveCSD As String = "12345678a"
    Private Shared szRegKeySistema As String = "SOFTWARE\\Computación en Acción, SA CV\\CONTPAQ I Facturacion"
    Private Shared sNombrePAQAs As String = "CONTPAQ I Facturacion"

#End Region

#Region "FUNCIONES INICIO"

    Public Shared Sub InicializarSDK()
        IniciarSDK()

    End Sub

    Private Sub IniciaConexionSDK()
        lError = MGW_SDK_F.SetCurrentDirectory(rutaBinarios)
        Console.WriteLine("Leer binarios" & MGW_SDK_F.lError)
        MGW_SDK_F.lError = MGW_SDK_F.fSetNombrePAQ(sistema)
        Console.WriteLine("Leer sistema" & MGW_SDK_F.lError)

        If MGW_SDK_F.lError <> 0 Then
            Console.WriteLine("------------------------- No se puedo iniciar conexión sdk -----------------------------")
            Console.WriteLine("Error : " & MGW_SDK_F.lError)
            MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError)
        End If
    End Sub

    Private Shared Sub fAbreSDK()
        Dim szRegKeySistema As String = "SOFTWARE\Computación en Acción, SA CV\CONTPAQ I Facturacion"
        Dim sNombrePAQ As String = "CONTPAQ I Facturacion"
        Dim HKEY_LOCAL_MACHINE As UIntPtr = New UIntPtr(&H80000002UI)
        Dim hRegKey As UIntPtr
        Dim sNombreEmpresa As StringBuilder = New StringBuilder(255)
        Dim sDirectorioEmpresa As StringBuilder = New StringBuilder(255)
        MGW_SDK_F.lError = MGW_SDK_F.RegOpenKeyEx(HKEY_LOCAL_MACHINE, szRegKeySistema, 0, 1, hRegKey)

        If MGW_SDK_F.lError <> 0 Then
            Console.WriteLine("Error al abrir el Registry")
        End If

        Dim pvSize As UInteger = 1024
        Dim lEntrada As StringBuilder = New System.Text.StringBuilder(1024)
        Dim pdwType As UInteger = 0
        MGW_SDK_F.lError = MGW_SDK_F.RegQueryValueEx(hRegKey, "DirectorioBase", 0, pdwType, lEntrada, pvSize)

        If MGW_SDK_F.lError <> 0 Then
            MGW_SDK_F.lError = MGW_SDK_F.RegCloseKey(hRegKey)
        End If

        MGW_SDK_F.lError = MGW_SDK_F.SetCurrentDirectory(lEntrada.ToString())
        MGW_SDK_F.fSetNombrePAQ(sNombrePAQ)
    End Sub

    Private Shared Sub IniciarSDK()

        Dim sLlaveSis = "HKEY_LOCAL_MACHINE\SOFTWARE\Computación en Acción, SA CV\CONTPAQ I Facturacion"
        'Establece la ruta donde se encuentar el archivo MGWSERVICIOS.DLL
        Dim lRutaBinarios = My.Computer.Registry.GetValue(sLlaveSis, "DIRECTORIOBASE", Nothing)
        SetCurrentDirectory(rutaBinarios)
        'Sistemas : CONTPAQi® Comercial
        MGW_SDK_F.lError = fSetNombrePAQ("CONTPAQ I Facturacion")
        If MGW_SDK_F.lError <> 0 Then
            Console.WriteLine(MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError))
            Exit Sub
        Else
            'Se abre empresa
            fAbreEmpresa("C:\\Compacw\\Empresas\\FAC_Pruebas")
            If MGW_SDK_F.lError <> 0 Then
                Console.WriteLine(MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError))
            Else
                Console.WriteLine("Se Abrio Empresa Correctamente...")

            End If
        End If
    End Sub



    Private Shared Sub AbrirEmpresa()
        MGW_SDK_F.lError = MGW_SDK_F.fAbreEmpresa(rutaEmpresas + empresa)

        If MGW_SDK_F.lError <> 0 Then
            Console.WriteLine("----------------- Error al Abrir Empresa ---------------")
            Console.WriteLine("Empresa : " & empresa)
            Console.WriteLine(" Error : " & MGW_SDK_F.lError)
            MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError)
        Else
            Console.WriteLine(" Empresa Cargada ")
        End If
    End Sub

    Private Shared Sub CerrarConexionSDK()
    End Sub

    Private Shared Sub CerrarEmpresa()
        MGW_SDK_F.fCierraEmpresa()
    End Sub
#End Region

#Region "FUNCIONES DE TIMBRADO"
    Private Shared Sub TimbrarXML()
        Dim concepto As String = "NOMINA"
        Dim UUID As StringBuilder = New StringBuilder(300)
        MGW_SDK_F.lError = MGW_SDK_F.fInicializaLicenseInfo(1)
        Console.WriteLine("LICENCIA: " & MGW_SDK_F.lError)
        MGW_SDK_F.lError = MGW_SDK_F.fTimbraXML("C:\\Compacw\\Empresas\\FAC_Pruebas\\Doctos\\XMLsSinSello\\Regimen13-2.xml", concepto, UUID, "", rutaDoctosTimbrados, claveCSD, "C:\Compacw\Empresas\Reportes\Facturacion\Plantilla_Factura_cfdi_1.htm")

        If MGW_SDK_F.lError <> 0 Then
            Console.WriteLine("----------------------- XML SIN Timbrar -----------------------")
            Console.WriteLine($"UUID: {UUID.ToString()}")
            Console.WriteLine("Error : " & MGW_SDK_F.lError.ToString())
            Console.WriteLine("Error : " & MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError))
        Else
            Console.WriteLine("----------------------- XML Timbrado -----------------------")
            Console.WriteLine($"UUID: {UUID.ToString()}")
        End If
    End Sub
#End Region


    Public Shared Sub TrabajarSistema()

        TimbrarXML()
        Console.Read()
        CerrarEmpresa()

    End Sub

End Class
