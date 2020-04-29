using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint4_App
{
    public class Troupe
    {
        public Guid TroupeId { get; set; }
        public string NameTroupe { get; set; }
        public List<MemberTroupe> MembersName { get; set; } = new List<MemberTroupe>();
        public string ShowType { get; set; }
        public List<Show> ShowsList { get; set; } = new List<Show>();
        public Calendar CalendarShow { get; set; }
    }
}
