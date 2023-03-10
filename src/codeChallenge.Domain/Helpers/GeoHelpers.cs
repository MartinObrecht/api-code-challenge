using codeChallenge.Domain.Entities;
using MongoDB.Driver.GeoJsonObjectModel;

namespace codeChallenge.Domain.Helpers
{
    public static class GeoHelpers
    {
        private const double EarthRadiusKm = 6371;

        public static double Distance(Address address, GeoJsonPoint<GeoJson2DGeographicCoordinates> point)
        {
            var lat = address.Coordinates[1];
            var lon = address.Coordinates[0];

            var dLat = ToRadians(point.Coordinates.Latitude - lat);
            var dLon = ToRadians(point.Coordinates.Longitude - lon);

            lat = ToRadians(lat);
            var pointLat = ToRadians(point.Coordinates.Latitude);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat) * Math.Cos(pointLat);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return EarthRadiusKm * c;
        }

        private static double ToRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}