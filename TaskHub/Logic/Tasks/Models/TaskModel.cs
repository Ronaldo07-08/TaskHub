using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Tasks.Models
{
    public class TaskModel
    {

        public TaskModel(Guid id, string? title, Guid createdByUserId, DateTimeOffset createdUtc)
        {
            Id = id;
            Title = title;
            CreatedByUserId = createdByUserId;
            CreatedUtc = createdUtc;
        }

        public Guid Id { get; set; }

        public string? Title { get; set; }

        public Guid CreatedByUserId { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
    }
}
