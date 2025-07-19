using System.Runtime.Versioning;

public class FeatureCollection
{
    public Feature[] Features { get; set; }
    public class Feature
    {
        public string Type { get; set; }
        public Property Properties { get; set; }
    }
    public class Property
    {
        public double Mag { get; set; }
        public string Place { get; set; }
    }
}