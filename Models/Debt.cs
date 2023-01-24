using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagosWebApi.Models
{
    public class Debt
    {
        public int DebtId { get; set; }
        public int ClientId { get; set; }
        public int ServiceId { get; set; }
        public string DocReference { get; set; }
        public double Amount { get; set; }
        public double Saldo { get; set; }
        public Client Client { get; set; }
        public PaymentService Service { get; set; }

        
        
    }
}