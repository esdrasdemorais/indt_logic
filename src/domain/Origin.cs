namespace Domain;

public class Origin : Object {
    public Double latitude  { get; set; }
    public Double longitude { get; set; }
    public String icaoIata { get; set; }
    public Boolean hasDestination { get; set; }
    public List<Destination> destinations { get; set; }
}


