using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace polis__Staden_
{
    internal class Fattighus : Place // OBS! alla kommentarer finns i Stad.cs
    {
        char[,] fattighus;
        int refundMoney;
        DateTime PoorReleaseTimer;
        int TotalPoliceRecoverd;
        


        public Fattighus() : base (10,50) 
        {
            fattighus = new char[Rows, Cols];
            PoorReleaseTimer = DateTime.Now;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    fattighus[i, j] = ' ';
                }
            }
        }


        public void ClearFattighus()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    fattighus[i, j] = ' ';
                }
            }
        }


        public void VisaFattighus() 
        {
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
                    Console.Write(fattighus[i, j]);
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

        public int PoliceRecovered
        {
            get { return TotalPoliceRecoverd; }
        }

        public int PoorHouseBalance
        {
            get { return refundMoney; }
        }

        List <Citizen> Poor = new List<Citizen>();

        public void addPoor(Citizen citizen) 
        {
            Poor.Add(citizen);
            Random random = new Random();
            citizen.Row = random.Next(10);
            citizen.Col = random.Next(50);
        }

        public void movePoor()
        {
            ClearFattighus();
            foreach (Citizen citizen in Poor) 
            {
                citizen.Move(10, 50);
                fattighus[citizen.Row, citizen.Col] = 'C';
            }
        }

        public void ReleasePoor()
        {
            if ((DateTime.Now - PoorReleaseTimer).TotalSeconds >= 15)
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
