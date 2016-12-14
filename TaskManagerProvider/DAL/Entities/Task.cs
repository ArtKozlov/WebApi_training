using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public virtual Author Author { get; set; }
    }
}