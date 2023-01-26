using AutoMapper;
using CWProject.Data.Exceptions;
using CWProject.Models.DtoModels.AmenitiesDto;
using CWProject.Models.Models;
using CWProject.Services;
using CWProject.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICourseWorkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenitiesService _amenitiesService;
        private readonly IMapper _mapper;
        public AmenitiesController(IAmenitiesService amenitiesService, IMapper mapper)
        {
            _amenitiesService = amenitiesService;
            _mapper = mapper;
        }

        
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var amenity = _amenitiesService.GetAll();
            var model = amenity.Select(_mapper.Map<AmenitiesModel>);
            return Ok(amenity);
        }
        
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var amenity = _amenitiesService.GetById(id);
            var model = _mapper.Map<AmenitiesModel>(amenity);
            return Ok(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateFacility([FromBody] AmenitiesCreateModel model)
        {
            // map model to entity
            var amenity = _mapper.Map<Amenities>(model);

            try
            {
                // create user
                _amenitiesService.Create(amenity);
                return Ok($"You have created successfully a facility. \n Name: {amenity.Name}");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] AmenitiesUpdateModel model)
        {
            var amenity = _mapper.Map<Amenities>(model);
            amenity.Id = id;

            try
            {
                // update facility 
                _amenitiesService.Update(amenity);
                return Ok("Successfully updated");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _amenitiesService.Delete(id);
            return Ok();
        }
        
    }
}
