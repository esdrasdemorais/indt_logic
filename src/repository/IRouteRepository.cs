namespace Repository;

using System;
using System.Collections.Generic;
using Route = Domain.Route;
using Domain;

public interface IRouteRepository : IRepository<Route> {
    public IEnumerable<Route> SearchRoute(string origin, string destination);
    public Route GettingBestRoute(string origin, string destination);
    public Route GetARoute(string icaoIata);
}
