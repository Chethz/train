using System;
using System.Collections.Generic;
using System.Text;

namespace Cheth
{
    class Route
    {
        public char DestinationTown;
        public int Distance;

        public Route(char destinationCity, int distance)
        {
            DestinationTown = destinationCity;
            Distance = distance;
        }
    }
}
