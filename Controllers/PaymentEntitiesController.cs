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
    public class PaymentEntitiesController : ControllerBase
    {
        IPaymentEntityService _service;

        public PaymentEntitiesController(IPaymentEntityService service ){
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

        [HttpGet("/api/[controller]/byName")]
        public async Task<IActionResult> GetByName(string name)
        {
            var data = await _service.GetByName(name);
            if (data != null){
                return Ok(new {data=data, message=""});
            } 
            else{
                return Ok(new {data="", message="No hay datos para mostrar"});
            }
            
        }

    }
}