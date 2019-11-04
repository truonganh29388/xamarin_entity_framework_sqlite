using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedTime = DateTime.UtcNow;
            UpdatedTime = DateTime.UtcNow;
        }

        [Key]
        public string Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
