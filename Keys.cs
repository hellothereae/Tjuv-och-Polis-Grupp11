using PoliceAndThief;
using System;
using System.Collections.Generic;
using System.Text;

namespace polis__Staden_
{
    internal class Keys
    {
        public void ShowKeyFunctions(int prisonStartRow)
        {
            Console.SetCursorPosition(70, prisonStartRow + 14);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("C");
            Console.ResetColor();
            Console.Write(" = Add a new citizen to city");

            Console.SetCursorPosition(70, prisonStartRow + 15);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("T");
            Console.ResetColor();
            Console.Write(" = Add a new Thief to city");

            Console.SetCursorPosition(70, prisonStartRow + 16);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("P");
            Console.ResetColor();
            Console.Write(" = Add a new Police to city");

            Console.SetCursorPosition(70, prisonStartRow + 17);
            Console.Write("ESC");
            Console.Write(" = Exit the game");

        }


        public void KeyFunction(City city,AddPersons addPersons, List<Citizen> citizens, List<Thief> thieves, List<Police> policeOfficers, EventLog eventLog)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.C)
                {
                    addPersons.CreateCitizens(city, citizens, 1);
                    eventLog.addEvent($"++ New Citizen added          {DateTime.Now:HH:mm:ss}");
                }

                if (key.Key == ConsoleKey.T)
                {
                    addPersons.CreateThieves(city, thieves, 1);
                    eventLog.addEvent($"++ New Thief added            {DateTime.Now:HH:mm:ss}");
                }

                if (key.Key == ConsoleKey.P)
                {
                    addPersons.CreatePolice(city, policeOfficers, 1);
                    eventLog.addEvent($"++ New Police added           {DateTime.Now:HH:mm:ss}");
                }

                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Environment.Exit(0);
                }
            }
        }
    }
}
