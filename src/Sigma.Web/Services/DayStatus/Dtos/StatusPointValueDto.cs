namespace Sigma.Web.Services.DayStatus.Dtos;

public class StatusPointValueDto
{
    public Guid Id { get; set; }
    
    public StatusPointDto Point { get; set; }
    
    public bool Value { get; set; }
}