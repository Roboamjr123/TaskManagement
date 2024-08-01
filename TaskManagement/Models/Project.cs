namespace TaskManagement.Models
{
    public class Project
    {
         public int Project_Id { get; set; }
         public string Project_Name { get; set; }

        // One Project has many Tasks
         public ICollection<Tasks> Tasks { get; set; }
    }
}
