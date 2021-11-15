using System;

namespace OperationDojima
{
    public class Location
    {
        public string name { get; set; }
        public double la { get; set; }
        public double lo { get; set; }

        public enum Mode { Degrees, Radians }

        public Location(double lat, double lon, string n)
        {
            la = lat;
            lo = lon;
            name = n;
        }

        public Location ChangeForm(Mode mode = Mode.Radians)
        {
            double equation;
            if (mode.Equals(Mode.Radians))
            {
                equation = Math.PI / 180;
            }
            else
            {
                equation = 180 / Math.PI;
            }
            return new Location(la * equation, lo * equation, name);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Location))
            {
                return false;
            }
            Location input = obj as Location;
            return la == input.la && lo == input.lo;
        }

        public override string ToString()
        {
            return $"{name}\nLatitude: {la}\nLongitude: {lo}\n";
        }
    }
}