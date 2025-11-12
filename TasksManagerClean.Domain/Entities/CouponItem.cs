using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoManager.Domain.Entities
{

    public class CouponItem
    {
        
        public Guid Id;
        public string Code;
        public string Kind;
        public decimal Amount;
        public bool IsActive;
        public DateTime CreatedAt;
        public DateTime? ExpiresAt;


        public CouponItem(Guid id, string code, string kind, decimal amount, DateTime? expiresAt, bool isActive)
        {
            Id = id;
            Code = code;
            Kind = kind;
            Amount = amount;
            ExpiresAt = expiresAt;
            CreatedAt = DateTime.Now;
            IsActive = isActive;
        }
    }
}
