using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateBoardingPass
{
    class Passenger
    {
        private string passengerName;
        private int sercurityNumber;
        private const int DEPTURE_GATE = 5;
        private int seatNumber;
        int i = 1;

        private int[] seats = new int[40];
        private string[] names = new string[40];

        static void Main(string[] args)
        {
            int i = 1;
            while(true) {

                Console.WriteLine("Please enter Name or PRESS q to quit");
                string input = Console.ReadLine();
                if (input == "q" || input == "Q") {
                    break;
                }
                
                Passenger pg = new Passenger();
                if (input.Length <= 5) {
                    pg.passengerName = input;
                    pg.names[i] = input;
                } else {
                    pg.passengerName = input.Trim();// to do
                }

                if (i <= 39) {
                    pg.seatNumber = i;
                    
                } else {
                    Console.WriteLine("No more seats can be signed...");
                    break;
                }
                

                Random random = new Random();
                pg.sercurityNumber = random.Next(30000, 999999);

                DateTime now = DateTime.Now;

                //generate boarding pass
                Console.WriteLine();
                Console.WriteLine("****************************************");
                Console.WriteLine("Passenger name: " + pg.passengerName);
                Console.WriteLine("Seat No. " + i);
                Console.WriteLine("Gate No. " + DEPTURE_GATE);
                Console.WriteLine("Depature Time: " + now);
                Console.WriteLine("****************************************");



                i++;

            }

            Console.ReadKey();

        }

        //This method lists all passengers' information
        public void Info()
        {
            
        }

        //This method displays available seats
        public void Display()
        {
            Console.WriteLine("Available seats is after {0}", i);
        }

        
    }
}
