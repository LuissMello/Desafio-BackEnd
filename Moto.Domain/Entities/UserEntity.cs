using Moto.Domain.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace Moto.Domain.Entities;

public sealed record UserEntity : BaseEntity
{
    public string Name { get; private set; }
    public string Cnpj { get; private set; }
    public DateTime BirthDate { get; private set; }
    public Role Role { get; private set; }
    public string Password { get; set; }
    public string Cnh { get; private set; }
    public CnhType CnhType { get; private set; }
    public byte[]? CnhImage { get; private set; }

    public UserEntity() { } // EF Core

    public UserEntity(string name, string cnpj, DateTime birthDate, string cnh, CnhType cnhType, Role role, string password)
    {
        Name = name;
        Cnpj = cnpj;
        BirthDate = birthDate;
        Cnh = cnh;
        CnhType = cnhType;
        Role = role;
        Password = password;
    }

    public bool IsValidCnh() => HasBikeLicense() || HasCarLicense();

    public bool HasCarLicense() => CnhType.HasFlag(CnhType.B);
    public bool HasBikeLicense() => CnhType.HasFlag(CnhType.A);
    public void UpdateCnhImage(byte[] image) => CnhImage = image;
}
