namespace Repository;

using System;
using System.Collections;
using MongoDB.Driver;
using MongoDB.Bson;
using Domain;
using Object = Domain.Object;

public abstract class Repository<T> : IRepository<T> where T : Object {
    private readonly String connectionUri;
    private readonly MongoClient mongoClient;
    private readonly MongoClientSettings mongoClientSettings;
    private readonly IMongoCollection<T> mongoCollection;

    public Repository(IConfiguration configuration) {
	connectionUri = "" + Environment.GetEnvironmentVariable("mongoConnectionString");
	mongoClientSettings = MongoClientSettings.FromConnectionString(connectionUri);
	mongoClientSettings.ServerApi = new ServerApi(ServerApiVersion.V1);
	mongoClient = new MongoClient(mongoClientSettings);
	var mongoDatabase = mongoClient.GetDatabase("indt_logic_test");
	mongoCollection = mongoDatabase.GetCollection<T>(typeof(T).Name);

	/*try {
	    var result = mongoClient.GetDatabase("admin").RunCommand<BsonDocument>(new BsonDocument("ping", 1));
	    Console.WriteLine("Pinged your deployment. You successfully connected to MongoDB!");
	} catch (Exception ex) {
	    Console.WriteLine(ex);
	}*/
    }

    public bool Create(T obj) {
	mongoCollection.InsertOne(obj);
    	return true;  
    }

    public IEnumerable<T> Read() {
	var filter = Builders<T>.Filter.Empty;
        var result = mongoCollection.Find(filter);
	return (IEnumerable<T>) result.ToList();
    }

    public bool Update(T obj) {
	var filter = Builders<T>.Filter.Eq("id", obj.id);

	var update = Builders<T>.Update.Set(o => o, obj);

	mongoCollection.UpdateOne(filter, update);

	return true;
    }

    public bool Delete(T obj) {
	var filter = Builders<T>.Filter.Eq("id", obj.id);

	mongoCollection.DeleteOne(filter);

	return true;
    }
}
