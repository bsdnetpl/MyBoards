using System.ComponentModel.DataAnnotations;

namespace MyBoards.Entities
{
    public class WorkItem
    {
     
        public int Id { get; set; } 
        public string State { get; set; }
        public string Area { get; set; }
        public string InterationPath { get; set; }
        public int Prioryti { get; set; }
        public DateTime? StardDate { get; set; }
        public DateTime? EnddDate { get; set; }
        public decimal Effort { get; set; }

        public string Activity { get; set; }

        public decimal RemaningWork { get; set; }
        public string Type { get; set; }



    }
}
