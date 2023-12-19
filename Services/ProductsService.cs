using mongodb_dotnet_example.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace mongodb_dotnet_example.Services
{
    public class ProductsService
    {
        private readonly IMongoCollection<Products> _products;

        public ProductsService(IProductsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

			_products = database.GetCollection<Products>(settings.ProductsCollectionName);
        }

       //public List<product> Get() => _products.Find(product => true).ToList();

		public List<Products> Get() 
		{
			return _products.Find(FilterDefinition<Products>.Empty).ToList();
		}
		

		public Products Get(string id) => _products.Find(product => product.Id == id).FirstOrDefault();

        public Products Create(Products product)
        {
			_products.InsertOne(product);
            return product;
        }

        public void Update(string id, Products updatedProduct) => _products.ReplaceOne(product => product.Id == id, updatedProduct);

        public void Delete(Products productForDeletion) => _products.DeleteOne(product => product.Id == productForDeletion.Id);

        public void Delete(string id) => _products.DeleteOne(product => product.Id == id);
    }
}