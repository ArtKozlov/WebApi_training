using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Entities;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {

        private readonly TaskManagerContext _context;

        public AuthorRepository()
        {
            _context = new TaskManagerContext();
        }
        public void Create(Author author)
        {           
            if (!ReferenceEquals(author, null))
                throw new ArgumentNullException();

            _context.Authors.Add(author);
            _context.SaveChanges();
            _context.Dispose();
        }

        public void Delete(int key)
        {
            var author = _context.Authors.FirstOrDefault(a => a.Id == key);
            if (!ReferenceEquals(author, null))
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
                _context.Dispose();
            }

        }

        public IEnumerable<Author> GetAll()
        {
            var result = _context.Authors;
        
            return result;
        }

        public Author GetById(int key)
        {
            var result = _context.Authors.FirstOrDefault(a => a.Id == key);
     
            return result;
        }

    }
}
