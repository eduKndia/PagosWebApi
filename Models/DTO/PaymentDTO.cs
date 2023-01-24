using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PagosWebApi.Models
{
    public class PaymentDTO
    {
        public int PaymentId { get; set; }
        public int PaymentServiceId { get; set; }
        public string AccountNumber { get; set; }
        public string numero_referencia_comprobante { get; set; }
        public Double  monto_deuda_total { get; set; }
        public Double  monto_abonado { get; set; }
    }
}