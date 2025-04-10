namespace Infrastructure
{
    public class MongoDBConfiguration
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public MongoDBConfiguration()
        {
            ConnectionString = "mongodb://localhost:27017";
            DatabaseName = "BookingProject";
        }
    }
}
