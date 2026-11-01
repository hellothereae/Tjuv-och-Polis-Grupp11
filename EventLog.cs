using System;
using System.Collections.Generic;
using System.Text;

namespace polis__Staden_
{
    internal class EventLog
    {

        List <string> events = new List <string> ();


        public void addEvent(string info)
        {
            events.Insert (0,info);
            if (events.Count > 10) 
            {
                events.RemoveAt(10);
            }
        }
        public void showEvent() 
        {
            for (int i = 0; i < events.Count; i++)  
            {
                
                if (i == 0) 
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{events[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"{events[i]}");
                }


            }

        }
        
    }
}
