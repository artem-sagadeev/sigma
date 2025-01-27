using Sigma.Web.Entities;

namespace Sigma.Web.Services.DayStatus.Dtos;

public class DayStatusDto
{
    public Guid UserId { get; set; }
    
    public DateOnly Day { get; set; }
    
    public Status Status { get; set; }

    public IReadOnlyCollection<StatusPointValueDto> Points { get; set; }
}