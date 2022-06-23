Imports System.Text

Public Class ExistenciasCostos

#Region "VARIABLES GLOBALES"
    Private Shared Property codigoDeError As Object
#End Region


#Region "EXISTENCIA A NIVEL CAPA"
    Public Function ConsultaCostoCapa(ByRef ImporteCosto As StringBuilder) As Integer
        'Variables Locaes
        Dim CodigoProducto As String = "SDKCOSTO" 'Codigo del producto con metodo de costeo PEPS o UEPS
        Dim CodigoAlmacen As String = "ALM003SDK" 'Almacen donde se consultara el costo
        Dim Unidades As Double = 2

        'Realizamos la consulta del COSTO
        codigoDeError = fRegresaCostoCapa(CodigoProducto, CodigoAlmacen, Unidades, ImporteCosto)

        If codigoDeError = 0 Then
            Console.WriteLine(ImporteCosto)
            Console.Read()
            Return 0
        Else
            Console.WriteLine(" Error " + CStr(codigoDeError))
            Return codigoDeError
        End If

    End Function
#End Region

#Region "EXISTENCIA"
    Public Function ConsultaExistencia() As Double
        ' ByVal aAnio As String, ByVal aMes As String, ByVal aDia As String, ByRef aExistencia As Double
        Dim CodigoProducto As String = "SDKCOSTO"
        Dim CodigoAlmacen As String = "ALM003SDK"
        Dim Anio As String = "2021"
        Dim Mes As String = "11"
        Dim Dia As String = "1"
        Dim Existencia As Double = 0

        'Realizamos la consulta de la existencia 
        codigoDeError = fRegresaExistencia(CodigoProducto, CodigoAlmacen, Anio, Mes, Dia, Existencia)
        Console.WriteLine("Existencia :" + CStr(Existencia))
        If codigoDeError = 0 Then
            Return 0
        Else
            Console.WriteLine(" Error " + codigoDeError)
            Return codigoDeError
        End If

    End Function
#End Region


End Class
