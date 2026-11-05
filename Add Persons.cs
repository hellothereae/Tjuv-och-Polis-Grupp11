
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

    }
}
