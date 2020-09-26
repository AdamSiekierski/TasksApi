using MongoDB.Driver;
using TasksApi.Models;
using System.Collections.Generic;
using System;

namespace TasksApi.Services
{
  public class TasksService
  {
    private readonly IMongoCollection<Task> _tasks;

    public TasksService(ITasksDatabaseSettings tasksDatabaseSettings)
    {
      var client = new MongoClient(tasksDatabaseSettings.ConnectionString);
      var database = client.GetDatabase("TasksApi");

      _tasks = database.GetCollection<Task>("Tasks");
    }

    public List<Task> Get() => _tasks.Find<Task>(task => true).ToList();

    public Task Get(string id) => _tasks.Find<Task>(task => task.Id == id).FirstOrDefault();

    public Task Create(Task task)
    {
      _tasks.InsertOne(task);

      return task;
    }

    public void Update(string id, Task taskIn) => _tasks.ReplaceOne(task => task.Id == id, taskIn);

    public void Delete(string id) => _tasks.DeleteOne(task => task.Id == id);
  }
}