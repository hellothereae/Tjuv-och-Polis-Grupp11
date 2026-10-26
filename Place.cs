using System;
using System.Collections.Generic;
using System.Text;

namespace polis__Staden_
{
    internal class Place
    {
        // Definierar dimensionerna för varje plats
        protected int Rows;
        protected int Cols;


        // Constructor to set the size of the place (stad,fangelse, fattighus och kanske fler platser i framtiden :)
        public Place (int row, int col) 
        {
            this.Rows = row; 
            this.Cols = col;
        }
                
          
        
    }
}
