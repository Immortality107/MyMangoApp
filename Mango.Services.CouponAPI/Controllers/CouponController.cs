using AutoMapper;
using Mango.Services.CouponAPI.Controllers.Base;
using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.DTO;
using Mango.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    public class CouponController : AppBaseController
    {
        private readonly AppDbContext _db;
        private ResponseDTO _ResponseDto;
        private IMapper _Mapper;
        public CouponController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _ResponseDto = new ResponseDTO();
            _Mapper = mapper;
        }

        [HttpGet]
        public object GetCoupons()
        {
            try
            {
                IEnumerable<Coupon> coupons = _db.Coupons.ToList();
                _ResponseDto.Result= _Mapper.Map<IEnumerable<CouponDTO>>(coupons);
            }
            catch (Exception ex)
            {
                _ResponseDto.IsSucceed=false;
                _ResponseDto.Message=ex.Message;
            }
            return _ResponseDto;
        }

        [HttpGet("{Id:int}")]
        public object GetCouponByID(int Id)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(Coupon => Coupon.CouponId== Id);
                _ResponseDto.Result= _Mapper.Map<CouponDTO>(coupon);
                return _ResponseDto;
            }
            catch (Exception ex)
            {
                _ResponseDto.IsSucceed=false;
                _ResponseDto.Message=ex.Message;
            }
            return _ResponseDto;
        }

        [HttpGet("/code")]
        public ResponseDTO GetCouponCode(string code)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(Coupon => Coupon.CouponCode.ToLower() == code.ToLower());
                _ResponseDto.Result = _Mapper.Map<CouponDTO>(coupon);
            }
            catch (Exception ex)
            {
                _ResponseDto.IsSucceed = false;
                _ResponseDto.Message = ex.Message;
            }
            return _ResponseDto;
        }

        [HttpPost]
        public ResponseDTO Post([FromBody] CouponDTO couponDTO)
        {
            try
            {
                Coupon coupon = _Mapper.Map<Coupon>(couponDTO);
                
                _db.Coupons.Add(coupon);
                _db.SaveChanges();
                _ResponseDto.Result = _Mapper.Map<CouponDTO>(coupon);
            }
            catch (Exception ex)
            {
                _ResponseDto.IsSucceed = false;
                _ResponseDto.Message = ex.Message;
            }
            return _ResponseDto;
        }

        [HttpPut]
        public ResponseDTO Put([FromQuery]int Id,[FromBody] CouponDTO couponDTO)
        {
            try
            {
              Coupon coupon= _db.Coupons.First(c=> c.CouponId== Id);
                coupon = _Mapper.Map<CouponDTO, Coupon>(couponDTO, coupon);
                _db.Coupons.Update(coupon);
               if (coupon == null)
                {
                    throw new Exception("Coupon not found");
                }
                _db.SaveChanges();
                _ResponseDto.Result = _Mapper.Map<CouponDTO>(coupon);
            }
            catch (Exception ex)
            {
                _ResponseDto.IsSucceed = false;
                _ResponseDto.Message = ex.Message;
            }
            return _ResponseDto;
        }

        [HttpDelete]
        public ResponseDTO Delete(int Id)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(c=> c.CouponId== Id);
                _db.Coupons.Remove(coupon);
                _db.SaveChanges();
                _ResponseDto.Result = _Mapper.Map<CouponDTO>(coupon);
            }
            catch (Exception ex)
            {
                _ResponseDto.IsSucceed = false;
                _ResponseDto.Message = ex.Message;
            }
            return _ResponseDto;
        }
    }
}
