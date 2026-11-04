using System;
using System.Collections.Generic;



namespace PoliceAndThief
{
    internal class Inventory
    {
        public void ShowInventory(int startCol, int startRow, List<Citizen> citizens, List<Thief> thieves, PoorHouse poorHouse, Prison prison)
        {
            int totalWealth = citizens.Count * 10;
            int totalCitizenMoney = 0;
            int totalRobberies = 0;
            foreach (Citizen citizen in citizens)
            {
                totalCitizenMoney += citizen.MoneyAmount;
                totalRobberies += citizen.TotalRobberies;
            }

            int totalThiefMoney = 0;
            foreach (Thief thief in thieves)
            {
                totalThiefMoney += thief.MoneyAmount;
            }

            

            PrintLine(startCol, startRow,  $"Citizens Wealth:\t\t {totalWealth}$");

            PrintLine(startCol, startRow + 1, $"Police Recovered:\t {poorHouse.TotalPoliceRecoverd,11}$");

            PrintLine(startCol, startRow + 2, $"Thieves got arrested: {prison.TotalArrests,8}");

            PrintLine(startCol, startRow + 3, $"Citizens got robbed: {totalRobberies,9}");

            Console.SetCursorPosition(startCol, startRow + 5);

           
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("INVENTORY");
            Console.ResetColor();

            addDivider(startCol, startRow + 6);

            PrintLine(startCol, startRow + 7, $"Citizens Money:\t{totalCitizenMoney,7}$");

            addDivider(startCol, startRow + 8);

            PrintLine(startCol, startRow + 9, $"Thiefs Money:\t{totalThiefMoney,7}$");

            addDivider(startCol, startRow + 10);

            PrintLine(startCol, startRow + 11, $"Poor House Balance:  {poorHouse.refundMoney,4}$");
        }

        private void addDivider(int startCol, int startRow) 
        {
            PrintLine(startCol, startRow, "--------------------------");
        }
        private void PrintLine(int col, int row, string text) 
        {
            Console.SetCursorPosition(col, row);
            Console.Write(text);
        }
    }
}

