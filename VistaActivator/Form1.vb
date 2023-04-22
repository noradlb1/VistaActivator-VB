Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports VistaActivator.Form1
Imports VistaActivator.Program
Imports VistaActivator
Imports System.Management

Namespace VistaActivator
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			If IsWindowsUEFI() Then
				label2.Text = "Firmware: UEFI"
			Else
				label2.Text = "Firmware: BIOS"
			End If
			'space
			If GetWindowsEdition() <> "Ultimate" AndAlso GetWindowsEdition() <> "Business" AndAlso GetWindowsEdition() <> "Enterprise" AndAlso GetWindowsEdition() <> "HomeBasic" AndAlso GetWindowsEdition() <> "HomePremium" Then
				'unsupported Windows Vista Edition
				label1.Text = $"Windows Edition: Windows Vista {GetWindowsEdition()} Edition"
				label3.Text = "Status: Unsupported Windows Vista Edition"
				button1.Enabled = False
				button2.Enabled = False
			ElseIf IsWindowsUEFI() AndAlso GetWindowsEdition() <> "Business" AndAlso GetWindowsEdition() <> "Enterprise" Then
				'unsupported Windows Vista UEFI Edition
				label1.Text = $"Windows Edition: Windows Vista {GetWindowsEdition()} Edition"
				label3.Text = "Status: Unsupported partition table"
				button1.Enabled = False
				button2.Enabled = False
			Else
				label1.Text = $"Windows Edition: Windows Vista {GetWindowsEdition()} Edition"
				label3.Text = "Status: Ready"
			End If
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			progressBar1.Visible = True
			button3.Visible = False
			Dim thr As New Thread(AddressOf InstallThread)
			thr.Start()
		End Sub
		Private Sub InstallThread()
			Me.Enabled = False
			Try
				If Directory.Exists(TempActivatorPath) Then
					Directory.Delete(TempActivatorPath, True)
				End If
				If GetWindowsEdition() = "Enterprise" Then
					HiddenProcess.StartWaitHiddenProcess("cscript.exe", $"{GetWindowsDrive}\Windows\System32\slmgr.vbs -ipk VKK3X-68KWM-X2YGT-QR4M6-4BWMV", "", True)
					progressBar1.Value = 30
					HiddenProcess.StartWaitHiddenProcess("cscript.exe", $"{GetWindowsDrive}\Windows\System32\slmgr.vbs -skms kms9.msguides.com", "", True)
					progressBar1.Value = 50
					HiddenProcess.StartWaitHiddenProcess("cscript.exe", $"{GetWindowsDrive}\Windows\System32\slmgr.vbs -ato", "", True)
					progressBar1.Value = 100
				ElseIf GetWindowsEdition() = "Business" Then
					HiddenProcess.StartWaitHiddenProcess("cscript.exe", $"{GetWindowsDrive}\Windows\System32\slmgr.vbs -ipk YFKBB-PQJJV-G996G-VWGXY-2V3X8", "", True)
					progressBar1.Value = 30
					HiddenProcess.StartWaitHiddenProcess("cscript.exe", $"{GetWindowsDrive}\Windows\System32\slmgr.vbs -skms kms9.msguides.com", "", True)
					progressBar1.Value = 50
					HiddenProcess.StartWaitHiddenProcess("cscript.exe", $"{GetWindowsDrive}\Windows\System32\slmgr.vbs -ato", "", True)
					progressBar1.Value = 100
				Else
					Directory.CreateDirectory(TempActivatorPath)
					File.WriteAllBytes(TempActivatorPath & "\Certificate.xrm-ms", My.Resources.Certificate)
					File.WriteAllBytes(TempActivatorPath & "\bootinst.exe", My.Resources.bootinst)
					File.WriteAllBytes(TempActivatorPath & "\grldr", My.Resources.grldr)
					HiddenProcess.StartWaitHiddenProcess("cscript.exe", $"{GetWindowsDrive}\Windows\System32\slmgr.vbs -ilc %temp%\WinVistaActivator.tmp\Certificate.xrm-ms", "", True)
					progressBar1.Value = 30
					File.Copy(TempActivatorPath & "\grldr", GetWindowsDrive & "\grldr", True)
					HiddenProcess.StartWaitHiddenProcess(TempActivatorPath & "\bootinst.exe", $"/nt60 {GetWindowsDrive}", "", True)
					HiddenProcess.StartWaitHiddenProcess("cmd.exe", $"/c attrib +s +h +i +r {GetWindowsDrive}\grldr && exit", "", True)
					progressBar1.Value = 50
					If GetWindowsEdition() = "Ultimate" Then
						HiddenProcess.StartWaitHiddenProcess("cscript.exe", $"{GetWindowsDrive}\Windows\System32\slmgr.vbs -ipk 6F2D7-2PCG6-YQQTB-FWK9V-932CC", "", True)
						HiddenProcess.StartWaitHiddenProcess("cscript.exe", $"{GetWindowsDrive}\Windows\System32\slmgr.vbs -ato", "", True)
						progressBar1.Value = 100
					ElseIf GetWindowsEdition() = "HomePremium" Then
						HiddenProcess.StartWaitHiddenProcess("cscript.exe", $"{GetWindowsDrive}\Windows\System32\slmgr.vbs -ipk 8XPM9-7F9HD-4JJQP-TP64Y-RPFFV", "", True)
						HiddenProcess.StartWaitHiddenProcess("cscript.exe", $"{GetWindowsDrive}\Windows\System32\slmgr.vbs -ato", "", True)
						progressBar1.Value = 100
					ElseIf GetWindowsEdition() = "HomeBasic" Then
						HiddenProcess.StartWaitHiddenProcess("cscript.exe", $"{GetWindowsDrive}\Windows\System32\slmgr.vbs -ipk 762HW-QD98X-TQVXJ-8RKRQ-RJC9V", "", True)
						HiddenProcess.StartWaitHiddenProcess("cscript.exe", $"{GetWindowsDrive}\Windows\System32\slmgr.vbs -ato", "", True)
						progressBar1.Value = 100
					End If
				End If
				Dim dlg = MessageBox.Show("A restart is required to successfully activate Windows. Would you like to restart?", "Windows Vista Activator for BIOS & UEFI", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
				If dlg = System.Windows.Forms.DialogResult.Yes Then
					Dim computerName As String = Environment.MachineName.ToString() ' computer name or IP address

					Dim options As New ConnectionOptions()
					options.EnablePrivileges = True
					' To connect to the remote computer using a different account, specify these values:
					' options.Username = "USERNAME";
					' options.Password = "PASSWORD";
					' options.Authority = "ntlmdomain:DOMAIN";

					Dim scope As New ManagementScope("\\" & computerName & "\root\CIMV2", options)
					scope.Connect()

					Dim query As New SelectQuery("Win32_OperatingSystem")
					Dim searcher As New ManagementObjectSearcher(scope, query)

					For Each os As ManagementObject In searcher.Get()
						' Obtain in-parameters for the method
						Dim inParams As ManagementBaseObject = os.GetMethodParameters("Win32Shutdown")

						' Add the input parameters.
						inParams("Flags") = 2

						' Execute the method and obtain the return values.
						Dim outParams As ManagementBaseObject = os.InvokeMethod("Win32Shutdown", inParams, Nothing)
					Next os
				End If
				Environment.Exit(0)
			Catch ex As Exception
				Me.Enabled = True
				MessageBox.Show($"Error: {ex.Message}. You can ask for support", "Windows Vista Activator for UEFI & BIOS", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			End Try
		End Sub

		Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
			progressBar1.Visible = True
			button3.Visible = False
			Dim thr As New Thread(AddressOf UninstallThread)
			thr.Start()
		End Sub
		Private Sub UninstallThread()
			Me.Enabled = False
			Try
				HiddenProcess.StartWaitHiddenProcess("cscript.exe", $"{GetWindowsDrive}\Windows\System32\slmgr.vbs -ckms", "", True)
				progressBar1.Value = 25
				HiddenProcess.StartWaitHiddenProcess("cscript.exe", $"{GetWindowsDrive}\Windows\System32\slmgr.vbs -upk", "", True)
				progressBar1.Value = 50
				HiddenProcess.StartWaitHiddenProcess("cscript.exe", $"{GetWindowsDrive}\Windows\System32\slmgr.vbs -cpky", "", True)
				progressBar1.Value = 75
				HiddenProcess.StartWaitHiddenProcess("cscript.exe", $"{GetWindowsDrive}\Windows\System32\slmgr.vbs -rilc", "", True)
				progressBar1.Value = 100
				Dim dlg = MessageBox.Show("A restart is required to successfully uninstall the tool. Would you like to restart?", "Windows Vista Activator for BIOS & UEFI", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
				If dlg = System.Windows.Forms.DialogResult.Yes Then
					Dim computerName As String = Environment.MachineName.ToString() ' computer name or IP address

					Dim options As New ConnectionOptions()
					options.EnablePrivileges = True
					' To connect to the remote computer using a different account, specify these values:
					' options.Username = "USERNAME";
					' options.Password = "PASSWORD";
					' options.Authority = "ntlmdomain:DOMAIN";

					Dim scope As New ManagementScope("\\" & computerName & "\root\CIMV2", options)
					scope.Connect()

					Dim query As New SelectQuery("Win32_OperatingSystem")
					Dim searcher As New ManagementObjectSearcher(scope, query)

					For Each os As ManagementObject In searcher.Get()
						' Obtain in-parameters for the method
						Dim inParams As ManagementBaseObject = os.GetMethodParameters("Win32Shutdown")

						' Add the input parameters.
						inParams("Flags") = 2

						' Execute the method and obtain the return values.
						Dim outParams As ManagementBaseObject = os.InvokeMethod("Win32Shutdown", inParams, Nothing)
					Next os
				End If
				Environment.Exit(0)
			Catch ex As Exception
				Me.Enabled = True
				MessageBox.Show($"Error: {ex.Message}. You can ask for support", "Windows Vista Activator for UEFI & BIOS", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			End Try
		End Sub

		Private Sub button3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button3.Click
			Try
				If File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Windows_Vista_OEM_PreActivation.zip") Then
					File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Windows_Vista_OEM_PreActivation.zip")
				End If
				File.WriteAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Windows_Vista_OEM_PreActivation.zip", My.Resources.OEMPreActivation)
				MessageBox.Show($"Done, extracted the zip file to {Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Windows_Vista_OEM_PreActivation.zip"}", "Windows Vista Activator for UEFI & BIOS", MessageBoxButtons.OK, MessageBoxIcon.Information)
				Environment.Exit(0)
			Catch ex As Exception
				Me.Enabled = True
				MessageBox.Show($"Error: {ex.Message}. You can ask for support", "Windows Vista Activator for UEFI & BIOS", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			End Try
		End Sub
	End Class
End Namespace
