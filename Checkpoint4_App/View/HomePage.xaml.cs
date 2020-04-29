using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Checkpoint4_App
{
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Home_btn_Click(object sender, RoutedEventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Owner = this;
            homePage.Show();
            homePage.Closed += (s, eventarg) =>
            {
                this.Activate();
            };
        }

        private void Troupe_btn_Click(object sender, RoutedEventArgs e)
        {
            Troupes troupePage = new Troupes();
            troupePage.Owner = this;
            troupePage.Show();
            troupePage.Closed += (s, eventarg) =>
            {
                this.Activate();
            };
        }

        private void Calendar_btn_Click(object sender, RoutedEventArgs e)
        {
            CalendarEvent calendarEvent = new CalendarEvent();
            calendarEvent.Owner = this;
            calendarEvent.Show();
            calendarEvent.Closed += (s, eventarg) =>
            {
                this.Activate();
            };
        }

        private void Prices_btn_Click(object sender, RoutedEventArgs e)
        {
            PricesSchedule pricesSchedule = new PricesSchedule();
            pricesSchedule.Owner = this;
            pricesSchedule.Show();
            pricesSchedule.Closed += (s, eventarg) =>
            {
                this.Activate();
            };
        }

        private void Reservation_btn_Click(object sender, RoutedEventArgs e)
        {
            Reservations reservations = new Reservations();
            reservations.Owner = this;
            reservations.Show();
            reservations.Closed += (s, eventarg) =>
            {
                this.Activate();
            };
        }

        private void Staff_btn_Click(object sender, RoutedEventArgs e)
        {
            StaffOnly StaffOnly = new StaffOnly();
            StaffOnly.Owner = this;
            StaffOnly.Show();
            StaffOnly.Closed += (s, eventarg) =>
            {
                this.Activate();
            };
        }
    }
}
