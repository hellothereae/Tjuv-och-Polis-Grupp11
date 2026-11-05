using System;
using System.Collections.Generic;
using System.Text;

namespace PoliceAndThief
{
    internal class Movement
    {
        public void MovePeople(City city, List<Thief> thieves, List<Citizen> citizens, List<Police> policeOfficers)
        {
            city.ClearCity();

            foreach (Thief thief in thieves)
            {
                if (thief.InPrison == false)
                {
                    thief.Move(25, 100);
                    city.addThief(thief);
                }
            }

            foreach (Citizen citizen in citizens)
            {
                if (citizen.citizenStatus == false)
                {
                    citizen.Move(25, 100);
                    city.addCitizen(citizen);
                }
            }

            foreach (Police police in policeOfficers)
            {
                police.Move(25, 100);
                city.addPolice(police);
            }
        }

        private DateTime newDirection = DateTime.Now;
        public void ChangeThievesDirection(List<Thief> thieves)
        {
            if ((DateTime.Now - newDirection).TotalSeconds >= 20) 
            {
                foreach (Thief thief in thieves)
                {
                    if (thief.InPrison == false)
                    {
                        thief.newDirection();
                    }
                }

                newDirection = DateTime.Now;
            }
        }
    }
}
