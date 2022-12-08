using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmissionWithFile
{
    public delegate void EventManager();
    public static class Events
    {
        public static event EventManager starter;//co - ordinates all the functionalites so we use multicasting
        public static void Subscribe()
        {
            starter = new EventManager(Files.Create);
            starter+=new EventManager(Operation.Subscribe);
            starter += new EventManager(Files.ReadFiles);
            starter += new EventManager(Operation.MainMenu);
            starter += new EventManager(Files.WriteFiles);
        }

        public static void Starter()
        {
            Subscribe();
            starter();
        }

    }
}