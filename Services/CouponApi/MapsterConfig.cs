using CouponApi.Models;
using Mapster;

public class MapsterConfig
{
    public static void RegisterMaps()
    {
        TypeAdapterConfig<Coupon, CouponDto>.NewConfig().TwoWays();
    }
}