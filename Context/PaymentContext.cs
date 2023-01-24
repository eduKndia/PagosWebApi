using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PagosWebApi.Models;

namespace PagosWebApi.Context
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options ) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            #region PaymentEntity
                
                List<PaymentEntity> entitiesInit = new List<PaymentEntity>();
                entitiesInit.Add(new PaymentEntity() {PaymentEntityId = 1 ,Name = "Ande"});
                entitiesInit.Add(new PaymentEntity() {PaymentEntityId = 2 ,Name = "Tigo"});
                entitiesInit.Add(new PaymentEntity() {PaymentEntityId = 3 ,Name = "Banco Continental"});

                builder.Entity<PaymentEntity>( entity => {
                    entity.ToTable("PaymentEntities");
                    entity.HasKey(p=> p.PaymentEntityId);
                    entity.Property(p=> p.Name).IsRequired().HasMaxLength(100);
                    entity.HasData(entitiesInit);
                });
               
            #endregion 
            
            #region PaymentService

                List<PaymentService> servicesInit =  new List<PaymentService>();
                servicesInit.Add(new PaymentService(){PaymentServiceId = 1, PaymentEntityId = 1, Name = "Pago de factura"});
                servicesInit.Add(new PaymentService(){PaymentServiceId = 2, PaymentEntityId = 2, Name = "Pago de factura Telefonia"});
                servicesInit.Add(new PaymentService(){PaymentServiceId = 3, PaymentEntityId = 2, Name = "Pago de factura Internet"});
                servicesInit.Add(new PaymentService(){PaymentServiceId = 4, PaymentEntityId = 2, Name = "Pago de factura TV"});
                servicesInit.Add(new PaymentService(){PaymentServiceId = 5, PaymentEntityId = 3, Name = "Pago de prestamos"});
                servicesInit.Add(new PaymentService(){PaymentServiceId = 6, PaymentEntityId = 3, Name = "Pago de tarjeta de credito"});
                

                builder.Entity<PaymentService>(service => {
                    service.ToTable("PaymentServices");
                    service.HasKey(p=> p.PaymentServiceId);
                    service.Property(p=> p.Name).IsRequired().HasMaxLength(100);
                    service.HasOne(p=> p.PaymentEntity).WithMany(p=> p.Services).HasForeignKey(p=> p.PaymentEntityId);
                    service.HasData(servicesInit);
                });

            #endregion     

            
            #region Client

                List<Client> clientsInit =  new List<Client>();
                clientsInit.Add(new Client(){ClientId = 1, Name = "Pedro Martinez", DocNumber="2344221" ,Email="pmartinez@gmail.com"});
                clientsInit.Add(new Client(){ClientId = 2, Name = "Maria Ortega", DocNumber="2331231" ,Email="maor@gmail.com"});
               
                builder.Entity<Client>(client => {
                    client.ToTable("Clients");
                    client.HasKey(p=> p.ClientId);
                    client.Property(p=> p.Name).IsRequired().HasMaxLength(500);
                    client.HasData(clientsInit);
                });

            #endregion  

            #region Account
                List<Account> accountInit =  new List<Account>();
                accountInit.Add(new Account(){AccountId = 1, Name = "Pedro Martinez", Number="1233321",ClientId = 1,Saldo = 2300000});
                accountInit.Add(new Account(){AccountId = 2, Name = "Maira Ortega", Number="4523251",ClientId = 2,Saldo = 250000});       

                builder.Entity<Account>(Account => {
                    Account.ToTable("Accounts");
                    Account.HasKey(p=> p.AccountId);
                    Account.Property(p=> p.Name).IsRequired().HasMaxLength(100);
                    Account.HasOne(p=> p.Client).WithMany(p=> p.Accounts).HasForeignKey(p=> p.ClientId);
                    Account.HasData(accountInit);
                });
            #endregion

            #region Debt
                List<Debt> debtInit =  new List<Debt>();
                debtInit.Add(new Debt(){DebtId = 1, ClientId = 1, ServiceId = 1, DocReference="111232" , Amount = 120000, Saldo = 120000});
                debtInit.Add(new Debt(){DebtId = 2, ClientId = 1, ServiceId = 2, DocReference="1233321" , Amount = 90000, Saldo = 90000});
                debtInit.Add(new Debt(){DebtId = 3, ClientId = 1, ServiceId = 3, DocReference="4523251" , Amount = 290000, Saldo = 290000});

                builder.Entity<Debt>(debt => {
                    debt.ToTable("Debts");
                    debt.HasKey(p=> p.DebtId);
                    debt.Property(p=> p.DocReference).IsRequired().HasMaxLength(50);
                    debt.HasOne(p=> p.Client).WithMany(p=> p.Debts).HasForeignKey(p=> p.ClientId);
                    debt.HasOne(p=> p.Service).WithMany(p=> p.Debts).HasForeignKey(p=> p.ServiceId);
                    debt.HasData(debtInit);
                });
            #endregion

            #region Payments
                
                builder.Entity<Payment>(payment => {
                    payment.ToTable("Payments");
                    payment.HasKey(p=> p.PaymentId);
                    payment.Property(p=> p.DueDate).IsRequired();
                    payment.HasOne(p=> p.Account).WithMany(p=> p.Payments).HasForeignKey(p=> p.AccountId);
                    payment.HasOne(p=> p.PaymentService).WithMany(p=> p.Payments).HasForeignKey(p=> p.PaymentServiceId);
                });
            #endregion
           
        }

        //Entities
        public DbSet<PaymentEntity> PaymentEntities {set; get;}
        public DbSet<PaymentService> PaymentServices {set; get;}
        public DbSet<Client> Clients {set; get;}
        public DbSet<Account> Accounts {set; get;}
        public DbSet<Debt> Debts {set; get;}
        public DbSet<Payment> Payments {set; get;}
    
    }
}