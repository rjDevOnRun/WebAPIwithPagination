using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebAPIService.Models;
using WebAPIService.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // GET: api/<OrderController>
        [HttpGet]
        public async Task<PagedList<Order>> GetOrders([FromQuery] PagingParameter pagingParameter)
        {
            return await OrdersRepository.GetOrders(pagingParameter);
        }

        //// GET: api/<OrderController>
        //[HttpGet]
        //public List<Order> Get()
        //{
        //    return OrdersRepository.GetOrders();
        //}

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
