using System.ComponentModel.DataAnnotations;

namespace Prueba1.Models.DataModels
{
    public class Chapter : BaseEntity
    {

        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = new Course();  


        [Required]
        public String List { get; set; }= String.Empty; 
    }
}
