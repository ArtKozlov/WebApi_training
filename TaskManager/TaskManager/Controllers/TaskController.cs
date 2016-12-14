using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Models;

namespace TaskManager.Controllers
{
    public class TaskController : ApiController
    {
        private readonly TaskManagerContext _context = new TaskManagerContext();

        // GET api/tasks
        [HttpGet]
        public IEnumerable<Task> Get()
            => _context.Tasks;

        // GET api/tasks/5
        [HttpGet]
        public Task Get(int id)
            => _context.Tasks.FirstOrDefault(t => t.Id == id);

        // POST api/tasks
        [HttpPost]
        public IHttpActionResult Post(Task task)
        {
            if (ReferenceEquals(task, null))
                return Ok(); // What I need to return in this situation???
            task.CreateDate = DateTime.Now;
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return Ok();

        }        

        // DELETE api/tasks/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (!ReferenceEquals(task, null))
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
                

            return Ok();
        }
    }
}
