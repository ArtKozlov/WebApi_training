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
        public IHttpActionResult Get()
            => Ok(_taskRepository.GetAll().Select(t => t.ToTaskDto()));

        
        [HttpGet]
        public IHttpActionResult Get(int id)
            => Ok(_taskRepository.GetById(id).ToTaskDto());

        
        [HttpPost]
        public IHttpActionResult Post(TaskDto task)
        {
            if (ModelState.IsValid)
            {
                if (!ReferenceEquals(task, null))
                {
                    task.CreateDate = DateTime.Now;
                    _taskRepository.Create(task.ToTask());
                }
            }
            return Ok();

        }

        [HttpPut]
        public IHttpActionResult Put(TaskDto tasktoDto)
        {
            if(ModelState.IsValid)
            { 
                if (!ReferenceEquals(tasktoDto, null))
                {
                    _taskRepository.Update(tasktoDto.ToTask());
                }
            }
            return Ok();
        }

        
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var task = _taskRepository.GetById(id);

            if (!ReferenceEquals(task, null))
            {
                _taskRepository.Delete(id);
            }
            return Ok();
        }
    }
}
