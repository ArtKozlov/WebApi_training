using System;
using DAL.Entities;

namespace TaskManagerProvider.Models
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
    }
}