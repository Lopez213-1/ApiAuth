using TaskApi.Data;
using TaskApi.Modesl;

namespace TaskApi.Repositories{
    public class TaskRepository
{
        private readonly AppDbContext _appDbContext;

        public TaskRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Tarea> GetAll()
        {
            var tareas = _appDbContext.Tareas.ToList();
            return tareas;
        }

        public void Create(Tarea tarea)
        {
            _appDbContext.Tareas.Add(tarea);
            _appDbContext.SaveChanges();
        }

        public Tarea? GetById(int id)
        {
            var tarea = _appDbContext.Tareas.Find(id);
            return tarea;
        }

        public void Update(Tarea tarea)
        {
            _appDbContext.Tareas.Update(tarea);
            _appDbContext.SaveChanges();
        }
        
        public void Delete (Tarea tarea)
        {
            _appDbContext.Tareas.Remove(tarea);
            _appDbContext.SaveChanges();
        }
    }
    
}