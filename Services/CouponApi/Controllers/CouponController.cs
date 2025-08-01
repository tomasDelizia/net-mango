using CouponApi.Data;
using CouponApi.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace CouponApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController(AppDbContext db, IMapper mapper) : ControllerBase
    {
        private readonly AppDbContext _db = db;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public ResponseDto<IEnumerable<CouponDto>> Get()
        {
            ResponseDto<IEnumerable<CouponDto>> response = new();
            try
            {
                var coupons = _db.Coupons;
                response.Result = _mapper.Map<IEnumerable<CouponDto>>(coupons);
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.IsSuccess = false;
            }
            return response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto<CouponDto> Get(int id)
        {
            ResponseDto<CouponDto> response = new();
            try
            {
                var coupon = _db.Coupons.First(u => u.CouponId == id);
                response.Result = _mapper.Map<CouponDto>(coupon);
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
