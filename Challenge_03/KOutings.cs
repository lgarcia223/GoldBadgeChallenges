using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_03
{
    public enum OutingType { Golf, Bowling, AmusementPark, Concert, Other}
    public class KOutings
    {
        public OutingType TypeofOuting { get; set; }
        public decimal Attendees { get; set; }
        public string Date { get; set; }
        public decimal CostPerson { get; set; }
        public decimal CostEvent { get; set; }


        public KOutings()
        {

        }

        public KOutings(OutingType typeOfOuting, decimal attendees, string date, decimal costPerson)
        {
            TypeofOuting = typeOfOuting;
            Attendees = attendees;
            Date = date;
            CostPerson = costPerson;
            CostEvent = CostPerson * Attendees;
        }
    }
}
