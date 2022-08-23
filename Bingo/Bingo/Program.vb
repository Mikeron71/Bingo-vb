Imports System

Module Program

    Dim nbCards As Integer
    Dim CardList As New List(Of Card)
    Public mode As String
    Dim boulier As New List(Of Boule)
    Dim bouleTiree As Boule
    Public winner = False

    Sub Main(args As String())
        Console.WriteLine("%cThis is a %cConsole.log", "background:black ; color: white", "color: red; font-size:25px")
        CreerBoulier()
        Welcome()
        CreateCards(nbCards)
        MontrerCarte()

        Do
            TirerBoule()
            CardList(0).stampLigne(bouleTiree.valeur)
            MontrerCarte()
            CardList(0).Valider()
        Loop Until winner = True




    End Sub


    Sub Welcome()
        Dim valide As Boolean
        Dim rep As Char
        Console.WriteLine("Bienvenu au bingo magique visual basic.")
        Do

            Console.WriteLine(Environment.NewLine + "A quel mode de bingo voulez vous jouer? " + Environment.NewLine + "1 pour ligne-colone-diagonale " + Environment.NewLine +
                "2 pour carte pleine" + Environment.NewLine + "3 pour quatre coins")
            valide = Char.TryParse(Console.ReadKey.KeyChar(), rep) And rep = "1" Or rep = "2" Or rep = "3"
        Loop While valide = False
        Select Case rep
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




    Class Boule
        Public valeur As Integer
        Public classe As Char
        Public appelation As String
    End Class


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
        boulier.Remove(boulier(0))
        Console.WriteLine("LA BOULE TIREE EST")
        Console.WriteLine(bouleTiree.appelation)
    End Sub

    Public Sub MontrerCarte()
        Dim cartePlayer As Card = CardList(0)
        Console.WriteLine("Voici votre carte. Appuyez sur une touche pour débuter le tirage")


        Console.WriteLine(" B  I  N  G  O")
        For x As Integer = 0 To 4
            For y As Integer = 0 To 4
                If cartePlayer.quadrille(x, y).stamp = True Then
                    ColorWrite(" " & CStr(cartePlayer.quadrille(x, y).valeur))
                Else
                    Console.Write(" " & CStr(cartePlayer.quadrille(x, y).valeur))
                End If

            Next
            Console.WriteLine()
        Next
    End Sub

    Public Sub ColorWrite(s As String)
        Console.BackgroundColor = ConsoleColor.Blue
        Console.Write(s)
        Console.ResetColor()
    End Sub

End Module




