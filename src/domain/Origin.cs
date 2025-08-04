namespace Domain;

public class Origin : Object {
    public Double? latitude  { get; set; }
    public Double? longitude { get; set; }
    public String icaoIata { get; set; } = "GRU";
    public Boolean hasDestination { get; set; } = false;
    public List<Destination> destinations { get; set; }
}
