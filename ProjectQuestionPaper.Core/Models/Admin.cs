using System.ComponentModel.DataAnnotations;

namespace ProjectQuestionPaper.Core.Models
{
    public class Admin
    {
        [Key]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
