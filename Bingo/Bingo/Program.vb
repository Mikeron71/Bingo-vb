Imports System

Module Program

    Dim nbCards As Integer
    Dim CardList As New List(Of Card)
    Public mode As String
    Dim boulier As New List(Of Boule)
    Dim boulesUtilises As New List(Of Boule)
    Dim bouleTiree As Boule
    Dim gagnant As Integer = 0
    Dim compteBoule As Integer = 0
    Dim continuer As Boolean = False
    Dim valide As Boolean
    Dim reponseUser As Char
    Class Boule
        Public valeur As Integer
        Public classe As Char
        Public appelation As String
        Public tirage As Integer
    End Class



    Sub Main(args As String())

        Console.WriteLine("Bienvenu au bingo magique visual basic.")
        Do
            CreerBoulier()
            ChoisirParams()
            CreateCards(nbCards)
            Console.WriteLine("Voici votre carte. Appuyez sur une touche pour débuter le tirage")
            MontrerCarte()
            Console.ReadKey()

            Do
                Threading.Thread.Sleep(500)
                TirerBoule()
                For Each card In CardList
                    card.stampLigne(bouleTiree.valeur)
                    card.Valider()
                    If card.estGagnante = True Then
                        gagnant = gagnant + 1
                    End If
                Next
                MontrerCarte()


            Loop Until gagnant > 1


            For index As Integer = 0 To nbCards - 1
                If index = 0 And CardList(index).estGagnante = True Then
                    Console.WriteLine("Vous gagnez!")
                ElseIf CardList(index).estGagnante = True Then
                    Console.Write("la carte" & index + 1 & "est gagnante")
                End If

            Next
            Console.WriteLine("Nous avons tirés " & compteBoule & " boules avant d'avoir un gagnant.")



            Console.WriteLine("Voulez-vous rejouer? (O)ui ou (N)on?")
            Do

                valide = Char.TryParse(Console.ReadKey.KeyChar(), reponseUser) And reponseUser = "o" Or reponseUser = "O" Or reponseUser = "N" Or reponseUser = "n"
            Loop Until valide = True
            If reponseUser = "O" Or reponseUser = "o" Then
                continuer = True
                CardList.Clear()
                boulier.AddRange(boulesUtilises)
                gagnant = False
                compteBoule = 0
            Else
                continuer = False
            End If
        Loop Until continuer = False

        boulier.AddRange(boulesUtilises)
        boulier.Sort(Function(x, y) x.valeur.CompareTo(y.valeur))

        Console.WriteLine("Voici les statistiques des boules tirées au cours des parties:")
        For Each boule As Boule In boulier
            If boule.tirage > 0 Then
                Console.WriteLine(boule.appelation & " : " & boule.tirage)
            End If
        Next

    End Sub


    Sub ChoisirParams()



        Do

            Console.WriteLine(Environment.NewLine + "A quel mode de bingo voulez vous jouer? " + Environment.NewLine + "1 pour ligne-colone-diagonale " + Environment.NewLine +
                "2 pour carte pleine" + Environment.NewLine + "3 pour quatre coins")
            valide = Char.TryParse(Console.ReadKey.KeyChar(), reponseUser) And reponseUser = "1" Or reponseUser = "2" Or reponseUser = "3"
        Loop While valide = False
        Select Case reponseUser
            Case "1"
                mode = "ligneCol"
            Case "2"
                mode = "cartePleine"
            Case "3"
                mode = "quatreCoins"
            Case Else

        End Select
        Do
            Console.WriteLine(Environment.NewLine + "Combien de cartes de bingo voulez-vous? Choissisez entre 4 et 20")
            valide = Integer.TryParse(Console.ReadLine(), nbCards) And nbCards > 3 AndAlso nbCards < 21
        Loop While valide = False



    End Sub


    Sub CreateCards(nb As Integer)
        For index As Integer = 1 To nb
            Dim carte = New Card
            CardList.Add(carte)
        Next
    End Sub






    Sub CreerBoulier()

        For index As Integer = 1 To 75
            Dim boule As New Boule
            boule.valeur = index
            Select Case index
                Case 1 To 15
                    boule.classe = "B"
                Case 16 To 30
                    boule.classe = "I"
                Case 31 To 45
                    boule.classe = "N"
                Case 46 To 60
                    boule.classe = "G"
                Case 61 To 75
                    boule.classe = "O"
            End Select
            boule.appelation = CStr(boule.classe & boule.valeur)

            boulier.Add(boule)
            'Console.WriteLine(boule.appelation)


        Next


    End Sub

    Public Sub Shuffle(boule As List(Of Boule))
        Dim rnd As New Random()
        Dim rando As Integer
        Dim temp As Boule

        For n As Integer = boulier.Count - 1 To 0 Step -1
            rando = rnd.Next(0, n + 1)
            temp = boule(n)
            boule(n) = boule(rando)
            boule(rando) = temp
        Next n
    End Sub

    Public Sub TirerBoule()
        Shuffle(boulier)
        bouleTiree = boulier(0)
        bouleTiree.tirage = bouleTiree.tirage + 1
        boulesUtilises.Add(bouleTiree)
        boulier.Remove(bouleTiree)
        compteBoule = compteBoule + 1
        Console.Write("LA BOULE TIREE EST")
        Console.WriteLine(CStr(bouleTiree.appelation).PadLeft(20))
    End Sub

    Public Sub MontrerCarte()
        Dim cartePlayer As Card = CardList(0)


        Console.WriteLine(" B  I  N  G  O")
        For x As Integer = 0 To 4
            For y As Integer = 0 To 4
                If cartePlayer.quadrille(x, y).stamp = True Then
                    ColorWrite("  " & CStr(cartePlayer.quadrille(x, y).valeur))
                Else
                    Console.Write("  " & CStr(cartePlayer.quadrille(x, y).valeur))
                End If

            Next
            Console.WriteLine()
        Next
    End Sub

    Public Sub ColorWrite(s As String)
        Console.BackgroundColor = Console.BackgroundColor
        Console.ForegroundColor = ConsoleColor.DarkGreen
        Console.Write(s)
        Console.ResetColor()
    End Sub




End Module




