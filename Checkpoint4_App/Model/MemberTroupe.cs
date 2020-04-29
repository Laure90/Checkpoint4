using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint4_App
{
    public class MemberTroupe
    {
        public Guid MemberTroupeId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Job { get; set; }
        public Troupe Troupe { get; set; }
    }
}
