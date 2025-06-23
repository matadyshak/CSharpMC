using MongoDB.Bson;
using MongoDB.Driver;

namespace DataAccessLibrary
{
    public class MongoDBDataAccess
    {
        private IMongoDatabase db;

        public MongoDBDataAccess(string dbName, string? connectionString)
        {
            var client = new MongoClient(connectionString);
            db = client.GetDatabase(dbName);
        }

        // Insert record if it does not already exist, else do nothing
        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);

            collection.InsertOne(record);
        }

        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList();
        }

        public T LoadRecordById<T>(string table, Guid? id)
        {
            var collection = db.GetCollection<T>(table);

            var filter = Builders<T>.Filter.Eq("Id", id);
            return collection.Find(filter).First();
        }
        public T LoadRecordByName<T>(string table, string firstName, string lastName)
        {
            var collection = db.GetCollection<T>(table);

            var filter = Builders<T>.Filter.And(
                Builders<T>.Filter.Eq("FirstName", firstName),
                Builders<T>.Filter.Eq("LastName", lastName));

            return collection.Find(filter).First();
        }
        public void UpsertRecord<T>(string table, Guid id, T record)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);
            var options = new ReplaceOptions { IsUpsert = true };

            collection.ReplaceOne(filter, record, options);
        }

        public void DeleteRecord<T>(string table, Guid? id)
        {
            var collection = db.GetCollection<T>(table);

            var filter = Builders<T>.Filter.Eq("Id", id);
            collection.DeleteOne(filter);
        }
    }
}
