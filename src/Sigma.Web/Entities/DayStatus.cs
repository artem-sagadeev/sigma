namespace Sigma.Web.Entities;

public class DayStatus
{
    private List<StatusPointValue> _values = new();
    
    public Guid UserId { get; set; }
    
    public DateOnly Day { get; set; }

    public Status Status { get; set; }
    
    public IReadOnlyCollection<StatusPointValue> Values => _values.AsReadOnly();
}