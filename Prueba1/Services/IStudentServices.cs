using Prueba1.Models.DataModels;

namespace Prueba1.Services
{
    public interface IStudentServices
    {
        IEnumerable<Student> GetStudentWithCourse();
        IEnumerable<Student> GetStudentWithNotCourse();

    }
}
