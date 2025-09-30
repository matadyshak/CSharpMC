using HotelAppLibrary.Data;
using System.Windows;

namespace HotelApp.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IDatabaseData db)
        {
            InitializeComponent();
        }
    }
}