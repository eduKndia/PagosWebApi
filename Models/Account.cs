using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagosWebApi.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public double Saldo { get; set; }
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        
    }
}