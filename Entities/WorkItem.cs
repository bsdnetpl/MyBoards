using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBoards.Entities
{
    public class Epic : WorkItem
    {
        public DateTime? StardDate { get; set; }
        //[Precision(3)] // precyzja
        public DateTime? EnddDate { get; set; }
    }
    public class Issue : WorkItem
    {
        //[Column(TypeName = "decimal(5,2)")] // zmiana typu
        public decimal Effort { get; set; }
    }

    public class Task : WorkItem
    {
        //[MaxLength(200)]  // maksymalna długosc
        public string Activity { get; set; }
        //[Precision(14,2)] // precyzja
        public decimal RemaningWork { get; set; }
    }

    public abstract class WorkItem
    {
     
        public int Id { get; set; } 
        
        public WorkItemState State { get; set; }

        public int StateId { get; set; }

        //[Required] // nie null
       // public string State { get; set; }
        //[Column(TypeName ="varchar(200)")] // zmiana typu
        public string Area { get; set; }
        //[Column("Iteration_patch")] // zmiana nazwy kolumny
        public string InterationPath { get; set; }
        public int Prioryti { get; set; }
        public string Type { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public User Author { get; set; }

        public Guid AuthorId { get; set; }

        public List<Tag> Tags { get; set; }

        //public List<WorkItemTag> WorkItemTags { get; set; }= new List<WorkItemTag>();


    }
}
