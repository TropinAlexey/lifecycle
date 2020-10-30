using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BWMS.WorkshopManagementAPI.Repositories;

namespace BWMS.WorkshopManagementAPI.Controllers
{
    [Route("/api/[controller]")]
    public class RefDataController : Controller
    {
        ICustomerRepository _customerRepo;
        IVehicleRepository _vehicleRepo;

        public RefDataController(ICustomerRepository customerRepo, IVehicleRepository vehicleRepo)
        {
            _customerRepo = customerRepo;
            _vehicleRepo = vehicleRepo;
        }

        [HttpGet]
        [Route("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await _customerRepo.GetCustomersAsync());
        }

        [HttpGet]
        [Route("customers/{customerId}")]
        public async Task<IActionResult> GetCustomerByCustomerId(string customerId)
        {
            var customer = await _customerRepo.GetCustomerAsync(customerId);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpGet]
        [Route("vehicles")]
        public async Task<IActionResult> GetVehicles()
        {
            return Ok(await _vehicleRepo.GetVehiclesAsync());
        }

        [HttpGet]
        [Route("vehicles/{Name}")]
        public async Task<IActionResult> GetVehicleByName(string Name)
        {
            var vehicle = await _vehicleRepo.GetVehicleAsync(Name);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }
    }
}
