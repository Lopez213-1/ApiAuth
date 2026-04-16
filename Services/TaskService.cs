using TaskApi.Dtos;
using TaskApi.Modesl;
using TaskApi.Repositories;

namespace TaskApi.Services
{
    public class TaskService
    {
        private readonly TaskRepository _taskRepository;

        public TaskService(TaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<GetAllDto> GetAll()
        {
            var tareas = _taskRepository.GetAll();
            var resultado = new List<GetAllDto>();

            foreach(var task in tareas)
            {
                var dto = new GetAllDto
                {
                    Id = task.Id,
                    Titulo = task.Titulo,
                    Completada = task.Completada,
                    UserId = task.UserId
                };

                resultado.Add(dto);
            }

            return resultado;
        }

        public void Create(CreateTareaDto createTareaDto)
        {
            var tarea = new Tarea
            {
                Titulo = createTareaDto.Titulo,
                Completada = createTareaDto.Completada,
                UserId = createTareaDto.UserId
            };
            _taskRepository.Create(tarea);
        }

        public bool Update(int id, UpdateTareaDto updateTareaDto )
        {
            var task = _taskRepository.GetById(id);
            if (task is null)
            {
                return false;
            }

            task.Titulo = updateTareaDto.Titulo;
            task.Completada = updateTareaDto.Completada;
            _taskRepository.Update(task);
            return true;

        }
        
        public bool Delete(int id)
        {
            var tarea = _taskRepository.GetById(id);
            if (tarea is null)
            {
                return false;
            }

            _taskRepository.Delete(tarea);
            return true;
        }

        
    }
}