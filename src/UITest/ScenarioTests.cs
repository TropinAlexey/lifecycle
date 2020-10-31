using System;
using Xunit;
using Xunit.Abstractions;
using BWMS.UITest.PageModel;
using TestUtils;

namespace BWMS.UITest
{
    public class ScenarioTests
    {
        private readonly ITestOutputHelper _output;

        public ScenarioTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void End_To_End()
        {
            // arrange
            string testrunId = Guid.NewGuid().ToString("N");
            App app = new App(testrunId, TestConstants.PitstopStartUrl);
            var homePage = app.Start();
            //string Name = TestDataGenerators.GenerateRandomName();
            string Name = "";

            // act
            app.Menu
                .CustomerManagement()
                .RegisterCustomer()
                .Cancel()
                .RegisterCustomer()
                .FillCustomerDetails(
                    $"TestCustomer {testrunId}", "Verzonnenstraat 21", 
                    "Uitdeduimerveen", "1234 AZ", "+31612345678", "tc@test.com")
                .Submit()
                .SelectCustomer($"TestCustomer {testrunId}")
                .Back();

            app.Menu
                .VehicleManagement()
                .RegisterVehicle()
                .Cancel()
                .RegisterVehicle()
                .FillVehicleDetails(Name, "Testla", "Model T", $"TestCustomer {testrunId}")
                .Submit()
                .SelectVehicle(Name)
                .Back(); 

            app.Menu
                .WorkshopManagement()
                .RegisterMaintenanceJob()
                .Cancel()
                .RegisterMaintenanceJob()
                .FillJobDetails("08:00", "12:00", $"Job {testrunId}", Name)
                .Submit()
                .SelectMaintenanceJob($"Job {testrunId}")
                .Back(); 

            app.Menu
                .WorkshopManagement()
                .SelectMaintenanceJob($"Job {testrunId}")
                .GetJobStatus(out string beforeJobStatus)
                .Complete()
                .FillJobDetails("08:00", "11:00", $"Mechanic notes {testrunId}")
                .Complete()
                .GetJobStatus(out string afterJobStatus)
                .Back();

            // assert
            Assert.Equal("Planned", beforeJobStatus);
            Assert.Equal("Completed", afterJobStatus);

            // cleanup
            app.Stop();
        }
    }
}
