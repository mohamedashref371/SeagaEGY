Public Class zoom
    ' Zoom in and out of the form
    Public Shared x, y, x1, y1 As Integer
    Public Shared boxes As New List(Of box)

    Public Shared Sub zoom()
        x = Sega.ClientSize.Width : x1 = x
        y = Sega.ClientSize.Height : y1 = y
        Dim box As box
        For i = 0 To Sega.Controls.Count - 1
            box = New box
            box.tool = Sega.Controls(i)
            box.size = Sega.Controls(i).Size
            box.location = Sega.Controls(i).Location
            If Sega.Controls(i).Text = "" Then
                box.font = Nothing
            Else
                box.font = Sega.Controls(i).Font.Size
            End If
            boxes.Add(box)
        Next
    End Sub

    Public Shared Sub zoomIn()
        x1 *= 1.25
        zoomX()
    End Sub
    Public Shared Sub zoomOut()
        x1 /= 1.25
        zoomX()
    End Sub

    Public Shared Sub zoomX()
        y1 = y * (x1 / x)

        For i = 0 To boxes.Count - 1
            boxes(i).tool.Size = New Size(boxes(i).size.Width * (x1 / x), boxes(i).size.Height * (y1 / y))
            boxes(i).tool.Location = New Point(boxes(i).location.X * (x1 / x), boxes(i).location.Y * (y1 / y))
            If boxes(i).font <> Nothing Then
                boxes(i).tool.Font = New Font(boxes(i).tool.Font.Name.ToString, boxes(i).font * (x1 / x))
            End If
        Next
        Sega.ClientSize = New Size(x1, y1)
    End Sub

    Public Shared Function newPoint(point As Point) As Point
        Return New Point(point.X * (x1 / x), point.Y * (y1 / y))
    End Function
End Class


Public Class box
    Public tool As Control
    Public size As Size
    Public location As Point
    Public font As Single
End Class
