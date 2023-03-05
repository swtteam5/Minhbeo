
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using OnlineLearning.Controllers;
using OnlineLearningg.Data;
using OnlineLearningg.Dto;
using OnlineLearningg.Interface;
using OnlineLearningg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningWebApp.Testing.Controllers
{
    public class CourseRepositoryTest
    {
        private readonly ICourse _ICourse;
        private readonly IMapper _mapper;
        public CourseRepositoryTest()
        {
            _ICourse = A.Fake<ICourse>();
            _mapper = A.Fake<IMapper>();
        }
        [Fact]
        public void PostController_Get_ReturnSuccess()
        {
            //Arrange
            var course = A.Fake<IEnumerable<Course>>();
            var courseDto = A.Fake<List<CourseDto>>();
            A.CallTo(() => _mapper.Map<List<CourseDto>>(course)).Returns(courseDto);
            var controller = new CourseController(_ICourse, _mapper);
            //Act
            var result = controller.Get();
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void PostController_GetById_ReturnActionResult()
        {
            //Arrange
            var id = 1;
            var course = A.Fake<Course>();
            A.CallTo(() => _mapper.Map<Course>(course)).Returns(course);
            var controller = new CourseController(_ICourse, _mapper);

            //Act
            var result = controller.GetById(id);
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void PostController_Create_ReturnActionResult()
        {
            //Arrange
            var course = A.Fake<Course>();
            var courseDto = A.Fake<CourseDto>();
            A.CallTo(() => _mapper.Map<Course>(courseDto)).Returns(course);
            var controller = new CourseController(_ICourse, _mapper);
            //Act
            var result = controller.Create(courseDto);
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void PostController_Update_ReturnActionResult()
        {
            //Arrange
            var id = 1;
            var course = A.Fake<Course>();
            var courseDto = A.Fake<CourseDto>();
            A.CallTo(() => _mapper.Map<Course>(courseDto)).Returns(course);
            var controller = new CourseController(_ICourse, _mapper);

            //Act
            var result = controller.Update(id, courseDto);
            //Assert
            result.Should().NotBeNull();
        }
        [Fact]
        public void PostController_Delete_ReturnActionResult()
        {
            //Arrange
            var id = 2;
            var controller = new CourseController(_ICourse, _mapper);
            //Act
            var result = controller.Delete(id);
            //Assert
            result.Should().NotBeNull();
        }
    }
}
