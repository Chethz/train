using System;
using System.Collections.Generic;
using System.Text;

namespace Cheth
{
    class View
    {
        private Logic logic = new Logic();
        public void mainMenu()
        {
            bool end = false;
            while (!end)
            {
                Console.WriteLine("\n------------------------------- Main Menu -------------------------------");
                Console.WriteLine("Enter 1 to create transport network");
                Console.WriteLine("Enter 2 to print distance of routes");
                Console.WriteLine("Enter 3 to print number of trips starting at C and ending at C with maximum of 3 stops");
                Console.WriteLine("Enter 4 to print number of trips starting at A and ending at C with exactly of 4 stops");
                Console.WriteLine("Enter 4 to print length of the shortest route from A to C");
                Console.WriteLine("Enter 5 to print length of the shortest route from B to B");
                Console.WriteLine("Enter 6 to print number of different routes from C to C with a distance of less than 30");
                Console.WriteLine("\n-------------------------------------------------------------------------");
                Console.WriteLine("Your option : ");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        CreateTransportNetwork();
                        break;
                    case "2":
                        getDistance();
                        break;
                    case "3":
                        startingAtCEndC();
                        break;
                    case "4":
                        StartingAtAEndC();
                        break;
                    case "5":
                        getShortestPath();
                        break;
                    case "6":
                        differentRoutesCtoC();
                        break;
                    default:
                        Console.WriteLine("Thank you for using our system. Bye!");
                        end = true;
                        break;
                }

            }
        }

        private void CreateTransportNetwork()
        {
            Console.WriteLine("Enter number of towns need to add");
            string numberOfTwons = Console.ReadLine().Trim();
            Console.WriteLine("Enter routes separated by comma ex: AB5, BC4...");
            string routes = Console.ReadLine().Trim();
            Console.WriteLine("Press S if you want to submit");
            Console.WriteLine("Press any other key if you want to cancel");
            Console.WriteLine("Your option");

            string option = Console.ReadLine().ToUpper();
            if (option == "S")
            {
                try
                {
                    logic.createNetwork(numberOfTwons);
                    logic.processRoutes(routes);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void getDistance()
        {
            Console.WriteLine("Enter routes to get distance Ex: A-B-C");
            string journy = Console.ReadLine();
            Console.WriteLine("Press S if you want to submit");
            Console.WriteLine("Press any other key if you want to cancel");
            Console.WriteLine("Your option");

            string option = Console.ReadLine().ToUpper().Trim();
            if (option == "S")
            {
                try
                {
                    logic.DistanceOfRoutes(journy);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void startingAtCEndC()
        {

        }

        private void StartingAtAEndC()
        {

        }

        private void getShortestPath()
        {

        }

        private void differentRoutesCtoC()
        {

        }
    }
}
