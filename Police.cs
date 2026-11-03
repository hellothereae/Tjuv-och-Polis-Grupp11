using System;
using System.Collections.Generic;
using System.Text;

namespace PoliceAndThief
{
    internal class Police : Person
    {
        public Police() 
        {
          Money = 0;
            
        }

        public void CatchThief(Thief thief, Prison prison, PoorHouse poorHouse) 
        {
            if (thief.MoneyAmount > 0)
            {
                thief.Arrest(prison, poorHouse);
            }
        }

    }
}
