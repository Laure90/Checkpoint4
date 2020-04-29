using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Checkpoint4_App
{
    public partial class Reservations : Window
    {
        public List<TicketOffice> TicketOfficesList { get; set; } = new List<TicketOffice>();
        public Reservations()
        {
            InitializeComponent();
            var list = GetInfos.GetShowByTroupe();
            List<string> shows = list.Select(x => x.ShowName).ToList();
            ShowNameComboBox.ItemsSource = shows;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string show = ShowNameComboBox.Text;
            int numberTicket= Convert.ToInt32(NumberTicketBox.Text);
            int availablePlace = GetInfos.GetNumberAvailableTickets(show);
            if(availablePlace > 0 && numberTicket <= availablePlace)
            {
                int price = Convert.ToInt32(priceTextBox.Text);
                int ticketNumber = numberTicket;
                TotalTextBox.Text = Convert.ToString(price * ticketNumber);
                int availablePlaces = Convert.ToInt32(RemainingPlacesTextBox.Text);
                int numberPlace = availablePlaces - ticketNumber;
                RemainingPlacesTextBox.Text = numberPlace.ToString();                
            }
            else
            {
                MessageBox.Show("There is no place you can't sold it.");
            }
            if (availablePlace <= 0)
            {
                RemainingPlacesTextBox.Text = "0";
            }
            using (var context = new CircusContext())
            {
                TicketOfficesList = GetInfos.GetTicketOffices();
                TicketOffice ticketOffice = TicketOfficesList.FirstOrDefault(s => s.ShowName == ShowNameComboBox.Text);
                ticketOffice.AvailableTickets = Convert.ToInt32(RemainingPlacesTextBox.Text);
                ticketOffice.SoldTickets = ticketOffice.SoldTickets + Convert.ToInt32(NumberTicketBox.Text);
                context.Update(ticketOffice);
                context.SaveChanges();
            }
        }

        private void Display_Click(object sender, RoutedEventArgs e)
        {
            string show = ShowNameComboBox.Text;
            RemainingPlacesTextBox.Text = GetInfos.GetNumberAvailableTickets(show).ToString();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
