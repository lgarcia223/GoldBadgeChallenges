using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03
{
    public class KOutings
    {
        public string Outing { get; set; }
        public decimal Attendees { get; set; }
        public string Date { get; set; }
        public decimal CostPerson { get; set; }
        public decimal CostEvent { get; set; }

        public KOutings()
        {

        }

        public KOutings(string outing, decimal attendees, string date, decimal costPerson, decimal costEvent)
        {
            Outing = outing;
            Attendees = attendees;
            Date = date;
            CostPerson = costPerson;
            CostEvent = costEvent;
        }
    }
}
