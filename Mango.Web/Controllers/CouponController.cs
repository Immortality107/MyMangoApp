using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _CouponService;
        public CouponController(ICouponService couponService)
        {
            _CouponService=couponService;
        }

        public async Task< IActionResult> CouponIndex( )
        {
            List<CouponDTO>? Couponslist = new();
            ResponseDTO? response = await  _CouponService.GetAllCouponsAsync();
            if (response != null && response.IsSucceed)
            {
      Couponslist = JsonConvert.DeserializeObject<List<CouponDTO>>(Convert.ToString(response.Result));
            
            }
            return View(Couponslist);
        }
    }
}
