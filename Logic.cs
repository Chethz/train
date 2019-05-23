using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Cheth
{
    class Logic
    {
        private RailNetwork _RailNetwork = new RailNetwork();

        //adding number of cities to the list depending on user input
        public void createNetwork(string noOfCities)
        {
            try {
                bool isNumber = int.TryParse(noOfCities, out int n);

                if (!isNumber)
                    throw new Exception(ErrorMessages.InvalidNoOfCitiest);
                _RailNetwork.addTownsToRailMap(n);
            } catch (Exception ex)
            {
                throw ex;
            }
            
        }

        //add destination and distance to the list of town
        public void addDestinations(char source, char destination, int distance)
        {
            Town sourceTown = null;
            Town destinationTown = null;
            try
            {
                foreach (var town in _RailNetwork.RailMapList)
                {
                    if (source == town.Name)
                    {
                        sourceTown = town;
                    }

                    if (destination == town.Name)
                    {
                        destinationTown = town;
                    }
                }
                _RailNetwork.AddEdge(sourceTown, destinationTown, distance);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Split user inputs by , and break them in to sourse city, destination city and distance as per user input
        public void processRoutes(string routes)
        {
            char source= '\0';
            char destination = '\0';
            int distance = 0;

            try
            {
                List<string> routeList = routes.Split(',').ToList<string>();

                foreach (var route in routeList)
                {
                    char[] splitRoute = route.ToCharArray();

                    for (int i = 0; i < splitRoute.Length; i++)
                    {
                        if (splitRoute.Length != 3)
                            throw new Exception(ErrorMessages.InvalidRoute);
                        if(!Char.IsLetter(splitRoute[0])|| !Char.IsLetter(splitRoute[1]))
                            throw new Exception(ErrorMessages.InvalidSourceOrDestination);
                        if(!Char.IsDigit(splitRoute[2]))
                            throw new Exception(ErrorMessages.InvalidDistance);
                        source = splitRoute[0];
                        destination = splitRoute[1];
                        distance = (int)Char.GetNumericValue(splitRoute[2]);
                    }
                    addDestinations(source, destination, distance);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

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


    }
}
