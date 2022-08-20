using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public bool End { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime EndTime { get; set; }


    }
}
