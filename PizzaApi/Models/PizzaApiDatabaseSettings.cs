namespace PizzaApi.Models
{
    public class PizzaApiDatabaseSettings
    {

        public string ConnectionString { get; set; } = null;

        public string DatabaseName { get; set; } = null;

        public string PizzaCollectionName { get; set; } = null;

        public string BeverageCollectionName { get; set; } = null;
    }
}
