using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Checkpoint4_App
{
    public partial class StaffOnly : Window
    {
        public List<MemberTroupe> memberTroupes { get; set; } = new List<MemberTroupe>();
        public Troupe newTroupe { get; set; } = new Troupe();
        public StaffOnly()
        {
            InitializeComponent();
            TroupeNameComboBox.ItemsSource = GetInfos.GetTroupesName();
        }

        private void AddShow_btn_Click(object sender, RoutedEventArgs e)
        {
            if(ShowNameTextBox.Text != String.Empty && TypeShowTextBox.Text != String.Empty && DescriptionTextBox.Text != String.Empty && 
                TroupeNameComboBox.Text != String.Empty && PutNumberPlacesTxtBox.Text != String.Empty && !GetInfos.IsShowNameExisting(ShowNameTextBox.Text))
            {
                using (var context = new CircusContext())
                {
                    Troupe troupe = GetInfos.GetTroupeByName(TroupeNameComboBox.Text);
                    Show newShow = new Show();
                    newShow.ShowName = ShowNameTextBox.Text;
                    newShow.ShowType = TypeShowTextBox.Text;
                    newShow.TroupeName = troupe.NameTroupe;
                    newShow.Description = DescriptionTextBox.Text;
                    TicketOffice ticketOffice = new TicketOffice();
                    ticketOffice.NameTroupe = troupe.NameTroupe;
                    ticketOffice.ShowName = newShow.ShowName;
                    ticketOffice.AvailableTickets = Convert.ToInt32(PutNumberPlacesTxtBox.Text);
                    ticketOffice.SoldTickets = 0;
                    troupe.ShowsList.Add(newShow);
                    context.Add(newShow);
                    context.Add(ticketOffice);
                    context.Update(troupe);
                    context.SaveChanges();
                }
                MessageBox.Show("Your show is save.");
            }
            else
            {
                MessageBox.Show("Have you complete all cases ?");
            }
        }

        private void Display_btn_Click(object sender, RoutedEventArgs e)
        {
            if (ChoiceComboBox.Text == "User")
            {
                GetUsers();
            }
            if (ChoiceComboBox.Text == "Show")
            {
                GetShows();
            }
        }

        private void Reset_btn_Click(object sender, RoutedEventArgs e)
        {
            ChoiceComboBox.Text = null;
            DisplayTextBox.Text = String.Empty;
        }

        private void Export_btn_Click(object sender, RoutedEventArgs e)
        {
            if(DisplayTextBox.Text != String.Empty)
            {
                string todaysDate = DateTime.Today.Date.ToString("MM-dd-yyyy");
                string path = "ExportDataFiles/" + ChoiceComboBox.Text + "_" + todaysDate + ".txt";
                using (var tw = new StreamWriter(path))
                {
                    tw.WriteLine(DisplayTextBox.Text);
                }
                MessageBox.Show("Your file is created. You can fine it in the ExportFile repository : " + System.IO.Path.GetFullPath(path));
            }
            else
            {
                MessageBox.Show("Choose data to export !");
            }
        }       

        private void AddMember_btn_Click_1(object sender, RoutedEventArgs e)
        {            
            if(MembersTxtBox.Text != String.Empty)
            {
                MemberTroupe newMemeber = new MemberTroupe();
                newMemeber.Name = MembersTxtBox.Text;
                newMemeber.Age = Convert.ToInt32(AgeTxtBx.Text);
                newMemeber.Job = JobTxtBx.Text;
                memberTroupes.Add(newMemeber);
            }            
            ClearListView();
        }

        private void AddTroupe_Click(object sender, RoutedEventArgs e)
        {
            if(TroupeNameTxtBox.Text!=String.Empty && ShowTypeTxtBox.Text != String.Empty && MembersListView.Items.Count > 0)
            {
                newTroupe.NameTroupe = TroupeNameTxtBox.Text;
                newTroupe.ShowType = ShowTypeTxtBox.Text;
                using (var context = new CircusContext())
                {
                    context.Add(newTroupe);
                    context.AddRange(memberTroupes);
                    context.SaveChanges();
                }
                ClearComboBox();
                MessageBox.Show("You have save your Troupe !");
            }
            else
            {
                MessageBox.Show("Have you complete all cases ?");
            }
        }

        private void GetUsers()
        {
            var Client = new WebClient();
            var path = ChoiceComboBox.Text;
            string text = Client.DownloadString($"http://localhost:1234/" + path);
            ICollection<User> users = JsonConvert.DeserializeObject<ICollection<User>>(text);
            foreach (User item in users)
            {
                DisplayTextBox.Text = DisplayTextBox.Text + "userid = " + item.UserId + "\n " + "Name = " + item.Name + "\n\n";
            }
        }
        private void GetShows()
        {
            var Client = new WebClient();
            var path = ChoiceComboBox.Text;
            string text = Client.DownloadString($"http://localhost:1234/" + path);
            ICollection<Show> shows = JsonConvert.DeserializeObject<ICollection<Show>>(text);
            foreach (Show item in shows)
            {
                DisplayTextBox.Text = DisplayTextBox.Text + "userid = " + item.ShowId + "\n " + "Name = " + item.ShowName + "\n" + "Show Type = " +
                    item.ShowType + "\n" + "Troupe name = " + item.TroupeName + "\n" + "Description= " + item.Description + "\n\n";
            }
        }
        private void ClearListView()
        {
            MembersListView.ItemsSource = null;
            MembersListView.ItemsSource = memberTroupes;
        }

        private void ClearComboBox()
        {
            TroupeNameComboBox.ItemsSource = null;
            TroupeNameComboBox.ItemsSource = GetInfos.GetTroupesName();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            TypeShowTextBox.Text = String.Empty;
            ShowNameTextBox.Text = String.Empty;
            PutNumberPlacesTxtBox.Text = String.Empty;
            DescriptionTextBox.Text = String.Empty;
            TroupeNameComboBox.Text = String.Empty;
        }
    }
}
