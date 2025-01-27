using Microsoft.EntityFrameworkCore;
using Sigma.Web.Entities;

namespace Sigma.Web.Data;

public class ApplicationContext : DbContext
{
    public DbSet<DayStatus> DayStatuses { get; private set; }
    
    public DbSet<StatusPoint> Points { get; private set; }
    
    public DbSet<StatusPointValue> PointValues { get; private set; }
}