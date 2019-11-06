using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Entities
{
    public class TaskToDo : BaseEntity
    {
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public DateTime ExpectedFinishedTime { get; set; }
        public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public string ParentTaskId { get; set;  }

        [ForeignKey(nameof(CategoryId))]
        public TaskCategory Category { get; set; }

        [ForeignKey(nameof(ParentTaskId))]
        public TaskToDo Parent { get; set; }

        public virtual ICollection<TaskToDo> SubTasks { get; set;  }
    }

    public enum TaskStatus
    {
        New,
        Doing,
        Completed,
        Missed,
        Deleted
    }
    public enum TaskPriority
    {
        Normal,
        Medium,
        High
    }
}
