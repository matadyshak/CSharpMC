using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;


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

        public T LoadRecordById<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);

            var filter = Builders<T>.Filter.Eq("Id", id);
            return collection.Find(filter).First();
        }

        // Upsert: If record exists update it, If record does not exist insert it
        public void UpsertRecord<T>(string table, Guid id, T record)
        {
            var collection = db.GetCollection<T>(table);


            // Id { 0a9bbc7d-a050-40e9-a761-b58728e591d8 }


            // Tim = 0a9bbc7d-a050-40e9-a761-b58728e591d8

            // Little endian -> 7d, bc, 9b, 0a, 50, a0, e9, 40, // Big endian -> a7, 61, b5, 87, 28, e5, 91, d8
            var bsonGuid = new BsonBinaryData(id.ToByteArray(), BsonBinarySubType.UuidStandard);


            // Little endian -> 7d, bc, 9b, 0a, 50, a0, e9, 40, // Big endian -> a7, 61, b5, 87, 28, e5, 91, d8
            var bsonGuid2 = new BsonBinaryData(id.ToByteArray(), BsonBinarySubType.UuidLegacy);

            // filter : NAME = "_id"
            //         	Value	{Binary:0x7dbc9b0a50a0e940a761b58728e591d8}	 UUIDStandard


            var filter = new BsonDocument("_id", id.ToByteArray());


            var existing = collection.Find(filter).FirstOrDefault();

            if (existing == null)
            {
                collection.InsertOne(record);
            }
            else
            {
                collection.ReplaceOne(filter, record);
            }
        }




        //collection.ReplaceOne(new BsonDocument("_id",
        //    new BsonBinaryData(id.ToByteArray(),
        //    BsonBinarySubType.UuidStandard)), record);


        //var result = collection.ReplaceOne(
        //        new BsonDocument("_id", new BsonBinaryData(id.ToByteArray(), BsonBinarySubType.UuidStandard)),
        //        record,
        //        new ReplaceOptions { IsUpsert = true });

        //public void UpsertRecord<T>(string table, Guid id, T record)
        //{
        //    var collection = db.GetCollection<T>(table);

        //    var result = collection.ReplaceOne(
        //        new BsonDocument("_id", id),
        //        record,
        //        new UpdateOptions { IsUpsert = true });
        //}

        public void DeleteRecord<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);

            var filter = Builders<T>.Filter.Eq("_Id", id);
            collection.DeleteOne(filter);
        }
    }
}
