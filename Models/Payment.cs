using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagosWebApi.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public DateOnly DueDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public Double DebtAmount { get; set; }
        public Double PaymentAmount { get; set; }
        public Double Saldo { get; set; }
        public int AccountId { get; set; }
        public int PaymentServiceId { get; set; }
        public Account Account { get; set; }
        public PaymentService PaymentService { get; set; } 

    }
}