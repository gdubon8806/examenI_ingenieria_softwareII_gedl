using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoManager.Domain.Entities;

namespace PromoManager.Domain.Interfaces
{
    //implementacion de ISP (principio de segregacion de interfaces)
    //uno de los pasos para la implementacion de DIP (princ. de inversion de dependencias) 
    public interface ICouponReader
    {
        Task<IEnumerable<CouponItem>> GetAllAsync();
        Task<CouponItem> GetByIdAsync(Guid Id);
    }
}