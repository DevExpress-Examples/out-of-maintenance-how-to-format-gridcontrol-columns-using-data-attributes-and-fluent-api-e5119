Imports DevExpress.Mvvm.DataAnnotations
Imports System.Collections.ObjectModel
Imports System.ComponentModel.DataAnnotations
Imports System.Windows
Imports System.Windows.Controls

Namespace colGeneration

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            MetadataLocator.Default = MetadataLocator.Create().AddMetadata(GetType(Customer), GetType(DataAnnotationsElement1Metadata))
            Dim customers As ObservableCollection(Of Customer) = New ObservableCollection(Of Customer)()
            For i As Integer = 1 To 10 - 1
                customers.Add(New Customer() With {.ID = i, .Name = "Name" & i, .Phone = "00-00-0" & i Mod 10, .HiredAt = Date.Now.AddDays(-i)})
            Next

            Me.grid.ItemsSource = customers
            Dim customers2 As ObservableCollection(Of Customer2) = New ObservableCollection(Of Customer2)()
            For i As Integer = 1 To 10 - 1
                customers2.Add(New Customer2() With {.ID = i, .Name = "Name" & i, .Phone = "00-00-0" & i Mod 10, .HiredAt = Date.Now.AddDays(-i)})
            Next

            Me.grid2.ItemsSource = customers2
        End Sub
    End Class

    Public Class DataAnnotationsElement1Metadata
        Implements IMetadataProvider(Of Customer)

        Private Sub BuildMetadata(ByVal builder As MetadataBuilder(Of Customer)) Implements IMetadataProvider(Of Customer).BuildMetadata
            builder.[Property](Function(p) p.ID).NumericMask("N0")
            builder.Property(Function(p) p.Name).DisplayFormatString("name is: {0}", True)
            builder.[Property](Function(p) p.Phone).RegExMask("\d{2}-\d{2}-\d{2}")
            builder.[Property](Function(p) p.HiredAt).DateTimeMask("dd/MM/yyyy")
        End Sub
    End Class

    Public Class Customer

        Public Property ID As Integer

        Public Property Name As String

        Public Property Phone As String

        Public Property HiredAt As Date
    End Class

    Public Class Customer2

        <NumericMask(Mask:="N0")>
        Public Property ID As Integer

        <DisplayFormat(DataFormatString:="name is: {0}")>
        Public Property Name As String

        <RegExMask(Mask:="\d{2}-\d{2}-\d{2}")>
        Public Property Phone As String

        <DateTimeMask(Mask:="dd/MM/yyyy")>
        Public Property HiredAt As Date
    End Class
End Namespace
