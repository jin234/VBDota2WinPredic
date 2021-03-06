﻿Public Class Form1
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

        PictureHero1.Image = My.Resources.icon
        PictureHero2.Image = My.Resources.icon
        PictureHero3.Image = My.Resources.icon
        PictureHero4.Image = My.Resources.icon
        PictureHero5.Image = My.Resources.icon

    End Sub

    Private Sub ClearDuplicationHero(sender As Object, e As EventArgs) Handles HeroSelect5.SelectedIndexChanged, HeroSelect4.SelectedIndexChanged, HeroSelect3.SelectedIndexChanged, HeroSelect2.SelectedIndexChanged

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

    Private Sub changePic1(sender As Object, e As EventArgs) Handles HeroSelect1.SelectedIndexChanged
        If HeroSelect1.SelectedItem = "Anti-Mage" Then
            PictureHero1.Image = My.Resources.Anti_Mage_icon
        End If
        If HeroSelect1.SelectedItem = "Phantom Assasin" Then
            PictureHero1.Image = My.Resources.Phantom_Assassin_icon
        End If
        If HeroSelect1.SelectedItem = "Slark" Then
            PictureHero1.Image = My.Resources.Slark_icon
        End If
        If HeroSelect1.SelectedItem = "Juggernaut" Then
            PictureHero1.Image = My.Resources.Juggernaut_icon
        End If
    End Sub

    Private Sub changePic2(sender As Object, e As EventArgs) Handles HeroSelect2.SelectedIndexChanged
        If HeroSelect2.SelectedItem = "Outworld Devourer" Then
            PictureHero2.Image = My.Resources.Outworld_Devourer_icon
        End If
        If HeroSelect2.SelectedItem = "Rubic" Then
            PictureHero2.Image = My.Resources.Rubick_icon
        End If
        If HeroSelect2.SelectedItem = "Huskar" Then
            PictureHero2.Image = My.Resources.Huskar_icon
        End If
        If HeroSelect2.SelectedItem = "Drow Ranger" Then
            PictureHero2.Image = My.Resources.Drow_Ranger_icon
        End If
    End Sub

    Private Sub changePic3(sender As Object, e As EventArgs) Handles HeroSelect3.SelectedIndexChanged
        If HeroSelect3.SelectedItem = "Magnus" Then
            PictureHero3.Image = My.Resources.Magnus_icon
        End If
        If HeroSelect3.SelectedItem = "Axe" Then
            PictureHero3.Image = My.Resources.Axe_icon
        End If
        If HeroSelect3.SelectedItem = "Sand King" Then
            PictureHero3.Image = My.Resources.Sand_King_icon
        End If
        If HeroSelect3.SelectedItem = "Beast Master" Then
            PictureHero3.Image = My.Resources.Beastmaster_icon
        End If
    End Sub

    Private Sub changePic4(sender As Object, e As EventArgs) Handles HeroSelect4.SelectedIndexChanged
        If HeroSelect4.SelectedItem = "Anti-Mage" Then
            PictureHero4.Image = My.Resources.Anti_Mage_icon
        End If
        If HeroSelect4.SelectedItem = "Phantom Assasin" Then
            PictureHero4.Image = My.Resources.Phantom_Assassin_icon
        End If
        If HeroSelect4.SelectedItem = "Slark" Then
            PictureHero4.Image = My.Resources.Slark_icon
        End If
        If HeroSelect4.SelectedItem = "Juggernaut" Then
            PictureHero4.Image = My.Resources.Juggernaut_icon
        End If
        If HeroSelect4.SelectedItem = "Outworld Devourer" Then
            PictureHero4.Image = My.Resources.Outworld_Devourer_icon
        End If
        If HeroSelect4.SelectedItem = "Rubic" Then
            PictureHero4.Image = My.Resources.Rubick_icon
        End If
        If HeroSelect4.SelectedItem = "Huskar" Then
            PictureHero4.Image = My.Resources.Huskar_icon
        End If
        If HeroSelect4.SelectedItem = "Drow Ranger" Then
            PictureHero4.Image = My.Resources.Drow_Ranger_icon
        End If
        If HeroSelect4.SelectedItem = "Magnus" Then
            PictureHero4.Image = My.Resources.Magnus_icon
        End If
        If HeroSelect4.SelectedItem = "Axe" Then
            PictureHero4.Image = My.Resources.Axe_icon
        End If
        If HeroSelect4.SelectedItem = "Sand King" Then
            PictureHero4.Image = My.Resources.Sand_King_icon
        End If
        If HeroSelect4.SelectedItem = "Beast Master" Then
            PictureHero4.Image = My.Resources.Beastmaster_icon
        End If
        If HeroSelect4.SelectedItem = "Lion" Then
            PictureHero4.Image = My.Resources.Lion_icon
        End If
        If HeroSelect4.SelectedItem = "Lich" Then
            PictureHero4.Image = My.Resources.Lich_icon
        End If
        If HeroSelect4.SelectedItem = "Orge Magi" Then
            PictureHero4.Image = My.Resources.Ogre_Magi_icon
        End If
        If HeroSelect4.SelectedItem = "Shadow Shaman" Then
            PictureHero4.Image = My.Resources.Shadow_Shaman_icon
        End If
        If HeroSelect4.SelectedItem = "Jakiro" Then
            PictureHero4.Image = My.Resources.Jakiro_icon
        End If
        If HeroSelect4.SelectedItem = "Phoenix" Then
            PictureHero4.Image = My.Resources.Phoenix_icon
        End If
        If HeroSelect4.SelectedItem = "Dazzle" Then
            PictureHero4.Image = My.Resources.Dazzle_icon
        End If
        If HeroSelect4.SelectedItem = "Bane" Then
            PictureHero4.Image = My.Resources.Bane_icon
        End If
    End Sub

    Private Sub changePic5(sender As Object, e As EventArgs) Handles HeroSelect5.SelectedIndexChanged
        If HeroSelect5.SelectedItem = "Anti-Mage" Then
            PictureHero5.Image = My.Resources.Anti_Mage_icon
        End If
        If HeroSelect5.SelectedItem = "Phantom Assasin" Then
            PictureHero5.Image = My.Resources.Phantom_Assassin_icon
        End If
        If HeroSelect5.SelectedItem = "Slark" Then
            PictureHero5.Image = My.Resources.Slark_icon
        End If
        If HeroSelect5.SelectedItem = "Juggernaut" Then
            PictureHero5.Image = My.Resources.Juggernaut_icon
        End If
        If HeroSelect5.SelectedItem = "Outworld Devourer" Then
            PictureHero5.Image = My.Resources.Outworld_Devourer_icon
        End If
        If HeroSelect5.SelectedItem = "Rubic" Then
            PictureHero5.Image = My.Resources.Rubick_icon
        End If
        If HeroSelect5.SelectedItem = "Huskar" Then
            PictureHero5.Image = My.Resources.Huskar_icon
        End If
        If HeroSelect5.SelectedItem = "Drow Ranger" Then
            PictureHero5.Image = My.Resources.Drow_Ranger_icon
        End If
        If HeroSelect5.SelectedItem = "Magnus" Then
            PictureHero5.Image = My.Resources.Magnus_icon
        End If
        If HeroSelect5.SelectedItem = "Axe" Then
            PictureHero5.Image = My.Resources.Axe_icon
        End If
        If HeroSelect5.SelectedItem = "Sand King" Then
            PictureHero5.Image = My.Resources.Sand_King_icon
        End If
        If HeroSelect5.SelectedItem = "Beast Master" Then
            PictureHero5.Image = My.Resources.Beastmaster_icon
        End If
        If HeroSelect5.SelectedItem = "Lion" Then
            PictureHero5.Image = My.Resources.Lion_icon
        End If
        If HeroSelect5.SelectedItem = "Lich" Then
            PictureHero5.Image = My.Resources.Lich_icon
        End If
        If HeroSelect5.SelectedItem = "Orge Magi" Then
            PictureHero5.Image = My.Resources.Ogre_Magi_icon
        End If
        If HeroSelect5.SelectedItem = "Shadow Shaman" Then
            PictureHero5.Image = My.Resources.Shadow_Shaman_icon
        End If
        If HeroSelect5.SelectedItem = "Jakiro" Then
            PictureHero5.Image = My.Resources.Jakiro_icon
        End If
        If HeroSelect5.SelectedItem = "Phoenix" Then
            PictureHero5.Image = My.Resources.Phoenix_icon
        End If
        If HeroSelect5.SelectedItem = "Dazzle" Then
            PictureHero5.Image = My.Resources.Dazzle_icon
        End If
        If HeroSelect5.SelectedItem = "Bane" Then
            PictureHero5.Image = My.Resources.Bane_icon
        End If
    End Sub

End Class
