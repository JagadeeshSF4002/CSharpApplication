using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaCardManagement
{
    public delegate void EventManager();
    public class Events
    {
        public static event EventManager starter;

        public static void Subcribe()
        {
            starter = new EventManager(Files.Create);
            starter = new EventManager(Operation.subcribe);
            starter += new EventManager(Files.ReadLines);
            starter += new EventManager(Operation.MainMenu);
            starter += new EventManager(Files.WriteFiles);
        }

        public static void Starter()
        {
            Subcribe();
            starter();
        }
    }
}