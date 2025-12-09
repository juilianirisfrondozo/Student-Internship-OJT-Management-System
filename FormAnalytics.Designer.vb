<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAnalytics
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAnalytics))
        btnImport = New Button()
        btnAnalytics = New Button()
        btnMachineLearning = New Button()
        dgvImportFile = New DataGridView()
        btnBack = New Button()
        Panel27 = New Panel()
        Panel28 = New Panel()
        CType(dgvImportFile, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnImport
        ' 
        btnImport.Location = New Point(15, 613)
        btnImport.Name = "btnImport"
        btnImport.Size = New Size(141, 46)
        btnImport.TabIndex = 0
        btnImport.Text = "Import"
        btnImport.UseVisualStyleBackColor = True
        ' 
        ' btnAnalytics
        ' 
        btnAnalytics.Location = New Point(167, 613)
        btnAnalytics.Name = "btnAnalytics"
        btnAnalytics.Size = New Size(141, 46)
        btnAnalytics.TabIndex = 1
        btnAnalytics.Text = "Analytics"
        btnAnalytics.UseVisualStyleBackColor = True
        ' 
        ' btnMachineLearning
        ' 
        btnMachineLearning.Location = New Point(324, 613)
        btnMachineLearning.Name = "btnMachineLearning"
        btnMachineLearning.Size = New Size(162, 46)
        btnMachineLearning.TabIndex = 2
        btnMachineLearning.Text = "Machine Learning"
        btnMachineLearning.UseVisualStyleBackColor = True
        ' 
        ' dgvImportFile
        ' 
        dgvImportFile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvImportFile.Location = New Point(12, 38)
        dgvImportFile.Name = "dgvImportFile"
        dgvImportFile.RowHeadersWidth = 51
        dgvImportFile.Size = New Size(460, 444)
        dgvImportFile.TabIndex = 3
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(501, 613)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(141, 46)
        btnBack.TabIndex = 6
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' Panel27
        ' 
        Panel27.BackColor = Color.FromArgb(CByte(188), CByte(221), CByte(203))
        Panel27.BackgroundImage = CType(resources.GetObject("Panel27.BackgroundImage"), Image)
        Panel27.Location = New Point(532, 336)
        Panel27.Name = "Panel27"
        Panel27.Size = New Size(514, 240)
        Panel27.TabIndex = 274
        ' 
        ' Panel28
        ' 
        Panel28.BackColor = Color.FromArgb(CByte(188), CByte(221), CByte(203))
        Panel28.BackgroundImage = CType(resources.GetObject("Panel28.BackgroundImage"), Image)
        Panel28.Location = New Point(546, 38)
        Panel28.Name = "Panel28"
        Panel28.Size = New Size(365, 261)
        Panel28.TabIndex = 275
        ' 
        ' FormAnalytics
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1069, 671)
        Controls.Add(Panel28)
        Controls.Add(Panel27)
        Controls.Add(btnBack)
        Controls.Add(dgvImportFile)
        Controls.Add(btnMachineLearning)
        Controls.Add(btnAnalytics)
        Controls.Add(btnImport)
        Name = "FormAnalytics"
        Text = "FormAnalytics"
        CType(dgvImportFile, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnImport As Button
    Friend WithEvents btnAnalytics As Button
    Friend WithEvents btnMachineLearning As Button
    Friend WithEvents dgvImportFile As DataGridView
    Friend WithEvents btnBack As Button
    Friend WithEvents Panel27 As Panel
    Friend WithEvents Panel28 As Panel
End Class
