using TasksApi.Services;
using TasksApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace TasksApi.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class TasksController : ControllerBase
  {
    private readonly TasksService _tasksService;

    public TasksController(TasksService tasksService)
    {
      _tasksService = tasksService;
    }

    [HttpGet]
    public ActionResult<List<Task>> Get() => _tasksService.Get();

    [HttpGet("{id:length(24)}", Name = "GetTask")]
    public ActionResult<Task> Get(string id)
    {
      var task = _tasksService.Get(id);

      if (task == null)
      {
        return NotFound();
      }

      return task;
    }

    [HttpPost]
    public ActionResult<Task> Create(Task task)
    {
      _tasksService.Create(task);

      return CreatedAtRoute("GetTask", new { id = task.Id.ToString() }, task);
    }

    [HttpPut("{id:length(24)")]
    public IActionResult Update(string id, Task taskIn)
    {
      var task = _tasksService.Get(id);

      if (task == null)
      {
        return NotFound();
      }

      _tasksService.Update(id, taskIn);

      return NoContent();
    }

    [HttpDelete("{id:length(24)")]
    public IActionResult Delete(string id)
    {
      var task = _tasksService.Get(id);

      if (task == null)
      {
        return NotFound();
      }

      _tasksService.Delete(id);

      return NoContent();
    }
  }
}