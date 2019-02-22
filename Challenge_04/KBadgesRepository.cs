using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_04
{
    public class KBadgesRepository
    {
        private List<string> _doorAccessList = new List<string>();
        private Dictionary<int, List<string>> BadgeDic = new Dictionary<int, List<string>>();

        public List<string> GetList()
        {
            return _doorAccessList;
        }

        public void AddDoortoList(string door)
        {
            _doorAccessList.Add(door);
        }

        public void RemoveDoorFromList(string door)
        {
            _doorAccessList.Remove(door);
        }
        public void AddBadgeToDictionary(KomodoBadge badge)
        {
            BadgeDic.Add(badge.BadgeID, badge.DoorList);
        }
        public Dictionary<int, List<string>> GetDictionary()
        {
            return BadgeDic;
        }
    }
}
