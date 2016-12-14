using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class TaskRepository : IRepository<Task>
    {
        private readonly TaskManagerContext _context;

        public TaskRepository()
        {
            _context = new TaskManagerContext();
        }
        public void Create(Task task)
        {
            if (!ReferenceEquals(task, null))
                throw new ArgumentNullException();

            _context.Tasks.Add(task);
            _context.SaveChanges();
            _context.Dispose();
        }

        public void Delete(int key)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == key);
            if (!ReferenceEquals(task, null))
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
                _context.Dispose();
            }
        }

        public IEnumerable<Task> GetAll()
        {
            var result = _context.Tasks.Select(t => t);
        
            return result;
        }

        public Task GetById(int key)
        {
            var result = _context.Tasks.FirstOrDefault(t => t.Id == key);
         
            return result;
        }
    }
}
