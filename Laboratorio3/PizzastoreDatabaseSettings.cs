using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laboratorio3
{
    public class PizzastoreDatabaseSettings : IPizzastoreDatabaseSettings
    {
        public string PizzasCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IPizzastoreDatabaseSettings
    {
        string PizzasCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
