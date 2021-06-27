Public Class BMICalc
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblBMI.Text = ""
        lblProperWeight.Text = ""
    End Sub

    ''' <summary>
    ''' BMI計算をします
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Protected Sub btnCalc_Click(sender As Object, e As EventArgs)
        Dim height As Double
        Dim weight As Double

        If Not Double.TryParse(txtHeight.Text, height) OrElse
            Not Double.TryParse(txtWeight.Text, weight) OrElse
            height = 0 OrElse
            weight = 0 Then
            ShowMessage("身長、体重には0より大きい数値を入力して下さい")
            Return
        End If

        Dim bmi As Double = Math.Round(weight / ((height / 100) ^ 2), 2)
        Dim stdWeight As Double = Math.Round((height / 100) ^ 2 * 22, 2)

        lblBMI.Text = bmi
        lblProperWeight.Text = stdWeight & "kg"
    End Sub

    Private Sub ShowMessage(message As String)
        Dim script As String = $"alert('{message}');"
        ClientScript.RegisterStartupScript(Me.GetType(), "ALERT_MESSAGE", script, True)
    End Sub

End Class