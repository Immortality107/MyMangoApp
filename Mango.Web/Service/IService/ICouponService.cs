using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {
        Task <ResponseDTO?> CreateCouponAsync (CouponDTO couponDTO);
        Task<ResponseDTO?> UpdateCouponAsync (CouponDTO couponDTO);
        Task <ResponseDTO?> DeleteCouponAsync (Guid id);
        Task <ResponseDTO?> GetAllCouponsAsync ();
        Task <ResponseDTO?> GetCouponByIdAsync(Guid Id);
        Task <ResponseDTO?> GetCouponByCodeAsync(string code);
    }
}
