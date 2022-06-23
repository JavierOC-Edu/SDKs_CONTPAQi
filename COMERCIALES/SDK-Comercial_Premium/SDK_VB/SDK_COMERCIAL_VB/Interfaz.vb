Imports System.Text

Public Class Interfaz

#Region "VARIABLES GLOBALES"
    Private Shared Property codigoDeError As Object
#End Region

#Region "Consultar el costo de un producto "
    Public Shared Sub ConsultarCosto()
        'VARIABLES LOCALES
        Dim Costo = New ExistenciasCostos()
        Dim ImporteCosto As StringBuilder = New StringBuilder("")

        codigoDeError = Costo.ConsultaCostoCapa(ImporteCosto)

        If codigoDeError <> 0 Then
            Console.WriteLine(SDK.rError(codigoDeError))
        End If
    End Sub
#End Region


#Region "Consultar Existencia de un producto "
    Public Shared Sub ConsultarExistencia()
        'VARIABLES LOCALES
        Dim Existencia = New ExistenciasCostos()

        codigoDeError = Existencia.ConsultaExistencia()

        If codigoDeError <> 0 Then
            Console.WriteLine(SDK.rError(codigoDeError))
        End If
    End Sub
#End Region

End Class
