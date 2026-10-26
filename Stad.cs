using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace polis__Staden_
{
    internal class Stad:Place
    {
        char[,] stad; // Jag använder char istället för string så länge vi bara behöver ett tecken (T, M, P).


        // Constructor to create a city with its dimensions
        public Stad() : base (25,100)  
        {
            stad = new char[Rows, Cols];
            for (int i = 0; i < Rows; i++) // Loop to fill the city (array) with empty spaces :)
            {
                for (int j = 0; j < Cols; j++)
                {
                    stad[i,j] = ' '; 
                }
            }
         
        }


        public void addThief(Thief thief)
        {
            stad[thief.Row, thief.Col] = 'T';
        }

        public void addCitizen(Citizen citizen)
        {
            stad[citizen.Row, citizen.Col] = 'C';
        }

        public void addPolice(Police police)
        {
            stad[police.Row, police.Col] = 'P';
        }


        public void ClearCity()
        {
            for (int i = 0; i < Rows; i++) 
            {
                for (int j = 0; j < Cols; j++)
                {
                    stad[i, j] = ' ';
                }
            }
        }
        

        // Method to display city borders in the terminal
        public void visaStad()  
        {
            for (int i = 0; i < Cols-1; i++) //"City" tar tre platser mer än *, och vi vill ha totalt 102 tecken inklusive kanterna, då blir det Cols-1.
            {
                if (i == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("City");
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
                Console.Write('*');
                for (int j = 0; j < Cols; j++)
                {
                    switch (stad[i, j])
                    {
                        case 'T':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;

                        case 'P':
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;

                        case 'C':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;

                        default:
                            Console.ResetColor();
                            break;
                    }

                    Console.Write(stad[i, j]);
                }
                Console.ResetColor();
                Console.Write('*');
                Console.WriteLine();
            }
            for (int i = 0;i < Cols+2; i++) //+2 för kanterna :)
            {
                Console.Write('*');
            }
            Console.WriteLine();

        }
    }
}
