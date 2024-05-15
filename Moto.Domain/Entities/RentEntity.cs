namespace Moto.Domain.Entities;

public sealed record RentEntity : BaseEntity
{
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public DateTime PreviewEndDate { get; private set; }
    public Guid UserId { get; private set; }
    public Guid BikeId { get; private set; }
    public Guid PlanId { get; private set; }

    public UserEntity User { get; private set; }
    public BikeEntity Bike { get; private set; }
    public PlanEntity Plan { get; private set; }

    public RentEntity() { } // EF Core

    public RentEntity(UserEntity user, BikeEntity bike, PlanEntity plan)
    {
        UserId = user.Id;
        BikeId = bike.Id;
        PlanId = plan.Id;
        StartDate = DateTime.Now.AddDays(1);
        EndDate = StartDate.AddDays(plan.Days).AddHours(1);

        User = user;
        Bike = bike;
        Plan = plan;
    }

    public bool CanRent() => User.HasBikeLicense();

    public decimal CalculateFine(DateTime previewEndDate)
    {
        PreviewEndDate = previewEndDate;

        int totalRentDays = (previewEndDate - StartDate).Days;
        int daysNotEffected = Plan.Days - totalRentDays;

        if (daysNotEffected == 0)
            return 0;

        return daysNotEffected > 0 ?
                    (Plan.Price * Plan.Fee) * daysNotEffected
                    : 
                    Math.Abs(daysNotEffected) * 50.0M;
    }

    public decimal CalculatePrice(DateTime previewEndDate)
    {
        DateTime actualEndDate = EndDate >= previewEndDate ? previewEndDate : EndDate;

        int totalRentDays = (actualEndDate - StartDate).Days;

        return Plan.Price * totalRentDays;

    }
}
