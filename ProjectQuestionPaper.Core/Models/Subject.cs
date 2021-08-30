using System.ComponentModel.DataAnnotations;

namespace ProjectQuestionPaper.Core.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string SubjectName { get; set; }

        public Semester Semester { get; set; }
    }
}
