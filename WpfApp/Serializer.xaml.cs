using System.Windows;

namespace ViewModel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Serializer : Window
    {
        public Serializer()
        {
            InitializeComponent();
            DataContext = new EmployeeViewModel();
        }
    }
}