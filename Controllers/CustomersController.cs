using System;
using System.Threading.Tasks;
using API_ALB.Models;
using API_ALB.UOF;
using Microsoft.AspNetCore.Mvc;

namespace API_ALB.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public CustomersController(IUnitOfWork uof)
        {
            _uof = uof;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _uof.CustomerRepository.GetAllCustomer());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }

        [HttpGet("{customerId}", Name = "GetCustomerById")]
        public async Task<IActionResult> Get(int customerId)
        {
            var customer = await _uof.CustomerRepository.GetCustomerById(customerId);

            if (customer == null)
            {
                return NotFound($"Customer with customerId ={customerId} not found.");
            }

            return Ok(customer);
        }

        [HttpGet("GetCustomerOlderAge")]
        public async Task<IActionResult> GetCustomerOlderAge()
        {
            try
            {
                return Ok(await _uof.CustomerRepository.GetCustomerOlderAge());
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            try
            {
                _uof.CustomerRepository.CreateCustomer(customer);
                await _uof.Save();
                return new CreatedAtRouteResult("GetCustomerById", new { customerId = customer.CustomerId }, customer);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> Put(int customerId, [FromBody] Customer customer)
        {
            if (customerId != customer.CustomerId)
            {
                return BadRequest();
            }

            try
            {
                _uof.CustomerRepository.UpdateCustomer(customer);
                await _uof.Save();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> Delete(int customerId)
        {
            var customer = await _uof.CustomerRepository.GetCustomerById(customerId);

            if (customer == null)
            {
                return NotFound($"Customer with customerId ={customerId} not found.");
            }

            try
            {
                _uof.CustomerRepository.DeleteCustomer(customer);
                await _uof.Save();
                return Ok(customer);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}