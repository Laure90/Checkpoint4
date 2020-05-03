using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace Checkpoint4_App
{
    public partial class Troupes : Window
    {
        public Troupes()
        {
            InitializeComponent();
            TroupeNameComboBox.ItemsSource = GetInfos.GetTroupesName();
        }

        private void DisplayInfo_Click(object sender, RoutedEventArgs e)
        {
            string troupe = TroupeNameComboBox.Text;
            List<Troupe> listTroupe = GetInfos.ReturnTroupeData(troupe);
            foreach(Troupe tp in listTroupe)
            {
                InfoTroupe.Text += "Name Troupe : " + tp.NameTroupe + "\nShow Type : " + tp.ShowType ;                
            }
            List<MemberTroupe> memberList = GetInfos.GetMembersByTroupe(troupe);
            foreach (MemberTroupe mb in memberList)
            {
                InfoTroupe.Text += "\nMember Name : " + mb.Name;
            }
            List<Show> showList = GetInfos.GetShowByTroupeName(troupe);           
            foreach (Show sh in showList)
            {
                InfoTroupe.Text += "\nShow Name : " + sh.ShowName + "\nDescription of the show : " + sh.Description;
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            TroupeNameComboBox.Text = String.Empty;
            InfoTroupe.Text = String.Empty;
        }
    }
}
