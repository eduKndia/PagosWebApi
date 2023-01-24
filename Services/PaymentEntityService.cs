using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PagosWebApi.Context;
using PagosWebApi.Models;

namespace PagosWebApi.Services
{
    public class PaymentEntityService : IPaymentEntityService
    {
        PaymentContext context;

        public PaymentEntityService(PaymentContext dbcontext){
            context =  dbcontext;
        }

        public async Task<IEnumerable<PaymentEntityDTO>> GetAll(){
            var dataList = await context.PaymentEntities.ToListAsync();
            return (from data in dataList
                    select new PaymentEntityDTO { PaymentEntityId = data.PaymentEntityId, Name = data.Name }).ToList();
        }

        public async Task<PaymentEntityDTO> Get(int id){
            var data = await context.PaymentEntities.Where(b => b.PaymentEntityId == id).FirstOrDefaultAsync(); 
            return (data != null)? new PaymentEntityDTO() {PaymentEntityId= data.PaymentEntityId, Name = data.Name} : new PaymentEntityDTO();
        }

        public async Task<IEnumerable<PaymentEntityDTO>>  GetByName(string name){
            var dataList = await context.PaymentEntities.Where(b => b.Name.ToUpper().Contains(name.ToUpper())).ToListAsync();            
            return (from data in dataList
                    select new PaymentEntityDTO { PaymentEntityId = data.PaymentEntityId, Name = data.Name }).ToList();
        }
        
    }

    public interface IPaymentEntityService
    {
        Task<IEnumerable<PaymentEntityDTO>> GetAll();
        Task<PaymentEntityDTO> Get(int id);
        Task<IEnumerable<PaymentEntityDTO>>  GetByName(string name);
    }
}