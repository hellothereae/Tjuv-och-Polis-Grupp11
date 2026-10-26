namespace polis__Staden_
{
    internal class Program
    {
        static void Line()
        {
            Console.WriteLine("--------------------------");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Maximize the terminal window, then press Enter...");
            Console.ReadLine();
            Console.Clear();


            Stad stad = new Stad(); // create a new object of stad class

            List<Thief> thieves = new List<Thief>();  //To set the amount of thieves in the city
            for (int i = 1; i <= 10; i++)
            {
                Thief thief = new Thief();
                stad.addThief(thief);
                thieves.Add(thief);
            }
            
            List<Citizen> citizens = new List<Citizen>(); //To set the amount of citizens in the city
            for (int i = 1; i <= 1; i++) 
            {
                Citizen citizen = new Citizen();
                stad.addCitizen(citizen);
                citizens.Add(citizen);
            }

            List<Police> policeOfficers = new List<Police>(); //To set the amount of police in the city
            for (int i = 1; i <= 10; i++) 
            {
                Police police = new Police();
                stad.addPolice(police);
                policeOfficers.Add(police);
            }

            

            stad.visaStad(); //Call the method to show stad in console

            Prison fangelse = new Prison(); // create a new object of fangelse class


            Fattighus fattighus = new Fattighus(); // create a new object of stad class


            DateTime newDirection = DateTime.Now;

            int CitizensWealth = citizens.Count * 10; // How to calculate the money amount of citizen in city if every citizen got 10$

            EventLog eventLog = new EventLog(); // create a new object of event log class


            while (true)
            {
                // To change movement of thieves direction randomly every 20 seconds to increase the chance of police meeting.
                if ((DateTime.Now - newDirection).TotalSeconds >= 20)
                {
                    foreach (Thief thief in thieves)
                    {
                        if (thief.PrisonStatus == false)
                        {
                            thief.newDirection();
                        }
                    }
                    newDirection = DateTime.Now;
                }
                //Thieves in city and check they are not in prison 
                stad.ClearCity();
                foreach (Thief thief in thieves) 
                {
                    if (thief.PrisonStatus == false)
                    {
                        thief.Move(25, 100);
                        stad.addThief(thief);
                    }
                }
                //citizens in city and check they are not in prison
                foreach (Citizen citizen in citizens)
                {
                    if (citizen.PoorStatus == false)
                    {
                        citizen.Move(25, 100);
                        stad.addCitizen(citizen);
                    }
                }
                //Police in city and check they are not in prison
                foreach (Police police in policeOfficers)
                {
                    police.Move(25, 100);
                    stad.addPolice(police);
                }
                //Arrest condition thief should have money to get arrest wheen he meet police
                foreach (Police police in policeOfficers)
                {
                    foreach (Thief thief in thieves)
                    {
                        if (police.Row == thief.Row && police.Col == thief.Col)
                        {
                            if (thief.MoneyAmount > 0)
                            {
                                police.CatchThief(thief, fangelse, fattighus);
                                eventLog.addEvent($"Police arrested Thief  {DateTime.Now:HH:mm:ss}");// Eventlog when thief get arrest
                                Thread.Sleep(500);
                                
                            }
                        }
                    }
                }
                //Release time from prison
                foreach (Thief thief in thieves)
                {
                    if (thief.PrisonStatus == true)
                    {
                        thief.releaseTime(fangelse);
                    }
                }
                //When thief meets citizen steel 5$ in every meets
                foreach (Thief thief in thieves)
                {
                    foreach(Citizen citizen in citizens)
                    {
                        if(thief.Row == citizen.Row && thief.Col == citizen.Col && thief.PrisonStatus == false && citizen.PoorStatus == false)
                        {
                            citizen.stolenCitizen(thief, fattighus);
                            eventLog.addEvent($"Thief robbed Citizen  {DateTime.Now:HH:mm:ss}");// Eventlog when thief rob citizen

                        }
                    }
                }
               
                Console.SetCursorPosition(0, 0);// Cursor position starts on 0.0 in console.
                stad.visaStad();

                
                fangelse.MovePrisoners();
                int prisonStartRow = Console.CursorTop;
                int statsStartCol = 70; // cursor start after poor house not from firstr line to put poor house beside prison in console
                fangelse.visaFangelse();

                
                fattighus.movePoor();
                fattighus.ReleasePoor();
                Console.SetCursorPosition(15, prisonStartRow);
                fattighus.VisaFattighus();
                Console.SetCursorPosition(0, prisonStartRow + 13);
                

                int TotalCitizenMoney = 0;

                foreach (Citizen citizen in citizens)
                {
                    TotalCitizenMoney += citizen.MoneyAmount;
                    
                }

                int TotalThiefMoney = 0;
                foreach (Thief thief in thieves) 
                {
                    TotalThiefMoney += thief.MoneyAmount;
                }
               
                int TotalRobberies = 0;
                foreach (Citizen citizen in citizens)
                {
                    TotalRobberies += citizen.TotalRobberies;
                }


                Console.SetCursorPosition(statsStartCol, prisonStartRow);
                Console.Write($"Citizens Wealth:\t\t {CitizensWealth}$");

                Console.SetCursorPosition(statsStartCol, prisonStartRow + 1);
                Console.Write($"Police Recovered:\t {fattighus.PoliceRecovered,11}$");

                Console.SetCursorPosition(statsStartCol, prisonStartRow + 2);
                Console.Write($"Thieves got arrested: {fangelse.ArrestsCount,8}");

                Console.SetCursorPosition(statsStartCol, prisonStartRow + 3);
                Console.Write($"Citizens got robbed: {TotalRobberies,9}");

                Console.SetCursorPosition(statsStartCol, prisonStartRow + 5);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("INVENTORY");
                Console.ResetColor();

                Console.SetCursorPosition(statsStartCol, prisonStartRow + 6);
                Line();

                Console.SetCursorPosition(statsStartCol, prisonStartRow + 7);
                Console.Write($"Citizens Money:\t{TotalCitizenMoney,7}$");

                Console.SetCursorPosition(statsStartCol, prisonStartRow + 8);
                Line();

                Console.SetCursorPosition(statsStartCol, prisonStartRow + 9);
                Console.Write($"Thiefs Money:\t{TotalThiefMoney,7}$");

                Console.SetCursorPosition(statsStartCol, prisonStartRow + 10);
                Line();

                Console.SetCursorPosition(statsStartCol, prisonStartRow + 11);
                Console.Write($"Poor House Balance:  {fattighus.PoorHouseBalance,4}$");
 
                Console.SetCursorPosition(0, prisonStartRow + 14);
                eventLog.showEvent();

                Console.SetCursorPosition(70, prisonStartRow + 14);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("C");
                Console.ResetColor();
                Console.Write(" = Add a new citizen to city");


                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (key.Key == ConsoleKey.C)
                    {
                        Citizen citizen = new Citizen();
                        stad.addCitizen(citizen);
                        citizens.Add(citizen);
                        CitizensWealth += 10;
                    }
                }

            }
            
        }
        
    }
}
