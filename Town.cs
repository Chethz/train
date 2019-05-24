using System;
using System.Collections.Generic;
using System.Linq;

namespace Cheth
{
    class Town
    {
        public char Name { get; set; }

        //list of destinations
        private List<Route> _destinationList;

        public List<Route> DestinationList
        {
            get { return _destinationList; }
        }

        //Constructor
        public Town(char name)
        {
            Name = name;
            _destinationList = new List<Route>();
        }

        //Add routes to _destinationList
        public void addRoute(Town town, int distance)
        {
            if(town == null || distance.Equals(null))
                throw new Exception(ErrorMessages.InvalidDistanceOrTown);
            var route = new Route(town.Name, distance);
            _destinationList.Add(route);
        }

        //check for existing routes
        public bool IsRouteExists(char destinationTown)
        {
            return _destinationList.Where(x => x.DestinationTown == destinationTown).FirstOrDefault() != null;
        }

        //get distance for the routes
        public int Distance(char destinationTown)
        {
            return _destinationList.Where(x => x.DestinationTown == destinationTown).Select(x => x.Distance)
                .FirstOrDefault();
        }
    }
}
