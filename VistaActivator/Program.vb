Imports Microsoft.Win32
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace VistaActivator
	Friend NotInheritable Class Program

		Private Sub New()
		End Sub

		''' <summary>
		''' Get Windows Drive (C:\)
		''' </summary>
		Public Shared GetWindowsDrive As String = Path.GetPathRoot(Environment.SystemDirectory)
		''' <summary>
		''' 
		''' </summary>
		Public Shared TempActivatorPath As String = Path.GetTempPath() & "\WinVistaActivator.tmp"
		Public Const ERROR_INVALID_FUNCTION As Integer = 1

		<DllImport("kernel32.dll", EntryPoint := "GetFirmwareEnvironmentVariableW", SetLastError := True, CharSet := CharSet.Unicode, ExactSpelling := True, CallingConvention := CallingConvention.StdCall)> _
		Public Shared Function GetFirmwareType(ByVal lpName As String, ByVal lpGUID As String, ByVal pBuffer As IntPtr, ByVal size As UInteger) As Integer
		End Function

		''' <summary>
		''' Returns if Windows is installed on a UEFI or BIOS firmware
		''' </summary>
		''' <returns></returns>
		Public Shared Function IsWindowsUEFI() As Boolean
			' Call the function with a dummy variable name and a dummy variable namespace (function will fail because these don't exist.)
			GetFirmwareType("", "{00000000-0000-0000-0000-000000000000}", IntPtr.Zero, 0)

			If Marshal.GetLastWin32Error() = ERROR_INVALID_FUNCTION Then
				' Calling the function threw an ERROR_INVALID_FUNCTION win32 error, which gets thrown if either
				' - The mainboard doesn't support UEFI and/or
				' - Windows is installed in legacy BIOS mode
				Return False
			Else
				' If the system supports UEFI and Windows is installed in UEFI mode it doesn't throw the above error, but a more specific UEFI error
				Return True
			End If
		End Function
		Private Shared returnvalue As String 'GetWindowsEdition return value
		''' <summary>
		''' Returns the current Windows Edition
		''' </summary>
		''' <returns></returns>
		Public Shared Function GetWindowsEdition() As String

			Try
				Dim key As RegistryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion")
				returnvalue = DirectCast(key.GetValue("EditionID"), String)
				key.Close()
			Catch
				returnvalue = "Unknown"
			End Try
			Return returnvalue
		End Function
		''' <summary>
		''' Checks if the system is Windows Vista
		''' </summary>
		''' <returns></returns>
		Public Shared Function IsWindowsVista() As Boolean
			If Environment.OSVersion.Version.Major = 6 AndAlso Environment.OSVersion.Version.Minor = 0 Then
				Return True
			Else
				Return False
			End If
		End Function
		''' <summary>
		''' Punto di ingresso principale dell'applicazione.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			If IsWindowsVista() Then
				Application.Run(New Form1())
			Else
				MessageBox.Show("This program works only on Windows Vista!","Windows Vista Activator for BIOS & UEFI",MessageBoxButtons.OK,MessageBoxIcon.Error)
				Environment.Exit(-1)
			End If
		End Sub
	End Class
End Namespace
