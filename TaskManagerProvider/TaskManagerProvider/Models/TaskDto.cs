using System;
using System.ComponentModel.DataAnnotations;
using TaskManagerProvider.Attributes;

namespace TaskManagerProvider.Models
{
    public class TaskDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [StringLength(40, ErrorMessage = "The Name must contain at least 4-40 characters", MinimumLength = 4)]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [StringLength(80, ErrorMessage = "The Description must contain at least 6-80 characters", MinimumLength = 6)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        //[StringLength(40, ErrorMessage = "The Author must contain at least 4-40 characters", MinimumLength = 4)]
        [CustomStringLength(40)]
        public string Author { get; set; }
    }
}