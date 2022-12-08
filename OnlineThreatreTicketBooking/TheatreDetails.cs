using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineThreatreTicketBooking
{
    public class TheatreDetails
    {
        private static int s_theatreID = 300;
        public string TheatreID { get;}
        public string TheatreName { get; set; }
        public string TheatreLocation { get; set; }

        public TheatreDetails(string theatreName,string theatreLocation)
        {
            s_theatreID++;
            TheatreID = "TID"+s_theatreID;
            TheatreName = theatreName;
            TheatreLocation = theatreLocation;
        }

        public TheatreDetails(string data)
        {
            string[] values = data.Split(',');
            s_theatreID = int.Parse(values[0].Remove(0,3));
            TheatreID = values[0];
            TheatreName = values[1];
            TheatreLocation = values[2];        
        }
    }
}