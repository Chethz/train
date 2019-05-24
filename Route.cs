using System;
using System.Collections.Generic;
using System.Text;

namespace Cheth
{
    class Route
    {
        private int _distance;

        public Town DestinationTown { get; }
        public int Distance
        {
            get { return _distance; }
        }

        public Route(Town destinationTown, int distance)
        {
            this.DestinationTown = destinationTown;
            this._distance = distance;
        }
    }
}
