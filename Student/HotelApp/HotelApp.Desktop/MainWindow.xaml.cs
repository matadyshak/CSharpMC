using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace HotelApp.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly IDatabaseData _db;

        public event PropertyChangedEventHandler? PropertyChanged;
        public MainWindow(IDatabaseData db)
        {
            InitializeComponent();
            _db = db;
            DataContext = this; // This enables binding to MainWindow's properties
        }

        public ObservableCollection<BookingFullModel> FilteredReservations { get; set; } = new();
        public List<BookingFullModel> Bookings { get; set; } = new();

        private bool _canCheckIn;
        public bool CanCheckIn
        {
            get => _canCheckIn;
            set
            {
                if (_canCheckIn != value)
                {
                    _canCheckIn = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CanCheckIn)));
                }
            }
        }
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

            CanCheckIn = false; // Reset after search
        }

        private void ReservationGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ReservationGrid.SelectedItem is BookingFullModel selected)
            {
                CanCheckIn = !selected.CheckedIn;
            }
            else
            {
                CanCheckIn = false;
            }
        }
        private void CheckInButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReservationGrid.SelectedItem is BookingFullModel selected)
            {
                // Update CheckedIn status in database
                CheckInResultModel result = _db.CheckInGuest(selected.Id);

                // Update local object based on returned status
                if (result.PassFailMessage == "Success")
                {
                    selected.CheckedIn = true;
                    CanCheckIn = false;
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