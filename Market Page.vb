﻿'displays stock name, price etc
Public Class Market_Page
    'abrev, name, current price, price movement, avg change
    Dim MyFormat As String = "{0,-10}{1,-50}{2,-20}{3,-20}{4,-25}" 'format list box

    Private Sub Main_Page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = Windows.Forms.FormWindowState.Maximized
        LblBalance.Text = ("Balance: £" + User1.Balance.ToString("N"))
        LblScore.Text = ("Score: " + User1.Score.ToString("N0"))
        DisplayData() 'diplay contents of list in list box

    End Sub
    Private Sub LstBxStockTable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LstBxStockTable.SelectedIndexChanged
        'open transaction form for the selected stock 
        Try
            'column header is not selectable
            If LstBxStockTable.SelectedIndex - 1 >= 0 Then
                Index = LstBxStockTable.SelectedIndex - 1
                Dim TransactionForm As New Transaction_Page
                TransactionForm.Show()

                'if more than one form is open, close the first one
                TranPageList.Add(TransactionForm)
                If TranPageList.Count() > 1 Then
                    TranPageList.Item(0).Close()
                    TranPageList.RemoveAt(0)
                End If
            End If
        Catch ex As ArgumentOutOfRangeException
            MsgBox("Table is updating")
        End Try

    End Sub
    Public Sub DisplayData()
        'diplay stocklist to table
        LstBxStockTable.Items.Clear()
        LstBxStockTable.Items.Add(String.Format(MyFormat, "Ticker", "Company name", "Price(£)", "Price change(£)", "Volume"))
        For i = 0 To StocksList.Count - 1
            With StocksList.Item(i)
                LstBxStockTable.Items.Add(String.Format(MyFormat, .GetStockID, .GetStockName, .GetStockPrice.ToString("N"), .GetPriceChange.ToString("N"), .GetStockVol.ToString("N0")))
            End With
        Next

    End Sub

End Class