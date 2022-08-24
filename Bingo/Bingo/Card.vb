

Public Class Card

    Public quadrille(4, 4) As carre
    Public estGagnante As Boolean = False
    Public Structure carre
        Dim valeur As Integer
        Dim stamp As Boolean

    End Structure



    Public Sub New()

        Dim chiffresB As New List(Of Integer)
        Dim chiffresI As New List(Of Integer)
        Dim chiffresN As New List(Of Integer)
        Dim chiffresG As New List(Of Integer)
        Dim chiffresO As New List(Of Integer)
        Dim chiffreB As Integer
        Dim chiffreI As Integer
        Dim chiffreN As Integer
        Dim chiffreG As Integer
        Dim chiffreO As Integer


        For index As Integer = 1 To 5

            Do
                chiffreB = Int((15 * Rnd()) + 1)
            Loop While (chiffresB.Contains(chiffreB))
            chiffresB.Add(chiffreB)

            Do
                chiffreI = Int((15 * Rnd()) + 16)
            Loop While (chiffresI.Contains(chiffreI))
            chiffresI.Add(chiffreI)

            Do
                chiffreN = Int((15 * Rnd()) + 31)
            Loop While (chiffresN.Contains(chiffreN))
            chiffresN.Add(chiffreN)

            Do
                chiffreG = Int((15 * Rnd()) + 46)
            Loop While (chiffresG.Contains(chiffreG))
            chiffresG.Add(chiffreG)

            Do
                chiffreO = Int((15 * Rnd()) + 61)
            Loop While (chiffresO.Contains(chiffreO))
            chiffresO.Add(chiffreO)
        Next

        chiffresB.Sort()
        chiffresI.Sort()
        chiffresN.Sort()
        chiffresG.Sort()
        chiffresO.Sort()




        For lign As Integer = 0 To 4
            For col As Integer = 0 To 4
                quadrille(lign, col).stamp = False
                Select Case col
                    Case 0
                        quadrille(lign, col).valeur = chiffresB(lign)
                    Case 1
                        quadrille(lign, col).valeur = chiffresI(lign)
                    Case 2
                        quadrille(lign, col).valeur = chiffresN(lign)
                    Case 3
                        quadrille(lign, col).valeur = chiffresG(lign)
                    Case 4
                        quadrille(lign, col).valeur = chiffresO(lign)

                End Select
            Next
        Next

        quadrille(2, 2).valeur = 0
        quadrille(2, 2).stamp = True


        'For index As Integer = 0 To 4
        '    Console.Write(" " & chiffresB(index))
        'Next
        'Console.WriteLine()
        'For index As Integer = 0 To 4
        '    Console.Write(" " & chiffresI(index))
        'Next
        'Console.WriteLine()

        'For index As Integer = 0 To 4
        '    Console.Write(" " & chiffresN(index))
        'Next
        'Console.WriteLine()

        'For index As Integer = 0 To 4
        '    Console.Write(" " & chiffresG(index))
        'Next
        'Console.WriteLine()

        'For index As Integer = 0 To 4
        '    Console.Write(" " & chiffresO(index))
        'Next


        'For x As Integer = 0 To 4
        '    Console.WriteLine()
        '    For y As Integer = 0 To 4
        '        Console.Write(" " & quadrille(x, y).valeur)

        '    Next
        'Next


    End Sub


    Public Sub stampLigne(valeurBoule As Integer)
        Dim count As Integer = 0

        For x As Integer = 0 To 4

            For y As Integer = 0 To 4
                If quadrille(x, y).valeur = valeurBoule Then
                    quadrille(x, y).stamp = True
                End If


            Next
        Next



    End Sub


    Public Sub Valider()
        Select Case mode
            Case "ligneCol"


                'VERIFICATION LIGNE
                For x As Integer = 0 To 4
                    Dim count As Integer = 0

                    For y As Integer = 0 To 4
                        If quadrille(x, y).stamp = True Then
                            count = count + 1
                        End If
                        If count = 5 Then
                            Console.WriteLine("winner ligne")
                            estGagnante = True
                        End If
                    Next
                Next

                'VERIFICATION COL

                For x As Integer = 0 To 4
                    Dim count As Integer = 0

                    For y As Integer = 0 To 4
                        If quadrille(y, x).stamp = True Then
                            count = count + 1
                        End If
                        If count = 5 Then
                            Console.WriteLine("winner col")
                            estGagnante = True
                        End If

                    Next
                Next

                ''VERIFICATION Diagonale 

                For x As Integer = 0 To 4
                    Dim count As Integer = 0


                    If quadrille(x, x).stamp = True Then
                        count = count + 1
                    End If
                    If count = 5 Then
                        Console.WriteLine("winner diag")
                        estGagnante = True
                    End If

                Next

                For x As Integer = 0 To 4
                    Dim count As Integer = 0

                    For y As Integer = 0 To 4
                        If x + y = 4 AndAlso quadrille(y, x).stamp = True Then
                            count = count + 1
                        End If
                        If count = 5 Then
                            Console.WriteLine("winner Diag")
                            estGagnante = True
                        End If

                    Next
                Next







            Case "cartePleine"
                Dim count As Integer = 0
                For x As Integer = 0 To 4
                    For y As Integer = 0 To 4
                        If quadrille(x, y).stamp = True Then
                            count = count + 1
                        End If
                        If count > 24 Then
                            Console.WriteLine("full")

                            estGagnante = True
                        End If

                    Next
                Next
            Case "quatreCoins"

                If quadrille(0, 0).stamp = True AndAlso quadrille(0, 4).stamp = True AndAlso quadrille(4, 0).stamp = True AndAlso quadrille(4, 4).stamp Then
                    Console.WriteLine("4coins")
                    estGagnante = True
                End If

        End Select
    End Sub




End Class
