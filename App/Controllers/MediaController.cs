using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using App.ApiModels;
using App.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        private string CurrentUserId
        {
            get
            {
                return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var mediaModels = _mediaService
                .GetAllForUser(CurrentUserId)
                .ToApiModels();

            return Ok(mediaModels);
            //return Ok(_mediaService.GetAll().ToApiModels());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var media = _mediaService.Get(id);

            if (media == null)
                return NotFound();

            if (media.UserId != CurrentUserId)
            {
                ModelState.AddModelError("UserId", "You can only retrieve your own activities");
                return BadRequest(ModelState);
            }

            return Ok(media.ToApiModel());
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] MediaModel mediaModel)
        {
            try
            {
                return Ok(_mediaService.Add(mediaModel.ToDomainModel()));
                //return NotFound();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Post", e.Message);
                return BadRequest(ModelState);
            }
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MediaModel mediaModel)
        {
            var current = _mediaService.Get(id);

            if (current == null)
                return NotFound();

            current = _mediaService.Update(mediaModel.ToDomainModel());
            //return NotFound();

            return Ok(current);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var current = _mediaService.Get(id);

            if (current == null)
                return NotFound();

            _mediaService.Remove(current);

            return NoContent();
        }
    }
}
