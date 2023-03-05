using OnlineLearningg.Models;
namespace OnlineLearningg.Interface
{
    public interface ICourse
    {
        ICollection<Course> GetCourse();
        Course GetCourseByID(int Course_Id);
        bool CreateCourse(int userID,Course course);
        bool UpdateCourse(int id,Course course);
        bool DeleteCourse(Course course);
        bool DeleteCourse(List<Course> courses);
        bool Exist(int id);
        bool Save();
    }
}
