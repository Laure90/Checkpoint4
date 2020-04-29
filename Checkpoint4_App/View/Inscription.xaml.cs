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
    public partial class Inscription : Window
    {
        public Inscription()
        {
            InitializeComponent();
        }

        private void Validate_btn_Click(object sender, RoutedEventArgs e)
        {
            var name = UserNameTextBox.Text;
            var password = PasswordTextBox.Password;
            User newUser = new User();
            newUser.Name = name;
            if(!IsNameExisting(newUser) || UserNameTextBox.Text == String.Empty || PasswordTextBox.Password == String.Empty)
            {
                var path = name + "/" + password;
                var url = $"http://localhost:1234/User/" + path;
                using (var client = new WebClient())
                {
                    client.UploadString(url, "PUT", "");
                    MessageBox.Show("Your registration was successful ! Now you can put your user name and your password.");
                }

                var request = WebRequest.Create(url);
                request.Method = "PUT";
            }
            else
            {
                MessageBox.Show("This user already exits or you haven't fill in the boxes correctly !");
            }
        }
        private static bool IsNameExisting(User currentPerson)
        {
            using (var context = new CircusContext())
            {
                var getName = from p in context.Users
                                         where currentPerson.Name == p.Name
                                         select new { p.Name };

                if (getName.Count() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void Close_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
