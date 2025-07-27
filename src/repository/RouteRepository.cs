namespace Repository;

using System;
using System.Collections;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using Route = Domain.Route;
using Domain;

public class RouteRepository : Repository<Route>, IRouteRepository {
    public RouteRepository(IConfiguration configuration) : base(configuration) {

    }
    public IEnumerable<Route> SearchRoute(string origin, string destination) {
	IEnumerable<Route> routes = (IEnumerable<Route>) Read().ToList();
Console.WriteLine("Count="+routes.Count());
	var result = routes.Where(r => r.origin.icaoIata == origin && r.destination.icaoIata == destination).ToList();
        return (IEnumerable<Route>) result;
    }
    public Route GetARoute(string icaoIata) {
	var routes = Read();
	var response = routes.Where(r => r.origin.icaoIata == icaoIata || r.destination.icaoIata == icaoIata);
	return response?.FirstOrDefault();
    }
}
