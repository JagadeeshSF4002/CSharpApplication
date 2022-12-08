using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineThreatreTicketBooking
{
    public class ScreeningDetails
    {
        public string MovieID { get; set; }
        public string TheatreID { get; set; }
        public int NoOfSeatsAvailable { get; set; }
        public double TotalPrice{ get; set; }

        public ScreeningDetails(string movieID,string theatreID,int noOfSeatsAvailable,double totalPrice)
        {
            MovieID = movieID;
            TheatreID = theatreID;
            NoOfSeatsAvailable = noOfSeatsAvailable;
            TotalPrice = totalPrice;
        }
    
        public ScreeningDetails(string data)
        {
            string[] values = data.Split(',');

            MovieID = values[0];
            TheatreID = values[1];
            NoOfSeatsAvailable = int.Parse(values[2]);
            TotalPrice = double.Parse(values[3]);
        }
    }

}