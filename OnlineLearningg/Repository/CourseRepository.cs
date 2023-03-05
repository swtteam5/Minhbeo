using Microsoft.Extensions.Hosting;
using OnlineLearningg.Data;
using OnlineLearningg.Interface;
using OnlineLearningg.Models;
using System.ComponentModel.Design;

namespace OnlineLearning.Repository
{
    public class CourseRepository : ICourse
    {
        private readonly OnlineLearningContext _context;
        public CourseRepository(OnlineLearningContext context)
        {
            _context = context;
        }
        public Course GetCourseByID(int id)
        {
            var course = _context.Courses.FirstOrDefault(x => x.CourseId == id);
            return course;
        }
        bool ICourse.CreateCourse(int userID,Course course)
        {
            _context.Courses.Add(course);
            return Save();
        }
        bool ICourse.UpdateCourse(int id,Course course)
        {
            _context.Courses.Update(course);
            return Save();
        }

        bool ICourse.DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);
            return Save();
        }

        bool ICourse.DeleteCourse(List<Course> courses)
        {
            _context.Courses.RemoveRange(courses);
            return Save();
        }

        ICollection<Course> ICourse.GetCourse()
        {
            return _context.Courses.ToList();
        }      

        
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Exist(int id)
        {
            return _context.Courses.Any(x => x.CourseId == id);
        }
    }
}
