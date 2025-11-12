using PromoManager.Application.DTOs.Coupons;
using PromoManager.Application.Mappers;
using PromoManager.Application.Requests;
using PromoManager.Domain.Entities;
using PromoManager.Domain.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Intrinsics.Arm;

namespace PromoManager.Application.Services
{
    public class CouponService
    {
        //DIP: el AppService depende de interfaces (abstracciones) de dominio y no de implementaciones de infraestructura    
        //nomenclatura de nombramiento pascal: couponReader, couponWriter, etc.
        private readonly ICouponReader _couponReader;
        private readonly ICouponWriter _couponWriter;

        public CouponService(ICouponReader reader, ICouponWriter writer)
        {
            _couponReader = reader;
            _couponWriter = writer;
        }

//        1. Crear cupón
//POST /api/coupons
//Request: { kind: "PERCENT"|"FIXED", amount: number, expiresAt?: ISO8601
//    }
//    Respuesta: { id, code, kind, amount, isActive, createdAt, expiresAt
//}
//Reglas: validaciones por tipo & isActive = true
        public async Task<CouponDto> CreateAsync(CreateCouponRequest request)
        {
            var entity = new CouponItem(Guid.NewGuid(), request.Code, request.Kind, request.Amount, request.ExpiresAt, isActive: true);
            await _couponWriter.Add(entity);
            return CouponMapper.ToDto(entity);
        }
           
//        2. Listar cupones
//GET /api/coupons
        public async Task<IReadOnlyList<CouponDto>> GetAllAsync()
        {
            var list = await _couponReader.GetAllAsync();
            return list.Select(CouponMapper.ToDto).ToList();
        }

        // 4. Desactivar cupón
        public async Task<bool> DeactivateAsync(Guid Id)
        {
            var coupon = await _couponReader.GetByIdAsync(Id);
            if (coupon == null) return false;

            if (!coupon.IsActive)
                return false; // Ya estaba inactivo

            await _couponWriter.Update(coupon);
            return true;
        }

        // 5. Eliminar cupón
        public async Task<bool> DeleteAsync(Guid Id)
        {
            var coupon = await _couponReader.GetByIdAsync(Id);
            if (coupon == null) return false;

            await _couponWriter.Delete(Id);
            return true;
        }

        // 6. Validar cupón
        public async Task<(bool isValid, string reason)> ValidateAsync(Guid Id)
        {
            var coupon = await _couponReader.GetByIdAsync(Id);
            if (coupon == null) return (false, "Cupón no encontrado");

            if (!coupon.IsActive) return (false, "Cupón inactivo");
            if (coupon.ExpiresAt != null && coupon.ExpiresAt < DateTime.Now) return (false, "Cupón expirado");

            return (true, null);
        }
    }

}
