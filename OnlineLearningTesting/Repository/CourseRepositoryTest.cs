using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using OnlineLearningg.Data;
using OnlineLearningg.Models;
using OnlineLearning.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningWebApp.Testing.Repository
{
	public class CourseRepositoryTest
	{
        private async Task<OnlineLearningContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<OnlineLearningContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new OnlineLearningContext(options);
            databaseContext.Database.EnsureCreated();
            databaseContext.Users.Add(new User()
            {
                Password = "password",
                Role = 1,
                Username = "Name",
                Age = 1,
                Gender = "Male",
                PhoneNumber = 123456,
                Email = "abc@gmail.com",

            });
            if (await databaseContext.Courses.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    databaseContext.Courses.Add(new Course()
                    {
                        CourseId = 1,
                        UserId = 1,
                        CourseName = "name",
                        Price = 1000,
                        Description = "course",

                    });
                    await databaseContext.SaveChangesAsync();
                }
            }
            return databaseContext;
        }
        [Fact]
        public async void CourseRepository_GetCourse_ReturnCourse()
        {
            //Arrange
            var id = 1;
            var dbContext = await GetDatabaseContext();
            var CourseRepository = new CourseRepository(dbContext);
            //Act
            var result = CourseRepository.GetCourseByID(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<Post>();
        }
    }
}
