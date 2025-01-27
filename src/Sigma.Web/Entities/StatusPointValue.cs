using Sigma.Web.Services.DayStatus;
using Sigma.Web.Services.DayStatus.Dtos;

namespace Sigma.Web.Entities;

public class StatusPointValue
{
    public Guid Id { get; set; }
    
    public Guid PointId { get; set; }
    
    public StatusPoint Point { get; set; }
    
    public Guid DayId { get; set; }
    
    public DayStatus Day { get; set; }
    
    public bool Value { get; set; }
}