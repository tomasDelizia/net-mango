using CouponApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CouponApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Coupon> Coupons { get; set; }
}
