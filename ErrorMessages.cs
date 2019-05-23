using System;
using System.Collections.Generic;
using System.Text;

namespace Cheth
{
    class ErrorMessages
    {
        private static string _InvalidInput = "Please input valid source, destination and distance";

        public static string InvalidInput
        {
            get { return _InvalidInput; }
        }

        private static string _InvalidSourceOrDestination = "ERROR :: Entered source or destination not valid";

        public static string InvalidSourceOrDestination
        {
            get { return _InvalidSourceOrDestination; }
        }

        private static string _DestinationCityExist = "City already have an destination city";

        public static string DestinationCityExist
        {
            get { return _DestinationCityExist; }
        }

        private static string _InvalidNoOfCities = "Please enter valid number number of cities";

        public static string InvalidNoOfCitiest
        {
            get { return _InvalidNoOfCities; }
        }

        private static string _InvalidDistanceOrTown = "Please enter valid destination town or distance";

        public static string InvalidDistanceOrTown
        {
            get { return _InvalidDistanceOrTown; }
        }

        private static string _InvalidRoute = "Please enter valid list of routes";

        public static string InvalidRoute
        {
            get { return _InvalidRoute; }
        }

        private static string _InvalidDistance = "Please valid distance";

        public static string InvalidDistance
        {
            get { return _InvalidDistance; }
        }

        private static string _NoRouteFound = "NO SUCH ROUTE FOUND";

        public static string NoRouteFound
        {
            get { return _NoRouteFound; }
        }


    }
}
