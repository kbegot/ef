using MongoDB.Driver;
using Tryhard.Models;

namespace Tryhard.Services
{
    public class MongoDBService
    {
        private readonly IMongoCollection<Product> _products;

        public MongoDBService(IMongoClient client)
        {
            var database = client.GetDatabase("TryhardDb");
            _products = database.GetCollection<Product>("Products");
        }

        public List<Product> Get() => _products.Find(_ => true).ToList();
        public Product? Get(string id) => _products.Find(p => p.Id == id).FirstOrDefault();
        public void Create(Product product) => _products.InsertOne(product);
        public void Update(string id, Product product) => _products.ReplaceOne(p => p.Id == id, product);
        public void Remove(string id) => _products.DeleteOne(p => p.Id == id);
    }
}
