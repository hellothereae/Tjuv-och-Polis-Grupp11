using System;


namespace polis__Staden_
{
    internal class Thief : Person // thief inherits from Person
    {
        bool InPrison = false; // To check if the thief is in prison false = In City
        int Prisonperiod;  // To store the prison period in seconds.
        DateTime PrisonStart; // Time of Prison entry


        public Thief() // Constructor to create a thief money amount
        {
            Money = 0;
        }

        // Method to arrest the thief, and calculate the period in prison every 5$ = 10 sec
        public void Arrest(Prison fangelse, Fattighus fattighus)
        {
            int stolenMoney = Money;
            Money = 0;
            fangelse.addPrisoner(this);
            InPrison = true;
            PrisonStart = DateTime.Now;
            fattighus.CitizenRefund(stolenMoney);
            Prisonperiod = stolenMoney * 2;
        }

        // Method to check if the prison time is over and release the thief
        public void releaseTime(Prison fangelse)
        {
            if ((DateTime.Now - PrisonStart).TotalSeconds >= Prisonperiod)
            {
                InPrison = false;
               fangelse.releasePrisoner(this);
            }
        }

        public bool PrisonStatus
        {
            get { return InPrison; }
        }

        public void CollectStolenMoney(int stolenMoney)
        {
            Money += stolenMoney;
        }
    }
}
