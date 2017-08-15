using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Event_Implementation
{
    public class StartUp
    {
        public static void Main()
        {
            Dispatcher dispatcher = new Dispatcher();
            Handler handler = new Handler();
            dispatcher.NameChange += handler.OnDispatcherNameChange;

            while (true)
            {
                string name = Console.ReadLine();
                if (name == "End") break;

                dispatcher.Name = name;
            }
        }
    }
}
