using System.Collections.Generic;

namespace TaskManager.Entities
{
    public class TaskCategory : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<TaskToDo> Tasks { get; set; }
    }
}
