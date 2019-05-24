using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Chaoran Li
 * n10298827
 * IFN501 Deliverable 2 2019
 */

namespace GenerateBoardingPass
{
    class Passenger
    {
        private string passengerName;
        public string _passengerName
        {
            get
            {
                return passengerName;
            }
            set
            {
                passengerName = value;
            }
        }

        private int securityNumber;
        public int _securityNumber
        {
            get
            {
                return securityNumber;
            }
            set
            {
                securityNumber = value;
            }
        }

        private const int DEPTURE_GATE = 5;

        private int seatNumber;
        public int _seatNumber
        {
            get
            {
                return seatNumber;
            }
            set
            {
                seatNumber = value;
            }
        }
        
        private static int[] seats = new int[41];
        private static string[] names = new string[41];
        private static int[] sNumbers = new int[41];

        static void Main(string[] args)
        {
            int i = 1;
            while(true)
            {
                Console.WriteLine("Please enter NAME or PRESS q to quit");
                string input = Console.ReadLine();
                if (input == "q" || input == "Q")
                {
                    break;
                }

                Passenger pg = new Passenger();

                //Corner case check
                while (true)
                {
                    if (input == "")
                    {
                        Console.WriteLine("The name cannot be empty, please try again...");
                        string newInput = Console.ReadLine();
                        input = newInput;
                    }
                    else if (input.Length <= 5)
                    {
                        pg._passengerName = input;
                        names[i - 1] = pg._passengerName;
                        break;
                    }
                    else if (input.Length > 5)
                    {
                        Console.WriteLine("Name cannot be greater 5 characters, please try again...");
                        string newInput = Console.ReadLine();
                        input = newInput;
                    }
                    else
                    {
                        break;
                    }
                }

                if (i <= 40)
                {
                    pg._seatNumber = i;
                    seats[i - 1] = pg._seatNumber;

                }
                else
                {
                    Console.WriteLine("No more seats can be signed...");
                    break;
                }

                //Generate random security numbers
                Random random = new Random();
                pg._securityNumber = random.Next(30000, 999999);
                sNumbers[i - 1] = pg._securityNumber;

                //Generate the depature time
                DateTime now = DateTime.Now;

                //Generate boarding pass
                Console.WriteLine();
                Console.WriteLine("**************Boarding Pass*************");
                Console.WriteLine("Passenger name: " + pg._passengerName);
                Console.WriteLine("Seat No. " + i);
                Console.WriteLine("Gate No. " + DEPTURE_GATE);
                Console.WriteLine("Depature Time: " + now);
                Console.WriteLine("****************************************");
                Display(seats[i - 1]);
                i++;
            }

            //Display the list of all passengers
            Info();   
            Console.ReadKey();

        }

        //This method lists all passengers' information
        private static void Info()
        {
            for (int i = 0; i < 40; i++) {
                Console.WriteLine("Passenger {0}: Name: {1}, Seat number: {2} and security number {3}", i + 1, names[i], seats[i], sNumbers[i]);
            }
        }

        //This method displays available seats
        private static void Display(int ocuppied)
        {
            Console.WriteLine("Available seats is after {0}", ocuppied);
        }

        
    }
}
