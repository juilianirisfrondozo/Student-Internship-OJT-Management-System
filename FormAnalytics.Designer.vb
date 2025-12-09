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
        components = New ComponentModel.Container()
        Dim DataGridViewCellStyle3 As DataGridViewCellStyle = New DataGridViewCellStyle()
        btnImport = New Button()
        btnMachineLearning = New Button()
        btnBack = New Button()
        pctBoxAnalytics = New PictureBox()
        pctBoxMachineLearning = New PictureBox()
        Timer1 = New Timer(components)
        cmbAnalytics = New ComboBox()
        lblTitleGraphs = New Label()
        lblMachineLearning = New Label()
        Label1 = New Label()
        dgvImportFile = New DataGridView()
        lblScore = New Label()
        CType(pctBoxAnalytics, ComponentModel.ISupportInitialize).BeginInit()
        CType(pctBoxMachineLearning, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvImportFile, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnImport
        ' 
        btnImport.Location = New Point(1341, 25)
        btnImport.Name = "btnImport"
        btnImport.Size = New Size(141, 46)
        btnImport.TabIndex = 0
        btnImport.Text = "Import"
        btnImport.UseVisualStyleBackColor = True
        ' 
        ' btnMachineLearning
        ' 
        btnMachineLearning.Location = New Point(1502, 23)
        btnMachineLearning.Name = "btnMachineLearning"
        btnMachineLearning.Size = New Size(162, 50)
        btnMachineLearning.TabIndex = 2
        btnMachineLearning.Text = "Machine Learning"
        btnMachineLearning.UseVisualStyleBackColor = True
        ' 
        ' btnBack
        ' 
        btnBack.Location = New Point(1683, 23)
        btnBack.Name = "btnBack"
        btnBack.Size = New Size(141, 51)
        btnBack.TabIndex = 6
        btnBack.Text = "Back"
        btnBack.UseVisualStyleBackColor = True
        ' 
        ' pctBoxAnalytics
        ' 
        pctBoxAnalytics.Location = New Point(163, 422)
        pctBoxAnalytics.Name = "pctBoxAnalytics"
        pctBoxAnalytics.Size = New Size(750, 561)
        pctBoxAnalytics.TabIndex = 276
        pctBoxAnalytics.TabStop = False
        ' 
        ' pctBoxMachineLearning
        ' 
        pctBoxMachineLearning.Location = New Point(1081, 361)
        pctBoxMachineLearning.Name = "pctBoxMachineLearning"
        pctBoxMachineLearning.Size = New Size(743, 651)
        pctBoxMachineLearning.TabIndex = 277
        pctBoxMachineLearning.TabStop = False
        ' 
        ' cmbAnalytics
        ' 
        cmbAnalytics.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        cmbAnalytics.FormattingEnabled = True
        cmbAnalytics.Location = New Point(441, 336)
        cmbAnalytics.Name = "cmbAnalytics"
        cmbAnalytics.Size = New Size(307, 36)
        cmbAnalytics.TabIndex = 278
        ' 
        ' lblTitleGraphs
        ' 
        lblTitleGraphs.AutoSize = True
        lblTitleGraphs.BackColor = Color.Transparent
        lblTitleGraphs.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblTitleGraphs.ForeColor = Color.FromArgb(CByte(8), CByte(48), CByte(25))
        lblTitleGraphs.Location = New Point(100, 1008)
        lblTitleGraphs.Name = "lblTitleGraphs"
        lblTitleGraphs.Size = New Size(32, 31)
        lblTitleGraphs.TabIndex = 279
        lblTitleGraphs.Text = "--"
        ' 
        ' lblMachineLearning
        ' 
        lblMachineLearning.AutoSize = True
        lblMachineLearning.BackColor = Color.Transparent
        lblMachineLearning.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblMachineLearning.ForeColor = Color.FromArgb(CByte(8), CByte(48), CByte(25))
        lblMachineLearning.Location = New Point(1081, 1028)
        lblMachineLearning.Name = "lblMachineLearning"
        lblMachineLearning.Size = New Size(32, 31)
        lblMachineLearning.TabIndex = 280
        lblMachineLearning.Text = "--"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(8), CByte(48), CByte(25))
        Label1.Location = New Point(100, 337)
        Label1.Name = "Label1"
        Label1.Size = New Size(219, 31)
        Label1.TabIndex = 281
        Label1.Text = "Data Visualizations"
        ' 
        ' dgvImportFile
        ' 
        dgvImportFile.BackgroundColor = Color.MintCream
        dgvImportFile.BorderStyle = BorderStyle.None
        dgvImportFile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvImportFile.Location = New Point(100, 103)
        dgvImportFile.Name = "dgvImportFile"
        DataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = Color.MintCream
        DataGridViewCellStyle3.Font = New Font("Segoe UI", 9F)
        DataGridViewCellStyle3.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = DataGridViewTriState.True
        dgvImportFile.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        dgvImportFile.RowHeadersWidth = 20
        dgvImportFile.Size = New Size(1748, 202)
        dgvImportFile.TabIndex = 282
        ' 
        ' lblScore
        ' 
        lblScore.AutoSize = True
        lblScore.BackColor = Color.Transparent
        lblScore.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblScore.ForeColor = Color.FromArgb(CByte(8), CByte(48), CByte(25))
        lblScore.Location = New Point(1516, 1034)
        lblScore.Name = "lblScore"
        lblScore.Size = New Size(24, 23)
        lblScore.TabIndex = 283
        lblScore.Text = "--"
        ' 
        ' FormAnalytics
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1920, 1080)
        Controls.Add(lblScore)
        Controls.Add(dgvImportFile)
        Controls.Add(Label1)
        Controls.Add(lblMachineLearning)
        Controls.Add(lblTitleGraphs)
        Controls.Add(cmbAnalytics)
        Controls.Add(pctBoxMachineLearning)
        Controls.Add(pctBoxAnalytics)
        Controls.Add(btnBack)
        Controls.Add(btnMachineLearning)
        Controls.Add(btnImport)
        FormBorderStyle = FormBorderStyle.None
        Name = "FormAnalytics"
        StartPosition = FormStartPosition.CenterScreen
        Text = "FormAnalytics"
        CType(pctBoxAnalytics, ComponentModel.ISupportInitialize).EndInit()
        CType(pctBoxMachineLearning, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvImportFile, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnImport As Button
    Friend WithEvents btnMachineLearning As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents pctBoxAnalytics As PictureBox
    Friend WithEvents pctBoxMachineLearning As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents cmbAnalytics As ComboBox
    Friend WithEvents lblTitleGraphs As Label
    Friend WithEvents lblMachineLearning As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvImportFile As DataGridView
    Friend WithEvents lblScore As Label
End Class
