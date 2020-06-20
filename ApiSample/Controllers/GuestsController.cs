using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSample.DAL;
using ApiSample.DTOs.Guests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSample.Controllers
{
    [Route("api/guests")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly IServiceExample _service;
        public GuestsController(IServiceExample service)
        {
            _service = service;
        }
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(_service.Test());
        }
        [HttpGet]
        public IActionResult GetGuests(string lastName)
        {
            return Ok(_service.GetGuestsCollection(lastName));
        }
        //... api/guests/2
        [HttpGet("{id:int}")]
        public IActionResult GetGuest(int id)
        {
            return Ok(_service.GetGuestById(id));
        }
        [HttpPost]
        public IActionResult AddGuest(GuestRequestDto requestDto)
        {
            if (_service.AddGuest(requestDto))
                return Ok("new guest created");
            else
                return BadRequest("cos poszlo nie tak");
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateGuest(int id, GuestRequestDto requestDto)
        {
            if (_service.UpdateGuest(id, requestDto))
                return Ok($"guest with id {id} has been updated");
            else
                return BadRequest("nie znaleziono goscia");
        }
        //....api
        [HttpDelete("{id:int}")]
        public IActionResult DeleteGuest(int id)
        {
            if (_service.DeleteGuest(id))
                return Ok($"guest with id {id} has been deleted");
            else
                return BadRequest("nie znaleziono goscia");
        }
    }
}
