namespace TaskManagement.Models
{
    public class Tasks
    {
        public int Tasks_Id { get; set; }
        public string Task_Name { get; set; }

        // Foreign key
        public int Project_Id { get; set; }

        // Many Tasks belong to one Project
        public Project Project { get; set; }

        // One Task has many Activities
        public ICollection<Activity> Activities { get; set; }
    }
}
