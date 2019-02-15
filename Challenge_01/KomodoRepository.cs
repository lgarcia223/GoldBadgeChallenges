using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Challenge_01.KomodoMenu;

namespace Challenge_01
{

    public class KomodoRepository
    {
        List<KomodoMenu> _menuList;

        public List<KomodoMenu> GetKomodoMenu()
        {
            _menuList = new List<KomodoMenu>();
            return _menuList;
        }
        public void AddItemToList(KomodoMenu item)
        {
            _menuList.Add(item);
        }

        public void RemoveItemFromList(KomodoMenu item)
        {
            _menuList.Remove(item);
        }
    }
}
