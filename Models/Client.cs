using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PagosWebApi.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string DocNumber { get; set; }
        
        public ICollection<Account> Accounts { get; set; }
        public ICollection<Debt> Debts { get; set; }
        
    }
}