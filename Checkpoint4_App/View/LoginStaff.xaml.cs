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
    public partial class LoginStaff : Window
    {
        public LoginStaff()
        {
            InitializeComponent();
        }
        private void btnEnter_Click_1(object sender, RoutedEventArgs e)
        {

            User newUser = new User { Name = UserNameTextBox.Text, Password = PasswordTextBox.Password };
            if (Authentify(newUser))
            {
                StaffOnly staffOnly = new StaffOnly();
                staffOnly.Show();
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
                                         where currentPerson.Name == p.Name && currentPerson.Password == p.Password && currentPerson.StaffMember == p.StaffMember
                                         select p;

                if (getNameAndPassword.Count() == 1 && currentPerson.StaffMember)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
