using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            if (ReferenceEquals(task, null))
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

        public void Update(Task task)
        {
            var entity = _context.Tasks.Find(task.Id);
            entity.Name = task.Name;
            entity.Description = task.Description;
            entity.CreateDate = DateTime.Now;
            var author = _context.Authors.FirstOrDefault(a => a.Name == task.Author.Name);
            if (!ReferenceEquals(author, null))
                entity.Author = author;
            else
                entity.Author = task.Author;
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            _context.Dispose();
        }
    }
}
