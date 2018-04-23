Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports DevExpress.XtraPrinting
' ...

Namespace UseModifiers
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click

			Dim graph As BrickGraphics = printingSystem1.Graph

			' Start the report generation.
			printingSystem1.Begin()

			' Set the modifier - specify the page area.
			graph.Modifier = BrickModifier.MarginalHeader

			Dim format As String = "Page {0} of {1}"
			graph.Font = graph.DefaultFont
			graph.BackColor = Color.Transparent
			Dim r As New RectangleF(0, 0, 0, graph.Font.Height)

			' Create a brick.
			Dim brick As PageInfoBrick = graph.DrawPageInfo(PageInfo.NumberOfTotal, format, Color.Black, r, BorderSide.None)

			brick.Alignment = BrickAlignment.Far
			brick.AutoWidth = True

			' Create another brick with different alignment.
			brick = graph.DrawPageInfo(PageInfo.DateTime, "{0:MMMM dd}", Color.Black, r, BorderSide.None)



			' Change the page area - set the modifier.
			printingSystem1.Graph.Modifier = BrickModifier.DetailHeader

			graph.BackColor = Color.Silver

			' Create a brick.
			printingSystem1.Graph.DrawString("Report Items", Color.Black, New RectangleF(0, 0, 200, 20), BorderSide.All)



			' Change the page area - set the modifier.
			printingSystem1.Graph.Modifier = BrickModifier.Detail

			graph.BackColor = Color.White

			' Create bricks.
			For i As Integer = 0 To 99
				printingSystem1.Graph.DrawString("Item N" & Convert.ToString(i + 1), Color.Black, New RectangleF(0, 20 * i, 200, 20), BorderSide.All)
			Next i


			printingSystem1.End()
			printingSystem1.PreviewFormEx.Show()
		End Sub

	End Class
End Namespace