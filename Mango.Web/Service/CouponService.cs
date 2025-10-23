using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using static Mango.Web.Utility.SD;
namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _BaseService;

        public CouponService(IBaseService baseService)
    {
        _BaseService = baseService;
    }

        public async Task<ResponseDTO?> CreateCouponAsync(CouponDTO couponDTO)
        {
            return await _BaseService.SendAsync(new RequestDTO()
            {
                ApiType= ApiType.POST,
                Data=couponDTO,
                Url= $"{SD.CouponApiBase} + /api/Coupon"
            });
        }

        public async Task<ResponseDTO?> DeleteCouponAsync(Guid Id)
        {
            return await _BaseService.SendAsync(new RequestDTO()
            {
                ApiType= ApiType.DELETE,
                Url= $"{SD.CouponApiBase} + /api/Coupon/{Id}"
            });
        }

        public async Task<ResponseDTO?> GetAllCouponsAsync()
        {
            return await _BaseService.SendAsync(new RequestDTO()
            {
                ApiType= Utility.SD.ApiType.GET,
                Url= $"{SD.CouponApiBase} + /api/Coupon"
            });
        }

        public async Task<ResponseDTO?> GetCouponByCodeAsync(string code)
        {
            return await _BaseService.SendAsync(new RequestDTO()
            {
                ApiType= Utility.SD.ApiType.GET,
                Url= $"{SD.CouponApiBase} + /api/Coupon/{code}"
            });
        }

        public async Task<ResponseDTO?> GetCouponByIdAsync(Guid Id)
        {
            return await _BaseService.SendAsync(new RequestDTO()
            {
                ApiType= ApiType.GET,
                Url= $"{SD.CouponApiBase} + /api/Coupon/{Id}"
            });
        }

        public async Task<ResponseDTO?> UpdateCouponAsync(CouponDTO couponDTO)
        {
            return await _BaseService.SendAsync(new RequestDTO()
            {
                ApiType= ApiType.PUT,
                Data=couponDTO,
                Url= $"{SD.CouponApiBase} + /api/Coupon"
            });
        }
    }
}
