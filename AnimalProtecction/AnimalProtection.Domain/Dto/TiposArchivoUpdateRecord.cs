namespace AnimalProtection.Domain.Dto
{
    public record TiposArchivoUpdateRecord(
        Guid Id,
        string? Nombre,
        string? Descripcion
    );
}
