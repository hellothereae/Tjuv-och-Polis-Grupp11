using System;
using System.Collections.Generic;
using System.Threading;

namespace PoliceAndThief
{
    internal class Meetings
    { 
        public void Arrest(List<Police> policeOfficers, List<Thief> thieves, Prison prison, PoorHouse poorHouse, EventLog eventLog)
        {
            foreach (Police police in policeOfficers)
            {
                foreach (Thief thief in thieves)
                {
                    if (police.Row == thief.Row && police.Col == thief.Col)
                    {
                        if (thief.MoneyAmount > 0)
                        {
                            police.CatchThief(thief, prison, poorHouse);
                            eventLog.addEvent($"** Police arrested Thief      {DateTime.Now:HH:mm:ss}");
                            Thread.Sleep(500);
                        }
                    }
                }
            }
        }

        
        public void Robbery(List<Thief> thieves, List<Citizen> citizens, PoorHouse poorHouse, EventLog eventLog) 
        {
            foreach (Thief thief in thieves)
            {
                foreach (Citizen citizen in citizens)
                {
                    if (thief.Row == citizen.Row &&
                        thief.Col == citizen.Col &&
                        thief.InPrison == false &&
                        citizen.citizenStatus == false)
                    {
                        citizen.stolenCitizen(thief, poorHouse); 
                        eventLog.addEvent($"$$ Thief robbed Citizen       {DateTime.Now:HH:mm:ss}");
                    }
                }
            }
        }
    }
}