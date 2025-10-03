using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using System.Collections.ObjectModel;
using System.Windows;

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
            DataContext = this; // This enables binding to MainWindow's properties
        }

        public ObservableCollection<BookingFullModel> FilteredReservations { get; set; } = new();
        public List<BookingFullModel> Bookings { get; set; } = new();
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string lastName = LastNameSearchBox.Text.Trim().ToLower();
            FilteredReservations.Clear();
            Bookings.Clear();

            // Get bookings with start date of today and lastName matching LastNameSearchBox from database
            Bookings = _db.SearchBookings(lastName);

            foreach (var booking in Bookings)
            {
                FilteredReservations.Add(booking);
            }
        }

        private void CheckInButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReservationGrid.SelectedItem is BookingFullModel selected)
            {
                // Update CheckedIn status in database
                int status = _db.CheckInGuest(selected.Id);

                // Update local object based on returned status
                if (status == 0)
                {
                    selected.CheckedIn = true;
                }
                else
                {
                    selected.CheckedIn = false;
                }
                ReservationGrid.Items.Refresh(); // Update UI
            }
        }
    }
}