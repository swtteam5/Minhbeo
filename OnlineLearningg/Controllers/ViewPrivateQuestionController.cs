using Microsoft.Extensions.Hosting;
using OnlineLearningg.Data;
using OnlineLearningg.Dto;
using OnlineLearningg.Interface;
using OnlineLearningg.Models;
using OnlineLearning.Repository;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace OnlineLearningg.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ViewPrivateQuestionController:ControllerBase
    {
        private readonly IQuestion _questionRepository;
        private readonly IMapper _mapper;
        public ViewPrivateQuestionController(IQuestion questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var questions = _mapper.Map<IEnumerable<QuestionDto>>(_questionRepository.GetQuestionByID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(questions);
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(Question), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            if (!_questionRepository.Exist(id))
            {
                return NotFound();
            }
            var questions = _mapper.Map<Question>(_questionRepository.GetQuestionByID(id));
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            return Ok(questions);
        }
    }
}
