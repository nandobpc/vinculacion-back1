namespace AnimalProtection.Domain.Dto
{
    public record TiposArchivoRecord(
        Guid Id,
        string Nombre,
        string? Descripcion,
        bool Estaactivo
    )
    {
        public TiposArchivoRecord(Entities.Tiposarchivo tiposArchivo)
            : this(
                tiposArchivo.Id,
                tiposArchivo.Nombre,
                tiposArchivo.Descripcion,
                tiposArchivo.Estaactivo ?? false
            )
        { }
    }
}
