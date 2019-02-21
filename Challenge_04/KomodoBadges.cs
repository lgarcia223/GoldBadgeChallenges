using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_04
{
    public class KomodoBadge
    {
        public string DoorOne { get; set; }
        public string DoorTwo { get; set; }
        public string DoorThree { get; set; }
        public string DoorFour { get; set; }
        public int BadgeID { get; set; }

        public KomodoBadge()
        {
            Dictionary<int, KomodoBadge> badges = new Dictionary<int, KomodoBadge>()
            {
                [101] = new KomodoBadge { BadgeID=2101, DoorOne = "A1", DoorTwo = "B1", DoorThree = "C1", DoorFour = "D1" },
                [102] = new KomodoBadge { BadgeID = 2102, DoorOne = "A2", DoorTwo = "B2", DoorThree = "C2", DoorFour = "D2" },
                [103] = new KomodoBadge { BadgeID = 2103, DoorOne = "A3", DoorTwo = "B3", DoorThree = "C3", DoorFour = "D3" },
            };

        }
    }
}
