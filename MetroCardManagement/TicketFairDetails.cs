using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class TicketFairDetails
    {
        private static int s_ticketID = 100;
        public string TicketID { get; }
        public string FromLocation { get; set; }
        public string ToLocation { get; set; }
        public int TicketPrice{ get; set; }

        public TicketFairDetails(string fromLocation,string toLocation,int ticketPrice)
        {
            s_ticketID++;
            TicketID = "MR"+s_ticketID;
            FromLocation = fromLocation;
            ToLocation = toLocation;
            TicketPrice = ticketPrice;
        }

        public TicketFairDetails(string data)
        {
            string[] values = data.Split(',');
            s_ticketID = int.Parse(values[0].Remove(0,3));
            TicketID = values[0];
            FromLocation = values[1];
            ToLocation = values[2];
            TicketPrice = int.Parse(values[3]);
        }
    }
}