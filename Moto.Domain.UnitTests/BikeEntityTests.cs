using Xunit;
using Moq.AutoMock;
using Bogus;
using Moto.Domain.Entities;

public class BikeEntityTests
{
    [Fact]
    public void Constructor_ValidParameters_PropertiesSetCorrectly()
    {
        // Arrange
        var year = 2022;
        var plate = "ABC-123";
        var model = "Yamaha";

        // Act
        BikeEntity entity = new(year, plate, model);

        // Assert
        Assert.Equal(year, entity.Year);
        Assert.Equal(plate, entity.Plate);
        Assert.Equal(model, entity.Model);
    }

    [Fact]
    public void UpdatePlate_NewPlate_PlateUpdated()
    {
        // Arrange
        var year = 2022;
        var plate = "ABC-123";
        var model = "Yamaha";

        var newPlate = "ABC-321";

        // Act
        BikeEntity entity = new(year, plate, model);

        // Act
        entity.UpdatePlate(newPlate);

        // Assert
        Assert.Equal(newPlate, entity.Plate);
    }
}
