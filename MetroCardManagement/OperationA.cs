using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public partial class Operation
    {
        private static void Travel()
        {
            System.Console.WriteLine("Ticket Fair Details");
            foreach(TicketFairDetails ticket in ticketList)
            {
                System.Console.WriteLine($"{ticket.TicketID} {ticket.FromLocation} {ticket.ToLocation} {ticket.TicketPrice}");
            }

            System.Console.WriteLine("Enter the Ticket ID :");
            string ticketID = Console.ReadLine().ToUpper();
            
            currentTicketFair = IsValidTicketID(ticketID);

            if(currentTicketFair != null)
            {
                if(currentUser.Balance >= currentTicketFair.TicketPrice)
                {
                    currentUser.DeductAmount(currentTicketFair.TicketPrice);
                    TravelDetails travel = new TravelDetails(currentUser.CardNumber,currentTicketFair.FromLocation,currentTicketFair.ToLocation,DateTime.Now,currentTicketFair.TicketPrice);
                    travelList.Add(travel);

                    System.Console.WriteLine("************************Ticket Booked Succesfully*******************");
                }
                else
                {
                    System.Console.WriteLine("******************Insufficient Balance******************");
                    SubMenu();
                    // System.Console.WriteLine($"Enter the amount to be rechaged : {currentTicketFair.TicketPrice}");
                    // long amount = long.Parse(Console.ReadLine());
                    // currentUser.Recharge(amount);
                }
            }
            else
            {
                System.Console.WriteLine("Invalid ID");
                
            }
        }

        public static TicketFairDetails IsValidTicketID(string ticketID)
        {
            foreach(TicketFairDetails ticket in ticketList)
            {
                if(ticket.TicketID == ticketID)
                {
                    return ticket;
                }
            }
            return null;
        }
    }
}