    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Checkpoint4_App
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            User newUser = new User { Name = UserNameTextBox.Text, Password = Sha256Tools.GetHash(PasswordTextBox.Password) };
            if (Authentify(newUser))
            {
                HomePage homePage = new HomePage();
                homePage.Show();
                this.Close();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Username or password invalid", "User issue!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public static bool Authentify(User currentPerson)
        {
            using (var context = new CircusContext())
            {
                var getNameAndPassword = from p in context.Users
                                         where currentPerson.Name == p.Name && currentPerson.Password == p.Password
                                         select new { p.Name, p.Password };

                if (getNameAndPassword.Count() == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void Subscribe_Click(object sender, RoutedEventArgs e)
        {
            Inscription inscription = new Inscription();
            inscription.Owner = this;
            inscription.Show();
            inscription.Closed += (s, eventarg) =>
            {
                this.Activate();
            };
        }
    }
}