using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace MBMS.Models
{
    public class DataAccess
    {
        string connectionString = "mongodb://localhost:27017";
        string dbName = "mbmsDB";
        MongoClient mongoClient = null;
        MongoServer mongoServer = null;
        MongoDatabase db = null;

        public DataAccess()
        {
            var mongoUrl = new MongoUrl(connectionString);
            mongoClient = new MongoClient(mongoUrl);
            mongoServer = new MongoServer(MongoServerSettings.FromClientSettings(mongoClient.Settings));
            db = mongoServer.GetDatabase(dbName);
        }

        public IEnumerable<User> GetUsers()
        {
            return db.GetCollection<User>("Users").FindAll();
        }


        public User GetUser(ObjectId id)
        {
            var res = Query<User>.EQ(p => p.ID, id);
            return db.GetCollection<User>("Users").FindOne(res);
        }

        public User CreateUser(User u)

        {

            db.GetCollection<User>("Users").Save(u);
            return u;
        }

        public void UpdateUser(ObjectId id, User u)
        {
            u.ID = id;
            var res = Query<User>.EQ(pd => pd.ID, id);
            var operation = Update<User>.Replace(u);
            db.GetCollection<User>("Users").Update(res, operation);
        }
        public void RemoveUser(ObjectId id)
        {
            var res = Query<User>.EQ(e => e.ID, id);
            var operation = db.GetCollection<User>("Users").Remove(res);
        }
    }
}
