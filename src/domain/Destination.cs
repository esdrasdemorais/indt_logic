namespace Domain;

public class Destination : Object {
    public Double? latitude { get; set; }
    public Double? longitude { get; set; }
    public String icaoIata { get; set; } = "ORL";
    public Boolean hasOrigin  { get; set; } = false;
    public List<Origin> origins  { get; set; }
}


