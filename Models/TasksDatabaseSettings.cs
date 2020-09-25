namespace TasksApi.Models
{
  public class TasksDatabaseSettings : ITasksDatabaseSettings
  {
    public string ConnectionString { get; set; }
  }

  public interface ITasksDatabaseSettings
  {
    string ConnectionString { get; set; }
  }
}