using TasksApi.Services;
using TasksApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
  }
}