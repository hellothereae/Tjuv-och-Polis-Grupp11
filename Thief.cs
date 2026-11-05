using System;


namespace PoliceAndThief
{
    internal class Thief : Person 
    {
        public bool InPrison = false; 
        int Prisonperiod;  
        DateTime PrisonStart; 


        public Thief() 
        {
            Money = 0;
        }

        
        public void Arrest(Prison prison, PoorHouse poorHouse)
        {
            int stolenMoney = Money;
            Money = 0;
            prison.addPrisoner(this);
            InPrison = true;
            PrisonStart = DateTime.Now;
            poorHouse.CitizenRefund(stolenMoney);
            Prisonperiod = stolenMoney * 2;
        }

        
        public void releaseTime(Prison prison)
        {
            if ((DateTime.Now - PrisonStart).TotalSeconds >= Prisonperiod)
            {
                InPrison = false;
                prison.releasePrisoner(this);
            }
        }


        public void CollectStolenMoney(int stolenMoney) 
        {
            Money += stolenMoney;
        }
    }
}
