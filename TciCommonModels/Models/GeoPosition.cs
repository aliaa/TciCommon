using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TciCommon.Models
{
    [Serializable]
    public class GeoPosition
    {
        public GeoPosition()
        { }

        public GeoPosition(double Latitude, double Longitude)
        {
            this.Latitude = Latitude;
            this.Longitude = Longitude;
        }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        private const double R = 6371; // Radius of the earth in km

        public override string ToString()
        {
            return "Lat:" + Latitude + " ,Lng:" + Longitude;
        }

        /// <summary>
        /// Gets distance of to points in KiloMeters
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static double Distance(GeoPosition p1, GeoPosition p2)
        {
            if (p1 == null || p2 == null)
                return double.NaN;
            double dLat = Deg2Rad(p2.Latitude - p1.Latitude);  // deg2rad below
            double dLon = Deg2Rad(p2.Longitude - p1.Longitude);
            double a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(Deg2Rad(p1.Latitude)) * Math.Cos(Deg2Rad(p2.Latitude)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c; // Distance in km
        }

        private static double Deg2Rad(double deg)
        {
            return deg * (Math.PI / 180);
        }
    }
}
