using Xunit;
using Moto.Domain.Entities;

public class PlanEntityTests
{
    [Fact]
    public void Constructor_ValidParameters_PropertiesSetCorrectly()
    {
        // Arrange
        int days = 7;
        decimal price = 30.0m;
        decimal fee = 1.2m;

        // Act
        var plan = new PlanEntity(days, price, fee);

        // Assert
        Assert.Equal(days, plan.Days);
        Assert.Equal(price, plan.Price);
        Assert.Equal(fee, plan.Fee);
    }

    [Fact]
    public void Update_NewValues_PropertiesUpdated()
    {
        // Arrange
        var plan = new PlanEntity(7, 30.0m, 1.2m);

        int newDays = 15;
        decimal newPrice = 30.0m;
        decimal newFee = 1.4m;

        // Act
        plan.Update(newDays, newPrice, newFee);

        // Assert
        Assert.Equal(newDays, plan.Days);
        Assert.Equal(newPrice, plan.Price);
        Assert.Equal(newFee, plan.Fee);
    }
}
