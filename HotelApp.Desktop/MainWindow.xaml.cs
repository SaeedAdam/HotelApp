using System;
using System.Collections.Generic;
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
using HotelAppLibrary.Data;
using HotelAppLibrary.Models;
using Microsoft.Extensions.DependencyInjection;

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
            _db = db;
            InitializeComponent();
        }

        private void SearchForGuest_OnClick(object sender, RoutedEventArgs e)
        {
            List<BookingFullModel> bookings = _db.SearchBookings(lastNameText.Text);
            resultsList.ItemsSource = bookings;
        }

        private void CheckInButton_OnClick(object sender, RoutedEventArgs e)
        {
            var checkInForm = App.serviceProvider.GetService<CheckInForm>();
            var model = (BookingFullModel)((Button)e.Source).DataContext;

            checkInForm.PopulateCheckInInfo(model);

            checkInForm.Show();
        }
    }
}
