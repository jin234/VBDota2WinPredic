Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load, ButtonReset.Click
        Reset()
    End Sub

    Private Sub Reset()
        GraphSelecter.SelectedIndex = 0
    End Sub
    Private Sub HeroSelect1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles HeroSelect1.SelectedIndexChanged
        If 
    End Sub

    Private Sub HeroSelect2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles HeroSelect2.SelectedIndexChanged

    End Sub

    Private Sub HeroSelect3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles HeroSelect3.SelectedIndexChanged

    End Sub

    Private Sub HeroSelect4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles HeroSelect4.SelectedIndexChanged

    End Sub

    Private Sub HeroSelect5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles HeroSelect5.SelectedIndexChanged

    End Sub

    Private Sub ClearDuplicationHero(sender As Object, e As EventArgs) Handles HeroSelect5.SelectedIndexChanged, HeroSelect4.SelectedIndexChanged, HeroSelect3.SelectedIndexChanged, HeroSelect2.SelectedIndexChanged, HeroSelect1.SelectedIndexChanged

    End Sub

    Private Sub GraphSelecter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GraphSelecter.SelectedIndexChanged
        If GraphSelecter.SelectedIndex = 0 Then
            GraphDisplay.Image = My.Resources.Graph1
        End If
        If GraphSelecter.SelectedIndex = 1 Then
            GraphDisplay.Image = My.Resources.Graph2
        End If

    End Sub

    Private Sub GetResult_Click(sender As Object, e As EventArgs) Handles GetResult.Click
        Dim Draft(5) As String
        Draft(0) = HeroSelect1.SelectedItem
        Draft(1) = HeroSelect2.SelectedItem
        Draft(2) = HeroSelect3.SelectedItem
        Draft(3) = HeroSelect4.SelectedItem
        Draft(4) = HeroSelect5.SelectedItem
        If GetMatchResult(Draft) Then
            LableResult.Text = "Predicted As Win"
        Else
            LableResult.Text = "Predicted As lose"
        End If

    End Sub

    Private Function GetMatchResult(Draft() As String)
        If PickedHero(Draft, "Anti-Mage") Then
            If PickedHero(Draft, "Draw Ranger") Then
                If PickedHero(Draft, "Sand King") Then
                    If PickedHero(Draft, "Lion") Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    If PickedHero(Draft, "Magnus") Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            Else
                If PickedHero(Draft, "Huska") Then
                    If PickedHero(Draft, "Dazzle") Then
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Return False
                End If
            End If
        Else
            If PickedHero(Draft, "Phantom Assassin") Then
                If PickedHero(Draft, "Huska") Then
                    If PickedHero(Draft, "Axe") Then
                        If PickedHero(Draft, "Dazzle") Then
                            Return True
                        Else
                            Return False
                        End If
                    Else
                        Return False
                    End If
                Else
                    If PickedHero(Draft, "Magnus") Then
                        If PickedHero(Draft, "Lion") Then
                            Return True
                        Else
                            Return False
                        End If
                    Else
                        If PickedHero(Draft, "Orge Magi") Then
                            Return True
                        Else
                            Return False
                        End If
                    End If
                End If
            Else
                If PickedHero(Draft, "Slark") Then
                    If PickedHero(Draft, "Rubic") Then
                        If PickedHero(Draft, "Outworld Devourer") Then
                            If PickedHero(Draft, "Beast Master") Then
                                If PickedHero(Draft, "Shadow Shaman") Then
                                    Return True
                                Else
                                    Return False
                                End If
                            Else
                                If PickedHero(Draft, "Sand King") Then
                                    If PickedHero(Draft, "Orge Magi") Then
                                        Return True
                                    Else
                                        Return False
                                    End If
                                Else
                                    If PickedHero(Draft, "Axe") Then
                                        Return True
                                    Else
                                        Return False
                                    End If
                                End If
                            End If
                        Else
                            Return False
                        End If
                    Else
                        If PickedHero(Draft, "Draw Ranger") Then
                            If PickedHero(Draft, "Sand King") Then
                                Return True
                            Else
                                Return False
                            End If
                        Else
                            Return False
                        End If
                    End If
                Else
                    If PickedHero(Draft, "Juggernaut") Then
                        If PickedHero(Draft, "Outworld Devouver") Then
                            If PickedHero(Draft, "Magnus") Then
                                Return True
                            Else
                                If PickedHero(Draft, "Axe") Then
                                    If PickedHero(Draft, "Lion") Then
                                        Return True
                                    Else
                                        Return False
                                    End If
                                Else
                                    If PickedHero(Draft, "SandKing") Then
                                        Return True
                                    Else
                                        Return False
                                    End If
                                End If
                            End If
                        Else
                            If PickedHero(Draft, "Rubic") Then
                                Return True
                            Else
                                If PickedHero(Draft, "Huskar") Then
                                    If PickedHero(Draft, "Dazzle") Then
                                        Return True
                                    Else
                                        Return False
                                    End If
                                Else
                                    If PickedHero(Draft, "Draw Ranger") Then
                                        If PickedHero(Draft, "Lich") Then
                                            If PickedHero(Draft, "Bane") Then
                                                Return True
                                            Else
                                                Return False
                                            End If
                                        Else
                                            If PickedHero(Draft, "Phoenix") Then
                                                Return False
                                            Else
                                                If PickedHero(Draft, "Jakiro") Then
                                                    Return True
                                                Else
                                                    Return False
                                                End If

                                            End If

                                        End If
                                    Else
                                        Return False
                                    End If

                                End If
                            End If
                        End If
                    Else
                        Return False
                    End If

                End If


            End If

        End If

        Return False
    End Function
    Private Function PickedHero(draft() As String, Hero As String)
        For Each i In draft
            If i = Hero Then
                Return True
            End If
        Next
        Return False
    End Function

End Class
