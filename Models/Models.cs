using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiSqlite.Models
{
    public class Employee 
    {
        public int EmployeeId { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public DateTime HireDate { get; set; } = DateTime.Now;
        public string? Occupation { get; set; }

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

    }

    public class Department
    {
        public int DepartmentId { get; set; }

        public string? Name { get; set; } = String.Empty;
        public int TimeScheduleId { get; set; } = 0;
    }
}

