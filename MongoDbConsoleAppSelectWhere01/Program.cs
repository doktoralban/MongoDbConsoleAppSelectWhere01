using System;
using MongoDB.Driver;
using MongoDB.Bson;

namespace MongoDbConsoleAppSelectWhere01
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbClient = new MongoClient("mongodb://127.0.0.1:27017");

            IMongoDatabase db = dbClient.GetDatabase("MyDatabase");
            var cars = db.GetCollection<BsonDocument>("Person");

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Gt("SiblingCount", 0) & 
                builder.Lt("SiblingCount", 3);

            var docs = cars.Find(filter).ToList();

            docs.ForEach(doc => {
                Console.WriteLine(doc);
            });

            Console.Read();
        }
    }
}