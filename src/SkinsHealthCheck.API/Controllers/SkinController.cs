using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkinsApiHealthChecks.Api.Context;
using SkinsApiHealthChecksApi.Models;

namespace SkinsApiHealthChecksApi.Controllers
{
    public class SkinController : ControllerBase
    {
        private readonly SkinContext _context;

        public SkinController(SkinContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize]
        [Route("/api/skin/create")]
        public async Task<IActionResult> CreateAsync([FromBody] Skin skin)
        {
            try
            {
                _context.Skins.Add(skin);
                await _context.SaveChangesAsync();

                return StatusCode(201, skin);
            }
            catch (Exception)
            {
                return StatusCode(500, "An internal server error has been occurred");
            }
        }

        [HttpGet]
        [Route("/api/skin/get-all")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                return Ok(await _context.Skins.ToListAsync());
            }
            catch (Exception)
            {
                return StatusCode(500, "An internal server error has been occurred");
            }
        }
    }
}
