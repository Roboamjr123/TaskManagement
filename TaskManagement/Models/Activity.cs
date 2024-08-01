namespace TaskManagement.Models
{
    public class Activity
    {
        public int Act_Id { get; set; }
        public string Act_Name { get; set;}
        public DateTime Act_Date { get; set; }
        public string Act_ImagePath { get; set; }

        // Foreign key
        public int? Tasks_Id { get; set; }

        // Many Activities belong to one Task
        public Tasks Tasks { get; set; }
    }
}
