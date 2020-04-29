using System;
using System.Collections.Generic;
using System.Linq;

namespace Checkpoint4_App
{
    public static class GetInfos
    {
        public static List<Show> GetShowByTroupe()
        {
            using(var context = new CircusContext())
            {
                var showList = (from t in context.Troupes
                               select t.ShowsList).FirstOrDefault();
                return showList;
            }
        }
        public static List<Show> GetShowByTroupeName(string name)
        {
            using (var context = new CircusContext())
            {
                var showList = (from t in context.Troupes
                                where t.NameTroupe == name
                                select t.ShowsList).FirstOrDefault();
                return showList;
            }
        }
        public static int GetNumberAvailableTickets(string nameShow)
        {
            using(var context = new CircusContext())
            {
                var number = (from to in context.Reservations
                             where to.ShowName == nameShow
                             select to.AvailableTickets).FirstOrDefault();
                return number;
            }
        }

        public static Show GetShowByName(string name)
        {
            using (var context = new CircusContext())
            {
                var show = (from s in context.Shows
                            where s.ShowName == name
                            select s).FirstOrDefault();

                return show;
            }
        }

        public static List<string> GetTroupesName()
        {
            using (var context = new CircusContext())
            {
                var troupeName = (from t in context.Troupes
                            select t.NameTroupe).ToList();

                return troupeName;
            }
        }

        public static Troupe GetTroupeByName(string name)
        {
            using (var context = new CircusContext())
            {
                var troupeName = (from t in context.Troupes
                                  where t.NameTroupe == name
                                  select t).FirstOrDefault();

                return troupeName;
            }
        }

        public static List<MemberTroupe> GetMembersByTroupe(string nametroupe)
        {
            using (var context = new CircusContext())
            {
                var members = (from m in context.MemberTroupes
                               join t in context.Troupes
                               on m.Troupe.TroupeId equals t.TroupeId
                               where m.Troupe.NameTroupe == nametroupe
                               select m).ToList();

                return members;
            }
        }

        public static List<TicketOffice> GetTicketOffices()
        {
            using (var context = new CircusContext())
            {
                var list = (from to in context.Reservations
                           select to).ToList();
                return list;
            }
        }

        public static bool IsShowNameExisting(string showName)
        {
            using (var context = new CircusContext())
            {
                var show = (from s in context.Shows
                            where s.ShowName == showName
                            select s).ToList();

                if (show.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static List<Troupe> ReturnTroupeData(string nameTroupe)
        {
            using (var context = new CircusContext())
            {
                var infoTroupe = (from t in context.Troupes
                           where t.NameTroupe == nameTroupe
                           select t).ToList();
                return infoTroupe;
            }
        }

        public static List<Calendar> GetCalendarShowByTroupe(string nameTroupe)
        {
            using (var context = new CircusContext())
            {
                var infoTroupe = (from t in context.Troupes
                                  where t.NameTroupe == nameTroupe
                                  select t.CalendarShow).ToList();
                return infoTroupe;
            }
        }
    }
}
