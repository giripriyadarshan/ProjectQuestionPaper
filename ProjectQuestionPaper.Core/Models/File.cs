using System.ComponentModel.DataAnnotations;

namespace ProjectQuestionPaper.Core.Models
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FileName { get; set; }

        public Year Year { get; set; }


    }
}
