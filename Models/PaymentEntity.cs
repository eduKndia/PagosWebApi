using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PagosWebApi.Models
{
    public class PaymentEntity
    {
        public int PaymentEntityId { get; set; }

        public string Name { get; set; }
    
        [JsonIgnore]
        public ICollection<PaymentService> Services { get; set; } = new List<PaymentService>();

        
    }
}