using System;
using System.Collections.Generic;
using DAL.Entities;

namespace TaskManagerProvider.Models
{
    public class AuthorDto
    {
        public AuthorDto()
        {
            Tasks = new List<TaskDto>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<TaskDto> Tasks { get; set; }
    }
}