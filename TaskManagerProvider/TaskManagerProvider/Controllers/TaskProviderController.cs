using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL.Entities;
using DAL.Repositories;
using DAL.Interfaces;
using TaskManagerProvider.Mapping;
using TaskManagerProvider.Models;

namespace TaskManagerProvider.Controllers
{
    public class TaskProviderController : ApiController
    {
        private readonly IRepository<Task> _taskRepository;

        public TaskProviderController()
        {
            _taskRepository = new TaskRepository();
        }

        [HttpGet]
        public IEnumerable<TaskDto> Get()
            => _taskRepository.GetAll().Select(t => t.ToTaskDto());

        // GET api/tasks/5
        [HttpGet]
        public TaskDto Get(int id)
            => _taskRepository.GetById(id).ToTaskDto();

        // POST api/tasks
        [HttpPost]
        public void Post(TaskDto task)
        {
            if (!ReferenceEquals(task, null))
            { 
                task.CreateDate = DateTime.Now;
                _taskRepository.Create(task.ToTask());
            }

        }

        [HttpPut]
        public void Put(TaskDto tasktoDto)
        {
            if (!ReferenceEquals(tasktoDto, null))
            {
                _taskRepository.Update(tasktoDto.ToTask());
            }

        }

        // DELETE api/tasks/5
        [HttpDelete]
        public void Delete(int id)
        {
            var task = _taskRepository.GetById(id);

            if (!ReferenceEquals(task, null))
            {
                _taskRepository.Delete(id);
            }
            
        }
    }
}
