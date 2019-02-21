using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_04
{

    public class KomodoBadge
    {
        public int BadgeID { get; set; }
        public List<string> DoorList { get; set; }

        public KomodoBadge()
        {

        }
        public KomodoBadge(int badgeID, List<string> doorList)
        {
            BadgeID = badgeID;
            DoorList = doorList;
        }

    }
}
