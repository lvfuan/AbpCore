﻿using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Timing;
using AbpCore.Models;
using AbpCore.Tasks.Dtos;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AbpCore.IRepositories
{
    /// <summary>
    /// Implements <see cref="ITaskAppService"/> to perform task related application functionality.
    /// 
    /// Inherits from <see cref="ApplicationService"/>.
    /// <see cref="ApplicationService"/> contains some basic functionality common for application services (such as logging and localization).
    /// </summary>
    public class TaskAppService : AbpCoreAppServiceBase, ITaskAppService
    {
        //These members set in constructor using constructor injection.

        private readonly IRepository<AbpCore.Models.Task> _taskRepository;

        /// <summary>
        ///In constructor, we can get needed classes/interfaces.
        ///They are sent here by dependency injection system automatically.
        /// </summary>
        public TaskAppService(IRepository<AbpCore.Models.Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public GetTasksOutput GetTasks(GetTasksInput input)
        {
            var query = _taskRepository.GetAll();

            if (input.AssignedPersonId.HasValue)
            {
                query = query.Where(t => t.AssignedPersonId == input.AssignedPersonId.Value);
            }

            if (input.State.HasValue)
            {
                query = query.Where(t => t.State == input.State.Value);
            }

            //Used AutoMapper to automatically convert List<Task> to List<TaskDto>.
            return new GetTasksOutput
            {
                Tasks = Mapper.Map<List<TaskDto>>(query.ToList())
            };
        }

        public async System.Threading.Tasks.Task<TaskDto> GetTaskByIdAsync(int taskId)
        {
            //Called specific GetAllWithPeople method of task repository.
            var task = await _taskRepository.GetAsync(taskId);

            //Used AutoMapper to automatically convert List<Task> to List<TaskDto>.
            return task.MapTo<TaskDto>();
        }

        public TaskDto GetTaskById(int taskId)
        {
            var task = _taskRepository.Get(taskId);

            return task.MapTo<TaskDto>();
        }

        public void UpdateTask(UpdateTaskInput input)
        {
            //We can use Logger, it's defined in ApplicationService base class.
            Logger.Info("Updating a task for input: " + input);

            //Retrieving a task entity with given id using standard Get method of repositories.
            var task = _taskRepository.Get(input.Id);

            //Updating changed properties of the retrieved task entity.

            if (input.State.HasValue)
            {
                task.State = input.State.Value;
            }

            //We even do not call Update method of the repository.
            //Because an application service method is a 'unit of work' scope as default.
            //ABP automatically saves all changes when a 'unit of work' scope ends (without any exception).
        }

        public int CreateTask(CreateTaskInput input)
        {
            //We can use Logger, it's defined in ApplicationService class.
            Logger.Info("Creating a task for input: " + input);

            //Creating a new Task entity with given input's properties
            var task = new AbpCore.Models.Task
            {
                Description = input.Description,
                Title = input.Title,
                State = input.State,
                CreationTime = Clock.Now
            };

            //Saving entity with standard Insert method of repositories.
            return _taskRepository.InsertAndGetId(task);
        }

        public void DeleteTask(int taskId)
        {
            var task = _taskRepository.Get(taskId);
            if (task != null)
            {
                _taskRepository.Delete(task);
            }
        }

        public IList<TaskDto> GetAllTasks()
        {
            var task= _taskRepository.GetAll();
            return task.MapTo<IList<TaskDto>>();// Mapper.Map<List<Task>,List<TaskDto>>(t.ToList());
        }
    }
}
