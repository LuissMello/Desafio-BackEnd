namespace Moto.Domain.Entities;

public sealed record BikeEntity : BaseEntity
{
    public int Year { get; private set; }
    public string Plate { get; private set; }
    public string Model { get; private set; }

    public BikeEntity() { } // EF Core
    public BikeEntity(int year, string plate, string model)
    {
        Year = year;
        Plate = plate;
        Model = model;
    }

    public void UpdatePlate(string plate) => Plate = plate;

}
