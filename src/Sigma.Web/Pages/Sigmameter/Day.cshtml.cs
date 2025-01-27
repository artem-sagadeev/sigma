using Microsoft.AspNetCore.Mvc.RazorPages;
using Sigma.Web.Services.DayStatus;
using Sigma.Web.Services.DayStatus.Dtos;

namespace Sigma.Web.Pages.Sigmameter;

public class Day : PageModel
{
    private readonly IDayStatusService _dayStatusService;

    public Day(IDayStatusService dayStatusService)
    {
        _dayStatusService = dayStatusService;
    }

    public DayStatusDto? DayStatus { get; set; }
    
    public async Task OnGet(DateOnly? day)
    {
        DayStatus = await _dayStatusService.GetDayStatus(day ?? DateOnly.FromDateTime(DateTime.Now));
    }
}