using AutoMapper;
using Mango.Services.CouponAPI.DTO;
using Mango.Services.CouponAPI.Models;

namespace Mango.Services.CouponAPI
{
    public class MappingConfig
    {

        public static MapperConfiguration RegisterMaps()
        {
           var Configuration = new MapperConfiguration(config =>
            {
                config.CreateMap<Coupon, CouponDTO>();
                config.CreateMap<CouponDTO, Coupon>();

            });

            return Configuration;
        }
    }
}
