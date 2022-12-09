using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiSqlite.Models
{
    public partial class Developer
    {
        public int DeveloperId { get; set; }
        public int Count { get; set; }
        public int Year { get; set; }

        [NotMapped]
        public string FormattedId 
        {
            get 
            { 
                return $"{Count.ToString().PadLeft(3,'0')}/{Year}"; 
            } 
        }

        public int ECOCount { get; set; }
        public int ECOYear { get; set; }    
        public bool ECOSelected { get; set; }

        [NotMapped]
        public string ECO
        {
            get
            {
                if(ECOSelected)
                {
                    return $"{ECOCount.ToString().PadLeft(3, '0')}/{ECOYear}";
                }
                return string.Empty;
            }
        }
        public List<ActionItem>? ActionItems { get; set; }
    }


    public class YearCount
    {
        public int Count { get; set; }
        public int Year { get; set; }
    }

    public class ActionItem
    {
        public int ActionItemId { get; set; }
        public string? Tilte { get; set; }
        public string? Description { get; set; }
        public string? State { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? PlanDate { get; set; }
        public DateTime? CloseDate { get; set; }

        public int DeveloperId { get; set; }
        public Developer? Developer { get; set; }
    }
}
