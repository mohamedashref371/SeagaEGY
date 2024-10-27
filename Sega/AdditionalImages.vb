Module AdditionalImages
    Sub AddIn(imagesList As List(Of Bitmap))
        imagesList.Clear()

        imagesList.AddRange({My.Resources.zx_, My.Resources.zx2, My.Resources.zx4, My.Resources.zx24, My.Resources.zx3, My.Resources.zx23})
        imagesList.AddRange({My.Resources.zs, My.Resources.zs4, My.Resources.zs3})

        imagesList.AddRange({My.Resources.cs, My.Resources.cs4, My.Resources.cs3})
        imagesList.AddRange({My.Resources.cv_, My.Resources.cv2, My.Resources.cv4, My.Resources.cv24, My.Resources.cv3, My.Resources.cv23})
    End Sub
End Module
