using System;
using System.Collections.Generic;
using System.Text;

namespace PoliceAndThief
{
    internal class Place
    {
        protected int Rows; 
        protected int Cols; 

        public Place (int row, int col) 
        {
            this.Rows = row; 
            this.Cols = col;
        } 
    }
}
