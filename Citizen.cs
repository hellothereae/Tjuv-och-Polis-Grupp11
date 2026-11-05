using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PoliceAndThief
{
    internal class Citizen : Person 
    {
        public bool citizenStatus = false;  
        public int Robbercount = 0; 


        public Citizen() 
        {
            Money = 10;
        }

        public void stolenCitizen(Thief thief, PoorHouse poorhouse) 
        {
            Money -= 5;
            thief.CollectStolenMoney(5);
            Robbercount++;
            if (Money == 0) 
            {
                poorhouse.addPoor(this);
                citizenStatus = true;
            }  
        }


        public void Moneyrecived() 
        {
            Money += 5;
            citizenStatus = false;
        }
    }
}
