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
        private int sercurityNumber;
        private const int DEPTURE_GATE = 5;
        private int seatNumber;
        

        private static int[] seats = new int[41];
        private static string[] names = new string[41];
        private static int[] sNumbers = new int[41];

        static void Main(string[] args)
        {
            int i = 1;
            while(true) {
                
                Console.WriteLine("Please enter Name or PRESS q to quit");
                string input = Console.ReadLine();
                while(true) {
                    if (input == null) {
                        Console.WriteLine("Please enter passenger name...");
                    } else {
                        break;
                    }
                }

                if (input == "q" || input == "Q") {
                    break;
                }
                
                Passenger pg = new Passenger();

                if (input.Length <= 5) {
                    pg.passengerName = input;
                    names[i - 1] = pg.passengerName;
                } else {
                    pg.passengerName = input.Trim();// to do
                }

                if (i <= 40) {
                    pg.seatNumber = i;
                    seats[i - 1] = pg.seatNumber;
                    
                } else {
                    Console.WriteLine("No more seats can be signed...");
                    break;
                }
                
                //Generate random security numbers
                Random random = new Random();
                pg.sercurityNumber = random.Next(30000, 999999);
                sNumbers[i - 1] = pg.sercurityNumber;

                DateTime now = DateTime.Now;

                //Generate boarding pass
                Console.WriteLine();
                Console.WriteLine("**************Boarding Pass*************");
                Console.WriteLine("Passenger name: " + pg.passengerName);
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
        public static void Info()
        {
            for(int i = 0; i < 40; i++) {
                Console.WriteLine("Passenger {0}: Name: {1}, Seat number: {2} and security number {3}", i + 1, names[i], seats[i], sNumbers[i]);
            }
        }

        //This method displays available seats
        public static void Display(int ocuppied)
        {
            Console.WriteLine("Available seats is after {0}", ocuppied);
        }

        
    }
}
