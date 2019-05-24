using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cheth
{
    class Logic
    {
        //to store vertise and edges to required vertices
        private RailNetwork _RailNetwork = new RailNetwork();

        //adding number of cities to the list depending on user input
//        public void createNetwork(string noOfCities)
//        {
//            try {
//                bool isNumber = int.TryParse(noOfCities, out int n);
//
//                if (!isNumber)
//                    throw new Exception(ErrorMessages.InvalidNoOfCitiest);
//                _RailNetwork.addTownsToRailMap(n);
//            } catch (Exception ex)
//            {
//                throw ex;
//            }
//            
//        }

        //add destination and distance to the list of town
//        public void addDestinations(char source, char destination, int distance)
//        {
//            Town sourceTown = null;
//            Town destinationTown = null;
//            try
//            {
//                foreach (var town in _RailNetwork.RailMapList)
//                {
//                    if (source == town.Name)
//                    {
//                        sourceTown = town;
//                    }
//
//                    if (destination == town.Name)
//                    {
//                        destinationTown = town;
//                    }
//                }
//                _RailNetwork.AddEdge(sourceTown.Name, destinationTown, distance);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }


        //Split user inputs by , and break them in to sores city, destination city and distance as per user input
        public void ProcessRoutes(string routes)
        {
            try
            {
                string[] routeArray = routes.Split(',');

                foreach (var route in routeArray)
                {
                    _RailNetwork.AddEdge(route);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        //Calculate distance of given routes
        public int DistanceOfRoutes(string journey)
        {
            try
            {
                int distance = 0;
                Town sourseTown = null;
                char destinationTown = '\0';
                char[] travelRoute = journey.ToCharArray();


                for (int i = 0; i < travelRoute.Length-1; i++)
                {
                    //check for char is a character
                    if(!Char.IsLetter(travelRoute[i]))
                        throw new Exception(ErrorMessages.InvalidInput);
                    
                    sourseTown = _RailNetwork.GetTown(travelRoute[i]);
                    if (travelRoute[i+1] >= travelRoute.Length)
                    {
                        destinationTown = travelRoute[i + 1];
                    }

                    if (sourseTown != null && sourseTown.IsRouteExists(destinationTown))
                    {
                        distance += sourseTown.Distance(destinationTown);
                    }
                    else
                    {
                        throw new Exception(ErrorMessages.NoRouteFound);
                    }
                }

                return distance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int NumberOfTripsWithMaximumStops(char sourceTown, char destinationTown, int maxStops, int totalStops,
            int totalTrips)
        {
            if (totalStops <= maxStops)
            {
                Town tempTown = _RailNetwork.GetTown(sourceTown);
                if (tempTown == null)
                    throw new Exception(ErrorMessages.NoRouteFound);

                if (tempTown.IsRouteExists(destinationTown))
                {
                    return totalTrips + 1;
                }
                else
                {
                    foreach (var destinations in tempTown.DestinationList)
                    {
                        totalTrips = NumberOfTripsWithMaximumStops(destinations.DestinationTown.Name, destinationTown,
                            maxStops, totalStops + 1, totalTrips);
                    }
                }
            }

            return totalTrips;
        }

        public int StartingAndEndCwithThreeStops()
        {
            try
            {
               int trips = NumberOfTripsWithMaximumStops('C', 'C', 3, 0, 0);
               return trips;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int StartingAtAAndEndCwithFourStops()
        {
            try
            {
                int trips = NumberOfTripsWithMaximumStops('A', 'C', 4, 0, 0);
                return trips;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ShortestRoute(char sourceTown, char destiantionT, int distance, int shortestDistance,
            char lastTown)
        {
            Town tempTwon = _RailNetwork.GetTown(sourceTown);
            if (tempTwon == null)
                throw new Exception(ErrorMessages.InvalidInput);
            if (tempTwon.IsRouteExists(destiantionT))
            {
                distance += tempTwon.Distance(destiantionT);
                shortestDistance = shortestDistance > distance || shortestDistance == 0 ? distance : shortestDistance;
                return shortestDistance;
            }
            else
            {
                foreach (var town in tempTwon.DestinationList.Where(x => x.DestinationTown.Name != lastTown))
                {
                    shortestDistance = ShortestRoute(town.DestinationTown.Name, destiantionT, distance += town.Distance,
                        shortestDistance, tempTwon.Name);
                }
            }

            return shortestDistance;
        }

        public int ShortestRouteAtoC()
        {
            int shortestRoute = ShortestRoute('A', 'C', 0, 0, '\0');
            return shortestRoute;
        }

        public int ShortestRouteBtoB()
        {
            int shortestRoute = ShortestRoute('B', 'B', 0, 0, '\0');
            return shortestRoute;
        }

    }
}
