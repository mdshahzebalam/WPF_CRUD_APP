using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Shahzeb.ViewModel;
namespace Shahzeb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployeesViewModel employeesViewModel;
        public MainWindow()
        {
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            InitializeComponent();
            employeesViewModel = new EmployeesViewModel();
            this.DataContext = employeesViewModel;
        }
    }
}