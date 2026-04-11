using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskApi.Data;
using TaskApi.Modesl;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{

    private readonly AppDbContext _appDbContext;

    public TaskController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var tareas = _appDbContext.Tareas.ToList();
        return Ok(tareas);
    }

    [HttpPost]
    public IActionResult Create(Tarea tarea)
    {
        _appDbContext.Add(tarea);
        _appDbContext.SaveChanges();
        return Ok(tarea);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Tarea tarea)
    {
        var tareaExistente = _appDbContext.Tareas.Find(id);
        if (tareaExistente == null)
        {
            return NotFound("Tarea no encontrada");
        }


        tareaExistente.Titulo = tarea.Titulo;
        tareaExistente.Completada = tarea.Completada;
        _appDbContext.SaveChanges();
        return Ok(tareaExistente);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var tarea = _appDbContext.Tareas.Find(id);
        if (tarea == null)
        {
            return NotFound("Tarea no encontrada");
        }


        _appDbContext.Tareas.Remove(tarea);
        _appDbContext.SaveChanges();
        return Ok("Tarea eliminada");
    }

}