using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PagosWebApi.Context;
using PagosWebApi.Models;

namespace PagosWebApi.Services
{
    public class PaymentServiceService : IPaymentServiceService
    {
        PaymentContext context;

        public PaymentServiceService(PaymentContext dbcontext){
            context =  dbcontext;
        }
        
        public async Task<IEnumerable<PaymentServiceDTO>> GetAll() => await (from service in context.Set<PaymentService>()
                                                                             join entity in context.Set<PaymentEntity>()
                                                                                 on service.PaymentEntityId equals entity.PaymentEntityId
                                                                             select new PaymentServiceDTO
                                                                             {
                                                                                 PaymentServiceId = service.PaymentServiceId,
                                                                                 Name = service.Name,
                                                                                 PaymentEntity = entity.Name
                                                                             }).ToListAsync(); 
        
       
        public async Task<PaymentServiceDTO> Get(int id) => await (from service in context.Set<PaymentService>()
                                                                   join entity in context.Set<PaymentEntity>()
                                                                       on service.PaymentEntityId equals entity.PaymentEntityId
                                                                   where service.PaymentServiceId == id
                                                                   select new PaymentServiceDTO
                                                                   {
                                                                       PaymentServiceId = service.PaymentServiceId,
                                                                       Name = service.Name,
                                                                       PaymentEntity = entity.Name
                                                                   }).FirstOrDefaultAsync();

       

        public async Task<ICollection<PaymentServiceDTO>> GetByPaymentEntity(int PaymentEntityId) => await (from service in context.Set<PaymentService>()
                                                                                                            join entity in context.Set<PaymentEntity>()
                                                                                                                on service.PaymentEntityId equals entity.PaymentEntityId
                                                                                                            where service.PaymentEntityId == PaymentEntityId
                                                                                                            select new PaymentServiceDTO
                                                                                                            {
                                                                                                                PaymentServiceId = service.PaymentServiceId,
                                                                                                                Name = service.Name,
                                                                                                                PaymentEntity = entity.Name
                                                                                                            }).ToListAsync();

        public async Task<ICollection<PaymentServiceDTO>> GetByPaymentEntityName(string name) => await (from service in context.Set<PaymentService>()
                                                                                                            join entity in context.Set<PaymentEntity>()
                                                                                                                on service.PaymentEntityId equals entity.PaymentEntityId
                                                                                                            where entity.Name.ToUpper().Contains(name.ToUpper()) 
                                                                                                            select new PaymentServiceDTO
                                                                                                            {
                                                                                                                PaymentServiceId = service.PaymentServiceId,
                                                                                                                Name = service.Name,
                                                                                                                PaymentEntity = entity.Name
                                                                                                            }).ToListAsync();

    }

    public interface IPaymentServiceService
    {
        Task<IEnumerable<PaymentServiceDTO>> GetAll();
        Task<PaymentServiceDTO> Get(int id);
        Task<ICollection<PaymentServiceDTO>> GetByPaymentEntity(int PaymentEntityId);
        Task<ICollection<PaymentServiceDTO>> GetByPaymentEntityName(string name);

    }
}