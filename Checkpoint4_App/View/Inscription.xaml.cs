using System;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

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
            var passwordHash = ComputeHash(password);
            User newUser = new User();
            newUser.Name = name;
            if(!IsNameExisting(newUser) || UserNameTextBox.Text == String.Empty || PasswordTextBox.Password == String.Empty)
            {
                var path = name + "/" + passwordHash;
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
        public string ComputeHash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private void Close_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
