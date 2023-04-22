Namespace VistaActivator
	Partial Public Class Form1
		''' <summary>
		''' Variabile di progettazione necessaria.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Pulire le risorse in uso.
		''' </summary>
		''' <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Codice generato da Progettazione Windows Form"

		''' <summary>
		''' Metodo necessario per il supporto della finestra di progettazione. Non modificare
		''' il contenuto del metodo con l'editor di codice.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
			Me.label1 = New System.Windows.Forms.Label()
			Me.groupBox1 = New System.Windows.Forms.GroupBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			Me.groupBox2 = New System.Windows.Forms.GroupBox()
			Me.progressBar1 = New System.Windows.Forms.ProgressBar()
			Me.button2 = New System.Windows.Forms.Button()
			Me.button1 = New System.Windows.Forms.Button()
			Me.button3 = New System.Windows.Forms.Button()
			Me.groupBox1.SuspendLayout()
			Me.groupBox2.SuspendLayout()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(6, 32)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(300, 17)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Windows Edition: Windows Vista {$Edition} Edition"
			' 
			' groupBox1
			' 
			Me.groupBox1.Controls.Add(Me.label3)
			Me.groupBox1.Controls.Add(Me.label2)
			Me.groupBox1.Controls.Add(Me.label1)
			Me.groupBox1.Location = New System.Drawing.Point(12, 12)
			Me.groupBox1.Name = "groupBox1"
			Me.groupBox1.Size = New System.Drawing.Size(395, 127)
			Me.groupBox1.TabIndex = 1
			Me.groupBox1.TabStop = False
			Me.groupBox1.Text = "OS Information"
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(6, 89)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(134, 17)
			Me.label3.TabIndex = 2
			Me.label3.Text = "Status: {$StatusString}"
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(6, 59)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(148, 17)
			Me.label2.TabIndex = 1
			Me.label2.Text = "Firmware: {$BIOSorUEFI}"
			' 
			' groupBox2
			' 
			Me.groupBox2.Controls.Add(Me.button3)
			Me.groupBox2.Controls.Add(Me.progressBar1)
			Me.groupBox2.Controls.Add(Me.button2)
			Me.groupBox2.Controls.Add(Me.button1)
			Me.groupBox2.Location = New System.Drawing.Point(12, 145)
			Me.groupBox2.Name = "groupBox2"
			Me.groupBox2.Size = New System.Drawing.Size(395, 143)
			Me.groupBox2.TabIndex = 2
			Me.groupBox2.TabStop = False
			Me.groupBox2.Text = "Actions"
			' 
			' progressBar1
			' 
			Me.progressBar1.Location = New System.Drawing.Point(6, 51)
			Me.progressBar1.Name = "progressBar1"
			Me.progressBar1.Size = New System.Drawing.Size(383, 27)
			Me.progressBar1.TabIndex = 2
			Me.progressBar1.Visible = False
			' 
			' button2
			' 
			Me.button2.Location = New System.Drawing.Point(203, 93)
			Me.button2.Name = "button2"
			Me.button2.Size = New System.Drawing.Size(186, 44)
			Me.button2.TabIndex = 1
			Me.button2.Text = "Uninstall"
			Me.button2.UseVisualStyleBackColor = True
'			Me.button2.Click += New System.EventHandler(Me.button2_Click)
			' 
			' button1
			' 
			Me.button1.Location = New System.Drawing.Point(6, 93)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(175, 44)
			Me.button1.TabIndex = 0
			Me.button1.Text = "Install"
			Me.button1.UseVisualStyleBackColor = True
'			Me.button1.Click += New System.EventHandler(Me.button1_Click)
			' 
			' button3
			' 
			Me.button3.Location = New System.Drawing.Point(6, 39)
			Me.button3.Name = "button3"
			Me.button3.Size = New System.Drawing.Size(383, 48)
			Me.button3.TabIndex = 3
			Me.button3.Text = "Extract preactivation files for Windows installation ISO"
			Me.button3.UseVisualStyleBackColor = True
'			Me.button3.Click += New System.EventHandler(Me.button3_Click)
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(7F, 17F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(426, 300)
			Me.Controls.Add(Me.groupBox2)
			Me.Controls.Add(Me.groupBox1)
			Me.Font = New System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
			Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.MaximizeBox = False
			Me.Name = "Form1"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Windows Vista Activator for UEFI & BIOS"
'			Me.Load += New System.EventHandler(Me.Form1_Load)
			Me.groupBox1.ResumeLayout(False)
			Me.groupBox1.PerformLayout()
			Me.groupBox2.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private groupBox1 As System.Windows.Forms.GroupBox
		Private label3 As System.Windows.Forms.Label
		Private label2 As System.Windows.Forms.Label
		Private groupBox2 As System.Windows.Forms.GroupBox
		Private progressBar1 As System.Windows.Forms.ProgressBar
		Private WithEvents button2 As System.Windows.Forms.Button
		Private WithEvents button1 As System.Windows.Forms.Button
		Private WithEvents button3 As System.Windows.Forms.Button
	End Class
End Namespace

