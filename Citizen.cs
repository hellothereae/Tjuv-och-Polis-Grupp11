using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace polis__Staden_
{
    internal class Citizen : Person 
    {
        bool citizenStatus = false; 
        int Robbercount = 0;


        public Citizen()
        {
            Money = 10;
        }

        public void stolenCitizen(Thief thief, Fattighus fattighus)
        {
            Money -= 5;
            thief.CollectStolenMoney(5);
            Robbercount++;
            if (Money == 0) 
            {
                fattighus.addPoor(this);
                citizenStatus = true;
            }  
        }

        public int TotalRobberies
        {
            get { return Robbercount; }
        }

        

        public bool PoorStatus
        {
            get { return citizenStatus; }
        }

        public void Moneyrecived()
        {
            Money += 5;
            citizenStatus = false;
        }
    }
}
