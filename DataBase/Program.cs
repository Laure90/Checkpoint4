using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkpoint4_App;
using Nancy.Hosting.Self;

namespace DataBase
{
    public class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("Start creation of the database");
            using (var context = new CircusContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();



                var troupe1 = new Troupe()
                {
                    NameTroupe = "The Croustillants",
                    MembersName = new List<MemberTroupe>()
                    {
                        new MemberTroupe { Name = "Pablo", Age = 28, Job = "Acrobate" },
                        new MemberTroupe { Name = "Ortencia", Age = 62, Job = "Acrobate" },
                        new MemberTroupe { Name = "Picasso", Age = 58, Job = "Acrobate" },
                        new MemberTroupe { Name = "Lolita", Age = 24, Job = "Acrobate" },
                    },

                };

                var troupe2 = new Troupe()
                {
                    NameTroupe = "The Clowns",
                    MembersName = new List<MemberTroupe>()
                    {
                        new MemberTroupe { Name = "Albert", Age = 28, Job = "Clown" },
                        new MemberTroupe { Name = "Filibert", Age = 62, Job = "Clown" },
                        new MemberTroupe { Name = "Gertrude", Age = 58, Job = "Clown" },
                        new MemberTroupe { Name = "Gaston", Age = 24, Job = "Clown" },
                    },

                };

                var show1 = new Show()
                {
                    ShowName = "Vol-au-Vent",
                    MemberTroupes = troupe1.MembersName,
                    TroupeName = troupe1.NameTroupe,
                    ShowType = "Acrobatics",
                    Description = "Personnes qui volent"
                };
                List<Show> show1List = new List<Show>();
                show1List.Add(show1);

                troupe1.ShowsList = show1List;
                troupe1.ShowType = show1.ShowType;

                var show2 = new Show()
                {
                    ShowName = "Qu'est-ce-qu'on se marre",
                    MemberTroupes = troupe2.MembersName,
                    TroupeName = troupe2.NameTroupe,
                    ShowType = "Clown show",
                    Description = "Clowns qui font rire"
                };

                List<Show> show2List = new List<Show>();
                show2List.Add(show2);

                troupe2.ShowsList = show2List;
                troupe2.ShowType = show2.ShowType;

                var calendar1 = new Calendar()
                {
                    ShowDay = "Lundi, Jeudi, Samedi",
                    Name = troupe1.NameTroupe,
                    Hour = "14H-15h30"
                };

                var calendar2 = new Calendar()
                {
                    ShowDay = "Lundi, Jeudi, Samedi",
                    Name = troupe2.NameTroupe,
                    Hour = "16H-18h"
                };

                troupe1.CalendarShow = calendar1;
                troupe2.CalendarShow = calendar2;


                var user1 = new User()
                {
                    Name = "Gruss",
                    Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                    StaffMember = false
                };

                var user2 = new User()
                {
                    Name = "Arlette",
                    Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                    StaffMember = false
                };

                var staffUser = new User()
                {
                    Name = "Staff",
                    Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4",
                    StaffMember = true
                };

                var tickets1 = new TicketOffice()
                {
                    NameTroupe = troupe1.NameTroupe,
                    ShowName = show1.ShowName,
                    AvailableTickets = 200,
                    SoldTickets = 10
                };

                var tickets2 = new TicketOffice()
                {
                    NameTroupe = troupe2.NameTroupe,
                    ShowName = show2.ShowName,
                    AvailableTickets = 150,
                    SoldTickets = 20
                };

                context.Add(troupe1);
                context.Add(troupe2);
                context.Add(calendar1);
                context.Add(calendar2);
                context.Add(show1);
                context.Add(show2);
                context.Add(user1);
                context.Add(user2);
                context.Add(staffUser);
                context.Add(tickets1);
                context.Add(tickets2);
                context.SaveChanges();

                Console.WriteLine("End of the database creation");
                GetHost();
            }
        }

        public static void GetHost()
        {
            HostConfiguration hostConfiguration = new HostConfiguration()
            {
                UrlReservations = new UrlReservations() { CreateAutomatically = true },
            };

            using (var host = new NancyHost(hostConfiguration, new Uri("http://localhost:1234")))
            {
                host.Start();
                Console.WriteLine("Running on http://localhost:1234");
                Console.ReadLine();
                host.Stop();
            }
        }
    }
}
