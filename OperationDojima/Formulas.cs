using System;

namespace OperationDojima
{
    class Formulas
    {
        public static double Haversine(Location l1, Location l2, double r = 6731)
        {
            double sdLat = Math.Sin((l2.la - l1.la) / 2), sdLong = Math.Sin((l2.lo - l1.lo) / 2);

            double q = Math.Pow(sdLat, 2) + Math.Cos(l1.la) * Math.Cos(l2.la) * Math.Pow(sdLong, 2);

            return 2 * r * Math.Asin(Math.Sqrt(q));
        }

        public static Location MidPoint(Location l1, Location l2)
        {
            double Bx = Math.Cos(l2.la) * Math.Cos(l2.lo - l1.lo);
            double By = Math.Cos(l2.la) * Math.Sin(l2.lo - l1.lo);

            double tanAngle1 = Math.Sin(l1.la) + Math.Sin(l2.la);
            double tanAngle2 = Math.Sqrt((Math.Cos(l1.la) + Bx) * (Math.Cos(l1.la) + Bx) + By * By);

            double latValue = Math.Atan2(tanAngle1, tanAngle2);
            double longValue = l1.lo + Math.Atan2(By, Math.Cos(l1.la) + Bx);

            return new Location(latValue, longValue, $"Midpoint Between {l1.name} and {l2.name}").ChangeForm(Location.Mode.Degrees);
        }
    }
}