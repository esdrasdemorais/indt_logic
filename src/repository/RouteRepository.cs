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
    private Route GettingBestRoute(IEnumerable<Route> possibleRoutes) {
	possibleRoutes = possibleRoutes.OrderBy(r => r.price);
	var result = new Route();
	var minorPrice = possibleRoutes.FirstOrDefault().price;
	foreach (var route in possibleRoutes) {
	    if (route.price < minorPrice) {
		minorPrice = route.price;
		result = route;
		result.price = minorPrice;
	    }
	}
	return result;
    }
    public Route GettingBestRoute(string origin, string destination) {
	IEnumerable<Route> routes = (IEnumerable<Route>) Read().ToList();
Console.WriteLine("Count="+routes.Count());
	var possibleRoutes = routes.Where(r => r.origin.icaoIata == origin || r.destination.icaoIata == destination).ToList().OrderBy(r => r.origin.icaoIata);
	var result = GettingBestRoute(possibleRoutes);
        return result;
    }
    public IEnumerable<Route> SearchRoute(string origin, string destination) {
     	IEnumerable<Route> routes = (IEnumerable<Route>) Read().ToList();
Console.WriteLine("Count="+routes.Count());
	routes = routes.Where(r => r.origin.icaoIata == origin && r.destination.icaoIata == destination).ToList().OrderBy(r => r.origin.icaoIata);
	return routes;
    }
    public Route GetARoute(string icaoIata) {
	var routes = Read();
	var response = routes.Where(r => r.origin.icaoIata == icaoIata || r.destination.icaoIata == icaoIata);
	return response?.FirstOrDefault();
    }
}
