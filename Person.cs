using System;
using System.Collections.Generic;
using System.Text;

namespace polis__Staden_
{
    internal class Person
    {
        int posRow; //Position Row
        int posCol; //Position Col
        int Rowdir;
        int Coldir;
        protected int Money;

        public void Move(int height,int width)
        {
            posRow = posRow + Rowdir;
            posCol = posCol + Coldir;
            
            if (posRow > height-1)// for city border (pacman) style
            {
                posRow = 0;
            } 
            else if (posRow < 0)
            {
                posRow = height-1;
            }

            if (posCol < 0)
            {
                posCol = width-1;
            }
            else if (posCol > width-1)
            {
                posCol = 0;
            } 
        }
        public Person() //Constructor for random movment
        {
            Random movment = new Random();
            posRow = movment.Next(25);
            posCol = movment.Next(100);
            newDirection();
        }

        public int Row
        {
            get { return posRow; }
            set { posRow = value; }
        }
        public int Col
        {
            get { return posCol; }
            set { posCol = value; }
        }
        public int MoneyAmount
        {
            get { return Money;}
        }

        public void newDirection()
        {
            Random movment = new Random();

            int direction = movment.Next(0, 8);
            // 0 = N , 1 = E , 2 = S , 3 = W
            // 4 = NE, 5 = SE, 6 = SW, 7 = NW
            switch (direction)
            {
                case 0:
                    Rowdir = -1;
                    Coldir = 0;
                    break;
                case 1:
                    Rowdir = 0;
                    Coldir = +1;
                    break;
                case 2:
                    Rowdir = +1;
                    Coldir = 0;
                    break;
                case 3:
                    Rowdir = 0;
                    Coldir = -1;
                    break;
                case 4:
                    Rowdir = -1;
                    Coldir = +1;
                    break;
                case 5:
                    Rowdir = +1;
                    Coldir = +1;
                    break;
                case 6:
                    Rowdir = +1;
                    Coldir = -1;
                    break;
                case 7:
                    Rowdir = -1;
                    Coldir = -1;
                    break;
            }
        }
    }
}
