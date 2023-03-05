using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using OnlineLearningg.Data;
using OnlineLearningg.Dto;
using OnlineLearningg.Interface;
using OnlineLearningg.Models;
using OnlineLearning.Repository;
using System.Net.WebSockets;

namespace OnlineLearning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {

        private readonly ICourse _courseRepository;
        private readonly IMapper _mapper;
        public CourseController(ICourse courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var courses = _mapper.Map<IEnumerable<CourseDto>>(_courseRepository.GetCourse());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(courses);
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            if (!_courseRepository.Exist(id))
            {
                return NotFound();
            }
            var course = _mapper.Map<Course>(_courseRepository.GetCourseByID(id));
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(course);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CourseDto course)
        {
            if (course == null) { return BadRequest(ModelState); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var CourseMap = _mapper.Map<Course>(course);
            if (!_courseRepository.CreateCourse(CourseMap.UserId, CourseMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return Ok("Successfully saved");
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(int id, [FromBody] CourseDto course)
        {
            if (course == null) { return BadRequest(ModelState); }
            if (id != course.Course_ID)
            {
                return BadRequest(ModelState);
            }
            if (!_courseRepository.Exist(id)) { return NotFound(); }
            var CourseMap = _mapper.Map<Course>(course);
            if (!_courseRepository.UpdateCourse(id, CourseMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return Ok("Successfully saved");
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            if (!_courseRepository.Exist(id)) { return NotFound(); }
            var course = _courseRepository.GetCourseByID(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }           
            if (!_courseRepository.DeleteCourse(course))
            {
                ModelState.AddModelError("", "Something went wrong deleting course");
            }
            return NoContent();
        }
    }
}

