using System.Threading;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetroCardManagement
{
    public class Files
    {
        public static void Create()
        {
            if(!Directory.Exists("Metro Management"))
            {
                Directory.CreateDirectory("Metro Management");
                System.Console.WriteLine("Folder created succesfully");
            }

            if(!File.Exists("Metro Management/UserDetails.csv"))
            {
                File.Create("Metro Management/UserDetails.csv").Close();
                System.Console.WriteLine("File created");
            }

            if(!File.Exists("Metro Management/TravelDetails.csv"))
            {
                File.Create("Metro Management/TravelDetails.csv").Close();
                System.Console.WriteLine("File created");
            }

            if(!File.Exists("Metro Management/TicketFairDetails.csv"))
            {
                File.Create("Metro Management/TicketFairDetails.csv").Close();
                System.Console.WriteLine("File created");
            }
        }

        
        public static void WritFiles()
        {
            string[] userDetail = new string[Operation.userList.Count];
            int i=0;
            foreach(UserDetails user in Operation.userList)
            {
                userDetail[i] = user.CardNumber+","+user.UserName+","+user.MobileNumber+","+user.Balance;
                i++;
            }
            File.WriteAllLines("Metro Management/UserDetails.csv",userDetail);

            string[] travelHistory = new string[Operation.travelList.Count];
            i=0;
            foreach (TravelDetails travel in Operation.travelList)
            {
                travelHistory[i] = travel.TravelID+","+travel.CardNumber+","+travel.FromLocation+","+travel.ToLocation+","+travel.Date.ToString("dd/MM/yyyy")+","+travel.TravelCost;
                i++;
            }
            File.WriteAllLines("Metro Management/TravelDetails.csv",travelHistory);

            string[] ticketFair = new string[Operation.ticketList.Count];
            i=0;
            foreach(TicketFairDetails ticket in Operation.ticketList)
            {
                ticketFair[i] = ticket.TicketID+","+ticket.FromLocation+","+ticket.ToLocation+","+ticket.TicketPrice;
                i++;
            }   
            File.WriteAllLines("Metro Management/TicketFairDetails.csv",ticketFair);  
   
        }

        public static void ReadFile()
        {
            string[] userDetails = File.ReadAllLines("Metro Management/UserDetails.csv");

            foreach(string userData in userDetails)
            {
                UserDetails user = new UserDetails(userData);
                Operation.userList.Add(user);
            }

            string[] travelDetails = File.ReadAllLines("Metro Management/TravelDetails.csv");

            foreach(string travel in travelDetails)
            {
                TravelDetails travels = new TravelDetails(travel);
                Operation.travelList.Add(travels);
            }

            string[] tickFair = File.ReadAllLines("Metro Management/TicketFairDetails.csv");

            foreach(string ticket in tickFair)
            {
                TicketFairDetails tickets = new TicketFairDetails(ticket);
                Operation.ticketList.Add(tickets);
            }
            
        }
    }
}