using PromoManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoManager.Domain.Interfaces
{
    public interface ICouponWriter
    {
        Task Add(CouponItem coupon);
        Task Delete(Guid code);
        Task Update(CouponItem coupon); 

    }
}
