using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint4_App
{
    public class TicketOffice
    {
        public Guid TicketOfficeId { get; set; }
        public string NameTroupe { get; set; }
        public string ShowName { get; set; }
        public int AvailableTickets{ get; set; }
        public int SoldTickets { get; set; }
    }
}
