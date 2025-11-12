using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PromoManager.Application.Requests
{
    public class CreateCouponRequest
    {
        public string Kind { get; set; } 
        public decimal Amount { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string Code { get; set; } 
    }
}