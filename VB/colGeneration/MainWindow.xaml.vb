Imports Microsoft.VisualBasic
Imports DevExpress.Mvvm.DataAnnotations
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace colGeneration
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window
        Public Sub New()
            InitializeComponent()

            MetadataLocator.Default = MetadataLocator.Create().AddMetadata(GetType(Customer), GetType(DataAnnotationsElement1Metadata))

            Dim customers As New ObservableCollection(Of Customer)()
            For i As Integer = 1 To 9
                customers.Add(New Customer() With {.ID = i, .Name = "Name" & i, .Phone = "00-00-0" & i Mod 10, .HiredAt = DateTime.Now.AddDays(-i)})
            Next i
            grid.ItemsSource = customers

            Dim customers2 As New ObservableCollection(Of Customer2)()
            For i As Integer = 1 To 9
                customers2.Add(New Customer2() With {.ID = i, .Name = "Name" & i, .Phone = "00-00-0" & i Mod 10, .HiredAt = DateTime.Now.AddDays(-i)})
            Next i
            grid2.ItemsSource = customers2
        End Sub
    End Class
    Public Class DataAnnotationsElement1Metadata
        Implements IMetadataProvider(Of Customer)
        Private Sub BuildMetadata(ByVal builder As MetadataBuilder(Of Customer)) Implements IMetadataProvider(Of Customer).BuildMetadata
            builder.Property(Function(p) p.ID).NumericMask("N0")
            builder.Property(Function(p) p.Name).DisplayFormatString("name is: {0}", True)
            builder.Property(Function(p) p.Phone).RegExMask("\d{2}-\d{2}-\d{2}")
            builder.Property(Function(p) p.HiredAt).DateTimeMask("dd/MM/yyyy")
        End Sub
    End Class
    Public Class Customer
        Private privateID As Integer
        Public Property ID() As Integer
            Get
                Return privateID
            End Get
            Set(ByVal value As Integer)
                privateID = value
            End Set
        End Property
        Private privateName As String
        Public Property Name() As String
            Get
                Return privateName
            End Get
            Set(ByVal value As String)
                privateName = value
            End Set
        End Property
        Private privatePhone As String
        Public Property Phone() As String
            Get
                Return privatePhone
            End Get
            Set(ByVal value As String)
                privatePhone = value
            End Set
        End Property
        Private privateHiredAt As DateTime
        Public Property HiredAt() As DateTime
            Get
                Return privateHiredAt
            End Get
            Set(ByVal value As DateTime)
                privateHiredAt = value
            End Set
        End Property
    End Class
    Public Class Customer2
        Private privateID As Integer
        <NumericMask(Mask:="N0")> _
        Public Property ID() As Integer
            Get
                Return privateID
            End Get
            Set(ByVal value As Integer)
                privateID = value
            End Set
        End Property

        Private privateName As String
        <DisplayFormat(DataFormatString:="name is: {0}")> _
        Public Property Name() As String
            Get
                Return privateName
            End Get
            Set(ByVal value As String)
                privateName = value
            End Set
        End Property

        Private privatePhone As String
        <RegExMask(Mask:="\d{2}-\d{2}-\d{2}")> _
        Public Property Phone() As String
            Get
                Return privatePhone
            End Get
            Set(ByVal value As String)
                privatePhone = value
            End Set
        End Property

        Private privateHiredAt As DateTime
        <DateTimeMask(Mask:="dd/MM/yyyy")> _
        Public Property HiredAt() As DateTime
            Get
                Return privateHiredAt
            End Get
            Set(ByVal value As DateTime)
                privateHiredAt = value
            End Set
        End Property
    End Class
End Namespace
