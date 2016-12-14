using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Author
    {
        public Author()
        {
            Tasks = new List<Task>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}