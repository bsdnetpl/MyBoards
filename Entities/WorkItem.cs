using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBoards.Entities
{
    public class WorkItem
    {
     
        public int Id { get; set; } 
        //[Required] // nie null
        public string State { get; set; }
        //[Column(TypeName ="varchar(200)")] // zmiana typu
        public string Area { get; set; }
        //[Column("Iteration_patch")] // zmiana nazwy kolumny
        public string InterationPath { get; set; }
        public int Prioryti { get; set; }
        public DateTime? StardDate { get; set; }
        //[Precision(3)] // precyzja
        public DateTime? EnddDate { get; set; }
        //[Column(TypeName = "decimal(5,2)")] // zmiana typu
        public decimal Effort { get; set; }
        //[MaxLength(200)]  // maksymalna długosc
        public string Activity { get; set; }
        //[Precision(14,2)] // precyzja
        public decimal RemaningWork { get; set; }
        public string Type { get; set; }



    }
}
