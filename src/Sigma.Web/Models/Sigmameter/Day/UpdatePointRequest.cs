namespace Sigma.Web.Models.Sigmameter.Day;

public class UpdatePointRequest
{
    public Guid? PointValueId { get; set; }
    
    public bool? Value { get; set; }
}