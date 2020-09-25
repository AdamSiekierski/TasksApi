using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TasksApi.Models
{
  public class Task
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

    public string Description { get; set; }
  }
}