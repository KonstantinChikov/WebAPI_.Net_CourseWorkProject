﻿using AutoMapper;
using CWProject.Data.Exceptions;
using CWProject.Models.DtoModels.VillasDto;
using CWProject.Models.Models;
using CWProject.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APICourseWorkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillasController : ControllerBase
    {
        private readonly IVillasService _villasService;
        private readonly IMapper _mapper;
        public VillasController(IVillasService villasService, IMapper mapper)
        {
            _villasService = villasService;
            _mapper = mapper;
        }

        
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            var villas = _villasService.GetAll();
            var model = _mapper.Map<IList<VillasModel>>(villas);
            return Ok(model);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var villas = _villasService.GetById(id);
            var model = _mapper.Map<VillasModel>(villas);
            return Ok(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateVilla([FromBody] VillasCreateModel model)
        {
            // map model to entity
            var villa = _mapper.Map<Villas>(model);
            var currentUserId = int.Parse(User.Identity.Name);

            try
            {
                // create user
                _villasService.Create(villa, currentUserId);
                return Ok($"You have created successfully a villa. \n Name: {villa.Name} ");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] VillasUpdateModel model)
        {
            var villaChecker = _villasService.FindVilla(id);
            var currentUserId = int.Parse(User.Identity.Name);
            if (currentUserId != villaChecker.User.Id && !User.IsInRole("Admin"))
                return Forbid();

            var villa = _mapper.Map<Villas>(model);
            villa.Id = id;
            try
            {
                // update amenity 
                _villasService.Update(villa);
                return Ok("Successfully updated");
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var villa = _villasService.FindVilla(id);
            /*
            var currentUserId = int.Parse(User.Identity.Name);
            if (currentUserId != villa.User.Id && !User.IsInRole("Admin"))
                return Forbid();
            */
            _villasService.Delete(id);
            return Ok();
        }
    }
}
