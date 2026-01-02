using MongoDB.Driver;

namespace Aplikasi_Manajemen_Sampah.Models
{
    public class MongoService
    {
        private readonly IMongoDatabase db;

        public IMongoCollection<User> Users => db.GetCollection<User>("Users");
        public IMongoCollection<Sampah> Sampah => db.GetCollection<Sampah>("Sampah");
        public IMongoCollection<Penjemputan> Penjemputan => db.GetCollection<Penjemputan>("Penjemputan");

        public MongoService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase("ManajemenSampahDB");
        }
    }
}