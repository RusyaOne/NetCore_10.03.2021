using System.ComponentModel.DataAnnotations;

namespace Fiction.Models
{
    public class Character
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name must not be empty")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Name must contain only literal symbols")]
        public string Name { get; set; }
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Age must be specified")]
        [Range(0,3000, ErrorMessage = "Age must be in range between 0 to 3000")]
        public int? Age { get; set; }

        [Required(ErrorMessage = "Story Id must not be empty")]
        public int? StoryId { get; set; }
        public virtual Story Story { get; set; }
    }

    public enum Gender 
    { 
        Unidentified,
        Male,
        Female
    }
}