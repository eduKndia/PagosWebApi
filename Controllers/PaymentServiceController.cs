using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PagosWebApi.Services;


namespace PagosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentServiceController : ControllerBase
    {
        IPaymentServiceService _service;

        public PaymentServiceController(IPaymentServiceService service ){
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAll();
            return Ok(new {data=data, message=""});
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.Get(id);
            if (data != null){
                return Ok(new {data=data, message=""});
            } 
            else{
                return Ok(new {data="", message="No hay datos para mostrar"});
            }
            
        }

        [HttpGet("/api/[controller]/entity")]
        public async Task<IActionResult> GetByPaymentEntity(int id)
        {
            
            var data = await _service.GetByPaymentEntity(id);

            if (data.Count > 0){
                return Ok(new {data=data, message=""});
            } 
            else{
                return Ok(new {data=data, message="No hay datos para mostrar"});
            }
        }

         [HttpGet("/api/[controller]/entityName")]
        public async Task<IActionResult> GetByPaymentEntityName(string name)
        {
            
            var data = await _service.GetByPaymentEntityName(name);

            if (data.Count > 0){
                return Ok(new {data=data, message=""});
            } 
            else{
                return Ok(new {data=data, message="No hay datos para mostrar"});
            }
        }


    }
}