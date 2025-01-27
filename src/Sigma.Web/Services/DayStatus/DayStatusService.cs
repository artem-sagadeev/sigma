using Microsoft.EntityFrameworkCore;
using Sigma.Web.Data;
using Sigma.Web.Entities;
using Sigma.Web.Exceptions;
using Sigma.Web.Models.Sigmameter.Day;
using Sigma.Web.Services.DayStatus.Dtos;

namespace Sigma.Web.Services.DayStatus;

public class DayStatusService : IDayStatusService
{
    private readonly ApplicationContext _context;

    public DayStatusService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<DayStatusDto> GetDayStatus(DateOnly day)
    {
        var dayStatus = new DayStatusDto
        {
            UserId = Guid.NewGuid(),
            Day = day,
            Status = Status.Sigma,
            Points = new[]
            {
                new StatusPointValueDto
                {
                    Id = Guid.NewGuid(),
                    Point = new StatusPointDto
                    {
                        Name = "Не играл в доту?"
                    },
                    Value = true
                },
                new StatusPointValueDto
                {
                    Id = Guid.NewGuid(),
                    Point = new StatusPointDto
                    {
                        Name = "Ел только полезную еду?"
                    },
                    Value = true
                },
                new StatusPointValueDto
                {
                    Id = Guid.NewGuid(),
                    Point = new StatusPointDto
                    {
                        Name = "Встал рано?"
                    },
                    Value = true
                }
            }
        };
        
        return await Task.FromResult(dayStatus);
    }

    public async Task<Status> UpdatePointAndRecalculateDayStatus(UpdatePointRequest request)
    {
        if (request.PointValueId is null || request.Value is null)
        {
            throw new ArgumentException("Update point failed: one of argumets were null");
        }

        var pointValue = await _context.PointValues
            .Include(pointValue => pointValue.Day)
            .SingleOrDefaultAsync(pointValue => pointValue.Id == request.PointValueId);

        if (pointValue is null)
        {
            throw new EntityNotFoundException("Update point failed: point doesnt exist");
        }

        pointValue.Value = request.Value.Value;
        pointValue.Day.Status = await CalculateDayStatus(pointValue.DayId);

        await _context.SaveChangesAsync();

        return pointValue.Day.Status;
    }

    private async Task<Status> CalculateDayStatus(Guid dayId)
    {
        var pointValues = await _context.PointValues
            .Where(pointValue => pointValue.DayId == dayId)
            .ToListAsync();

        if (pointValues.Count == 0)
        {
            return Status.Boy;
        }

        if (pointValues.All(pointValue => pointValue.Value))
        {
            return Status.Sigma;
        }

        if (pointValues.Count(pointValue => pointValue.Value) * 2 > pointValues.Count)
        {
            return Status.Man;
        }

        return Status.Boy;
    }
}