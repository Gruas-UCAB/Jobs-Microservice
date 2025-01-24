using Hangfire;
using JobsMicroservice.src.services;
using Microsoft.AspNetCore.Mvc;

namespace JobsMicroservice.src.controllers
{
    [Controller]
    [Route("jobs")]
    public class JobsController(IRecurringJobManager recurringJobManager, BackgroundJobsService backgroundJobsService) : ControllerBase
    {
        private readonly IRecurringJobManager _recurringJobManager = recurringJobManager;
        private readonly BackgroundJobsService _backgroundJobsService = backgroundJobsService;

        [HttpPost("change-order-status")]
        public IActionResult ChangeOrderStatus([FromHeader(Name = "Authorization")] string token)
        {
            _recurringJobManager.AddOrUpdate(
                "ChangeOrderStatus",
                () => _backgroundJobsService.ChangeOrderStatus(token),
                "*/3 * * * *"
                );
            return Ok("Order status has been changed");
        }
    }
}
