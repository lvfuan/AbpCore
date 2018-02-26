using Abp.Application.Services;
using AbpCore.Tasks.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbpCore.IRepositories
{
    public interface ITaskAppService : IApplicationService
    {
        GetTasksOutput GetTasks(GetTasksInput input);

        void UpdateTask(UpdateTaskInput input);

        int CreateTask(CreateTaskInput input);

        Task<TaskDto> GetTaskByIdAsync(int taskId);

        TaskDto GetTaskById(int taskId);

        void DeleteTask(int taskId);

        IList<TaskDto> GetAllTasks();
    }
}
