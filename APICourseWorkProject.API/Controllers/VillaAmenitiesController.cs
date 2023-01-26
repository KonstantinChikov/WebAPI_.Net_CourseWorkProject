using AutoMapper;
using CWProject.Data.Exceptions;
using CWProject.Models.DtoModels.VillaAmenitiesDto;
using CWProject.Models.Models;
using CWProject.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
            var villaAmenities = _villaAmenitiesService.GetAll();
            var model = _mapper.Map<IList<VillaAmenitiesModel>>(villaAmenities);
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
            var villaAmenities = _mapper.Map<VillaAmenities>(model);

            try
            {
                // create user
                _villaAmenitiesService.Create(villaAmenities);
                return Ok($"You have created successfully mapped them. \n {villaAmenities.VillasId} -  {villaAmenities.AmenitiesId} ");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("{id}/{villaId}")]
        public IActionResult Delete([FromRoute] int id, int villaId)
        {
            //int currentUserId = int.Parse(User.Identity.Name);
            var villaAmenity = _villaAmenitiesService.FindVilla(villaId);

            //if (currentUserId != villaAmenity.User.Id && !User.IsInRole("Admin"))
            //    return Forbid();

            _villaAmenitiesService.Delete(id, villaId);
            return Ok();
        }
    }
}
