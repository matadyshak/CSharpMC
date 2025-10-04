using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Controls;

namespace HotelApp.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IDatabaseData _db;
        public MainWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
        }

        private void searchForGuest_Click(object sender, RoutedEventArgs e)
        {
            List<BookingFullModel> bookings = _db.SearchBookings(lastNameText.Text);
            resultsList.ItemsSource = bookings;
        }

        private void CheckInButton_Click(object sender, RoutedEventArgs e)
        {
            //if (resultsList.SelectedItem is BookingFullModel booking)
            //{
            //    var checkInForm = App.serviceProvider.GetService(typeof(CheckInForm)) as CheckInForm;
            //    checkInForm.LoadBooking(booking);
            //    checkInForm.ShowDialog();
            //    //Refresh the list after check-in
            //    searchForGuest_Click(null, null);
            //}
            //else
            //{
            //    MessageBox.Show("Please select a booking from the list.");
            //}

            var checkInForm = App.serviceProvider.GetService<CheckInForm>();
            var model = (BookingFullModel)((Button)e.Source).DataContext;

            checkInForm.PopulateCheckInInfo(model);

            checkInForm.Show();
        }
    }
}