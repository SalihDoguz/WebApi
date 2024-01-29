namespace ExampleLT.API.Models
{
    public class Issue
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public Priority Priority { get; set; }
        public IssueType IssueType { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime CompletedTime { get; set; }
    }
               
    public enum Priority // Öncelik
    {
        Low,Medium,High
    }

    public enum IssueType // Sorun Tipi
    {
        Feature,Bug,Documentation
    }

}
