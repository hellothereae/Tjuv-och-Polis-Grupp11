using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Channels;

namespace polis__Staden_
{
    internal class Prison : Place // OBS! alla kommentarer finns i Stad.cs
    {
        char[,] fangelse;
        int TotalArrests = 0;

        public Prison() : base(10, 10)
        {
            fangelse = new char[Rows, Cols];
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    fangelse[i, j] = ' ';
                }
            }

        }

        public void ClearFangelse()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Cols; j++)
                {
                    fangelse[i, j] = ' ';
                }
            }
        }


        public void visaFangelse()
        {
            for (int i = 0; i < Cols - 3; i++)
            {
                if (i == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Prison");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write('x');
                }
            }
            Console.WriteLine();

            for (int i = 0; i < Rows; i++)
            {
                Console.Write('x');
                for (int j = 0; j < Cols; j++)
                {
                    switch (fangelse[i, j])
                    {
                        case 'T':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;

                        default:
                            Console.ResetColor();
                            break;
                    }

                    Console.Write(fangelse[i, j]);
                }
                Console.ResetColor();
                Console.Write('x');
                Console.WriteLine();
            }
            for (int i = 0; i < Cols + 2; i++)
            {
                Console.Write('x');
            }
            Console.WriteLine();
            Console.WriteLine($"Prisoners: {Prisoner.Count}");
        }

        public void addPrisoner(Thief thief)
        {
            Prisoner.Add(thief);
            TotalArrests++;
            Random random = new Random();
            thief.Row = random.Next(10);
            thief.Col = random.Next(10);
        }

        public int ArrestsCount
        {
            get { return TotalArrests; }
        }

        public void releasePrisoner(Thief thief)
        {
            Prisoner.Remove(thief);
        }

        List<Thief> Prisoner = new List<Thief>();


        public void MovePrisoners()
        {
            ClearFangelse();
            foreach (Thief thief in Prisoner)
            {
                thief.Move(10, 10);
                fangelse[thief.Row, thief.Col] = 'T';
            }

        }

        
       
        
        
    }
}



    