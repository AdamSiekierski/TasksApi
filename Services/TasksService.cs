using MongoDB.Driver;
using TasksApi.Models;
using System.Collections.Generic;

namespace TasksApi.Services
{
  public class TasksService
  {
    private readonly IMongoCollection<Task> _tasks;

    public TasksService(ITasksDatabaseSettings tasksDatabaseSettings)
    {
      var client = new MongoClient(tasksDatabaseSettings.ConnectionString);
      var database = client.GetDatabase("TasksApi");

      _tasks = database.GetCollection<Task>("tasks");
    }

    public List<Task> Get() => _tasks.Find<Task>(task => true).ToList();
  }
}