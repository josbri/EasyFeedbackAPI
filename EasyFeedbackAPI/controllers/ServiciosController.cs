using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyFeedbackAPI.Extensions;
using EasyFeedbackAPI.models;
using EasyFeedbackAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyFeedbackAPI.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {

        private readonly IServicioService _servicioService;
        private readonly IMapper _mapper;

        public ServiciosController(IServicioService servicioService, IMapper mapper)
        {
            _servicioService = servicioService;
            _mapper = mapper;
        }


        // GET: api/Servicios/Restaurant/5
        [HttpGet("Restaurant/{id}")]
        public async Task<ActionResult<List<ServicioGetDTO>>> GetByRestaurantId(int id)
        {
            var servicios = await _servicioService.FindByRestaurantIdAsync(id);

            if (servicios == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ServicioGetDTO>>(servicios));
        }



        // POST: api/Servicios
        [HttpPost]
        public async Task<ActionResult<ServicioGetDTO>> PostServicio(ServicioDTO servicioDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var servicioEntity = _mapper.Map<Servicio>(servicioDTO);

            var result = await _servicioService.CreateAsync(servicioEntity);

            if (!result.Success)
            {
                return BadRequest(result.Message);

            }

            return Ok(_mapper.Map<ServicioGetDTO>(result.Servicio));
        }

        // DELETE: api/Servicios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Servicio>> DeleteServicio(int id)
        {

            var result = await _servicioService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);

            }

            return Ok(_mapper.Map<ServicioGetDTO>(result.Servicio));
        }

    }
}
