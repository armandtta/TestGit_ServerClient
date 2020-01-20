Imports System.Net.Sockets
Imports System.Net
Module Module1
    Dim port As String = "8080"
    Dim ip As String = "127.0.0.1"
    Sub Main()
        Dim MonSocketClient As New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
        Dim MonEP As IPEndPoint = New IPEndPoint(IPAddress.Parse(ip), port)
        Console.WriteLine("Socket client initialisé. ")
        Try
            Console.WriteLine("Connexion au serveur .....")
            MonSocketClient.Connect(MonEP)
            TraitementConnexion(MonSocketClient)
        Catch ex As Exception
            Console.WriteLine("Erreur lors de la tentative de connexion : " & ex.ToString)
        End Try
        Console.ReadLine()
    End Sub

    Sub TraitementConnexion(ByVal SocketReception As Socket)
        Console.Write("Connecté, réception de l'heure : ")
        Dim Heure(255) As Byte 'Création du tableau de réception
        'For t As Integer = 0 To 3
        Try
            SocketReception.Receive(Heure) 'Réception
            Console.WriteLine("Message: " & System.Text.Encoding.ASCII.GetString(Heure))
            'Affichage
            'Heure = System.Text.Encoding.ASCII.GetBytes(Console.ReadLine)
            'SocketReception.Send(Heure)
        Catch ex As Exception
            Console.WriteLine("Erreur lors de la réception des données : " & ex.ToString)
        End Try
        'Next


    End Sub

End Module
