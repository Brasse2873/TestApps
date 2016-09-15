Imports System.IO
Imports System.IO.Compression


Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Using decompressedFile As New FileStream(Application.StartupPath & "\decompressed.xml", FileMode.Open)
            Using compressedFile As New FileStream(Application.StartupPath & "\compressed.xml.gz", FileMode.Create)
                Using compStream As GZipStream = New GZipStream(compressedFile, CompressionMode.Compress)
                    decompressedFile.CopyTo(compStream)
                End Using
            End Using
        End Using
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Using compressedFile As New FileStream(Application.StartupPath & "\compressed.xml.gz", FileMode.Open)
            Using decompressedFile As New FileStream(Application.StartupPath & "\decompressed_new.xml", FileMode.Create)
                Using gzs As GZipStream = New GZipStream(compressedFile, CompressionMode.Decompress)
                    gzs.CopyTo(decompressedFile)
                End Using
            End Using
        End Using
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim compData() As Byte = File.ReadAllBytes(Application.StartupPath & "\compressed.xml.gz")

        Dim ms As New MemoryStream(compData)
        Using decompressedFile As New FileStream(Application.StartupPath & "\decompressed_bytearray.xml", FileMode.Create)
            Using gzs As GZipStream = New GZipStream(ms, CompressionMode.Decompress)
                gzs.CopyTo(decompressedFile)
            End Using
        End Using
    End Sub



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        'Create compressed array
        Dim fiCompFile As New FileInfo(Application.StartupPath & "\compressed.xml.gz")
        Dim numBytes As Long = fiCompFile.Length

        Dim compFile As New FileStream(Application.StartupPath & "\compressed.xml.gz", FileMode.Open)
        Dim br As New BinaryReader(compFile)

        Dim compData(numBytes + 1) As Byte
        br.Read(compData, 0, numBytes)


        'Save to temp file as compressed
        Dim tempFileName = System.IO.Path.GetTempFileName()
        Dim tempFile As New FileStream(tempFileName, FileMode.Create)
        tempFile.Write(compData, 0, numBytes)
        tempFile.Close()


        'Decompress
        Using compressedFile As New FileStream(tempFileName, FileMode.Open)
            Using decompressedFile As New FileStream(Application.StartupPath & "\decompressed_data.xml", FileMode.Create)
                Using gzs As GZipStream = New GZipStream(compressedFile, CompressionMode.Decompress)
                    gzs.CopyTo(decompressedFile)
                End Using
            End Using
        End Using

        System.IO.File.Delete(tempFileName)


    End Sub


End Class





