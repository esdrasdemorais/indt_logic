namespace tests;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Repository;
using Domain;
using Route = Domain.Route;

public class RouteTest
{
    private readonly Mock<IRouteRepository> routeRepository;
    private readonly Origin origin;
    private readonly Destination destination;

    public RouteTest() {
    	routeRepository = new Mock<IRouteRepository>();    	    
        origin = new Origin() {
	    icaoIata = "GRU"
	};
	destination = new Destination() {
	    icaoIata = "CGH"
	};
    }

    [Fact]
    public void SearchARouteNotFound() {
        var response = routeRepository.Object.SearchRoute(origin.icaoIata, destination.icaoIata); 
	Assert.Equal(0, response.Count());
    }
    
    [Fact]
    public void SearchARouteWithSuccess() {
	var returnRoutes = new List<Route>();
	returnRoutes.Add(new Route());

	routeRepository.Setup(r => r.SearchRoute("GRU", "CGH")).Returns(returnRoutes);

    	var response = routeRepository.Object.SearchRoute("GRU", "CGH");
	
	Assert.Equal(true, response.Count() > 0);
    }
    
    [Fact]
    public void CreateARouteDuplicatedFailed() {
    	var response = routeRepository.Object.Create(new Route());
	Assert.Equal(false, response);
    }
    
    [Fact]
    public void CreateARouteSuccesfull() {
    	routeRepository.Setup(r => r.Create(It.IsAny<Route>())).Returns(true);
	var response = routeRepository.Object.Create(It.IsAny<Route>());
	Assert.Equal(true, response);
    }

    [Fact]
    public void ReadARouteReturnsNothing() {
    	var response = routeRepository.Object.Read();
	Assert.Equal(0, response.Count());
    }
    
    [Fact]
    public void ReadARouteReturnsRowsSuccesfull() {
    	var returnRoutes = new List<Route>();
	returnRoutes.Add(new Route());
	routeRepository.Setup(r => r.Read()).Returns(returnRoutes);
	var response = routeRepository.Object.Read();
	Assert.Equal(true, response.Count() > 0);
    }

    [Fact]
    public void UpdateARouteFailed() {
    	var response = routeRepository.Object.Update(new Route());
	Assert.Equal(false, response);
    }
    
    [Fact]
    public void UpdateARouteSuccesfull() {
    	routeRepository.Setup(r => r.Update(It.IsAny<Route>())).Returns(true);
	var response = routeRepository.Object.Update(It.IsAny<Route>());
	Assert.Equal(true, response);
    }

    [Fact]
    public void DeleteARouteFailed() {
        var response = routeRepository.Object.Delete(new Route());
        Assert.Equal(false, response);
    }

    [Fact]
    public void DeleteARouteSuccesfull() {
        routeRepository.Setup(r => r.Delete(It.IsAny<Route>())).Returns(true);
        var response = routeRepository.Object.Delete(It.IsAny<Route>());
        Assert.Equal(true, response);
    }
}
