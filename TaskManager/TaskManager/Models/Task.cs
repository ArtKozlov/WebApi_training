using System;
using System.Collections.Generic;

namespace TaskManager.Models
{
    public class Task
    {
        public Task()
        {
            Authors = new List<Author>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}