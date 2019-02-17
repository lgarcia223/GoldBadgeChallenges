using System.Collections.Generic;

namespace Challenge_03
{
    public class KOutingsRepository
    {
        List<KOutings> _outingsList;

        public List<KOutings> GetOutingsList()
        {
            _outingsList = new List<KOutings>();
            return _outingsList;
        }
        public void AddOutingToList(KOutings outing)
        {
            _outingsList.Add(outing);
        }

    }
}