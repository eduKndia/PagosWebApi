using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PagosWebApi.Models
{
    public class PaymentService
    {
        public int PaymentServiceId{ get; set; }

        public string Name { get; set; }

        public int PaymentEntityId { get; set; }
        
        public PaymentEntity PaymentEntity { get; set; }

        public ICollection<Debt> Debts { get; set; } = new List<Debt>();

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }   
}