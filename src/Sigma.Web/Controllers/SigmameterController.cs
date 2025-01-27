using Microsoft.AspNetCore.Mvc;
using Sigma.Web.Models.Sigmameter.Day;
using Sigma.Web.Services.DayStatus;

namespace Sigma.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class SigmameterController : ControllerBase
{
    private readonly IDayStatusService _dayStatusService;

    public SigmameterController(IDayStatusService dayStatusService)
    {
        _dayStatusService = dayStatusService;
    }
    
    [HttpPut("UpdatePoint")]
    public async Task<UpdatePointResponse> OnPut(UpdatePointRequest request)
    {
        var status = await _dayStatusService.UpdatePointAndRecalculateDayStatus(request);

        var result = new UpdatePointResponse
        {
            Status = status
        };

        return result;
    }
}