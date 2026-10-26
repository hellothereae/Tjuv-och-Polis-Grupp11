using System;
using System.Collections.Generic;
using System.Text;

namespace polis__Staden_
{
    internal class Police : Person
    {
        public Police()
        {
          Money = 0;
            
        }

        public void CatchThief(Thief thief, Prison fangelse, Fattighus fattighus)
        {
            if (thief.MoneyAmount > 0)
            {
                thief.Arrest(fangelse,fattighus);
            }
            

        }

    }
}
