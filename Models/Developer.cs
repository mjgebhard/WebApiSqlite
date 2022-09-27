using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiSqlite.Models
{
    public class Developer
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
    }

    public class YearCount
    {
        public int Count { get; set; }
        public int Year { get; set; }
    }
}
