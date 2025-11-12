using Microsoft.AspNetCore.Mvc;
using PromoManager.Application.Services;
using PromoManager.Application.DTOs.Coupons;
using PromoManager.Application.Requests;

namespace PromoManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public sealed class CouponsController : ControllerBase
    {
        private readonly CouponService _couponService;

        public CouponsController(CouponService couponService)
        {
            _couponService = couponService;
        }

        // GET: api/coupons
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var list = await _couponService.GetAllAsync();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        // POST: api/coupons
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCouponRequest request)
        {
            try
            {
                var dto = await _couponService.CreateAsync(request);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/coupons/{code}/deactivate
        [HttpPost("{code}/deactivate")]
        public async Task<IActionResult> Deactivate(Guid Id)
        {
            try
            {
                var result = await _couponService.DeactivateAsync(Id);
                if (!result) return NotFound(new { message = "Cupón no encontrado o ya estaba inactivo" });
                return Ok(new { message = "Cupón desactivado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/coupons/{code}
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                var result = await _couponService.DeleteAsync( Id);
                if (!result) return NotFound(new { message = "Cupón no encontrado" });
                return Ok(new { message = "Cupón eliminado" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // GET: api/coupons/{code}/validate
        [HttpGet("{code}/validate")]
        public async Task<IActionResult> Validate(Guid Id)
        {
            try
            {
                var (isValid, reason) = await _couponService.ValidateAsync(Id);
                return Ok(new { valid = isValid, reason });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
