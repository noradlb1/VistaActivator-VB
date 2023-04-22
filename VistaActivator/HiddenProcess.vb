Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Text

Namespace VistaActivator
	Friend Class HiddenProcess
		''' <summary>
		''' Starts an hidden process
		''' </summary>
		''' <param name="filename">Process file name</param>
		''' <param name="arguments">Arguments (cmd parameters) for the file name</param>
		''' <param name="verbose">Verbose (usually we use "runas" here for triggering uac)</param>
		''' <param name="shellexecute">Launches program from the shell (true or false)</param>
		Public Shared Sub StartHiddenProcess(ByVal filename As String, ByVal arguments As String, ByVal verbose As String, ByVal shellexecute As Boolean)
			Dim info As New ProcessStartInfo()
			info.FileName = filename
			info.Arguments = arguments
			info.Verb = verbose
			info.UseShellExecute = shellexecute
			info.WindowStyle = ProcessWindowStyle.Hidden
			info.CreateNoWindow = True
			Process.Start(info)
			Return
		End Sub
		''' <summary>
		''' Starts an hidden process and waits for its termination
		''' </summary>
		''' <param name="filename">Process file name</param>
		''' <param name="arguments">Arguments (cmd parameters) for the file name</param>
		''' <param name="verbose">Verbose (usually we use "runas" here for triggering uac)</param>
		''' <param name="shellexecute">Launches program from the shell (true or false)</param>
		Public Shared Sub StartWaitHiddenProcess(ByVal filename As String, ByVal arguments As String, ByVal verbose As String, ByVal shellexecute As Boolean)
			Dim info As New ProcessStartInfo()
			info.FileName = filename
			info.Arguments = arguments
			info.Verb = verbose
			info.UseShellExecute = shellexecute
			info.WindowStyle = ProcessWindowStyle.Hidden
			info.CreateNoWindow = True
			Process.Start(info).WaitForExit()
			Return
		End Sub
	End Class
End Namespace
