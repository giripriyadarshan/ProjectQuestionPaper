using System.ComponentModel.DataAnnotations;

namespace ProjectQuestionPaper.Core.Models
{
    public class Year
    {
        [Key] public int Id { get; set; }
        [Required] public int YearNumber { get; set; }

        public Subject Subject { get; set; }
    }
}