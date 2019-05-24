using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cheth
{
    class RailNetwork
    {
        //adjacency list
        private List<Town> _railMap = new List<Town>() ;
        char[] townNames;
        //List<Town> towns = new List<Town>();

        public List<Town> RailMapList
        {
            get { return _railMap; }
        }

        //add cities to townNames array
        public void RailNetWork(int noOfTowns)
        {
            townNames = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        }

        //add destination to the town in the _railMap list
        //check for null inputs
        //check _railMap for existing source and destination
//        public void AddEdge(Town source, Town destination, int distance)
//        {
//            if (source == null || destination == null || distance <= 0)
//                throw new Exception(ErrorMessages.InvalidInput);
//
//            if (!(_railMap.Any(town => town.Name == source.Name)) || _railMap.Any(town => town.Name == destination.Name))
//            {
//                throw new Exception(ErrorMessages.InvalidSourceOrDestination);
//            }
//
//            //_railMap.Where(town => town.Name == source.Name).FirstOrDefault().AddRoute(destination, distance);
//        }

        //Add routes to _railMap
        public void AddEdge(string sourceName, string destinationName, int distance)
        {
            var sourceTown = _railMap.Where(town => town.Name.ToString() == sourceName).FirstOrDefault();

            if (sourceTown == null)
            {
                sourceTown = new Town(sourceName);
                _railMap.Add(sourceTown);
            }

            var destinationTown = _railMap.Where(town => town.Name.ToString() == destinationName).FirstOrDefault();

            if (destinationTown == null)
            {
                destinationTown = new Town(destinationName);
                _railMap.Add(destinationTown);
            }

            sourceTown.AddRoute(destinationTown,distance);
        }

        public void AddEdge(string route)
        {
            char[] splitRoute = route.ToCharArray();
            if (splitRoute.Length != 3)
                throw new Exception(ErrorMessages.InvalidRoute);
            if (!Char.IsLetter(splitRoute[0]) || !Char.IsLetter(splitRoute[1]))
                throw new Exception(ErrorMessages.InvalidSourceOrDestination);
            if (!Char.IsDigit(splitRoute[2]))
                throw new Exception(ErrorMessages.InvalidDistance);

            string sourceName = route[0].ToString();
            string destination = route[1].ToString();
            int.TryParse(route[2].ToString(), out int distance);

            this.AddEdge(sourceName, destination, distance);
        }

        //return town name
        public Town GetTown(char name)
        {
            return _railMap.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
