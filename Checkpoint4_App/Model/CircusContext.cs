using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Checkpoint4_App
{
    public class CircusContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Troupe> Troupes { get; set; }
        public virtual DbSet<Calendar> Calendars { get; set; }
        public virtual DbSet<TicketOffice> Reservations { get; set; }
        public virtual DbSet<MemberTroupe> MemberTroupes { get; set; }
        public virtual DbSet<Show> Shows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LOCALHOST\SQLEXPRESS;Database=Checkpoint4;Integrated Security=True;MultipleActiveResultSets=true");
        }

    }
}
