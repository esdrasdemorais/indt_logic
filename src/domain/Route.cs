using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain;

public class Route : Object {
    //public Int64 id { get; set; }
    //public Origin origin { get; set; }
    //public Destination destination  { get; set; }
    public KindOfRoute kind  { get; set; }
    public Boolean hasConnection  { get; set; }
    public IEnumerable<Route>connections  { get; set; }
    public float price { get; set; }
    public Route() {}
    /*public Route (Origin origin, Destination destination) {
        this.origin = origin;
	this.destination = destination;
    }*/
}
