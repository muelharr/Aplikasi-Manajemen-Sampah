using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aplikasi_Manajemen_Sampah.Models
{
    public class Penjemputan
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = "";

        [BsonRepresentation(BsonType.ObjectId)]
        public string SampahID { get; set; } = "";

        [BsonRepresentation(BsonType.ObjectId)]
        public string PetugasID { get; set; } = "";

        public DateTime TanggalJadwal { get; set; } = DateTime.Now;

        // Terjadwal, Selesai, Dibatalkan
        public string Status { get; set; } = "Terjadwal";

        public string Catatan { get; set; } = "";

        // Properti Display (Tidak masuk database secara langsung jika tidak di-map)
        public string NamaPetugas { get; set; } = "";
        public string NamaSampah { get; set; } = "";
        public string LokasiSampah { get; set; } = "";
    }
}