using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Data;
using TaskApi.Dtos;
using TaskApi.Modesl;
using TaskApi.Services;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{

    private readonly TaskService _taskService;

    public TaskController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var tareas = _taskService.GetAll();
        return Ok(tareas);
    }

    [HttpPost]
    public IActionResult Create(CreateTareaDto createTareaDto )
    {
        _taskService.Create(createTareaDto);
        return Ok("Tarea creada Correctamente.");
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateTareaDto updateTareaDto)
    {
        var tareaExistente = _taskService.Update(id, updateTareaDto);
        if (tareaExistente)
        {

            return Ok("Tarea Actualizada correctamente.");
        }

        return NotFound("Tarea no encontrada");




    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var tarea = _taskService.Delete(id);
        if (tarea)
        {
            return Ok("Tarea eliminada Correctamente");
        }

        return NotFound("Tarea no encontrada");


    }

}