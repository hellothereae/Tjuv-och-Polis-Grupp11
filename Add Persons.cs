
using System;
using System.Collections.Generic;

namespace PoliceAndThief
{
    internal class AddPersons
    {

        public void CreateThieves(City city, List<Thief> thieves, int count) 
        {
            for (int i = 0; i < count; i++)
            {
                Thief thief = new Thief();
                city.addThief(thief);
                thieves.Add(thief);
            }
        }

        public void CreateCitizens(City city, List<Citizen> citizens, int count) 
        {
            for (int i = 0; i < count; i++)
            {
                Citizen citizen = new Citizen();
                city.addCitizen(citizen);
                citizens.Add(citizen);
            }
        }

        public void CreatePolice(City city, List<Police> policeOfficers, int count) 
        {
            for (int i = 0; i < count; i++)
            {
                Police police = new Police();
                city.addPolice(police);
                policeOfficers.Add(police);
            }
        }

        

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
        }




        
        public void KeyFunction(City city, List<Citizen> citizens, List<Thief> thieves, List<Police> policeOfficers, EventLog eventLog) 
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.C)
                {
                    CreateCitizens(city, citizens, 1);
                    eventLog.addEvent($"++ New Citizen added          {DateTime.Now:HH:mm:ss}");
                }

                if (key.Key == ConsoleKey.T)
                {
                    CreateThieves(city, thieves, 1);
                    eventLog.addEvent($"++ New Thief added            {DateTime.Now:HH:mm:ss}");
                }

                if (key.Key == ConsoleKey.P)
                {
                    CreatePolice(city, policeOfficers, 1);
                    eventLog.addEvent($"++ New Police added           {DateTime.Now:HH:mm:ss}");
                } 
            }
        }
    }
}
