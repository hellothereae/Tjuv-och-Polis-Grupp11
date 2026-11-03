using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PoliceAndThief
{
    internal class City:Place
    {
        char[,] city; 

        public City() : base (25,100)  
        {
            city = new char[Rows, Cols];
            for (int i = 0; i < Rows; i++) 
            {
                for (int j = 0; j < Cols; j++)
                {
                    city[i,j] = ' '; 
                }
            }
         
        }


        public void addThief(Thief thief) 
        {
            city[thief.Row, thief.Col] = 'T';
        }

        public void addCitizen(Citizen citizen) 
        {
            city[citizen.Row, citizen.Col] = 'C';
        }

        public void addPolice(Police police) 
        {
            city[police.Row, police.Col] = 'P';
        }


        public void ClearCity() 
        {
            for (int i = 0; i < Rows; i++) 
            {
                for (int j = 0; j < Cols; j++)
                {
                    city[i, j] = ' ';
                }
            }
        }
        

        
        public void showCity()  
        {
            for (int i = 0; i < Cols-1; i++) 
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
                    switch (city[i, j])
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

                    Console.Write(city[i, j]);
                }
                Console.ResetColor();
                Console.Write('*');
                Console.WriteLine();
            }
            for (int i = 0;i < Cols+2; i++) 
            {
                Console.Write('*');
            }
            Console.WriteLine();

        }
    }
}
