using System.ComponentModel.DataAnnotations;

namespace Fiction.Models
{
    public class Character
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*$")]
        public string Name { get; set; }
        public Gender Gender { get; set; }
        [Range(0,3000)]
        public int Age { get; set; }

        [Required]
        public int StoryId { get; set; }
        public virtual Story Story { get; set; }
    }

    public enum Gender 
    { 
        Unidentified,
        Male,
        Female
    }
}