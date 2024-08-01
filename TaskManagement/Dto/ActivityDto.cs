namespace TaskManagement.Dto
{
    public class ActivityDto
    {
        public int Act_Id { get; set; }
        public string Act_Name { get; set; }
        public DateTime Act_Date { get; set; }
        public string Act_ImagePath { get; set; }
        public int? Tasks_Id { get; set; }
    }
}
