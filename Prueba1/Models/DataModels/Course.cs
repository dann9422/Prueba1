using System.ComponentModel.DataAnnotations;

namespace Prueba1.Models.DataModels
{
    public class Course
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required,MaxLength]
        public String Name { get; set; }
        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        public string TargetAudiences { get; set; } = string.Empty;
        public string Goals { get; set; } = string.Empty;
        public string Requirements { get; set; } = string.Empty;
        public int Level { get; set; } 
        

    }
}
