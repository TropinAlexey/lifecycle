using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using BWMS.CustomerManagementAPI.DataAccess;
using BWMS.CustomerManagementAPI.Model;
using BWMS.Infrastructure.Messaging;
using BWMS.CustomerManagementAPI.Events;
using BWMS.CustomerManagementAPI.Commands;
using BWMS.CustomerManagementAPI.Mappers;
using Serilog;
using System;

namespace BWMS.Application.CustomerManagementAPI.Controllers
{
    [Route("/api/[controller]")]
    public class CustomersController : Controller
    {
        IMessagePublisher _messagePublisher;
        CustomerManagementDBContext _dbContext;

        public CustomersController(CustomerManagementDBContext dbContext, IMessagePublisher messagePublisher)
        {
            _dbContext = dbContext;
            _messagePublisher = messagePublisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _dbContext.Customers.ToListAsync());
        }

        [HttpGet]
        [Route("{customerId}", Name = "GetByCustomerId")]
        public async Task<IActionResult> GetByCustomerId(string customerId)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterCustomer command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // insert customer
                    Customer customer = command.MapToCustomer();
                    _dbContext.Customers.Add(customer);
                    await _dbContext.SaveChangesAsync();

                    // send event
                    CustomerRegistered e = command.MapToCustomerRegistered();
                    await _messagePublisher.PublishMessageAsync(e.MessageType, e , "");

                    // return result
                    return CreatedAtRoute("GetByCustomerId", new { customerId = customer.CustomerId }, customer);
                }
                return BadRequest();
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
                return StatusCode(StatusCodes.Status500InternalServerError);
                throw;
            }
        }
    }
}
