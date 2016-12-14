using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.Entities;
using TaskManagerProvider.Models;

namespace TaskManagerProvider.Mapping
{
    public static class Mapper
    {
        #region Task mapping
        public static TaskDto ToTaskDto(this Task taskEntity)
        {
            if (ReferenceEquals(taskEntity, null))
                return null;
            return new TaskDto()
            {
                Id = taskEntity.Id,
                Name = taskEntity.Name,
                Description = taskEntity.Description,
                CreateDate = taskEntity.CreateDate,
                Author = taskEntity.Author.ToAuthorDto()
            };
        }

        public static Task ToTask(this TaskDto taskDtoEntity)
        {
            if (ReferenceEquals(taskDtoEntity, null))
                return null;
            return new Task()
            {
                Id = taskDtoEntity.Id,
                Name = taskDtoEntity.Name,
                Description = taskDtoEntity.Description,
                CreateDate = taskDtoEntity.CreateDate,
                Author = taskDtoEntity.Author.ToAuthor()
            };
        }

        #endregion
        #region Author mapping
                public static Author ToAuthor(this AuthorDto authorDtoEntity)
                {
                    if (ReferenceEquals(authorDtoEntity, null))
                        return null;
                    return new Author()
                    {
                        Id = authorDtoEntity.Id,
                        Name = authorDtoEntity.Name,
                       // Tasks = authorDtoEntity.Tasks.ToTaskCollection().ToList()
                    };
                }

                public static AuthorDto ToAuthorDto(this Author authorEntity)
                {
                    if (ReferenceEquals(authorEntity, null))
                        return null;
                    return new AuthorDto()
                    {
                        Id = authorEntity.Id,
                        Name = authorEntity.Name,
                        //Tasks = authorEntity.Tasks.ToTaskDtoCollection().ToList()
                    };
                }
                #endregion

        #region private methods(collections mapping)
        //private static IEnumerable<Task> ToTaskCollection(this ICollection<TaskDto> collectionTaskDto)
        //{
        //    foreach (var taskDto in collectionTaskDto)
        //    {
        //        yield return new Task
        //        {
        //            Id = taskDto.Id,
        //            Name = taskDto.Name,
        //            Description = taskDto.Description,
        //            CreateDate = taskDto.CreateDate,
        //            Author = taskDto.Author.ToAuthor()
        //        };
        //    }
        //}

        //private static IEnumerable<TaskDto> ToTaskDtoCollection(this ICollection<Task> collectionTask)
        //{
        //    foreach (var task in collectionTask)
        //    {
        //        yield return new TaskDto
        //        {
        //            Id = task.Id,
        //            Name = task.Name,
        //            Description = task.Description,
        //            CreateDate = task.CreateDate,
        //            Author = task.Author.ToAuthorDto()
        //        };
        //    }
        //}
        #endregion
    }
}