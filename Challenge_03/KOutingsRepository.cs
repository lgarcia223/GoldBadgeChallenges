using System;
using System.Collections.Generic;
using System.Linq;
using static Challenge_03.KOutings;

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

        public OutingType GetTypefromInt(int outingInt)
        {
            OutingType type;
            switch (outingInt)
            {
                case 1:
                    type = OutingType.Golf;
                    break;
                case 2:
                    type = OutingType.Bowling;
                    break;
                case 3:
                    type = OutingType.AmusementPark;
                    break;
                case 4:
                    type = OutingType.Concert;
                    break;
                case 5:
                    type = OutingType.Other;
                    break;
                default:
                    type = OutingType.Other;
                    break;
            }
            return type;
        }

        public decimal OutingCostByType(OutingType subtype)
        {
            decimal costByType = 0;
            foreach (KOutings outing in _outingsList)
            {
                if (subtype == outing.TypeofOuting)
                {
                    costByType += outing.CostEvent;
                }
            }
            return costByType;
        }
    }
}
