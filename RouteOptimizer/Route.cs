namespace RouteOptimizer
{
    public class Route
    {
        public Area From { get; set; }
        public Area To { get; set; }

        public override bool Equals(object obj)
        {
            Route tmp = (Route)obj;

            return ((this.From == tmp.From) && (this.To == tmp.To));
        }
    }
}