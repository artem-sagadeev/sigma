using Sigma.Web.Entities;
using Sigma.Web.Models.Sigmameter.Day;
using Sigma.Web.Services.DayStatus.Dtos;

namespace Sigma.Web.Services.DayStatus;

public interface IDayStatusService
{ 
    Task<DayStatusDto> GetDayStatus(DateOnly day);

    Task<Status> UpdatePointAndRecalculateDayStatus(UpdatePointRequest request);
}