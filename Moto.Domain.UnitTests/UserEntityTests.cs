using System;
using Xunit;
using Moto.Domain.Entities;
using Moto.Domain.Enums;
using System.Reflection;

public class UserEntityTests
{
    [Fact]
    public void Constructor_ValidParameters_PropertiesSetCorrectly()
    {
        // Arrange
        string name = "Luis";
        string cnpj = "Cnpj";
        DateTime date = DateTime.Now;
        string cnh = "Cnh";
        CnhType cnhType = CnhType.A;
        Role role = Role.Admin;
        string password = "senha";

        // Act
        var entity = new UserEntity(name, cnpj, date, cnh, cnhType, role, password);

        // Assert
        Assert.Equal(name, entity.Name);
        Assert.Equal(cnpj, entity.Cnpj);
        Assert.Equal(date, entity.BirthDate);
        Assert.Equal(cnh, entity.Cnh);
        Assert.Equal(cnhType, entity.CnhType);
        Assert.Equal(role, entity.Role);
        Assert.Equal(password, entity.Password);
    }
    [Fact]
    public void IsValidCnh_UserWithCarLicense_ReturnsTrue()
    {
        // Arrange
        var user = new UserEntity("Luis", "Cnpj", DateTime.Now, "Cnh", CnhType.B, Role.Admin, "senha");

        // Act
        var result = user.IsValidCnh();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void IsValidCnh_UserWithBikeLicense_ReturnsTrue()
    {
        // Arrange
        var user = new UserEntity("Luis", "Cnpj", DateTime.Now, "Cnh", CnhType.A, Role.Admin, "senha");

        // Act
        var result = user.IsValidCnh();

        // Assert
        Assert.True(result);
    }


    [Fact]
    public void HasCarLicense_UserWithCarLicense_ReturnsTrue()
    {
        // Arrange
        var user = new UserEntity("Luis", "Cnpj", DateTime.Now, "Cnh", CnhType.B, Role.Admin, "senha");

        // Act
        var result = user.HasCarLicense();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasCarLicense_UserWithoutCarLicense_ReturnsFalse()
    {
        // Arrange
        var user = new UserEntity("Luis", "Cnpj", DateTime.Now, "Cnh", CnhType.D, Role.Admin, "senha");

        // Act
        var result = user.HasCarLicense();

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void HasBikeLicense_UserWithBikeLicense_ReturnsTrue()
    {
        // Arrange
        var user = new UserEntity("Luis", "Cnpj", DateTime.Now, "Cnh", CnhType.A, Role.Admin, "senha");

        // Act
        var result = user.HasBikeLicense();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void HasBikeLicense_UserWithoutBikeLicense_ReturnsFalse()
    {
        // Arrange
        var user = new UserEntity("Luis", "Cnpj", DateTime.Now, "Cnh", CnhType.D, Role.Admin, "senha");

        // Act
        var result = user.HasBikeLicense();

        // Assert
        Assert.False(result);
    }
}
