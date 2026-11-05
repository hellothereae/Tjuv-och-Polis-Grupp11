using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PoliceAndThief
{
    internal class PoorHouse : Place 
    {
        char[,] poorhouse; 
        public int refundMoney; 
        DateTime PoorReleaseTimer; 
        public int TotalPoliceRecoverd; 

        public PoorHouse() : base (10,50) 
        {
            poorhouse = new char[Rows, Cols]; 
            PoorReleaseTimer = DateTime.Now; 
            ClearPoorHouse();
        }

        public void ClearPoorHouse() 
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    poorhouse[i, j] = ' '; 
                }
            }
        }

        public void ShowPoorHouse(int prisonStartRow)  
        {
            Console.SetCursorPosition(15, prisonStartRow);

            for (int i = 0; i < Cols - 7; i++)
            {
                if (i == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("Poor House");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write('*');
                }
            }
            Console.WriteLine();

            for (int i = 0; i < Rows; i++)
            {
                Console.SetCursorPosition(15, Console.CursorTop);
                Console.Write('*');
                for (int j = 0; j < Cols; j++)
                {
                    Console.Write(poorhouse[i, j]);
                }
                
                Console.Write('*');
                Console.WriteLine();
            }
            Console.SetCursorPosition(15, Console.CursorTop); 
            for (int i = 0; i < Cols + 2; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
            Console.SetCursorPosition(15, Console.CursorTop);
            Console.WriteLine($"\tPoor:{ Poor.Count,3}");
        }

        public void CitizenRefund(int amount) 
        {
            refundMoney += amount;
            TotalPoliceRecoverd += amount;
        }


        List <Citizen> Poor = new List<Citizen>(); 

        public void addPoor(Citizen citizen) 
        {
            Poor.Add(citizen);
            Random random = new Random();
            citizen.posRow = random.Next(10);
            citizen.posCol = random.Next(50);
        }
        
        public void movePoor() 
        {
            ClearPoorHouse();
            foreach (Citizen citizen in Poor) 
            {
                citizen.Move(10, 50);
                poorhouse[citizen.posRow, citizen.posCol] = 'C';

            }
        }

        public void ReleasePoor() 
        {
            
            if ((DateTime.Now - PoorReleaseTimer).TotalSeconds >= 10)
            {
                PoorReleaseTimer = DateTime.Now;
                while (refundMoney >= 5 && Poor.Count > 0)
                {
                    Citizen citizen = Poor[0];
                    Poor.RemoveAt(0);
                    citizen.Moneyrecived();
                    refundMoney -= 5; 

                }

            }
            
        }
    }
}
