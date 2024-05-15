using System;
using Xunit;
using Moto.Domain.Entities;
using Moto.Domain.Enums;

public class RentEntityTests
{
    [Fact]
    public void CanRent_UserWithLicense_ReturnsTrue()
    {
        // Arrange
        var user = new UserEntity("Luis", "Cnpj", DateTime.Now, "Cnh", CnhType.A, Role.Admin, "senha");
        var bike = new BikeEntity();
        var plan = new PlanEntity(7, 30.0m, 1.2m);
        var rent = new RentEntity(user, bike, plan);

        // Act
        var result = rent.CanRent();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void CanRent_UserWithoutLicense_ReturnsFalse()
    {
        // Arrange
        var user = new UserEntity("Luis", "Cnpj", DateTime.Now, "Cnh", CnhType.D, Role.Admin, "senha");
        var bike = new BikeEntity();
        var plan = new PlanEntity(7, 30.0m, 1.2m);
        var rent = new RentEntity(user, bike, plan);

        // Act
        var result = rent.CanRent();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void CalculatePrice_ReturnsCorrectPrice()
    {
        // Arrange
        var user = new UserEntity();
        var bike = new BikeEntity();
        var plan = new PlanEntity(7, 30.0m, 1.2m);
        var startDate = DateTime.Now.AddDays(1).AddHours(1);
        var rent = new RentEntity(user, bike, plan);

        // Act
        var price = rent.CalculatePrice(startDate.AddDays(5)); 

        // Assert
        Assert.Equal(150.0m, price);
    }

    [Fact]
    public void CalculateFine_ReturnsCorrectFine_WhenRentDurationExceedsPlan()
    {
        // Arrange
        var user = new UserEntity();
        var bike = new BikeEntity();
        var plan = new PlanEntity(7, 30.0m, 1.2m);
        var startDate = DateTime.Now.AddDays(1).AddHours(1);
        var rent = new RentEntity(user, bike, plan);

        // Act
        var fine = rent.CalculateFine(startDate.AddDays(5));

        // Assert
        Assert.Equal(72.0m, fine);
    }


    [Fact]
    public void CalculateFine_ReturnsCorrectFine_WhenRentDurationPreceedsPlan()
    {
        // Arrange
        var user = new UserEntity();
        var bike = new BikeEntity();
        var plan = new PlanEntity(7, 30.0m, 1.2m);
        var startDate = DateTime.Now.AddDays(1).AddHours(1);
        var rent = new RentEntity(user, bike, plan);

        // Act
        var fine = rent.CalculateFine(startDate.AddDays(10));

        // Assert
        Assert.Equal(150.0m, fine);
    }

    [Fact]
    public void CalculateFine_ReturnsZero_WhenRentDurationWithinPlan()
    {
        // Arrange
        var user = new UserEntity();
        var bike = new BikeEntity();
        var plan = new PlanEntity(7, 30.0m, 1.2m);
        var startDate = DateTime.Now.AddDays(1).AddHours(1);
        var rent = new RentEntity(user, bike, plan);

        // Act
        var fine = rent.CalculateFine(startDate.AddDays(7)); 

        // Assert
        Assert.Equal(0.0m, fine);
    }
}
