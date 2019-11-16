using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio3
{
    public class PizzaService
    {

        private readonly IMongoCollection<Pizza> _pizzas;

        public PizzaService(IPizzastoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _pizzas = database.GetCollection<Pizza>(settings.PizzasCollectionName);
        }

        public List<Pizza> Get() =>
            _pizzas.Find(x => true).ToList();

        public Pizza Get(string name) =>
            _pizzas.Find<Pizza>(x => x.nombre == name).FirstOrDefault();

        public Pizza Create(Pizza pizza)
        {
            _pizzas.InsertOne(pizza);
            return pizza;
        }

        public void Update(string name, Pizza pizzaIn) =>
            _pizzas.ReplaceOne(x => x.nombre == name, pizzaIn);

        public void Remove(Pizza pizzaIn) =>
            _pizzas.DeleteOne(x => x.nombre == pizzaIn.nombre);

        public void Remove(string name) =>
            _pizzas.DeleteOne(x => x.nombre == name);
    }
}
