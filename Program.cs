namespace PoliceAndThief
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Maximize the terminal window, then press Enter...");
            Console.ReadLine();
            Console.Clear();

            City city = new ();
            Prison prison = new();
            PoorHouse poorHouse = new();
            AddPersons addPersons = new ();

            int thievesCount = 5;
            int citizensCount = 20;
            int policeCount = 10;

            List<Thief> thieves = new List<Thief>(); 
            List<Citizen> citizens = new List<Citizen>();
            List<Police> policeOfficers = new List<Police>();

            addPersons.CreateThieves(city, thieves, thievesCount); 
            addPersons.CreateCitizens(city, citizens, citizensCount);
            addPersons.CreatePolice(city, policeOfficers, policeCount);


            EventLog eventLog = new (); 
            Inventory inventory = new (); 
            Movement movement = new (); 
            Meetings meetings = new (); 


            while (true)
            {
                movement.ChangeThievesDirection(thieves); 

                movement.MovePeople(city, thieves, citizens, policeOfficers);

                meetings.Arrest(policeOfficers, thieves, prison, poorHouse, eventLog);

                prison.ThiefStatus(thieves);

                meetings.Robbery(thieves, citizens, poorHouse, eventLog);

                Console.SetCursorPosition(0, 0);

                city.showCity();

                prison.MovePrisoners();

                int prisonStartRow = Console.CursorTop;

                prison.showPrison();

                poorHouse.movePoor();

                poorHouse.ReleasePoor();

                poorHouse.ShowPoorHouse(prisonStartRow);

                inventory.ShowInventory(70, prisonStartRow, citizens, thieves, poorHouse, prison);

                addPersons.ShowKeyFunctions(prisonStartRow);

                eventLog.showEvent(0, prisonStartRow + 14);

                addPersons.KeyFunction(city, citizens, thieves, policeOfficers, eventLog);
            }

        }

    }
}
