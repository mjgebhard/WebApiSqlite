namespace WebApiSqlite.Models
{
    public class DeveloperPoco
    {
        public int DeveloperId { get; set; }
        public ActionItemPoco? ActionItem { get; set; }
    }
    public class ActionItemPoco
    {
        public string? Tilte { get; set; }
        public string? Description { get; set; }
        public string? State { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? PlanDate { get; set; }
        public DateTime? CloseDate { get; set; }

        public int DeveloperId { get; set; }
    }


}
