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

        public List<Town> RailMapList
        {
            get { return _railMap; }
        }

        //add cities to railMap
        public void addTownsToRailMap(int noOfTowns)
        {
            char[] townNames = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            try
            {
                for (int i = 0; i < noOfTowns; i++)
                {
                   _railMap.Add(new Town(townNames[i]));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //add destination to the town in the _railMap list
        public void AddEdge(Town source, Town destination, int distance)
        {
            //check for null values
            if (source == null || destination == null || distance <= 0)
            {
                throw new Exception(ErrorMessages.InvalidInput);
            }
            //check _railMap list for existance of given sourse and destination
            //_railMap.Any(town=> town.Name == source.Name)==null)
            if (_railMap.Any(town => town.Name == source.Name)==null || _railMap.Any(town => town.Name == destination.Name)==null)
            {
                throw new Exception(ErrorMessages.InvalidSourceOrDestination);
            }

            //Route exists
            _railMap.Where(town => town.Name == source.Name).FirstOrDefault().addRoute(destination, distance);
        }

        //return town name
        public Town GetTown(char name)
        {
            return _railMap.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
