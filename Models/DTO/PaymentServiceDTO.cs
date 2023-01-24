using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagosWebApi.Models
{
    public class PaymentServiceDTO
    {
        public int PaymentServiceId { get; set; }

        public string Name { get; set; }

        public string PaymentEntity { get; set; }
    }
}