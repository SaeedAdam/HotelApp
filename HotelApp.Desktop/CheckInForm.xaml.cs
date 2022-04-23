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
using System.Windows.Shapes;
using HotelAppLibrary.Data;
using HotelAppLibrary.Models;

namespace HotelApp.Desktop
{
    /// <summary>
    /// Interaction logic for CheckInForm.xaml
    /// </summary>
    public partial class CheckInForm : Window
    {
        private readonly IDatabaseData _db;
        private BookingFullModel _data = null;
        public CheckInForm(IDatabaseData db)
        {
            _db = db;
            InitializeComponent();
        }

        public void PopulateCheckInInfo(BookingFullModel data)
        {
            _data = data;
            firstNameText.Text = _data.FirstName;
            lastNameText.Text = _data.LastName;
            typeText.Text = _data.Type;
            roomNumberText.Text = _data.RoomNumber;
            totalCostText.Text = $"{_data.TotalCost:C}";
        }

        private void CheckInUser_OnClick(object sender, RoutedEventArgs e)
        {
            _db.CheckInGuest(_data.Id);
            Close();
        }
    }
}
