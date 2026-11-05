using System;
using System.Collections.Generic;
using System.Text;

namespace PoliceAndThief
{
    internal class EventLog
    {
        List <string> events = new ();

        public void addEvent(string info)
        {
            events.Insert(0, info);
            if (events.Count > 5)
            {
                events.RemoveAt(5);
            }
        }

        public void showEvent(int startCol, int startRow) 
        {
            for (int i = 0; i < events.Count; i++)
            {
                Console.SetCursorPosition(startCol, startRow + i);

                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.ResetColor();
                }

                Console.Write(events[i]);
            }

            Console.ResetColor();

        }

    }
}
