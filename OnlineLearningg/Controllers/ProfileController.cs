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
    public class ProfileController :ControllerBase
    {
        private readonly IProfile _profileRepository;
        private readonly IMapper _mapper;
        public ProfileController(IProfile profileRepository, IMapper mapper)
        {
            _profileRepository = profileRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var profile = _mapper.Map<IEnumerable<ProfileDto>>(_profileRepository.UpdateProfile);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(profile);
        }
        [HttpPut]
        [Route("users/{userId}")]
        public IActionResult Update(int id, [FromBody] ProfileDto profile)
        {
            if (profile == null) { return BadRequest(ModelState); }
            if (id != profile.ProfileId)
            {
                return BadRequest(ModelState);
            }
            if (!_profileRepository.Exist(id)) { return NotFound(); }
            var ProfileMap = _mapper.Map<User>(profile);
            if (!_profileRepository.UpdateProfile(id, ProfileMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(StatusCodes.Status500InternalServerError, ModelState);
            }
            return Ok("Successfully saved");
        }

    }
}
