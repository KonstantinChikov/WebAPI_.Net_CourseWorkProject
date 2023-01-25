using AutoMapper;
using CWProject.Data.Exceptions;
using CWProject.Models.DtoModels.VillaAmenitiesDto;
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
    public class VillaAmenitiesController : ControllerBase
    {
        private readonly IVillaAmenitiesService _villaAmenitiesService;
        private readonly IMapper _mapper;
        public VillaAmenitiesController(IVillaAmenitiesService villaAmenitiesService, IMapper mapper)
        {
            _villaAmenitiesService = villaAmenitiesService;
            _mapper = mapper;
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var hotelfacilities = _villaAmenitiesService.GetAll();
            var model = _mapper.Map<IList<VillaAmenitiesModel>>(hotelfacilities);
            return Ok(model);
        }


        [Authorize]
        [HttpPost]
        public IActionResult CreateAmenity([FromBody] VillaAmenitiesCreateModel model)
        {
            int currentUserId = int.Parse(User.Identity.Name);
            Villas villa = _villaAmenitiesService.FindVilla(model.VillaId);

            if (currentUserId != villa.User.Id && !User.IsInRole("Admin"))
                return Forbid();

            // map model to entity
            var villaamenities = _mapper.Map<VillaAmenities>(model);

            try
            {
                // create user
                _villaAmenitiesService.Create(villaamenities);
                return Ok($"You have created successfully mapped them. \n {villaamenities.VillasId} -  {villaamenities.AmenitiesId} ");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("{id}/{hotelId}")]
        public IActionResult Delete(int id, int hotelId)
        {
            int currentUserId = int.Parse(User.Identity.Name);
            Villas hotelfacility = _villaAmenitiesService.FindVilla(hotelId);

            if (currentUserId != hotelfacility.User.Id && !User.IsInRole("Admin"))
                return Forbid();

            _villaAmenitiesService.Delete(id, hotelId);
            return Ok();
        }
    }
}
