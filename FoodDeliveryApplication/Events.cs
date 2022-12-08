using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApplication
{
    public delegate void EventManager();
    public class Events
    {
        public static EventManager starter;

        public static void Subcribe()
        {
            starter = new EventManager(Files.Create);
            starter = new EventManager(Operation.Subcribe);
            starter += new EventManager(Files.ReadFiles);
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