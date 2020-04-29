using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint4_App
{
    public class Show
    {
        public Guid ShowId { get; set; }
        public string ShowName { get; set; }
        public string TroupeName { get; set; }
        public string ShowType { get; set; }
        public List<MemberTroupe> MemberTroupes { get; set; }
        public string Description { get; set; }
    }
}
