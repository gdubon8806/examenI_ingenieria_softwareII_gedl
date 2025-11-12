using PromoManager.Application.DTOs.Coupons;
using PromoManager.Domain.Entities;

namespace PromoManager.Application.Mappers
{
    // Clean Code: separamos el mapeo para mantener los AppServices limpios 
    // de la lógica de transformación de datos entre entidades y DTOs.
    public static class CouponMapper
    {
        public static CouponDto ToDto(CouponItem i) => new(
            i.Id,
            i.Code,
            i.Kind.ToString(),
            i.Amount,
            i.IsActive,
            i.CreatedAt,
            i.ExpiresAt
        );
    }
}
