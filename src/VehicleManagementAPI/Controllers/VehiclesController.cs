using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BWMS.Application.VehicleManagement.Model;
using BWMS.Application.VehicleManagement.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Pitstop.Infrastructure.Messaging;
using BWMS.Application.VehicleManagement.Events;
using BWMS.Application.VehicleManagement.Commands;
using BWMS.VehicleManagementAPI.Mappers;
using System.Text.RegularExpressions;

namespace BWMS.Application.VehicleManagement.Controllers
{

    [Route("/api/[controller]")]
    public class VehiclesController : Controller
    {
        private const string NUMBER_PATTERN = @"^((\d{1,3}|[a-z]{1,3})-){2}(\d{1,3}|[a-z]{1,3})$";
        IMessagePublisher _messagePublisher;
        VehicleManagementDBContext _dbContext;

        public VehiclesController(VehicleManagementDBContext dbContext, IMessagePublisher messagePublisher)
        {
            _dbContext = dbContext;
            _messagePublisher = messagePublisher;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _dbContext.Vehicles.ToListAsync());
        }

        [HttpGet]
        [Route("{Name}", Name = "GetByName")]
        public async Task<IActionResult> GetByName(string Name)
        {
            var vehicle = await _dbContext.Vehicles.FirstOrDefaultAsync(v => v.Name == Name);
            if (vehicle == null)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterVehicle command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // check invariants
                    if (!Regex.IsMatch(command.Name, NUMBER_PATTERN, RegexOptions.IgnoreCase))
                    {
                        return BadRequest($"The specified license-number '{command.Name}' was not in the correct format.");
                    }

                    // insert vehicle
                    Vehicle vehicle = command.MapToVehicle();
                    _dbContext.Vehicles.Add(vehicle);
                    await _dbContext.SaveChangesAsync();

                    // send event
                    var e = VehicleRegistered.FromCommand(command);
                    await _messagePublisher.PublishMessageAsync(e.MessageType, e, "");

                    //return result
                    return CreatedAtRoute("GetByName", new { Name = vehicle.Name }, vehicle);
                }
                return BadRequest();
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
