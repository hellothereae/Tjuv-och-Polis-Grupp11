using System;
using System.Collections.Generic;
using System.Text;

namespace PoliceAndThief
{
    internal class Movement
    {
        public void MovePeople(City stad, List<Thief> thieves, List<Citizen> citizens, List<Police> policeOfficers)
        {
            stad.ClearCity();

            foreach (Thief thief in thieves)
            {
                if (thief.PrisonStatus == false)
                {
                    thief.Move(25, 100);
                    stad.addThief(thief);
                }
            }

            foreach (Citizen citizen in citizens)
            {
                if (citizen.PoorStatus == false)
                {
                    citizen.Move(25, 100);
                    stad.addCitizen(citizen);
                }
            }

            foreach (Police police in policeOfficers)
            {
                police.Move(25, 100);
                stad.addPolice(police);
            }
        }

        private DateTime newDirection = DateTime.Now;
        public void ChangeThievesDirection(List<Thief> thieves)
        {
            if ((DateTime.Now - newDirection).TotalSeconds >= 20) // Byt riktning på tjuven var 20:e sekund för att öka chansen för möten mellan tjuven och de andra
            {
                foreach (Thief thief in thieves)
                {
                    if (thief.PrisonStatus == false)
                    {
                        thief.newDirection();
                    }
                }

                newDirection = DateTime.Now;
            }
        }
    }
}
