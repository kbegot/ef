using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Tryhard.Models

public class Adresse {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("rue")]
    public string Rue { get; set; } = string.Empty;

    [BsonElement("codePostal")]
    public int CodePostal { get; set; }

    [BsonElement("ville")]
    public string Ville { get; set; } = string.Empty;
}