Public Class Form1
    Dim Heropool1() As String = {"Anti-Mage", "Phantom Assasin", "Slark", "Juggernaut"}
    Dim Heropool2() As String = {"Outworld Devourer", "Rubic", "Huskar", "Drow Ranger"}
    Dim Heropool3() As String = {"Magnus", "Axe", "Sand King", "Beast Master"}
    Dim Heropool0() As String = {"Anti-Mage", "Phantom Assasin", "Slark", "Juggernaut", "Rubic", "Drow Ranger", "Outworld Devourer", "Huskar", "Axe", "Magnus", "Sand King", "Beast Master", "Lion", "Lich", "Orge Magi", "Shadow Shaman", "Jakiro", "Phoenix", "Dazzle", "Bane"}
    Dim hero1 As String = "0"
    Dim hero2 As String = "0"
    Dim hero3 As String = "0"
    Dim hero4 As String = "0"
    Dim hero5 As String = "0"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load, ButtonReset.Click
        GraphSelecter.SelectedIndex = 0
        Reset()
    End Sub

    Private Sub Reset()

        HeroSelect1.Items.Clear()
        HeroSelect2.Items.Clear()
        HeroSelect3.Items.Clear()
        HeroSelect4.Items.Clear()
        HeroSelect5.Items.Clear()

        HeroSelect1.Items.AddRange(Heropool1)
        HeroSelect2.Items.AddRange(Heropool2)
        HeroSelect3.Items.AddRange(Heropool3)
        HeroSelect4.Items.AddRange(Heropool0)
        HeroSelect5.Items.AddRange(Heropool0)
    End Sub
    Private Sub HeroSelect1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles HeroSelect1.SelectedIndexChanged

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


        If HeroSelect1.SelectedIndex <> -1 Then
            HeroSelect4.Items.Remove(HeroSelect1.SelectedItem)
            HeroSelect5.Items.Remove(HeroSelect1.SelectedItem)
        End If
        If HeroSelect2.SelectedIndex <> -1 Then
            HeroSelect4.Items.Remove(HeroSelect2.SelectedItem)
            HeroSelect5.Items.Remove(HeroSelect2.SelectedItem)
        End If
        If HeroSelect3.SelectedIndex <> -1 Then
            HeroSelect4.Items.Remove(HeroSelect3.SelectedItem)
            HeroSelect5.Items.Remove(HeroSelect3.SelectedItem)
        End If

        hero1 = HeroSelect1.SelectedItem
        hero2 = HeroSelect2.SelectedItem
        hero3 = HeroSelect3.SelectedItem
        hero4 = HeroSelect4.SelectedItem
        hero5 = HeroSelect5.SelectedItem

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
