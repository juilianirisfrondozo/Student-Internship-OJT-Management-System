Imports Newtonsoft.Json
Public Class FormAnalytics

    Private csvLoaded As Boolean = False    ' ▶ FLAG para sa import
    Private lastCSVPath As String = ""      ' ▶ Store CSV location

    Private Sub FormAnalytics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbAnalytics.Items.Add("Bar Chart")
        cmbAnalytics.Items.Add("Histogram")
        cmbAnalytics.Items.Add("Scatter Plot")
        cmbAnalytics.Items.Add("Pie Chart")
        cmbAnalytics.SelectedIndex = -1   ' ▶ NO DEFAULT SELECTED

        For Each cmb As ComboBox In {cmbAnalytics}
            cmb.DrawMode = DrawMode.OwnerDrawFixed
            AddHandler cmb.DrawItem, AddressOf DrawComboItem


            cmb.DrawMode = DrawMode.OwnerDrawFixed
            cmb.DropDownStyle = ComboBoxStyle.DropDownList
            AddHandler cmb.DrawItem, AddressOf DrawComboItem
        Next


    End Sub

    'ComboBox custom draw
    Public Sub DrawComboItem(sender As Object, e As DrawItemEventArgs)
        If e.Index < 0 Then Exit Sub

        Dim combo As ComboBox = DirectCast(sender, ComboBox)
        e.DrawBackground()

        Dim bgColor As Color
        Dim textColor As Color

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            bgColor = Color.FromArgb(218, 239, 228)  ' highlight
            textColor = Color.FromArgb(8, 48, 25)
        Else
            bgColor = Color.White                    ' normal
            textColor = Color.FromArgb(8, 48, 25)
        End If

        Using b As New SolidBrush(bgColor)
            e.Graphics.FillRectangle(b, e.Bounds)
        End Using

        ' CORRECT way to get item text
        Dim text As String = combo.GetItemText(combo.Items(e.Index))

        Using b As New SolidBrush(textColor)
            e.Graphics.DrawString(text, e.Font, b, e.Bounds)
        End Using

        e.DrawFocusRectangle()
    End Sub


    '===============================
    '   IMPORT CSV FROM BUTTON
    '===============================

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "CSV Files (*.csv)|*.csv"

        If ofd.ShowDialog() = DialogResult.OK Then
            Dim dt As New DataTable()
            Dim lines() As String = IO.File.ReadAllLines(ofd.FileName)

            If lines.Length > 0 Then
                Dim headers() As String = lines(0).Split(","c)
                For Each header In headers
                    dt.Columns.Add(header)
                Next
                For i As Integer = 1 To lines.Length - 1
                    dt.Rows.Add(lines(i).Split(","c))
                Next
            End If

            dgvImportFile.DataSource = dt
            csvLoaded = True                     ' ▶ CSV is loaded
            lastCSVPath = ofd.FileName

            ' ✅ CREATE widths dictionary
            Dim widths As New Dictionary(Of String, Integer)
            For Each col As DataColumn In dt.Columns
                widths.Add(col.ColumnName, 150)   ' lahat ng column width 150
            Next

            ' Bind & style DGV
            DGVHelper.BindAndStyleFilesDGV(dgvImportFile, dt, widths)
            ' Liitan lang ang column header
            dgvImportFile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            dgvImportFile.ColumnHeadersHeight = 50
        End If
    End Sub


    '===============================
    '   EXPORT CSV TEMP FILE
    '===============================

    Private Function ExportToCSV(dgv As DataGridView, filePath As String) As Boolean
        Try
            Dim lines As New List(Of String)()

            Dim headers = dgv.Columns.Cast(Of DataGridViewColumn)().Select(Function(c) c.HeaderText)
            lines.Add(String.Join(",", headers))

            For Each row As DataGridViewRow In dgv.Rows
                If Not row.IsNewRow Then
                    Dim cells = row.Cells.Cast(Of DataGridViewCell)().Select(Function(c) c.Value?.ToString())
                    lines.Add(String.Join(",", cells))
                End If
            Next

            IO.File.WriteAllLines(filePath, lines)
            Return True

        Catch ex As Exception
            MessageBox.Show("Error exporting CSV: " & ex.Message)
            Return False
        End Try
    End Function


    '===============================
    '   COMBO ANALYTICS SELECTION
    '===============================

    Private Async Sub cmbAnalytics_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAnalytics.SelectedIndexChanged

        If Not csvLoaded Then
            MessageBox.Show("⚠ Please import a CSV file first!", "No CSV Loaded", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbAnalytics.SelectedIndex = -1
            Exit Sub
        End If

        Dim tempCSV As String = "C:\CSV\temp_data.csv"
        ExportToCSV(dgvImportFile, tempCSV)

        Dim plotType As String = ""

        Select Case cmbAnalytics.SelectedItem.ToString()
            Case "Bar Chart"
                lblTitleGraphs.Text = "Average Scores for Q1–Q20"
                plotType = "bar"
            Case "Histogram"
                lblTitleGraphs.Text = "Histogram of Ratings"
                plotType = "hist"
            Case "Scatter Plot"
                lblTitleGraphs.Text = "Total Earned Points vs Rating"
                plotType = "scatter"
            Case "Pie Chart"
                lblTitleGraphs.Text = "Gender Distribution"
                plotType = "pie"
        End Select

        If String.IsNullOrEmpty(plotType) Then Exit Sub

        Dim url As String = $"http://127.0.0.1:5000/analytics?plot={plotType}"

        Try
            Dim img As Image = Await Task.Run(Function()
                                                  Dim req = Net.WebRequest.Create(url)
                                                  Using resp = req.GetResponse()
                                                      Using stream = resp.GetResponseStream()
                                                          Return Image.FromStream(stream)
                                                      End Using
                                                  End Using
                                              End Function)

            ' Resize
            Dim finalImg As Image = Nothing
            Select Case cmbAnalytics.SelectedItem.ToString()
                Case "Bar Chart"
                    finalImg = New Bitmap(img, 909, 537)
                    pctBoxAnalytics.Size = New Size(909, 537)
                    pctBoxAnalytics.Location = New Point(100, 422)
                Case Else
                    finalImg = New Bitmap(img, 750, 561)
                    pctBoxAnalytics.Size = New Size(750, 561)
                    pctBoxAnalytics.Location = New Point(163, 422)
            End Select

            pctBoxAnalytics.Image = finalImg

        Catch ex As Exception
            MessageBox.Show("Error loading plot: " & ex.Message)
        End Try
    End Sub


    '===============================
    '   MACHINE LEARNING BUTTON
    '===============================

    Private Async Sub btnMachineLearning_Click(sender As Object, e As EventArgs) Handles btnMachineLearning.Click
        If Not csvLoaded Then
            MessageBox.Show("⚠ Import CSV before running Machine Learning.", "Missing CSV", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim url As String = "http://127.0.0.1:5000/ml"

        Try
            ' Load ML image
            Dim img As Image = Await Task.Run(Function()
                                                  Dim req = Net.WebRequest.Create(url)
                                                  Using resp = req.GetResponse()
                                                      Using stream = resp.GetResponseStream()
                                                          Return Image.FromStream(stream)
                                                      End Using
                                                  End Using
                                              End Function)

            Dim resized As New Bitmap(img, 780, 650)
            pctBoxMachineLearning.Size = New Size(780, 650)
            pctBoxMachineLearning.Image = resized

            ' Set ML title
            lblMachineLearning.Text = "Actual vs Predicted Ratings"

            ' Fetch MSE and R² from Flask
            Dim metricsUrl As String = "http://127.0.0.1:5000/ml_metrics"
            Using client As New Net.WebClient()
                Dim jsonText As String = client.DownloadString(metricsUrl)
                Dim metrics = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Double))(jsonText)
                lblScore.Text = $"Mean Squared Error: {metrics("mse"):0.00}, R² Score: {metrics("r2"):0.00}"
            End Using

        Catch ex As Exception
            MessageBox.Show("Error loading ML plot or metrics: " & ex.Message)
        End Try
    End Sub


    '===============================
    '   BACK BUTTON CONFIRMATION
    '===============================

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim result = MessageBox.Show("Are you sure you want to go back?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Me.Close()   ' ← this destroys the form completely
        End If

    End Sub

    Private Sub LoadFilesDGV()
        ' Gumawa ng sample DataTable gamit ang column names mo
        Dim dt As New DataTable()
        dt.Columns.Add("StudentID")
        dt.Columns.Add("Student_Last_Name")
        dt.Columns.Add("Student_First_Name")
        dt.Columns.Add("Gender")
        dt.Columns.Add("Course")
        dt.Columns.Add("Department")
        dt.Columns.Add("Section")
        dt.Columns.Add("Student Email")
        dt.Columns.Add("StudentContactNo")
        dt.Columns.Add("Q1: Attends regularly.")
        dt.Columns.Add("Q2: Starts the work promply.")
        dt.Columns.Add("Q3: Wear clothes suitable to his / her work.")
        dt.Columns.Add("Q4: Courteous and considerate.")
        dt.Columns.Add("Q5: Express his / her ideas well.")
        dt.Columns.Add("Q6: Listens attentively to trainer.")
        dt.Columns.Add("Q7: Display interest in the field of ICT.")
        dt.Columns.Add("Q8: Careful in handling tools and equipment")
        dt.Columns.Add("Q9: Works to develop a variety of skills.")
        dt.Columns.Add("Q10: Generally a potential leader")
        dt.Columns.Add("Q11: Accepts responsibility.")
        dt.Columns.Add("Q12: Volunteers for an assignment.")
        dt.Columns.Add("Q13: Makes worthwhile suggestios.")
        dt.Columns.Add("Q14: Exhibits orderly / safe work station.")
        dt.Columns.Add("Q15: Applies principle to actual work station.")
        dt.Columns.Add("Q16: Prepares report accurately.")
        dt.Columns.Add("Q17: Submits report punctually.")
        dt.Columns.Add("Q18: Works well under pressure.")
        dt.Columns.Add("Q19: Knows the functions, requirements & responsibilities.")
        dt.Columns.Add("Q20: Is generally open for growth & development.")
        dt.Columns.Add("Total Earned Points")
        dt.Columns.Add("Rating")

        ' Column widths - lahat 150
        Dim widths As New Dictionary(Of String, Integer)
        For Each col As DataColumn In dt.Columns
            widths.Add(col.ColumnName, 150)
        Next

        ' ⭐⭐ TAWAG SA MODULE DITO ⭐⭐
        DGVHelper.BindAndStyleFilesDGV(dgvImportFile, dt, widths)
    End Sub

End Class
