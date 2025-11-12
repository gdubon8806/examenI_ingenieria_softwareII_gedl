using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PromoManager.Application.DTOs.Coupons
{
    // SRP: representa un contrato de datos para la capa de Aplicación.
    // Su responsabilidad es transferir información del dominio a la capa de presentación.
    public record CouponDto(
        Guid Id,
        string Code,
        string Kind,       
        decimal Amount,
        bool IsActive,
        DateTime CreatedAt,
        DateTime? ExpiresAt
    );
}

