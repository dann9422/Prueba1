using System.ComponentModel.DataAnnotations;

namespace Prueba1.Models.DataModels
{ 
    public enum Level { 
    
    Basic,
    Medium,
    Advanced,
    Expert

}
    public class Course : BaseEntity
    {
       
        [Required,StringLength(50)]
        public String Name { get; set; } = string.Empty;
        [Required, StringLength(280)]
        public string ShortDescription { get; set; } = string.Empty;
        public string LongDescription { get; set; } = string.Empty;
        //public string TargetAudiences { get; set; } = string.Empty;
        //public string Goals { get; set; } = string.Empty;
        //public string Requirements { get; set; } = string.Empty;
        public Level Level { get; set; } = Level.Basic;

        [Required]
        public  Chapter chapter { get; set; } = new Chapter(); 

        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        [Required]
        public ICollection<Student> Students { get; set; } = new List<Student>();

     


    }
}
