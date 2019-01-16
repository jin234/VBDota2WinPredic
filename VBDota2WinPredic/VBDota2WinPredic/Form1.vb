Public Class Form1
    Dim Heropool1() As String = {"Anti-Mage", "Phantom Assasin", "Slark", "Juggernaut"}
    Dim Heropool2() As String = {"Outworld Devourer", "Rubic", "Huskar", "Drow Ranger"}
    Dim Heropool3() As String = {"Magnus", "Axe", "Sand King", "Beast Master"}
    Dim Heropool4() As String = {"Anti-Mage", "Phantom Assasin", "Slark", "Juggernaut", "Rubic", "Drow Ranger", "Outworld Devourer", "Huskar", "Axe", "Magnus", "Sand King", "Beast Master", "Lion", "Lich", "Orge Magi", "Shadow Shaman", "Jakiro", "Phoenix", "Dazzle", "Bane"}
    Dim Heropool5() As String = {"Anti-Mage", "Phantom Assasin", "Slark", "Juggernaut", "Rubic", "Drow Ranger", "Outworld Devourer", "Huskar", "Axe", "Magnus", "Sand King", "Beast Master", "Lion", "Lich", "Orge Magi", "Shadow Shaman", "Jakiro", "Phoenix", "Dazzle", "Bane"}

    Dim heroremove As New List(Of String)()

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
        HeroSelect4.Items.AddRange(Heropool4)
        HeroSelect5.Items.AddRange(Heropool5)
    End Sub

    Private Sub ClearDuplicationHero(sender As Object, e As EventArgs) Handles HeroSelect5.SelectedIndexChanged, HeroSelect4.SelectedIndexChanged, HeroSelect3.SelectedIndexChanged, HeroSelect2.SelectedIndexChanged, HeroSelect1.SelectedIndexChanged

        For Each i In heroremove
            If i <> HeroSelect1.SelectedItem And i <> HeroSelect2.SelectedItem And i <> HeroSelect3.SelectedItem And i <> HeroSelect4.SelectedItem And i <> HeroSelect5.SelectedItem Then
                If HeroSelect1.Items.Contains(i) = False And Heropool1.Contains(i) = True Then
                    HeroSelect1.Items.Add(i)
                End If
                If HeroSelect2.Items.Contains(i) = False And Heropool2.Contains(i) = True Then
                    HeroSelect2.Items.Add(i)
                End If
                If HeroSelect3.Items.Contains(i) = False And Heropool3.Contains(i) = True Then
                    HeroSelect3.Items.Add(i)
                End If
                If HeroSelect4.Items.Contains(i) = False And Heropool4.Contains(i) = True Then
                    HeroSelect4.Items.Add(i)
                End If
                If HeroSelect5.Items.Contains(i) = False And Heropool5.Contains(i) = True Then
                    HeroSelect5.Items.Add(i)
                End If
            End If
        Next

        heroremove.Clear()

        If HeroSelect1.SelectedIndex <> -1 Then
            HeroSelect4.Items.Remove(HeroSelect1.SelectedItem)
            HeroSelect5.Items.Remove(HeroSelect1.SelectedItem)
            heroremove.Add(HeroSelect1.SelectedItem)
        End If
        If HeroSelect2.SelectedIndex <> -1 Then
            HeroSelect4.Items.Remove(HeroSelect2.SelectedItem)
            HeroSelect5.Items.Remove(HeroSelect2.SelectedItem)
            heroremove.Add(HeroSelect2.SelectedItem)
        End If
        If HeroSelect3.SelectedIndex <> -1 Then
            HeroSelect4.Items.Remove(HeroSelect3.SelectedItem)
            HeroSelect5.Items.Remove(HeroSelect3.SelectedItem)
            heroremove.Add(HeroSelect3.SelectedItem)
        End If
        If HeroSelect4.SelectedIndex <> -1 Then
            HeroSelect1.Items.Remove(HeroSelect4.SelectedItem)
            HeroSelect2.Items.Remove(HeroSelect4.SelectedItem)
            HeroSelect3.Items.Remove(HeroSelect4.SelectedItem)
            HeroSelect5.Items.Remove(HeroSelect4.SelectedItem)
            heroremove.Add(HeroSelect4.SelectedItem)
        End If
        If HeroSelect5.SelectedIndex <> -1 Then
            HeroSelect1.Items.Remove(HeroSelect5.SelectedItem)
            HeroSelect2.Items.Remove(HeroSelect5.SelectedItem)
            HeroSelect3.Items.Remove(HeroSelect5.SelectedItem)
            HeroSelect4.Items.Remove(HeroSelect5.SelectedItem)
            heroremove.Add(HeroSelect5.SelectedItem)
        End If

        HeroSelect1.Sorted = True
        HeroSelect2.Sorted = True
        HeroSelect3.Sorted = True
        HeroSelect4.Sorted = True
        HeroSelect5.Sorted = True
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
