using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace colGeneration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MetadataLocator.Default = MetadataLocator.Create().AddMetadata(typeof(Customer), typeof(DataAnnotationsElement1Metadata));

            ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
            for (int i = 1; i < 10; i++)
            {
                customers.Add(new Customer() { ID = i, Name = "Name" + i, Phone = "00-00-0" + i % 10, HiredAt = DateTime.Now.AddDays(-i) });
            }
            grid.ItemsSource = customers;

            ObservableCollection<Customer2> customers2 = new ObservableCollection<Customer2>();
            for (int i = 1; i < 10; i++)
            {
                customers2.Add(new Customer2() { ID = i, Name = "Name" + i, Phone = "00-00-0" + i % 10, HiredAt = DateTime.Now.AddDays(-i) });
            }
            grid2.ItemsSource = customers2;
        }
    }
    public class DataAnnotationsElement1Metadata : IMetadataProvider<Customer>
    {
        void IMetadataProvider<Customer>.BuildMetadata(MetadataBuilder<Customer> builder)
        {
            builder.Property(p => p.ID).NumericMask("N0");
            builder.Property(p => p.Name).DisplayFormatString("name is: {0}", true);
            builder.Property(p => p.Phone).RegExMask(@"\d{2}-\d{2}-\d{2}");
            builder.Property(p => p.HiredAt).DateTimeMask("dd/MM/yyyy");
        }
    }
    public class Customer
    {
        public int ID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string Phone
        {
            get;
            set;
        }
        public DateTime HiredAt
        {
            get;
            set;
        }
    }
    public class Customer2
    {
        [NumericMask(Mask = "N0")]
        public int ID
        {
            get;
            set;
        }
        [DisplayFormat(DataFormatString = "name is: {0}")]
        public string Name
        {
            get;
            set;
        }
        [RegExMask(Mask = @"\d{2}-\d{2}-\d{2}")]
        public string Phone
        {
            get;
            set;
        }
        [DateTimeMask(Mask = "dd/MM/yyyy")]
        public DateTime HiredAt
        {
            get;
            set;
        }
    }
}
